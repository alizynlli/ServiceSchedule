using DevExpress.XtraEditors;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.Core.Extensions;
using NBA.ServiceSchedule.Core.Global;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Forms.Helpers;
using NBA.ServiceSchedule.Forms.Lists;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms
{
    public partial class LoginForm : XtraForm
    {
        private readonly IUserService _userService;
        private bool _processIsCompleted = true;

        public LoginForm()
        {
            InitializeComponent();

            _userService = ServiceContainer.UserService;
        }

        private string UserName
        {
            get => txtUserName.Text.Trim();
            set => txtUserName.Text = value;
        }

        private string Password => txtPassword.Text;

        private bool ValidateUi()
        {
            if (UserName.IsNullOrEmpty())
            {
                txtUserName.Focus();
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            using (var passwordForm = new PasswordForm())
            {
                passwordForm.ShowDialog();

                if (passwordForm.Accessible)
                    using (var connectionForm = new ConnectionForm())
                        connectionForm.ShowDialog();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_processIsCompleted) return;
                _processIsCompleted = false;

                if (!ValidateUi()) return;

                var userEntityResult = await _userService.FindUserByUserNameAndPassword(UserName, Password);
                if (userEntityResult.IsFailed)
                {
                    MessageBox.Show(userEntityResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                if (userEntityResult.Data == null || userEntityResult.Data.Id == 0)
                {
                    MessageBox.Show(@"İstifadəçi adı və ya şifrə yanlışdır.");
                    return;
                }

                var user = userEntityResult.Data;
                Session.CurrentUser = user;

                CloseThisAndOpenMainForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                _processIsCompleted = true;
            }
        }

        private void CloseThisAndOpenMainForm()
        {
            var mainForm = new MainForm();
            Hide();
            mainForm.ShowDialog();

            Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (UserName.IsNullOrEmpty()) return;

            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSelectUser_Click(object sender, EventArgs e)
        {
            using (var userListForm = new UserListForm())
            {
                userListForm.ShowDialog();

                var selectedUsers = userListForm.GetSelectedUsers();
                if (selectedUsers == null || !selectedUsers.Any()) return;

                if (selectedUsers.Count > 1)
                {
                    MessageBox.Show(@"Yalnız bir istifadəçi seçilməlidir.");
                    return;
                }

                var user = selectedUsers[0];
                UserName = user?.UserName;
                txtPassword.Focus();
            }
        }
    }
}
