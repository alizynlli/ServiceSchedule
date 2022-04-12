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
    public partial class ClientListForm : Form
    {
        private bool _rowsSelected;

        public ClientListForm()
        {
            InitializeComponent();
        }

        public List<ClientDto> GetSelectedClients()
        {
            if (!_rowsSelected) return new List<ClientDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ClientDto)gridView1.GetRow(row)).ToList();
        }

        private async void ClientListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dtoList = await GetClients();
                gridControl1.DataSource = dtoList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public async Task<List<ClientDto>> GetClients()
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = $@"select cari_kod as [{nameof(ClientDto.ClientCode)}], cari_unvan1 as [{nameof(ClientDto.ClientName)}], crg_isim as [{nameof(ClientDto.ClientGroupName)}] from CARI_HESAPLAR
                                    left join CARI_HESAP_GRUPLARI on cari_grup_kodu = crg_kod";

                    var clientList = (await connection.QueryAsync<ClientDto>(query)).ToList();

                    return clientList;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return new List<ClientDto>();
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
