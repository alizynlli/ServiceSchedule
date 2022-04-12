using Dapper;
using NBA.ServiceSchedule.DataAccess;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class MikroServiceListForm : Form
    {
        private bool _rowsSelected;

        public MikroServiceListForm()
        {
            InitializeComponent();
        }

        public List<MikroServiceDto> GetSelectedServices()
        {
            if (!_rowsSelected) return new List<MikroServiceDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (MikroServiceDto)gridView1.GetRow(row)).ToList();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridControl1.IsFocused)
            {
                _rowsSelected = true;
                Close();
            }
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            _rowsSelected = true;
            Close();
        }

        private async void MikroServiceListForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = "SELECT hiz_kod as Code, hiz_isim as [Name] FROM HIZMET_HESAPLARI";
                    var services = await connection.QueryAsync<MikroServiceDto>(query);

                    gridControl1.DataSource = services;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
