using DevExpress.XtraSplashScreen;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Models.Report;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Lists;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Report
{
    public partial class CubeReport : DevExpress.XtraEditors.XtraForm
    {
        private readonly IServiceOperationDocumentService _service;
        private List<string> _selectedClients;
        private List<string> _selectedServices;

        public CubeReport()
        {
            InitializeComponent();

            _service = ServiceContainer.ServiceOperationDocumentService;
            _selectedClients = new List<string>();
            _selectedServices = new List<string>();
        }

        private bool WithLastDateServiceCount => checkEditLastDatePayment.Checked;

        public DateTime FirstDate
        {
            get => dateEditFirstDate.DateTime;
            set => dateEditFirstDate.DateTime = value;
        }

        public DateTime LastDate
        {
            get => dateEditLastDate.DateTime;
            set => dateEditLastDate.DateTime = value;
        }

        private void TestReport_Load(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            FirstDate = new DateTime(today.Year, today.Month, 1);
            LastDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
        }

        public async Task LoadReport()
        {
            IOverlaySplashScreenHandle handle = null;

            try
            {
                handle = ShowProgressPanel();

                var result = await _service.GetCubeReport(FirstDate, LastDate, WithLastDateServiceCount, _selectedClients, _selectedServices);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                pivotGridReport.DataSource = result.Data;
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

        IOverlaySplashScreenHandle ShowProgressPanel()
        {
            return SplashScreenManager.ShowOverlayForm(pivotGridReport);
        }
        void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadReport();
        }

        private void buttonEditSelectedClientCodes_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var clientsForm = new ClientListForm())
                {
                    clientsForm.ShowDialog();
                    var clients = clientsForm.GetSelectedClients();

                    if (clients == null || !clients.Any())
                        return;

                    if (_selectedClients == null) _selectedClients = new List<string>();
                    else _selectedClients.Clear();

                    _selectedClients.AddRange(clients.Select(c => c.ClientCode));

                    buttonEditSelectedClientCodes.Text = _selectedClients.Count <= 3 ?
                        string.Join(", ", _selectedClients) :
                        $"{clients.Count} cari seçilib";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditServicesFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var servicesForm = new ServiceListForm(true))
                {
                    servicesForm.ShowDialog();
                    var services = servicesForm.GetSelectedServices();

                    if (services == null || !services.Any())
                        return;

                    if (_selectedServices == null) _selectedServices = new List<string>();
                    else _selectedServices.Clear();

                    _selectedServices.AddRange(services.Select(c => c.Code));

                    buttonEditServicesFilter.Text = _selectedServices.Count <= 3 ?
                        string.Join(", ", _selectedServices) :
                        $"{services.Count} servis seçilib";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnClearClientFilter_Click(object sender, EventArgs e)
        {
            if (_selectedClients == null) _selectedClients = new List<string>();
            else _selectedClients.Clear();

            buttonEditSelectedClientCodes.Text = string.Empty;
        }

        private void btnClearServiceFilter_Click(object sender, EventArgs e)
        {
            if (_selectedServices == null) _selectedServices = new List<string>();
            else _selectedServices.Clear();

            buttonEditServicesFilter.Text = string.Empty;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(pivotGridReport.DataSource is List<ClientServiceCubeReportModel> lines) || lines.Count == 0)
                {
                    MessageBox.Show(@"Saxlanılacaq sətir yoxdur");
                    return;
                }

                var saveFileDialog = new SaveFileDialog { Filter = @"Excel Workbook|*.xls", ValidateNames = true };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                var wb = new Workbook();
                var ws = wb.Worksheets[0];

                var column = 1;
                ws.Range[1, column++].Text = "Seriya";
                ws.Range[1, column++].Text = "No";
                ws.Range[1, column++].Text = "Tarix";
                ws.Range[1, column++].Text = "Sənəd No";
                ws.Range[1, column++].Text = "Sənəd Tarixi";
                ws.Range[1, column++].Text = "İstifadəçi";
                ws.Range[1, column++].Text = "Cari Kodu";
                ws.Range[1, column++].Text = "Cari Adı";
                ws.Range[1, column++].Text = "Cari Qrup Adı";
                ws.Range[1, column++].Text = "Servis Kodu";
                ws.Range[1, column++].Text = "Servis Adı";
                ws.Range[1, column++].Text = "İlkin Say";
                ws.Range[1, column++].Text = "Quraşdırma Sayı";
                ws.Range[1, column++].Text = "Ləğv Sayı";
                ws.Range[1, column].Text = "Son Say";

                var row = 2;
                foreach (var line in lines)
                {
                    column = 1;
                    ws.Range[row, column++].Value = line.Series;
                    ws.Range[row, column++].Value = line.Number.ToString();
                    ws.Range[row, column++].Value = line.Date.ToString("yyyy-MM-dd");
                    ws.Range[row, column++].Value = line.DocumentNumber;
                    ws.Range[row, column++].Value = line.DocumentDate.ToString("yyyy-MM-dd");
                    ws.Range[row, column++].Value = line.CreatorUser;
                    ws.Range[row, column++].Value = line.ClientCode;
                    ws.Range[row, column++].Value = line.ClientName;
                    ws.Range[row, column++].Value = line.ClientGroupName;
                    ws.Range[row, column++].Value = line.ServiceCode;
                    ws.Range[row, column++].Value = line.ServiceName;
                    ws.Range[row, column++].Value = line.PreviousCount.ToString();
                    ws.Range[row, column++].Value = line.InstallationCount.ToString();
                    ws.Range[row, column++].Value = line.CancellationCount.ToString();
                    ws.Range[row, column].Value = line.LastCount.ToString();

                    row++;
                }

                wb.Worksheets.RemoveAt(1);
                wb.Worksheets.RemoveAt(1);
                wb.SaveToFile(saveFileDialog.FileName, ExcelVersion.Version2007);
                MessageBox.Show(@"Cədvəl excelə export edildi");
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Excelə export edilərkən xəta yarandı.");
                MessageBox.Show(exception.Message);
            }
        }
    }
}