using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Lists;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Documents
{
    public partial class ServiceOperationDocumentForm : XtraForm
    {
        private readonly IServiceOperationDocumentService _service;

        public ServiceOperationDocumentForm()
        {
            InitializeComponent();

            _service = ServiceContainer.ServiceOperationDocumentService;
        }

        public string Series
        {
            get => txtSeries.Text.Trim();
            set => txtSeries.Text = value;
        }

        public int Number
        {
            get => Convert.ToInt32(buttonEditNumber.Text.Trim());
            set => buttonEditNumber.Text = value.ToString();
        }

        public DateTime Date
        {
            get => dateEditDate.DateTime;
            set => dateEditDate.DateTime = value;
        }

        public string DocumentNumber
        {
            get => txtDocumentNumber.Text.Trim();
            set => txtDocumentNumber.Text = value;
        }

        public DateTime DocumentDate
        {
            get => dateEditDocumentDate.DateTime;
            set => dateEditDocumentDate.DateTime = value;
        }

        public string ClientCode
        {
            get => buttonEditClientCode.Text.Trim();
            set => buttonEditClientCode.Text = value;
        }

        public string ClientName
        {
            get => buttonEditClientName.Text.Trim();
            set => buttonEditClientName.Text = value;
        }

        private void FillView(ServiceOperationDocumentDto dto)
        {
            Series = dto.Series;
            Number = dto.Number;
            Date = dto.Date;
            DocumentNumber = dto.DocumentNumber;
            DocumentDate = dto.DocumentDate;
            ClientCode = dto.ClientCode;
            ClientName = dto.ClientName;

            gridControl1.DataSource = dto.Lines;
        }

        private ServiceOperationDocumentDto GetFromView()
        {
            var dto = new ServiceOperationDocumentDto
            {
                Series = Series,
                Number = Number,
                Date = Date,
                DocumentNumber = DocumentNumber,
                DocumentDate = DocumentDate,
                ClientCode = ClientCode,
                Lines = ((List<ServiceOperationDocumentLineDto>)gridControl1.DataSource)
                    .Where(l => !string.IsNullOrEmpty(l.ServiceCode)).ToList()
            };

            return dto;
        }

        private async Task RefreshUi(string series = "")
        {
            try
            {
                FillView(new ServiceOperationDocumentDto());

                Series = series;
                var action = await _service.GetNewNumberBySeries(Series);

                if (action.IsFailed)
                {
                    MessageBox.Show(action.ErrorMessages.FirstOrDefault());
                    return;
                }

                Number = action.Data;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool ValidateUi()
        {
            if (string.IsNullOrEmpty(buttonEditNumber.Text) || Number == 0)
            {
                buttonEditNumber.Focus();
                MessageBox.Show(@"Sənəd No boş ola bilməz");
                return false;
            }
            if (string.IsNullOrEmpty(ClientCode))
            {
                buttonEditClientCode.Focus();
                MessageBox.Show(@"Cari hesab seçilməyib.");
                return false;
            }

            var lines = ((List<ServiceOperationDocumentLineDto>)gridControl1.DataSource).Where(l => !string.IsNullOrEmpty(l.ServiceCode)).ToList();

            if (!lines.Any())
            {
                MessageBox.Show(@"Saxlanacaq sətir yoxdur və ya sətirdə servis seçilməyib.");
                return false;
            }

            foreach (var line in lines)
            {
                if (line.Count == 0)
                {
                    MessageBox.Show(@"Say 0 ola bilməz");
                    return false;
                }
            }

            return true;
        }

        private void repositoryItemButtonEditService_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                var row = gridView1.GetSelectedRows()[0];

                string serviceCode = string.Empty, serviceName = string.Empty;

                using (var serviceListForm = new ServiceListForm(false))
                {
                    serviceListForm.ShowDialog();

                    var selectedRows = serviceListForm.GetSelectedServices();

                    if (selectedRows == null || selectedRows.Count == 0) return;

                    if (selectedRows.Count > 1)
                    {
                        MessageBox.Show(@"Yalnız bir servis seçilməlidir.", @"XƏBƏRDARLIQ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        var service = selectedRows[0];

                        serviceCode = service.Code;
                        serviceName = service.ServiceName;
                    }

                    gridView1.SetRowCellValue(row, colServiceCode, serviceCode);
                    gridView1.SetRowCellValue(row, colServiceName, serviceName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"XƏTA");
            }
        }

        private async void UcServiceOperationDocument_Load(object sender, EventArgs e)
        {
            try
            {
                repositoryItemLookUpEditOperationType.ValueMember = nameof(KeyValuePair<ServiceOperationType, string>.Key);
                repositoryItemLookUpEditOperationType.DisplayMember = nameof(KeyValuePair<ServiceOperationType, string>.Value);

                repositoryItemLookUpEditOperationType.DataSource = new List<KeyValuePair<ServiceOperationType, string>>
                {
                    new KeyValuePair<ServiceOperationType, string>(ServiceOperationType.Installation, "Quraşdırılma"),
                    new KeyValuePair<ServiceOperationType, string>(ServiceOperationType.Cancellation, "Ləğv etmə")
                };

                await RefreshUi();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNew_Click(object sender, EventArgs e) => await RefreshUi();

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUi()) return;

                if (MessageBox.Show(@"Qeydlər yadda saxlansın?", @"Xəbərdarlıq", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) != DialogResult.Yes)
                    return;

                var entity = GetFromView().ToEntity();

                var result = await _service.SaveAsync(entity);

                if (result.IsFailed)
                {
                    MessageBox.Show(@"Sened saxlanarkən xəta yarandı.\n" + result.ErrorMessages.FirstOrDefault());
                    return;
                }

                MessageBox.Show(@"Sened saxlandi");
                await RefreshUi();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUi())
                {
                    MessageBox.Show(@"Sənəd gətirilməyib.");
                    return;
                }

                var dto = GetFromView();
                var idList = dto.Lines.Where(line => line.Id != 0).Select(line => line.Id).ToList();
                if (!idList.Any())
                {
                    MessageBox.Show(@"Silinəcək sətir yoxdur!");
                    return;
                }

                var dialogResult = MessageBox.Show(@"Sənədi silmək istədiyinizə əminsinizmi?", @"XƏBƏRDARLIQ", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) return;

                var res = await _service.DeleteAsync(idList);

                if (res.IsSucceed)
                {
                    MessageBox.Show(@"Sənəd silindi");
                    await RefreshUi();
                }
                else
                {
                    MessageBox.Show(res.ErrorMessages.FirstOrDefault() ?? res.Exception?.Message);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetPreviousDocumentBySeries(Series, Number);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                if (result.Data == null || result.Data.Number == 0)
                {
                    MessageBox.Show(@"İlk sənəd qeydi!");
                    return;
                }

                var dto = ServiceOperationDocumentDto.FromEntity(result.Data);
                FillView(dto);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetNextDocumentBySeries(Series, Number);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                if (result.Data == null || result.Data.Number == 0)
                {
                    MessageBox.Show(@"Son sənəd qeydi!");
                    return;
                }

                var dto = ServiceOperationDocumentDto.FromEntity(result.Data);
                FillView(dto);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditClient_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var clientForm = new ClientListForm())
            {
                clientForm.ShowDialog();

                var selectedRows = clientForm.GetSelectedClients();

                if (selectedRows.Count == 0)
                {
                    ClientCode = string.Empty;
                    ClientName = string.Empty;
                }
                else if (selectedRows.Count > 1)
                {
                    MessageBox.Show(@"Yalnız bir cari hesab seçilməlidir.", @"XƏBƏRDARLIQ", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    var client = selectedRows[0];

                    ClientCode = client.ClientCode;
                    ClientName = client.ClientName;
                }
            }
        }

        private async void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colServiceCode)
            {
                var serviceCode = gridView1.GetRowCellValue(e.RowHandle, colServiceCode).ToString();
                if (string.IsNullOrEmpty(serviceCode))
                {
                    gridView1.SetRowCellValue(e.RowHandle, colServiceName, string.Empty);
                    return;
                }

                var serviceResult = await RepositoryContainer.ServiceRepository.GetByCode(serviceCode);

                if (serviceResult.IsFailed)
                {
                    MessageBox.Show(serviceResult.ErrorMessages.FirstOrDefault());
                }

                if (serviceResult.Data == null || serviceResult.Data.Code.IsNullOrEmpty())
                {
                    MessageBox.Show(@"Servis tapilmadi");
                    gridView1.SetRowCellValue(e.RowHandle, colServiceCode, string.Empty);
                    gridView1.SetRowCellValue(e.RowHandle, colServiceName, string.Empty);
                    return;
                }

                gridView1.SetRowCellValue(e.RowHandle, colServiceName, serviceResult.Data.ServiceName);
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter) && gridView1.FocusedColumn == colCount)
            {
                var dataSource = (List<ServiceOperationDocumentLineDto>)gridControl1.DataSource;
                dataSource.Add(new ServiceOperationDocumentLineDto());

                gridControl1.DataSource = dataSource;
                gridControl1.RefreshDataSource();
            }
        }

        private async void buttonEditNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetBySeriesAndNumber(Series, Number);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                if (result.Data == null || result.Data.Number == 0)
                {
                    await RefreshUi(Series);
                    return;
                }

                var dto = ServiceOperationDocumentDto.FromEntity(result.Data);
                FillView(dto);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditClientCode_Leave(object sender, EventArgs e)
        {

        }

        private async void txtSeries_Leave(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetNewNumberBySeries(Series);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                await RefreshUi(Series);
                Number = result.Data;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void buttonEditNumber_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                using (var form = new ServiceDocumentListForm())
                {
                    form.ShowDialog();

                    var selectedRows = form.GetSelectedDocuments();

                    if (selectedRows == null || selectedRows.Count == 0)
                        return;

                    if (selectedRows.Count > 1)
                    {
                        MessageBox.Show(@"Yalniz 1 setir secilmelidir.");
                        return;
                    }

                    var dto = selectedRows[0];
                    var documentResult = await _service.GetBySeriesAndNumber(dto.Series, dto.Number);
                    if (documentResult.IsFailed)
                    {
                        MessageBox.Show(documentResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    FillView(ServiceOperationDocumentDto.FromEntity(documentResult.Data));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
