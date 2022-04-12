using Dapper;
using NBA.ServiceSchedule.DataAccess;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class ProjectListForm : Form
    {
        private bool _rowsSelected;

        public ProjectListForm()
        {
            InitializeComponent();
        }

        public List<ProjectDto> GetSelectedProjects()
        {
            if (!_rowsSelected) return new List<ProjectDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ProjectDto)gridView1.GetRow(row)).ToList();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gridControl1.IsFocused)
            {
                _rowsSelected = true;
                Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _rowsSelected = true;
            Close();
        }

        private async void ProjectListForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = SqlHelper.CreateConnection())
                {
                    var query = "select pro_kodu as [Code], pro_adi as [Name] from PROJELER";
                    var services = await connection.QueryAsync<ProjectDto>(query);

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
