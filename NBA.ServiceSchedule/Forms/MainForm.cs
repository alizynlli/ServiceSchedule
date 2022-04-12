using NBA.ServiceSchedule.Core.Constants;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.Core.Models.Entities;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Cards;
using NBA.ServiceSchedule.Forms.Documents;
using NBA.ServiceSchedule.Forms.Helpers;
using NBA.ServiceSchedule.Forms.Lists;
using NBA.ServiceSchedule.Forms.Parameters;
using NBA.ServiceSchedule.Forms.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms
{
    public partial class MainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private readonly UserEntity _user;

        public MainForm()
        {
            InitializeComponent();

            _user = Session.CurrentUser;
        }

        private async Task ApplyPermissions()
        {
            try
            {
                if (_user.IsSupervisor) return;

                var permissionsResult = await RepositoryContainer.PermissionRepository.GetByUserAsync(_user.Id);
                if (permissionsResult.IsFailed || permissionsResult.Data == null)
                {
                    MessageBox.Show(permissionsResult.ErrorMessages.FirstOrDefault());
                    Close();
                }

                //TODO HARD CODE
                var permissions = permissionsResult.Data?.Select(dao => dao.PermissionKey).ToList() ?? new List<string>(0);

                //Documents
                acServiceOperationDocument.Visible = permissions.Contains(PermissionKeys.MenuKeys.Documents.ServiceOperationDocument);

                //Cards
                acServiceCard.Visible = permissions.Contains(PermissionKeys.MenuKeys.Cards.ServiceCard);
                acClientPaymentNote.Visible = permissions.Contains(PermissionKeys.MenuKeys.Cards.ClientPaymentNoteCard);
                acUserCard.Visible = permissions.Contains(PermissionKeys.MenuKeys.Cards.UserCard);

                //Reports
                acClientServicePaymentReport.Visible = permissions.Contains(PermissionKeys.MenuKeys.Reports.ClientServicePaymentReport);
                acCubeReport.Visible = permissions.Contains(PermissionKeys.MenuKeys.Reports.CubeReport);
                acServiceOperationDocumentReport.Visible = permissions.Contains(PermissionKeys.MenuKeys.Reports.ServiceOperationDocuments);

                //Lists
                acServiceOperationDocumentList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.ServiceOperationDocuments);
                accServiceList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.ServiceList);
                acClientList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.ClientPaymentNoteList);
                acClientGroupList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.ClientGroupList);
                acClientPaymentNoteList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.ClientList);
                acUserList.Visible = permissions.Contains(PermissionKeys.MenuKeys.Lists.UserList);

                //Parameters
                acConnection.Visible = permissions.Contains(PermissionKeys.MenuKeys.Parameters.ConnectionForm);
                acPermission.Visible = permissions.Contains(PermissionKeys.MenuKeys.Parameters.PermissionForm);

                acDocuments.Visible = acDocuments.Elements.Any(ac => ac.Visible);
                acCards.Visible = acCards.Elements.Any(ac => ac.Visible);
                acReports.Visible = acReports.Elements.Any(ac => ac.Visible);
                acDocumentList.Visible = acDocumentList.Elements.Any(ac => ac.Visible);
                acCardList.Visible = acCardList.Elements.Any(ac => ac.Visible);
                acLists.Visible = acLists.Elements.Any(ac => ac.Visible);
                acParameters.Visible = acParameters.Elements.Any(ac => ac.Visible);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            barStaticItemUserName.Caption = $@"{_user.FirstName} {_user.LastName}";
            barStaticItemDbName.Caption = GlobalParameters.DatabaseName;

            await ApplyPermissions();
        }

        private void AcServiceOperationDocument_Click(object sender, EventArgs e)
        {
            var form = new ServiceOperationDocumentForm();
            form.Show();
        }

        private void AcService_Click(object sender, EventArgs e)
        {
            var form = new ServiceForm();
            form.Show();
        }

        private void AccServiceList_Click(object sender, EventArgs e)
        {
            var form = new ServiceListForm(true);
            form.Show();
        }

        private void AccordionControlElement2_Click(object sender, EventArgs e)
        {
            var form = new ClientListForm();
            form.Show();
        }

        private void AccordionControlElement4_Click(object sender, EventArgs e)
        {
            var form = new ConnectionForm();
            form.Show();
        }

        private void AccordionControlElement5_Click(object sender, EventArgs e)
        {
            var form = new ClientServicePaymentReportForm();
            form.Show();
        }

        private void AccordionControlElement10_Click(object sender, EventArgs e)
        {
            var form = new ServiceDocumentListForm(true);
            form.Show();
        }

        private void AccordionControlElement11_Click(object sender, EventArgs e)
        {
            var form = new CubeReport();
            form.Show();
        }

        private void AccordionControlElement12_Click(object sender, EventArgs e)
        {
            var form = new ServiceOperationDocumentReportForm();
            form.Show();
        }

        private void AccordionControlElement13_Click(object sender, EventArgs e)
        {
            var form = new UserForm();
            form.Show();
        }

        private void ElementUserList_Click(object sender, EventArgs e)
        {
            var form = new UserListForm();
            form.Show();
        }

        private void AccordionControlElement6_Click(object sender, EventArgs e)
        {
            var form = new UserPermissionForm();
            form.Show();
        }

        private void AcClientPaymentNote_Click(object sender, EventArgs e)
        {
            var form = new ClientPaymentNoteForm();
            form.Show();
        }

        private void AcClientPaymentNoteList_Click(object sender, EventArgs e)
        {
            var form = new ClientPaymentNoteListForm(false);
            form.Show();
        }

        private void AcClientGroupList_Click(object sender, EventArgs e)
        {
            var form = new ClientGroupListForm();
            form.Show();
        }

        private void AcImportBulkDocuments_Click(object sender, EventArgs e)
        {
            var form = new ImportOldServicesForm();
            form.Show();
        }
    }
}
