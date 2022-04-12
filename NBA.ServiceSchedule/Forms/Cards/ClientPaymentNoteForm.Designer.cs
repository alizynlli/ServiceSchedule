namespace NBA.ServiceSchedule.Forms.Cards
{
    partial class ClientPaymentNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientPaymentNoteForm));
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditClientName = new DevExpress.XtraEditors.ButtonEdit();
            this.buttonEditClientCode = new DevExpress.XtraEditors.ButtonEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateEditFirstDate = new DevExpress.XtraEditors.DateEdit();
            this.dateEditLastDate = new DevExpress.XtraEditors.DateEdit();
            this.btnSelectNote = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClientName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClientCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Appearance.BackColor = System.Drawing.Color.RosyBrown;
            this.btnRemove.Appearance.Options.UseBackColor = true;
            this.btnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.ImageOptions.Image")));
            this.btnRemove.Location = new System.Drawing.Point(545, 247);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 38);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "Sil";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.btnNew.Appearance.Options.UseBackColor = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(359, 247);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 38);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "Yeni";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(448, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 38);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Yadda saxla";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonEditClientName
            // 
            this.buttonEditClientName.Location = new System.Drawing.Point(129, 57);
            this.buttonEditClientName.Name = "buttonEditClientName";
            this.buttonEditClientName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditClientName.Size = new System.Drawing.Size(183, 20);
            this.buttonEditClientName.TabIndex = 23;
            this.buttonEditClientName.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditClient_ButtonClick);
            // 
            // buttonEditClientCode
            // 
            this.buttonEditClientCode.Location = new System.Drawing.Point(129, 28);
            this.buttonEditClientCode.Name = "buttonEditClientCode";
            this.buttonEditClientCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditClientCode.Size = new System.Drawing.Size(133, 20);
            this.buttonEditClientCode.TabIndex = 22;
            this.buttonEditClientCode.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditClient_ButtonClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Cari adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ilk tarix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Son tarix:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cari kodu:";
            // 
            // dateEditFirstDate
            // 
            this.dateEditFirstDate.EditValue = null;
            this.dateEditFirstDate.Location = new System.Drawing.Point(455, 28);
            this.dateEditFirstDate.Name = "dateEditFirstDate";
            this.dateEditFirstDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFirstDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFirstDate.Size = new System.Drawing.Size(100, 20);
            this.dateEditFirstDate.TabIndex = 29;
            // 
            // dateEditLastDate
            // 
            this.dateEditLastDate.EditValue = null;
            this.dateEditLastDate.Location = new System.Drawing.Point(455, 57);
            this.dateEditLastDate.Name = "dateEditLastDate";
            this.dateEditLastDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLastDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditLastDate.Size = new System.Drawing.Size(100, 20);
            this.dateEditLastDate.TabIndex = 30;
            // 
            // btnSelectNote
            // 
            this.btnSelectNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNote.Appearance.BackColor = System.Drawing.Color.Orange;
            this.btnSelectNote.Appearance.Options.UseBackColor = true;
            this.btnSelectNote.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnSelectNote.Location = new System.Drawing.Point(265, 247);
            this.btnSelectNote.Name = "btnSelectNote";
            this.btnSelectNote.Size = new System.Drawing.Size(88, 38);
            this.btnSelectNote.TabIndex = 31;
            this.btnSelectNote.Text = "Qeyd seçin";
            this.btnSelectNote.Click += new System.EventHandler(this.btnSelectNote_Click);
            // 
            // ClientPaymentNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 307);
            this.Controls.Add(this.btnSelectNote);
            this.Controls.Add(this.dateEditLastDate);
            this.Controls.Add(this.dateEditFirstDate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.buttonEditClientName);
            this.Controls.Add(this.buttonEditClientCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(662, 346);
            this.MinimumSize = new System.Drawing.Size(662, 346);
            this.Name = "ClientPaymentNoteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cari Hesab Ödəniş Qeydləri";
            this.Load += new System.EventHandler(this.ClientPaymentNoteForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClientName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditClientCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFirstDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditLastDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ButtonEdit buttonEditClientName;
        private DevExpress.XtraEditors.ButtonEdit buttonEditClientCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dateEditFirstDate;
        private DevExpress.XtraEditors.DateEdit dateEditLastDate;
        private DevExpress.XtraEditors.SimpleButton btnSelectNote;
    }
}