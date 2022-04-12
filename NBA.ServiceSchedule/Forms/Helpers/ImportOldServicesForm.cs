using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Models;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Helpers
{
    public partial class ImportOldServicesForm : DevExpress.XtraEditors.XtraForm
    {
        private List<ServiceOperationDocumentDto> _dtoList;
        private readonly IServiceOperationDocumentService _service;

        public ImportOldServicesForm()
        {
            InitializeComponent();

            _dtoList = new List<ServiceOperationDocumentDto>();
            _service = ServiceContainer.ServiceOperationDocumentService;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dtoList == null || _dtoList.Count == 0)
                {
                    MessageBox.Show(@"Məlumatlar yüklənməyib.");
                    return;
                }

                const string series = "A";

                ActionResult saveResult;

                var numberResult = await _service.GetNewNumberBySeries(series);

                if (numberResult.IsFailed)
                {
                    MessageBox.Show(numberResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                lblFirstNumber.Text = numberResult.Data.ToString();
                int count = 0, totalCount = _dtoList.Count;
                var oldDate = new DateTime(2021, 10, 31);
                foreach (var dto in _dtoList)
                {
                    dto.Series = series;
                    dto.Number = numberResult.Data;
                    dto.Date = oldDate;
                    dto.DocumentDate = oldDate;

                    var entity = dto.ToEntity();
                    saveResult = await _service.SaveAsync(entity);

                    if (saveResult.IsFailed)
                    {
                        MessageBox.Show(saveResult.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    lblInsertedDocumentCount.Text = $@"{++count} / {totalCount}";

                    numberResult = await _service.GetNewNumberBySeries(series);

                    if (numberResult.IsFailed)
                    {
                        MessageBox.Show(numberResult.ErrorMessages.FirstOrDefault());
                        return;
                    }
                }

                MessageBox.Show(@"Məlumatlar saxlandı.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = "c:\\",
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                var filePath = openFileDialog.FileName;

                var workbook = new Workbook();
                workbook.LoadFromFile(filePath);
                var sheet = workbook.Worksheets[0];

                if (_dtoList == null) _dtoList = new List<ServiceOperationDocumentDto>();
                else _dtoList.Clear();

                for (var row = 2; ; row++)
                {
                    var clientCode = sheet.Range[$"A{row}"].Value;
                    if (string.IsNullOrEmpty(clientCode)) break;

                    var dto = new ServiceOperationDocumentDto
                    {
                        ClientCode = clientCode,
                        Lines = new List<ServiceOperationDocumentLineDto>(7)
                    };

                    for (var column = 3; column <= 9; column++)
                    {
                        var value = sheet.Range[row, column].Value;
                        if (int.TryParse(value, out var count) && count > 0)
                        {
                            dto.Lines.Add(new ServiceOperationDocumentLineDto
                            {
                                ServiceCode = $"000{column - 2}",
                                Count = count,
                                OperationType = ServiceOperationType.Installation
                            });
                        }
                    }

                    if (dto.Lines.Any())
                        _dtoList.Add(dto);
                }

                MessageBox.Show(@"Məlumatlar yükləndi.");
                lblDocumentCount.Text = _dtoList.Count.ToString();
                lblDocumentCount.ForeColor = _dtoList.Count > 0 ? Color.DarkGreen : Color.Red;
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Excel import edilərkən xəta yarandı.");
                MessageBox.Show(exception.Message);
            }
        }
    }
}
