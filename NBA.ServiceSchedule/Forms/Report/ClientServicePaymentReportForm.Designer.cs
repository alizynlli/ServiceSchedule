namespace NBA.ServiceSchedule.Forms.Report
{
    partial class ClientServicePaymentReportForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientServicePaymentReportForm));
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gridViewReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSaleInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditClients = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditLastDateCount = new DevExpress.XtraEditors.CheckEdit();
            this.colOldAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClients.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLastDateCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colActive
            // 
            this.colActive.Caption = "Aktiv";
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 2;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(106, 26);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tarix:";
            // 
            // gridControlReport
            // 
            this.gridControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlReport.Location = new System.Drawing.Point(12, 90);
            this.gridControlReport.MainView = this.gridViewReport;
            this.gridControlReport.Name = "gridControlReport";
            this.gridControlReport.Size = new System.Drawing.Size(777, 339);
            this.gridControlReport.TabIndex = 3;
            this.gridControlReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReport});
            // 
            // gridViewReport
            // 
            this.gridViewReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClientCode,
            this.colClientName,
            this.colActive,
            this.colDescription,
            this.colOldAmount});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colActive;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "1";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colActive;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "0";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridViewReport.FormatRules.Add(gridFormatRule1);
            this.gridViewReport.FormatRules.Add(gridFormatRule2);
            this.gridViewReport.GridControl = this.gridControlReport;
            this.gridViewReport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.colClientCode, "")});
            this.gridViewReport.Name = "gridViewReport";
            this.gridViewReport.OptionsView.ShowFooter = true;
            this.gridViewReport.OptionsView.ShowGroupPanel = false;
            // 
            // colClientCode
            // 
            this.colClientCode.Caption = "Cari Kodu";
            this.colClientCode.FieldName = "ClientCode";
            this.colClientCode.Name = "colClientCode";
            this.colClientCode.Visible = true;
            this.colClientCode.VisibleIndex = 0;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Cari Adı";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Name = "colClientName";
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Açıqlama";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // btnSaleInvoice
            // 
            this.btnSaleInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaleInvoice.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaleInvoice.Appearance.Options.UseBackColor = true;
            this.btnSaleInvoice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaleInvoice.ImageOptions.Image")));
            this.btnSaleInvoice.Location = new System.Drawing.Point(658, 435);
            this.btnSaleInvoice.Name = "btnSaleInvoice";
            this.btnSaleInvoice.Size = new System.Drawing.Size(108, 34);
            this.btnSaleInvoice.TabIndex = 4;
            this.btnSaleInvoice.Text = "Satış fakturası";
            this.btnSaleInvoice.Click += new System.EventHandler(this.BtnSaleInvoice_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Gold;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ImageOptions.ImageToTextIndent = 0;
            this.btnRefresh.Location = new System.Drawing.Point(373, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 25);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Yenilə";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // buttonEditClients
            // 
            this.buttonEditClients.Location = new System.Drawing.Point(106, 54);
            this.buttonEditClients.Name = "buttonEditClients";
            this.buttonEditClients.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditClients.Properties.ReadOnly = true;
            this.buttonEditClients.Size = new System.Drawing.Size(251, 20);
            this.buttonEditClients.TabIndex = 6;
            this.buttonEditClients.ToolTip = "Cari hesabları seçin";
            this.buttonEditClients.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ButtonEditClients_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(33, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Cari hesablar:";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToExcel.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExportToExcel.Appearance.Options.UseBackColor = true;
            this.btnExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.ImageOptions.Image")));
            this.btnExportToExcel.Location = new System.Drawing.Point(33, 435);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(108, 34);
            this.btnExportToExcel.TabIndex = 8;
            this.btnExportToExcel.Text = "Export";
            this.btnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
            // 
            // checkEditLastDateCount
            // 
            this.checkEditLastDateCount.Location = new System.Drawing.Point(223, 26);
            this.checkEditLastDateCount.Name = "checkEditLastDateCount";
            this.checkEditLastDateCount.Properties.Caption = "Son tarix qalıqları";
            this.checkEditLastDateCount.Size = new System.Drawing.Size(134, 20);
            this.checkEditLastDateCount.TabIndex = 9;
            // 
            // colOldAmount
            // 
            this.colOldAmount.Caption = "Kohne Mebleg";
            this.colOldAmount.FieldName = "OldAmount";
            this.colOldAmount.Name = "colOldAmount";
            this.colOldAmount.Visible = true;
            this.colOldAmount.VisibleIndex = 4;
            // 
            // ClientServicePaymentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 499);
            this.Controls.Add(this.checkEditLastDateCount);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.buttonEditClients);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSaleInvoice);
            this.Controls.Add(this.gridControlReport);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit1);
            this.Name = "ClientServicePaymentReportForm";
            this.Text = "Müştəri Servis Borcları";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UcClientServicePaymentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClients.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLastDateCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControlReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReport;
        private DevExpress.XtraGrid.Columns.GridColumn colClientCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraEditors.SimpleButton btnSaleInvoice;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.ButtonEdit buttonEditClients;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraEditors.CheckEdit checkEditLastDateCount;
        private DevExpress.XtraGrid.Columns.GridColumn colOldAmount;
    }
}
