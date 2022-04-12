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
    public partial class UserForm : Form
    {
        private readonly IUserService _service;

        public UserForm()
        {
            InitializeComponent();

            _service = ServiceContainer.UserService;
        }

        public int Id { get; set; }

        public string FirstName
        {
            get => buttonEditFirstName.Text.Trim();
            set => buttonEditFirstName.Text = value;
        }

        public string LastName
        {
            get => buttonEditLastName.Text.Trim();
            set => buttonEditLastName.Text = value;
        }

        public string UserName
        {
            get => txtUserName.Text.Trim();
            set => txtUserName.Text = value;
        }

        public string Password
        {
            get => txtPassword.Text.Trim();
            set => txtPassword.Text = value;
        }

        public void FillView(UserDto dto)
        {
            Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            UserName = dto.UserName;
            Password = dto.Password;
        }

        public UserDto GetFromView()
        {
            return new UserDto
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                UserName = UserName,
                Password = Password
            };
        }

        public bool ValidateUi()
        {
            if (FirstName.IsNullOrEmpty())
            {
                buttonEditFirstName.Focus();
                return false;
            }
            if (UserName.IsNullOrEmpty())
            {
                txtUserName.Focus();
                return false;
            }

            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FillView(new UserDto());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUi())
                    return;

                if (MessageBox.Show(@"Qeyd yadda saxlansın?", @"Diqqət", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var dto = GetFromView();
                var saveResult = await _service.SaveAsync(dto.ToEntity());
                if (saveResult.IsFailed)
                {
                    MessageBox.Show(saveResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                MessageBox.Show(@"Qeyd yadda saxlandı");
                FillView(new UserDto());
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

                if (MessageBox.Show(@"Qeyd silinsin?", @"Xəbərdarlıq", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var removeResult = await _service.DeleteAsync(Id);
                if (removeResult.IsFailed)
                {
                    MessageBox.Show(removeResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                MessageBox.Show(@"Qeyd silindi.");
                FillView(new UserDto());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonEditUser_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var userListForm = new UserListForm())
                {
                    userListForm.ShowDialog();
                    var users = userListForm.GetSelectedUsers();

                    if (users == null || users.Count == 0)
                        return;

                    if (users.Count > 1)
                    {
                        MessageBox.Show(@"Yalniz 1 istifadəçi secilməlidir");
                        return;
                    }

                    var dto = users[0];
                    FillView(dto);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
