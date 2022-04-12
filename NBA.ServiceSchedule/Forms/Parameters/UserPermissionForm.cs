using NBA.ServiceSchedule.Core.Constants;
using NBA.ServiceSchedule.Core.Models.DAOs;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.DataAccess.Implementation.Repositories;
using NBA.ServiceSchedule.Forms.Lists;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Parameters
{
    public partial class UserPermissionForm : DevExpress.XtraEditors.XtraForm
    {
        private UserDto _user;
        private readonly List<UserPermissionDto> _userPermissions;
        private readonly PermissionRepository _repository;

        public UserPermissionForm()
        {
            InitializeComponent();

            _userPermissions = PermissionKeys.Keys.Select(keyValuePair => new UserPermissionDto
            {
                PermissionKey = keyValuePair.Key,
                Description = keyValuePair.Value,
                Active = false
            }).ToList();

            _repository = RepositoryContainer.PermissionRepository;
        }

        private async void buttonEditUser_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        MessageBox.Show(@"Yalnız 1 istifadəçi secilməlidir");
                        return;
                    }

                    if (users[0].IsSupervisor)
                    {
                        MessageBox.Show(@"Supervisor üçün icazələr tətbiq edilmir.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _user = users[0];

                    buttonEditUser.Text = $@"{_user?.FirstName} {_user?.LastName}";
                    await FillPermissions();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public async Task FillPermissions()
        {
            try
            {
                var permissionsResult = await _repository.GetByUserAsync(_user.Id);
                if (permissionsResult.IsFailed)
                {
                    MessageBox.Show(permissionsResult.ErrorMessages.FirstOrDefault());
                    return;
                }
                var permissions = permissionsResult.Data.Select(dao => dao.PermissionKey);
                _userPermissions.ForEach(up => up.Active = permissions.Contains(up.PermissionKey));

                gridControl1.DataSource = _userPermissions;
                gridControl1.RefreshDataSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_user == null || _user.Id == 0)
                {
                    MessageBox.Show(@"İstifadəçi gətirilməyib.");
                    return;
                }

                if (MessageBox.Show(@"Qeydlər yadda saxlansın?", string.Empty, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                var deleteResult = await _repository.DeleteUserPermissionsAsync(_user.Id);
                if (deleteResult.IsFailed)
                {
                    MessageBox.Show(deleteResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                var userPermissions = ((List<UserPermissionDto>)gridControl1.DataSource).Where(p => p.Active);
                var daoList = userPermissions.Select(userPermission =>
                    new PermissionDao { PermissionKey = userPermission.PermissionKey, UserId = _user.Id });

                var insertResult = await _repository.InsertAllAsync(daoList);
                if (insertResult.IsFailed)
                {
                    MessageBox.Show(insertResult.ErrorMessages.FirstOrDefault());
                    return;
                }

                MessageBox.Show(@"Qeydlər saxlandı.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void UserPermissionForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _userPermissions;
        }
    }
}