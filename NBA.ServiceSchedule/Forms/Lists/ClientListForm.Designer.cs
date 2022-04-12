﻿namespace NBA.ServiceSchedule.Forms.Lists
{
    partial class ClientListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(776, 426);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClientCode,
            this.colClientName,
            this.colGroupName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colClientCode
            // 
            this.colClientCode.Caption = "Cari kodu";
            this.colClientCode.FieldName = "ClientCode";
            this.colClientCode.Name = "colClientCode";
            this.colClientCode.OptionsColumn.ReadOnly = true;
            this.colClientCode.Visible = true;
            this.colClientCode.VisibleIndex = 1;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Cari Adı";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Name = "colClientName";
            this.colClientName.OptionsColumn.ReadOnly = true;
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 2;
            // 
            // colGroupName
            // 
            this.colGroupName.Caption = "Cari Qrup Adı";
            this.colGroupName.FieldName = "ClientGroupName";
            this.colGroupName.Name = "colGroupName";
            this.colGroupName.Visible = true;
            this.colGroupName.VisibleIndex = 3;
            // 
            // ClientListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Name = "ClientListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Hesablar";
            this.Load += new System.EventHandler(this.ClientListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colClientCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupName;
    }
}