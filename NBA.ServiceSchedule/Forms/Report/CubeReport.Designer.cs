namespace NBA.ServiceSchedule.Forms.Report
{
    partial class CubeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CubeReport));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEditLastDatePayment = new DevExpress.XtraEditors.CheckEdit();
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
            this.pivotGridReport = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.ColClientCode = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColServiceCode = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColInstallationCount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColServiceName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColClientName = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColCancellationCount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColSeries = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColNumber = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColPreviousCount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.ColLastCount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCreatorUser = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPaymentAmount = new DevExpress.XtraPivotGrid.PivotGridField();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.colClientGroupName = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLastDatePayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServicesFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSelectedClientCodes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.checkEditLastDatePayment);
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
            this.panelControl1.Size = new System.Drawing.Size(890, 100);
            this.panelControl1.TabIndex = 1;
            // 
            // checkEditLastDatePayment
            // 
            this.checkEditLastDatePayment.Location = new System.Drawing.Point(634, 15);
            this.checkEditLastDatePayment.Name = "checkEditLastDatePayment";
            this.checkEditLastDatePayment.Properties.Caption = "Son tarix borcu";
            this.checkEditLastDatePayment.Size = new System.Drawing.Size(117, 19);
            this.checkEditLastDatePayment.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.Khaki;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Location = new System.Drawing.Point(757, 11);
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
            // pivotGridReport
            // 
            this.pivotGridReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pivotGridReport.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.ColClientCode,
            this.ColServiceCode,
            this.ColInstallationCount,
            this.ColServiceName,
            this.ColClientName,
            this.ColDate,
            this.ColCancellationCount,
            this.ColSeries,
            this.ColNumber,
            this.ColPreviousCount,
            this.ColLastCount,
            this.colCreatorUser,
            this.colPaymentAmount,
            this.colClientGroupName});
            this.pivotGridReport.Location = new System.Drawing.Point(12, 131);
            this.pivotGridReport.Name = "pivotGridReport";
            this.pivotGridReport.Size = new System.Drawing.Size(890, 308);
            this.pivotGridReport.TabIndex = 2;
            // 
            // ColClientCode
            // 
            this.ColClientCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.ColClientCode.AreaIndex = 0;
            this.ColClientCode.Caption = "Cari Kodu";
            this.ColClientCode.FieldName = "ClientCode";
            this.ColClientCode.Name = "ColClientCode";
            // 
            // ColServiceCode
            // 
            this.ColServiceCode.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.ColServiceCode.AreaIndex = 3;
            this.ColServiceCode.Caption = "Servis Kodu";
            this.ColServiceCode.FieldName = "ServiceCode";
            this.ColServiceCode.Name = "ColServiceCode";
            // 
            // ColInstallationCount
            // 
            this.ColInstallationCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.ColInstallationCount.AreaIndex = 0;
            this.ColInstallationCount.Caption = "Quraşdırılma sayı";
            this.ColInstallationCount.FieldName = "InstallationCount";
            this.ColInstallationCount.Name = "ColInstallationCount";
            // 
            // ColServiceName
            // 
            this.ColServiceName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.ColServiceName.AreaIndex = 4;
            this.ColServiceName.Caption = "Servis Adı";
            this.ColServiceName.FieldName = "ServiceName";
            this.ColServiceName.Name = "ColServiceName";
            // 
            // ColClientName
            // 
            this.ColClientName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.ColClientName.AreaIndex = 1;
            this.ColClientName.Caption = "Cari Adı";
            this.ColClientName.FieldName = "ClientName";
            this.ColClientName.Name = "ColClientName";
            // 
            // ColDate
            // 
            this.ColDate.AreaIndex = 0;
            this.ColDate.Caption = "Tarix";
            this.ColDate.FieldName = "Date";
            this.ColDate.Name = "ColDate";
            // 
            // ColCancellationCount
            // 
            this.ColCancellationCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.ColCancellationCount.AreaIndex = 1;
            this.ColCancellationCount.Caption = "Ləğv sayı";
            this.ColCancellationCount.FieldName = "CancellationCount";
            this.ColCancellationCount.Name = "ColCancellationCount";
            // 
            // ColSeries
            // 
            this.ColSeries.AreaIndex = 1;
            this.ColSeries.Caption = "Seriya";
            this.ColSeries.FieldName = "Series";
            this.ColSeries.Name = "ColSeries";
            // 
            // ColNumber
            // 
            this.ColNumber.AreaIndex = 2;
            this.ColNumber.Caption = "No";
            this.ColNumber.FieldName = "Number";
            this.ColNumber.Name = "ColNumber";
            // 
            // ColPreviousCount
            // 
            this.ColPreviousCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.ColPreviousCount.AreaIndex = 2;
            this.ColPreviousCount.Caption = "Ilkin Say";
            this.ColPreviousCount.FieldName = "PreviousCount";
            this.ColPreviousCount.Name = "ColPreviousCount";
            // 
            // ColLastCount
            // 
            this.ColLastCount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.ColLastCount.AreaIndex = 3;
            this.ColLastCount.Caption = "Son Say";
            this.ColLastCount.FieldName = "LastCount";
            this.ColLastCount.Name = "ColLastCount";
            // 
            // colCreatorUser
            // 
            this.colCreatorUser.AreaIndex = 3;
            this.colCreatorUser.Caption = "İstifadəçi";
            this.colCreatorUser.FieldName = "CreatorUser";
            this.colCreatorUser.Name = "colCreatorUser";
            // 
            // colPaymentAmount
            // 
            this.colPaymentAmount.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colPaymentAmount.AreaIndex = 5;
            this.colPaymentAmount.Caption = "Ödəmə məbləği";
            this.colPaymentAmount.FieldName = "ClientServicePayment";
            this.colPaymentAmount.Name = "colPaymentAmount";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToExcel.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnExportToExcel.Appearance.Options.UseBackColor = true;
            this.btnExportToExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.ImageOptions.Image")));
            this.btnExportToExcel.Location = new System.Drawing.Point(27, 445);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(81, 26);
            this.btnExportToExcel.TabIndex = 5;
            this.btnExportToExcel.Text = "Export";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // colClientGroupName
            // 
            this.colClientGroupName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colClientGroupName.AreaIndex = 2;
            this.colClientGroupName.Caption = "Cari Qrup Adi";
            this.colClientGroupName.FieldName = "ClientGroupName";
            this.colClientGroupName.Name = "colClientGroupName";
            // 
            // CubeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 489);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.pivotGridReport);
            this.Controls.Add(this.panelControl1);
            this.Name = "CubeReport";
            this.Text = "Kub Hesabatı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLastDatePayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServicesFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditSelectedClientCodes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
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
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridReport;
        private DevExpress.XtraPivotGrid.PivotGridField ColClientCode;
        private DevExpress.XtraPivotGrid.PivotGridField ColServiceCode;
        private DevExpress.XtraPivotGrid.PivotGridField ColInstallationCount;
        private DevExpress.XtraPivotGrid.PivotGridField ColServiceName;
        private DevExpress.XtraPivotGrid.PivotGridField ColClientName;
        private DevExpress.XtraPivotGrid.PivotGridField ColDate;
        private DevExpress.XtraPivotGrid.PivotGridField ColCancellationCount;
        private DevExpress.XtraPivotGrid.PivotGridField ColSeries;
        private DevExpress.XtraPivotGrid.PivotGridField ColNumber;
        private DevExpress.XtraPivotGrid.PivotGridField ColPreviousCount;
        private DevExpress.XtraPivotGrid.PivotGridField ColLastCount;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraPivotGrid.PivotGridField colCreatorUser;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraEditors.CheckEdit checkEditLastDatePayment;
        private DevExpress.XtraPivotGrid.PivotGridField colPaymentAmount;
        private DevExpress.XtraPivotGrid.PivotGridField colClientGroupName;
    }
}