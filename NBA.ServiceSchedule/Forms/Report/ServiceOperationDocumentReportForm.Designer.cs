namespace NBA.ServiceSchedule.Forms.Report
{
    partial class ServiceOperationDocumentReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceOperationDocumentReportForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearServiceFilter = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEditServicesFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.btnClearClientFilter = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.buttonEditSelectedClientCodes = new DevExpress.XtraEditors.ButtonEdit();
            this.dateEditLastDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFirstDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeries = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPreviousCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInstallationCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCancellationCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatorUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.colClientGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServicesFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSelectedClientCodes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnClearServiceFilter);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.buttonEditServicesFilter);
            this.panelControl1.Controls.Add(this.btnClearClientFilter);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.buttonEditSelectedClientCodes);
            this.panelControl1.Controls.Add(this.dateEditLastDate);
            this.panelControl1.Controls.Add(this.dateEditFirstDate);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(741, 100);
            this.panelControl1.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Khaki;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Location = new System.Drawing.Point(644, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Yenilə";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClearServiceFilter
            // 
            this.btnClearServiceFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClearServiceFilter.ImageOptions.Image")));
            this.btnClearServiceFilter.Location = new System.Drawing.Point(587, 38);
            this.btnClearServiceFilter.Name = "btnClearServiceFilter";
            this.btnClearServiceFilter.Size = new System.Drawing.Size(24, 22);
            this.btnClearServiceFilter.TabIndex = 9;
            this.btnClearServiceFilter.ToolTip = "Filteri təmizlə";
            this.btnClearServiceFilter.Click += new System.EventHandler(this.btnClearServiceFilter_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(238, 43);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Servislər:";
            // 
            // buttonEditServicesFilter
            // 
            this.buttonEditServicesFilter.Location = new System.Drawing.Point(323, 40);
            this.buttonEditServicesFilter.Name = "buttonEditServicesFilter";
            this.buttonEditServicesFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditServicesFilter.Properties.ReadOnly = true;
            this.buttonEditServicesFilter.Size = new System.Drawing.Size(258, 20);
            this.buttonEditServicesFilter.TabIndex = 7;
            this.buttonEditServicesFilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditServicesFilter_ButtonClick);
            // 
            // btnClearClientFilter
            // 
            this.btnClearClientFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClearClientFilter.ImageOptions.Image")));
            this.btnClearClientFilter.Location = new System.Drawing.Point(587, 12);
            this.btnClearClientFilter.Name = "btnClearClientFilter";
            this.btnClearClientFilter.Size = new System.Drawing.Size(24, 22);
            this.btnClearClientFilter.TabIndex = 6;
            this.btnClearClientFilter.ToolTip = "Filteri təmizlə";
            this.btnClearClientFilter.Click += new System.EventHandler(this.btnClearClientFilter_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(238, 17);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Cari hesablar:";
            // 
            // buttonEditSelectedClientCodes
            // 
            this.buttonEditSelectedClientCodes.Location = new System.Drawing.Point(323, 14);
            this.buttonEditSelectedClientCodes.Name = "buttonEditSelectedClientCodes";
            this.buttonEditSelectedClientCodes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditSelectedClientCodes.Properties.ReadOnly = true;
            this.buttonEditSelectedClientCodes.Size = new System.Drawing.Size(258, 20);
            this.buttonEditSelectedClientCodes.TabIndex = 4;
            this.buttonEditSelectedClientCodes.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditSelectedClientCodes_ButtonClick);
            // 
            // dateEditLastDate
            // 
            this.dateEditLastDate.EditValue = null;
            this.dateEditLastDate.Location = new System.Drawing.Point(80, 40);
            this.dateEditLastDate.Name = "dateEditLastDate";
            this.dateEditLastDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLastDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLastDate.Size = new System.Drawing.Size(100, 20);
            this.dateEditLastDate.TabIndex = 3;
            // 
            // dateEditFirstDate
            // 
            this.dateEditFirstDate.EditValue = null;
            this.dateEditFirstDate.Location = new System.Drawing.Point(80, 14);
            this.dateEditFirstDate.Name = "dateEditFirstDate";
            this.dateEditFirstDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFirstDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFirstDate.Size = new System.Drawing.Size(100, 20);
            this.dateEditFirstDate.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Son tarix:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "İlk tarix:";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 133);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(741, 351);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeries,
            this.colNumber,
            this.colDate,
            this.colDocumentNumber,
            this.colDocumentDate,
            this.colClientCode,
            this.colClientName,
            this.colServiceCode,
            this.colServiceName,
            this.colPreviousCount,
            this.colInstallationCount,
            this.colCancellationCount,
            this.colLastCount,
            this.colCreatorUser,
            this.colClientGroupName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", this.colPreviousCount, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", this.colInstallationCount, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", this.colCancellationCount, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", this.colSeries, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colSeries
            // 
            this.colSeries.Caption = "Seriya";
            this.colSeries.FieldName = "Series";
            this.colSeries.Name = "colSeries";
            this.colSeries.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Series", "{0}")});
            this.colSeries.Visible = true;
            this.colSeries.VisibleIndex = 0;
            this.colSeries.Width = 146;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "No";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 1;
            // 
            // colDate
            // 
            this.colDate.Caption = "Tarix";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = "Sened No";
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 3;
            this.colDocumentNumber.Width = 83;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.Caption = "Sened Tarixi";
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 4;
            this.colDocumentDate.Width = 104;
            // 
            // colClientCode
            // 
            this.colClientCode.Caption = "Cari Kodu";
            this.colClientCode.FieldName = "ClientCode";
            this.colClientCode.Name = "colClientCode";
            this.colClientCode.Visible = true;
            this.colClientCode.VisibleIndex = 6;
            this.colClientCode.Width = 125;
            // 
            // colClientName
            // 
            this.colClientName.Caption = "Cari Adi";
            this.colClientName.FieldName = "ClientName";
            this.colClientName.Name = "colClientName";
            this.colClientName.Visible = true;
            this.colClientName.VisibleIndex = 7;
            this.colClientName.Width = 146;
            // 
            // colServiceCode
            // 
            this.colServiceCode.Caption = "Servis Kodu";
            this.colServiceCode.FieldName = "ServiceCode";
            this.colServiceCode.Name = "colServiceCode";
            this.colServiceCode.Visible = true;
            this.colServiceCode.VisibleIndex = 9;
            this.colServiceCode.Width = 167;
            // 
            // colServiceName
            // 
            this.colServiceName.Caption = "Servis Adi";
            this.colServiceName.FieldName = "ServiceName";
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.Visible = true;
            this.colServiceName.VisibleIndex = 10;
            // 
            // colPreviousCount
            // 
            this.colPreviousCount.Caption = "Ilkin Sayi";
            this.colPreviousCount.FieldName = "PreviousCount";
            this.colPreviousCount.Name = "colPreviousCount";
            this.colPreviousCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PreviousCount", "SUM={0:0.##}")});
            this.colPreviousCount.Visible = true;
            this.colPreviousCount.VisibleIndex = 11;
            // 
            // colInstallationCount
            // 
            this.colInstallationCount.Caption = "Qurasdirma Sayi";
            this.colInstallationCount.FieldName = "InstallationCount";
            this.colInstallationCount.Name = "colInstallationCount";
            this.colInstallationCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InstallationCount", "SUM={0:0.##}")});
            this.colInstallationCount.Visible = true;
            this.colInstallationCount.VisibleIndex = 12;
            // 
            // colCancellationCount
            // 
            this.colCancellationCount.Caption = "Legv Sayi";
            this.colCancellationCount.FieldName = "CancellationCount";
            this.colCancellationCount.Name = "colCancellationCount";
            this.colCancellationCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CancellationCount", "SUM={0:0.##}")});
            this.colCancellationCount.Visible = true;
            this.colCancellationCount.VisibleIndex = 13;
            // 
            // colLastCount
            // 
            this.colLastCount.Caption = "Yekun Say";
            this.colLastCount.FieldName = "LastCount";
            this.colLastCount.Name = "colLastCount";
            this.colLastCount.Visible = true;
            this.colLastCount.VisibleIndex = 14;
            // 
            // colCreatorUser
            // 
            this.colCreatorUser.Caption = "İstifadəçi";
            this.colCreatorUser.FieldName = "CreatorUser";
            this.colCreatorUser.Name = "colCreatorUser";
            this.colCreatorUser.Visible = true;
            this.colCreatorUser.VisibleIndex = 5;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToExcel.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExportToExcel.Appearance.Options.UseBackColor = true;
            this.btnExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.ImageOptions.Image")));
            this.btnExportToExcel.Location = new System.Drawing.Point(27, 501);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 26);
            this.btnExportToExcel.TabIndex = 4;
            this.btnExportToExcel.Text = "Export";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // colClientGroupName
            // 
            this.colClientGroupName.Caption = "Cari Qrup Adi";
            this.colClientGroupName.FieldName = "ClientGroupName";
            this.colClientGroupName.Name = "colClientGroupName";
            this.colClientGroupName.Visible = true;
            this.colClientGroupName.VisibleIndex = 8;
            // 
            // ServiceOperationDocumentReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 552);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ServiceOperationDocumentReportForm";
            this.Text = "Servis Quraşdırılma Sənədləri";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ServiceOperationDocumentReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServicesFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSelectedClientCodes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnClearServiceFilter;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ButtonEdit buttonEditServicesFilter;
        private DevExpress.XtraEditors.SimpleButton btnClearClientFilter;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit buttonEditSelectedClientCodes;
        private DevExpress.XtraEditors.DateEdit dateEditLastDate;
        private DevExpress.XtraEditors.DateEdit dateEditFirstDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSeries;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colClientCode;
        private DevExpress.XtraGrid.Columns.GridColumn colClientName;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn colPreviousCount;
        private DevExpress.XtraGrid.Columns.GridColumn colInstallationCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCancellationCount;
        private DevExpress.XtraGrid.Columns.GridColumn colLastCount;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatorUser;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colClientGroupName;
    }
}