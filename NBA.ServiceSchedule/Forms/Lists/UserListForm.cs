using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class UserListForm : DevExpress.XtraEditors.XtraForm
    {
        private bool _rowsSelected;
        private readonly IUserService _service;

        public UserListForm()
        {
            InitializeComponent();

            _service = ServiceContainer.UserService;
        }

        private async void UserListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetAllAsync();

                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages?.FirstOrDefault());
                    return;
                }

                var dtoList = result.Data.Select(UserDto.FromEntity).ToList();
                gridControl1.DataSource = dtoList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public List<UserDto> GetSelectedUsers()
        {
            if (!_rowsSelected) return new List<UserDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (UserDto)gridView1.GetRow(row)).ToList();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridControl1.IsFocused)
            {
                _rowsSelected = true;
                Close();
            }
        }
    }
}