using Dapper;
using NBA.ServiceSchedule.DataAccess;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class ResponsibilityCenterListForm : Form
    {
        private bool _rowsSelected;

        public ResponsibilityCenterListForm()
        {
            InitializeComponent();
        }

        public List<ResponsibilityCenterDto> GetSelectedResponsibilityCenters()
        {
            if (!_rowsSelected) return new List<ResponsibilityCenterDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ResponsibilityCenterDto)gridView1.GetRow(row)).ToList();
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

        private async void ResponsibilityCenterListForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = "SELECT som_kod as Code, som_isim as [Name] FROM SORUMLULUK_MERKEZLERI";
                    var services = await connection.QueryAsync<ResponsibilityCenterDto>(query);

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
