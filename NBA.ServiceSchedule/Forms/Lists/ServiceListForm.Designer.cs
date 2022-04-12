namespace NBA.ServiceSchedule.Forms.Lists
{
    partial class ServiceListForm
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
            this.colServiceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthlyPaymentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyPaymentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colServiceCode,
            this.colServiceName,
            this.colMonthlyPaymentAmount,
            this.colDailyPaymentAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colServiceCode
            // 
            this.colServiceCode.Caption = "Servis kodu";
            this.colServiceCode.FieldName = "Code";
            this.colServiceCode.Name = "colServiceCode";
            this.colServiceCode.OptionsColumn.ReadOnly = true;
            this.colServiceCode.Visible = true;
            this.colServiceCode.VisibleIndex = 0;
            // 
            // colServiceName
            // 
            this.colServiceName.Caption = "Servis adi";
            this.colServiceName.FieldName = "ServiceName";
            this.colServiceName.Name = "colServiceName";
            this.colServiceName.OptionsColumn.ReadOnly = true;
            this.colServiceName.Visible = true;
            this.colServiceName.VisibleIndex = 1;
            // 
            // colMonthlyPaymentAmount
            // 
            this.colMonthlyPaymentAmount.Caption = "Ayliq xidmet haqqi";
            this.colMonthlyPaymentAmount.FieldName = "MonthlyPaymentAmount";
            this.colMonthlyPaymentAmount.Name = "colMonthlyPaymentAmount";
            this.colMonthlyPaymentAmount.OptionsColumn.ReadOnly = true;
            this.colMonthlyPaymentAmount.Visible = true;
            this.colMonthlyPaymentAmount.VisibleIndex = 2;
            // 
            // colDailyPaymentAmount
            // 
            this.colDailyPaymentAmount.Caption = "Gunluk xidmet haqqi";
            this.colDailyPaymentAmount.FieldName = "DailyPaymentAmount";
            this.colDailyPaymentAmount.Name = "colDailyPaymentAmount";
            this.colDailyPaymentAmount.OptionsColumn.ReadOnly = true;
            this.colDailyPaymentAmount.Visible = true;
            this.colDailyPaymentAmount.VisibleIndex = 3;
            // 
            // ServiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControl1);
            this.Name = "ServiceListForm";
            this.Text = "ServiceListForm";
            this.Load += new System.EventHandler(this.ServiceListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceCode;
        private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyPaymentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyPaymentAmount;
    }
}