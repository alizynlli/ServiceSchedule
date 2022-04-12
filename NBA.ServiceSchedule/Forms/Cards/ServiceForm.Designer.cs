namespace NBA.ServiceSchedule.Forms.Cards
{
    partial class ServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEditServiceCode = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEditServiceName = new DevExpress.XtraEditors.ButtonEdit();
            this.txtMonthlyPaymentAmount = new DevExpress.XtraEditors.TextEdit();
            this.txtDailyPaymentAmount = new DevExpress.XtraEditors.TextEdit();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServiceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServiceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthlyPaymentAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDailyPaymentAmount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servis kodu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Günlük xidmət haqqı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(362, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Aylıq xidmət haqqı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Servis adı:";
            // 
            // buttonEditServiceCode
            // 
            this.buttonEditServiceCode.Location = new System.Drawing.Point(120, 36);
            this.buttonEditServiceCode.Name = "buttonEditServiceCode";
            this.buttonEditServiceCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditServiceCode.Size = new System.Drawing.Size(107, 20);
            this.buttonEditServiceCode.TabIndex = 4;
            this.buttonEditServiceCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditService_ButtonClick);
            this.buttonEditServiceCode.Leave += new System.EventHandler(this.buttonEditServiceCode_Leave);
            // 
            // buttonEditServiceName
            // 
            this.buttonEditServiceName.Location = new System.Drawing.Point(120, 65);
            this.buttonEditServiceName.Name = "buttonEditServiceName";
            this.buttonEditServiceName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditServiceName.Size = new System.Drawing.Size(183, 20);
            this.buttonEditServiceName.TabIndex = 5;
            this.buttonEditServiceName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditService_ButtonClick);
            // 
            // txtMonthlyPaymentAmount
            // 
            this.txtMonthlyPaymentAmount.Location = new System.Drawing.Point(493, 36);
            this.txtMonthlyPaymentAmount.Name = "txtMonthlyPaymentAmount";
            this.txtMonthlyPaymentAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMonthlyPaymentAmount.Size = new System.Drawing.Size(100, 20);
            this.txtMonthlyPaymentAmount.TabIndex = 10;
            // 
            // txtDailyPaymentAmount
            // 
            this.txtDailyPaymentAmount.Location = new System.Drawing.Point(493, 65);
            this.txtDailyPaymentAmount.Name = "txtDailyPaymentAmount";
            this.txtDailyPaymentAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDailyPaymentAmount.Size = new System.Drawing.Size(100, 20);
            this.txtDailyPaymentAmount.TabIndex = 11;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Appearance.BackColor = System.Drawing.Color.RosyBrown;
            this.btnRemove.Appearance.Options.UseBackColor = true;
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.Location = new System.Drawing.Point(543, 248);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 38);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Sil";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(357, 248);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 38);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "Yeni";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(446, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 38);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Yadda saxla";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 307);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDailyPaymentAmount);
            this.Controls.Add(this.txtMonthlyPaymentAmount);
            this.Controls.Add(this.buttonEditServiceName);
            this.Controls.Add(this.buttonEditServiceCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(662, 346);
            this.MinimumSize = new System.Drawing.Size(662, 346);
            this.Name = "ServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servis Kartı";
            this.Load += new System.EventHandler(this.ServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServiceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditServiceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonthlyPaymentAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDailyPaymentAmount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.ButtonEdit buttonEditServiceCode;
        private DevExpress.XtraEditors.ButtonEdit buttonEditServiceName;
        private DevExpress.XtraEditors.TextEdit txtMonthlyPaymentAmount;
        private DevExpress.XtraEditors.TextEdit txtDailyPaymentAmount;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}
