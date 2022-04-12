using DevExpress.XtraSplashScreen;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class ServiceDocumentListForm : DevExpress.XtraEditors.XtraForm
    {
        private bool _rowsSelected;
        private readonly IServiceOperationDocumentService _service;

        public ServiceDocumentListForm(bool isMultiSelect = false)
        {
            InitializeComponent();

            _service = ServiceContainer.ServiceOperationDocumentService;
            gridView1.OptionsSelection.MultiSelect = isMultiSelect;
        }

        IOverlaySplashScreenHandle ShowProgressPanel()
        {
            return SplashScreenManager.ShowOverlayForm(this);
        }
        void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _rowsSelected = true;
            Close();
        }

        private async void ServiceDocumentListForm_Load(object sender, EventArgs e)
        {
            IOverlaySplashScreenHandle handle = null;

            try
            {
                handle = ShowProgressPanel();

                var result = await _service.GetAllAsync();
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                var dtoList = result.Data?.Select(ServiceOperationDocumentDto.FromEntity).ToList();
                gridControl1.DataSource = dtoList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                CloseProgressPanel(handle);
            }
        }

        public List<ServiceOperationDocumentDto> GetSelectedDocuments()
        {
            if (!_rowsSelected) return new List<ServiceOperationDocumentDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ServiceOperationDocumentDto)gridView1.GetRow(row)).ToList();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridControl1.IsFocused)
            {
                btnOk.PerformClick();
            }
        }
    }
}