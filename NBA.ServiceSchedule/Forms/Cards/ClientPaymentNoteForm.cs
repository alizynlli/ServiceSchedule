using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using NBA.ServiceSchedule.Forms.Lists;

namespace NBA.ServiceSchedule.Forms.Cards
{
    public partial class ClientPaymentNoteForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IClientPaymentNoteService _service;

        public ClientPaymentNoteForm()
        {
            InitializeComponent();

            _service = ServiceContainer.ClientPaymentNoteService;
        }

        public int Id { get; set; }

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

        private void FillView(ClientPaymentNoteDto dto)
        {
            Id = dto.Id;
            ClientCode = dto.ClientCode;
            ClientName = dto.ClientName;
            FirstDate = dto.FirstDate;
            LastDate = dto.LastDate;
        }

        private ClientPaymentNoteDto GetFromView()
        {
            return new ClientPaymentNoteDto
            {
                Id = Id,
                ClientCode = ClientCode,
                ClientName = ClientName,
                FirstDate = FirstDate,
                LastDate = LastDate
            };
        }

        private bool ValidateUserInputs()
        {
            if (ClientCode.IsNullOrEmpty())
            {
                buttonEditClientCode.Focus();
                return false;
            }
            if (FirstDate == DateTime.MinValue)
            {
                dateEditFirstDate.Focus();
                return false;
            }
            if (LastDate == DateTime.MinValue)
            {
                dateEditLastDate.Focus();
                return false;
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FillView(new ClientPaymentNoteDto());
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

                MessageBox.Show(@"Qeyd saxlandı");
                FillView(new ClientPaymentNoteDto());
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
                if (Id == 0)
                {
                    MessageBox.Show(@"Qeyd gətirilməyib.");
                    return;
                }

                var dialogButton = MessageBox.Show(@"Qeydi silmək istədiyinizə əminsinizmi?", @"Xəbərdarlıq", MessageBoxButtons.YesNo);
                if (dialogButton != DialogResult.Yes) return;

                var result = await _service.DeleteAsync(Id);

                if (result.IsFailed)
                {
                    MessageBox.Show(@"Qeyd silinərkən xəta yarandı.");
                    MessageBox.Show(result.ErrorMessages?.FirstOrDefault() ?? result.Exception?.Message);
                    return;
                }

                MessageBox.Show(@"Qeyd silindi.");
                FillView(new ClientPaymentNoteDto());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditClient_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var clientListForm = new ClientListForm())
                {
                    clientListForm.ShowDialog();
                    var clients = clientListForm.GetSelectedClients();

                    if (clients == null || clients.Count == 0)
                        return;

                    if (clients.Count > 1)
                    {
                        MessageBox.Show(@"Yalniz 1 cari hesab secilmelidir");
                        return;
                    }

                    var dto = clients[0];
                    ClientCode = dto.ClientCode;
                    ClientName = dto.ClientName;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnSelectNote_Click(object sender, EventArgs e)
        {
            try
            {
                using (var noteListForm = new ClientPaymentNoteListForm(false))
                {
                    noteListForm.ShowDialog();
                    var notes = noteListForm.GetSelectedClientPaymentNotes();

                    if (notes == null || notes.Count == 0)
                        return;

                    if (notes.Count > 1)
                    {
                        MessageBox.Show(@"Yalniz 1 qeyd secilmelidir");
                        return;
                    }

                    var dto = notes[0];
                    FillView(dto);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ClientPaymentNoteForm_Load(object sender, EventArgs e)
        {
            FillView(new ClientPaymentNoteDto());
        }
    }
}