using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Lists;
using NBA.ServiceSchedule.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Cards
{
    public partial class ServiceForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IServiceCardService _service;

        public ServiceForm()
        {
            InitializeComponent();

            _service = ServiceContainer.ServiceCardService;
        }

        public int Id { get; set; }

        public string ServiceCode
        {
            get => buttonEditServiceCode.Text.Trim();
            set => buttonEditServiceCode.Text = value;
        }

        public string ServiceName
        {
            get => buttonEditServiceName.Text.Trim();
            set => buttonEditServiceName.Text = value;
        }

        public decimal MonthlyPaymentAmount
        {
            get => Convert.ToDecimal(txtMonthlyPaymentAmount.Text.Trim());
            set => txtMonthlyPaymentAmount.Text = value.ToString("0.00");
        }
        public decimal DailyPaymentAmount
        {
            get => Convert.ToDecimal(txtDailyPaymentAmount.Text.Trim());
            set => txtDailyPaymentAmount.Text = value.ToString("0.00");
        }

        private void FillView(ServiceDto dto)
        {
            Id = dto.Id;
            ServiceCode = dto.Code;
            ServiceName = dto.ServiceName;
            MonthlyPaymentAmount = dto.MonthlyPaymentAmount;
            DailyPaymentAmount = dto.DailyPaymentAmount;
        }

        private ServiceDto GetFromView()
        {
            return new ServiceDto
            {
                Id = Id,
                Code = ServiceCode,
                ServiceName = ServiceName,
                MonthlyPaymentAmount = MonthlyPaymentAmount,
                DailyPaymentAmount = DailyPaymentAmount
            };
        }

        private bool ValidateUserInputs()
        {
            if (ServiceCode.IsNullOrEmpty())
            {
                buttonEditServiceCode.Focus();
                return false;
            }
            if (MonthlyPaymentAmount == 0)
            {
                txtMonthlyPaymentAmount.Focus();
                return false;
            }
            if (DailyPaymentAmount == 0)
            {
                txtDailyPaymentAmount.Focus();
                return false;
            }

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUserInputs()) return;

                var res = await _service.SaveAsync(GetFromView().ToEntity());

                if (res.IsFailed)
                {
                    MessageBox.Show(res.ErrorMessages.FirstOrDefault() ?? res.Exception?.Message);
                    return;
                }

                MessageBox.Show(@"Servis saxlandı");
                FillView(new ServiceDto());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditServiceCode_Leave(object sender, EventArgs e)
        {

        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id == 0)
                {
                    MessageBox.Show(@"Servis gətirilməyib.");
                    return;
                }

                var dialogButton = MessageBox.Show(@"Servisi silmək istədiyinizə əminsinizmi?", @"Xəbərdarlıq", MessageBoxButtons.YesNo);
                if (dialogButton != DialogResult.Yes) return;

                var result = await _service.DeleteAsync(Id);

                if (result.IsFailed)
                {
                    MessageBox.Show(@"Servis silinərkən xəta yarandı.");
                    MessageBox.Show(result.ErrorMessages?.FirstOrDefault() ?? result.Exception?.Message);
                    return;
                }

                MessageBox.Show(@"Servis silindi.");
                FillView(new ServiceDto());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            FillView(new ServiceDto());
        }

        private void buttonEditService_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var serviceListForm = new ServiceListForm(false))
                {
                    serviceListForm.ShowDialog();
                    var services = serviceListForm.GetSelectedServices();

                    if (services == null || services.Count == 0)
                        return;

                    if (services.Count > 1)
                    {
                        MessageBox.Show(@"Yalniz 1 servis secilmelidir");
                        return;
                    }

                    var dto = services[0];
                    FillView(dto);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FillView(new ServiceDto());
        }
    }
}
