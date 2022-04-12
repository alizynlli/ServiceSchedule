using DevExpress.XtraGrid.Views.Grid;
using NBA.ServiceSchedule.Core.Abstracts.Services;
using NBA.ServiceSchedule.DataAccess.Implementation;
using NBA.ServiceSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NBA.ServiceSchedule.Forms.Lists
{
    public partial class ClientPaymentNoteListForm : Form
    {
        private bool _rowsSelected;
        private readonly IClientPaymentNoteService _service;

        public ClientPaymentNoteListForm(bool isMultiSelect)
        {
            InitializeComponent();

            _service = ServiceContainer.ClientPaymentNoteService;
            gridView1.OptionsSelection.MultiSelect = isMultiSelect;
            gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
        }

        public List<ClientPaymentNoteDto> GetSelectedClientPaymentNotes()
        {
            if (!_rowsSelected) return new List<ClientPaymentNoteDto>();

            var rows = gridView1.GetSelectedRows();
            return rows.Select(row => (ClientPaymentNoteDto)gridView1.GetRow(row)).ToList();
        }

        private async void ClientPaymentNoteListForm_Load(object sender, EventArgs e)
        {
            try
            {
                var result = await _service.GetAllAsync();

                if (result.IsFailed)
                {
                    MessageBox.Show(result.ErrorMessages?.FirstOrDefault());
                    return;
                }

                var dtoList = result.Data.Select(ClientPaymentNoteDto.FromEntity).ToList();
                gridControl1.DataSource = dtoList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
