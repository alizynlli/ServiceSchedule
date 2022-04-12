using Dapper;
using NBA.ServiceSchedule.DataAccess;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class ClientGroupListForm : Form
    {
        private bool _rowsSelected;

        public ClientGroupListForm()
        {
            InitializeComponent();
        }

        public List<ClientGroupDto> GetSelectedClientGroups()
        {
            if (!_rowsSelected) return new List<ClientGroupDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ClientGroupDto)gridView1.GetRow(row)).ToList();
        }

        private async void ClientGroupListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dtoList = await GetClientGroups();
                gridControl1.DataSource = dtoList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async Task<List<ClientGroupDto>> GetClientGroups()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $"select crg_kod as [{nameof(ClientGroupDto.GroupCode)}], crg_isim as [{nameof(ClientGroupDto.GroupName)}] from CARI_HESAP_GRUPLARI";
                    var clientGroupList = (await connection.QueryAsync<ClientGroupDto>(query)).ToList();

                    return clientGroupList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return new List<ClientGroupDto>();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _rowsSelected = true;
            Close();
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
