using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Helpers
{
    public partial class PasswordForm : XtraForm
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        public bool Accessible { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "mikro12345")
            {
                Accessible = true;
                Close();
            }
            else
            {
                MessageBox.Show(@"Şifrə yanlışdır.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}