using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.DataAccess;
using NBA.ServiceSchedule.DataAccess.DbContext;
using NBA.ServiceSchedule.DataAccess.DbContext.DbSchema;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder(GlobalParameters.ConnectionString);

            txtServer.Text = connectionStringBuilder.DataSource;
            txtDatabase.Text = connectionStringBuilder.InitialCatalog;
            txtUserName.Text = connectionStringBuilder.UserID;
            txtPassword.Text = connectionStringBuilder.Password;

            txtInvoiceSeries.Text = GlobalParameters.SaleInvoiceSeries;
        }

        private bool ValidateUserInputs()
        {
            if (txtServer.Text.IsNullOrEmpty())
            {
                txtServer.Focus();
                return false;
            }
            if (txtDatabase.Text.IsNullOrEmpty())
            {
                txtDatabase.Focus();
                return false;
            }

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUserInputs()) return;

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = txtServer.Text.Trim(), InitialCatalog = txtDatabase.Text.Trim()
            };

            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
                connectionStringBuilder.UserID = txtUserName.Text.Trim();
            else connectionStringBuilder.IntegratedSecurity = true;

            if (!string.IsNullOrEmpty(txtPassword.Text))
                connectionStringBuilder.Password = txtPassword.Text;

            var conString = connectionStringBuilder.ToString();

            var testResult = await SqlHelper.TestConnection(connectionStringBuilder.ToString(), txtDatabase.Text.Trim());
            if (testResult.IsFailed)
            {
                MessageBox.Show(@"Bağlantı uğursuz alındı");
                return;
            }

            if (!testResult.Data)
            {
                MessageBox.Show($@"Bağlantı quruldu lakin {txtDatabase.Text} bazası tapılmadı");
                return;
            }

            var saveResult = await AppSetting.SaveConnectionString(conString);

            if (saveResult.IsFailed)
            {
                MessageBox.Show(saveResult.ErrorMessages.FirstOrDefault() ?? saveResult.Exception?.Message);
            }
            else
            {
                AppSetting.SaveSaleInvoiceSeries(txtInvoiceSeries.Text.Trim());
                AppSetting.Initialize();
                MessageBox.Show(@"Saxlandı");
            }
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"Əvvəlki versiya obyektləri(əgər varsa) silinəcək. Davam edilsin?", @"Xeberdarliq", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var objects = DatabasePackages.GetAllObjects().ToArray();

            var destroyQuery = string.Join(";\n", objects.Reverse().Select(o => o.DropQuery));

            var databaseBuilder = new DatabaseBuilder(GlobalParameters.DatabaseName, "dbo");

            var res1 = await databaseBuilder.ExecuteQuery(destroyQuery);

            if (res1.IsFailed)
                MessageBox.Show(res1.ErrorMessages?.FirstOrDefault() ?? res1.Exception?.Message);

            var databaseObjects = objects;

            foreach (var dbObj in databaseObjects)
            {
                var result = await databaseBuilder.CreateDbObject(dbObj);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault() ?? result.Exception?.Message);
                    return;
                }
            }

            foreach (var table in DatabasePackages.GetAllTables())
            {
                var result = await table.InsertDefaultValues();
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages?.FirstOrDefault() ?? result.Exception?.Message);
                    return;
                }
            }

            MessageBox.Show(@"Baza obyektləri qurasdirildi.");
        }
    }
}
