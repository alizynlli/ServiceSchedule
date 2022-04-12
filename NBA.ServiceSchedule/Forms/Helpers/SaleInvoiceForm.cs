using DevExpress.XtraEditors.Controls;
using NBA.ServiceSchedule.Core;
using NBA.ServiceSchedule.Core.Constants.Enums;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Helpers
{
    public partial class SaleInvoiceForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<ClientAccountOperationDao> _daoList;
        public SaleInvoiceForm(List<ClientAccountOperationDao> daoList, DateTime date)
        {
            InitializeComponent();

            _daoList = daoList.Where(dao => dao.cha_meblag > 0).ToList();
            Date = DocumentDate = date;
            ProjectCode = "102";
            ResponsibilityCenterCode = "02";
        }

        public bool InvoicesCreated { get; private set; }

        public string Series
        {
            get => txtSeries.Text.Trim();
            set => txtSeries.Text = value;
        }

        public int Number
        {
            get => Convert.ToInt32(txtNumber.Text.Trim());
            set => txtNumber.Text = value.ToString();
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

        public string ServiceCode
        {
            get => buttonEditServiceCode.Text.Trim();
            set => buttonEditServiceCode.Text = value;
        }

        public string ResponsibilityCenterCode
        {
            get => buttonEditResponsibilityCenterCode.Text.Trim();
            set => buttonEditResponsibilityCenterCode.Text = value;
        }

        public string ProjectCode
        {
            get => buttonEditProjectCode.Text.Trim();
            set => buttonEditProjectCode.Text = value;
        }

        public bool ValidateUi()
        {
            if (ServiceCode.IsNullOrEmpty())
            {
                MessageBox.Show("Xidmət kodu boş ola bilməz!", "XƏTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonEditServiceCode.Focus();
                return false;
            }
            if (ProjectCode.IsNullOrEmpty())
            {
                MessageBox.Show("Layihə kodu boş ola bilməz!", "XƏTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonEditProjectCode.Focus();
                return false;
            }
            if (ResponsibilityCenterCode.IsNullOrEmpty())
            {
                MessageBox.Show("Məsuliyyət mərkəzi kodu boş ola bilməz!", "XƏTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                buttonEditResponsibilityCenterCode.Focus();
                return false;
            }
            return true;
        }

        private async void SaleInvoiceForm_Load(object sender, EventArgs e)
        {
            Series = GlobalParameters.SaleInvoiceSeries;
            //Date = DateTime.Today;
            //DocumentDate = DateTime.Today;
            lblInvoiceCount.Text = _daoList.Count.ToString();

            await LoadNewNumber();
        }

        public async Task LoadNewNumber()
        {
            try
            {
                var series = txtSeries.Text.Trim();

                var result = await RepositoryContainer.ClientAccountOperationRepository.GetNewNumberBySeries(series);
                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                    return;
                }

                txtNumber.Text = result.Data.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUi()) return;

                var number = Number;
                ActionResult result;
                var count = 0;

                var monthName = ((Months)Date.Month).DescriptionAttr().ToUpper();
                var descriptionDao = new DocumentDescriptionDao
                {
                    egk_evracik1 = monthName,
                    egk_evracik6 = $"SRV({monthName})",
                };

                foreach (var dao in _daoList)
                {
                    dao.cha_kasa_hizkod = ServiceCode;
                    dao.cha_srmrkkodu = dao.cha_karsisrmrkkodu = ResponsibilityCenterCode;
                    dao.cha_projekodu = ProjectCode;
                    dao.cha_evrakno_seri = Series;
                    dao.cha_evrakno_sira = number++;
                    dao.cha_tarihi = Date;
                    dao.cha_belge_no = DocumentNumber;
                    dao.cha_belge_tarih = DocumentDate;
                    dao.cha_aciklama = monthName;
                    result = await RepositoryContainer.ClientAccountOperationRepository.InsertAsync(dao);
                    if (result.IsFailed)
                    {
                        var result2 = await RepositoryContainer.ClientAccountOperationRepository.InsertAsync(dao);

                        if (result2.IsFailed)
                        {
                            var result3 = await RepositoryContainer.ClientAccountOperationRepository.InsertAsync(dao);

                            if (result3.IsFailed)
                            {
                                MessageBox.Show(result3.ErrorMessages.FirstOrDefault());
                                return;
                            }
                        }
                    }

                    descriptionDao.egk_evr_seri = dao.cha_evrakno_seri;
                    descriptionDao.egk_evr_sira = dao.cha_evrakno_sira;
                    result = await RepositoryContainer.ClientAccountOperationRepository.InsertDescriptionAsync(descriptionDao);
                    if (result.IsFailed)
                    {
                        MessageBox.Show(result.ErrorMessages.FirstOrDefault());
                        return;
                    }

                    lblSavedCount.Text = (++count).ToString();
                }

                MessageBox.Show(@"Satış sənədləri saxlandı.");
                InvoicesCreated = true;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditServiceCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var form = new MikroServiceListForm())
            {
                form.ShowDialog();
                var selectedServices = form.GetSelectedServices();

                if (selectedServices == null || selectedServices.Count == 0)
                    return;

                if (selectedServices.Count > 1)
                {
                    MessageBox.Show(@"Yalniz bir xidmet secilmelidir");
                    return;
                }

                buttonEditServiceCode.Text = selectedServices[0].Code;
            }
        }

        private void buttonEditResponsibilityCenterCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var form = new ResponsibilityCenterListForm())
            {
                form.ShowDialog();
                var selectedResponsibilityCenters = form.GetSelectedResponsibilityCenters();

                if (selectedResponsibilityCenters == null || selectedResponsibilityCenters.Count == 0)
                    return;

                if (selectedResponsibilityCenters.Count > 1)
                {
                    MessageBox.Show(@"Yalniz bir mesuliyyet merkezi secilmelidir");
                    return;
                }

                buttonEditResponsibilityCenterCode.Text = selectedResponsibilityCenters[0].Code;
            }
        }

        private async void txtSeries_Leave(object sender, EventArgs e)
        {
            await LoadNewNumber();
        }

        private void buttonEditProjectCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var form = new ProjectListForm())
            {
                form.ShowDialog();
                var selectedProjects = form.GetSelectedProjects();

                if (selectedProjects == null || selectedProjects.Count == 0)
                    return;

                if (selectedProjects.Count > 1)
                {
                    MessageBox.Show(@"Yalniz bir layihe secilmelidir");
                    return;
                }

                buttonEditProjectCode.Text = selectedProjects[0].Code;
            }
        }
    }
}