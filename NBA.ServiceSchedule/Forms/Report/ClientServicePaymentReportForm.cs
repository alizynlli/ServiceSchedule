using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.Core.Models.Options;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.DataAccess.Implementation.Services;
using NBA.ServiceSchedule.Forms.Helpers;
using NBA.ServiceSchedule.Forms.Lists;
using NBA.ServiceSchedule.Models;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Report
{
    public partial class ClientServicePaymentReportForm : DevExpress.XtraEditors.XtraForm
    {
        private const string ClientCodeColumnName = "ClientCode";
        private const string ClientNameColumnName = "ClientName";
        private const string ActiveColumnName = "Active";
        private const string DescriptionColumnName = "Description";
        private const string OldAmountColumnName = "OldAmount";
        private const string TotalPaymentColumnName = "Total";

        private readonly List<ServiceDto> _serviceDtoList;
        private readonly IServiceCardService _serviceCardService;
        private readonly IClientPaymentNoteService _clientPaymentNoteService;
        private List<ClientDto> _selectedClients;

        public ClientServicePaymentReportForm()
        {
            InitializeComponent();

            _serviceDtoList = new List<ServiceDto>();
            _serviceCardService = ServiceContainer.ServiceCardService;
            _clientPaymentNoteService = new ClientPaymentNoteService();
        }

        private DateTime LastDate
        {
            get => dateEdit1.DateTime;
            set => dateEdit1.DateTime = value;
        }

        private bool WithLastDateServiceCount => checkEditLastDateCount.Checked;

        private async void UcClientServicePaymentReport_Load(object sender, EventArgs e)
        {
            try
            {
                var today = DateTime.Today;
                LastDate = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

                var serviceResult = await _serviceCardService.GetAllAsync();
                if (serviceResult.IsFailed)
                {
                    MessageBox.Show(serviceResult.ErrorMessages.FirstOrDefault());
                    return;
                }
                if (serviceResult.Data == null || !serviceResult.Data.Any())
                {
                    MessageBox.Show(@"Sistemdə servis yoxdur.");
                    return;
                }

                _serviceDtoList.AddRange(serviceResult.Data.Select(ServiceDto.FromEntity));

                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.TaxNumber)}", Caption = @"VOEN", FieldName = nameof(ClientDetailsDao.TaxNumber), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.ContractNumber)}", Caption = @"Muqavile No", FieldName = nameof(ClientDetailsDao.ContractNumber), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.ContractDate)}", Caption = @"Muqavile Tarixi", FieldName = nameof(ClientDetailsDao.ContractDate), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.GroupName)}", Caption = @"Qrup", FieldName = nameof(ClientDetailsDao.GroupName), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.Address)}", Caption = @"Unvan", FieldName = nameof(ClientDetailsDao.Address), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.Contact)}", Caption = @"Kontakt", FieldName = nameof(ClientDetailsDao.Contact), Visible = true });
                gridViewReport.Columns.Add(new GridColumn { Name = $"col{nameof(ClientDetailsDao.Email)}", Caption = @"Email", FieldName = nameof(ClientDetailsDao.Email), Visible = true });

                foreach (var service in _serviceDtoList)
                {
                    var servicePaymentColumn = new GridColumn
                    {
                        Name = "col" + service.Code,
                        Caption = service.ServiceName,
                        FieldName = service.Code,
                        Visible = true
                    };
                    servicePaymentColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, service.Code, "SUM={0:0.##}")});

                    gridViewReport.Columns.Add(servicePaymentColumn);
                    gridViewReport.GroupSummary.Add(new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", servicePaymentColumn, ""));

                    var serviceCountColumn = new GridColumn
                    {
                        Name = "col" + service.Code + "Count",
                        Caption = service.ServiceName + @" Sayı",
                        FieldName = service.Code + "Count",
                        Visible = true
                    };
                    serviceCountColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, service.Code + "Count", "SUM={0:0.##}")});

                    gridViewReport.Columns.Add(serviceCountColumn);
                    gridViewReport.GroupSummary.Add(new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", serviceCountColumn, ""));
                }

                //Add Total column
                var totalColumn = new GridColumn
                { Name = "colTotal", Caption = @"Cəmi", FieldName = TotalPaymentColumnName, Visible = true };

                totalColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, totalColumn.FieldName, "SUM={0:0.##}") });
                gridViewReport.Columns.Add(totalColumn);
                gridViewReport.GroupSummary.Add(new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", totalColumn, ""));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BtnSaleInvoice_Click(object sender, EventArgs e)
        {
            if (!(gridControlReport.DataSource is DataTable dataSource))
            {
                MessageBox.Show(@"Məlumatlar gətirilməyib.");
                return;
            }

            var list = new List<ClientAccountOperationDao>();

            for (var i = 0; i < dataSource.Rows.Count; i++)
            {
                if (Convert.ToInt32(dataSource.Rows[i][ActiveColumnName]) == 1)
                {
                    var clientCode = dataSource.Rows[i][ClientCodeColumnName].ToString();
                    var totalPayments = Convert.ToDecimal(dataSource.Rows[i][TotalPaymentColumnName]);

                    var dao = new ClientAccountOperationDao();
                    dao.cha_kod = dao.cha_ciro_cari_kodu = clientCode;
                    dao.cha_miktari = 1;
                    dao.cha_meblag = Math.Round(totalPayments * 1.18M, 2);
                    dao.cha_vergipntr = 4;
                    dao.cha_aratoplam = totalPayments;
                    dao.cha_vergi4 = Math.Round(totalPayments * 0.18M, 2);

                    list.Add(dao);
                }
            }

            if (!list.Any())
            {
                MessageBox.Show(@"Saxlanacaq faktura yoxdur.");
                return;
            }

            using (var form = new SaleInvoiceForm(list.ToList(), LastDate))
            {
                form.ShowDialog();
                if (form.InvoicesCreated) btnSaleInvoice.Enabled = false;
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadReport();
        }

        private IOverlaySplashScreenHandle ShowProgressPanel()
        {
            return SplashScreenManager.ShowOverlayForm(this);
        }

        private static void CloseProgressPanel(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }

        private async Task LoadReport()
        {
            IOverlaySplashScreenHandle handle = null;

            try
            {
                handle = ShowProgressPanel();

                if (_selectedClients != null && _selectedClients.Any())
                {
                    var lastDate = LastDate;
                    var firstDate = new DateTime(lastDate.Year, lastDate.Month, 1);

                    var dataTable = new DataTable();
                    dataTable.Columns.AddRange(gridViewReport.Columns.Select(c => new DataColumn(c.FieldName)).ToArray());

                    var invoiceSeries = GlobalParameters.SaleInvoiceSeries;
                    var insertedInvoicesResult =
                        await RepositoryContainer.ClientAccountOperationRepository.GetClientsWithInvoices(lastDate, _selectedClients.Select(c => c.ClientCode).ToList(), invoiceSeries);

                    if (insertedInvoicesResult.IsFailed)
                    {
                        MessageBox.Show(insertedInvoicesResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    var clientsWithInvoices = insertedInvoicesResult.Data;

                    IClientServicePaymentService clientServicePaymentService =
                        new ClientServicePaymentService(new ClientServicePaymentOptions
                        {
                            FilteredClientCodeList = _selectedClients.Select(c => c.ClientCode).ToList(),
                            FilteredServiceCodeList = _serviceDtoList.Select(s => s.Code).ToList(),
                            FirstDate = firstDate,
                            LastDate = lastDate
                        });

                    var loadResult = await clientServicePaymentService.LoadServicesAsync();
                    if (loadResult.IsFailed)
                    {
                        MessageBox.Show(loadResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    loadResult = await clientServicePaymentService.LoadClientServiceDocumentsAsync();
                    if (loadResult.IsFailed)
                    {
                        MessageBox.Show(loadResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    loadResult = await clientServicePaymentService.LoadClientServiceFirstDateCountsAsync();
                    if (loadResult.IsFailed)
                    {
                        MessageBox.Show(loadResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    if (WithLastDateServiceCount)
                    {
                        loadResult = await clientServicePaymentService.LoadClientServiceLastDateCountsAsync();
                        if (loadResult.IsFailed)
                        {
                            MessageBox.Show(loadResult.ErrorMessages.FirstOrDefault());
                            return;
                        }
                    }

                    foreach (var client in _selectedClients)
                    {
                        var row = dataTable.NewRow();
                        row[ClientCodeColumnName] = client.ClientCode;
                        row[ClientNameColumnName] = client.ClientName;

                        var daoDetailsResult =
                            await RepositoryContainer.ClientRepository.GetClientDetails(client.ClientCode);
                        if (daoDetailsResult.IsFailed)
                        {
                            MessageBox.Show(daoDetailsResult.ErrorMessages.FirstOrDefault());
                            return;
                        }

                        row[nameof(ClientDetailsDao.TaxNumber)] = daoDetailsResult.Data.TaxNumber;
                        row[nameof(ClientDetailsDao.ContractNumber)] = daoDetailsResult.Data.ContractNumber;
                        row[nameof(ClientDetailsDao.ContractDate)] = daoDetailsResult.Data.ContractDate;
                        row[nameof(ClientDetailsDao.GroupName)] = daoDetailsResult.Data.GroupName;
                        row[nameof(ClientDetailsDao.Address)] = daoDetailsResult.Data.Address;
                        row[nameof(ClientDetailsDao.Contact)] = daoDetailsResult.Data.Contact;
                        row[nameof(ClientDetailsDao.Email)] = daoDetailsResult.Data.Email;

                        if (_serviceDtoList == null || !_serviceDtoList.Any())
                        {
                            MessageBox.Show(@"Sistemdə servis yoxdur.");
                            return;
                        }

                        var totalPayments = 0M;
                        bool active;

                        foreach (var service in _serviceDtoList)
                        {
                            var serviceTotalPaymentResult = clientServicePaymentService.CalculateClientServicePayment(
                                new ClientServicePaymentCalculationOptions
                                {
                                    ClientCode = client.ClientCode,
                                    ServiceCode = service.Code
                                });

                            if (serviceTotalPaymentResult.IsFailed)
                            {
                                MessageBox.Show(serviceTotalPaymentResult.ErrorMessages.FirstOrDefault());
                                return;
                            }

                            var serviceLastCount = clientServicePaymentService.GetClientServiceLastCount(client.ClientCode, service.Code);

                            totalPayments += serviceTotalPaymentResult.Data;
                            row[service.Code] = serviceTotalPaymentResult.Data.ToString("0.00");
                            if (WithLastDateServiceCount)
                                row[service.Code + "Count"] = serviceLastCount;
                        }

                        var clientPaymentNoteResult = await _clientPaymentNoteService.GetMonthlyClientPaymentNote(client.ClientCode, firstDate, lastDate);
                        if (clientPaymentNoteResult.IsFailed)
                        {
                            MessageBox.Show(clientPaymentNoteResult.ErrorMessages.FirstOrDefault());
                            return;
                        }

                        if (clientPaymentNoteResult.Data != null && clientPaymentNoteResult.Data.Id != 0)
                        {
                            row[DescriptionColumnName] = "Əvvəlcədən ödəniş qeydi";
                            //row[DescriptionColumnName] = "X";//TODO
                            active = false;
                        }
                        else if (clientsWithInvoices.Contains(client.ClientCode))
                        {
                            //var invoice = await RepositoryContainer.ClientAccountOperationRepository.GetOldAmount( lastDate, client.ClientCode, invoiceSeries);
                            //row[DescriptionColumnName] = totalPayments == invoice ? "Eyni" : "Fərqli";
                            row[DescriptionColumnName] = "Cari ay fakturası";
                            //row[OldAmountColumnName] = invoice;
                            active = false;
                        }
                        else
                        {
                            row[DescriptionColumnName] = totalPayments > 0 ? $"Ödənilməli ({totalPayments:0.00})" : totalPayments == 0 ? "Borcu yoxdur." : "Mənfi borc!";
                            //row[DescriptionColumnName] = "X";
                            active = totalPayments > 0;
                        }

                        row[TotalPaymentColumnName] = totalPayments.ToString("0.00");
                        row[ActiveColumnName] = active ? 1 : 0;
                        dataTable.Rows.Add(row);
                    }

                    gridControlReport.DataSource = dataTable;
                    gridControlReport.RefreshDataSource();

                    btnSaleInvoice.Enabled = true;
                }
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

        private void ButtonEditClients_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var form = new ClientListForm())
            {
                form.ShowDialog();
                var clients = form.GetSelectedClients();

                if (_selectedClients == null) _selectedClients = new List<ClientDto>();
                else _selectedClients.Clear();

                _selectedClients.AddRange(clients);

                buttonEditClients.Text = _selectedClients.Count <= 3 ?
                    string.Join(", ", _selectedClients.Select(c => c.ClientCode)) :
                    $"{clients.Count} cari seçilib";
            }
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var lines = (List<object>)gridViewReport.DataController.GetAllFilteredAndSortedRows();

                if (lines == null || lines.Count == 0)
                {
                    MessageBox.Show(@"Saxlanılacaq sətir yoxdur");
                    return;
                }

                var saveFileDialog = new SaveFileDialog { Filter = @"Excel Workbook|*.xls", ValidateNames = true };
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                var wb = new Workbook();
                var ws = wb.Worksheets[0];

                var dataTable = (DataTable)gridControlReport.DataSource;

                var columnNumber = 1;
                foreach (GridColumn column in gridViewReport.Columns)
                {
                    var rowNumber = 1;
                    ws.Range[rowNumber++, columnNumber].Text = column.Caption;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ws.Range[rowNumber, columnNumber].Text = row[column.FieldName].ToString();
                        var active = row[ActiveColumnName].ToString();
                        ws.Range[rowNumber, columnNumber].Style.Font.Color = active == "1" ? Color.MediumSeaGreen : Color.Red;

                        rowNumber++;
                    }

                    columnNumber++;
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
