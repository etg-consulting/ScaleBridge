namespace ETG.ScaleBridge
{
    partial class FormSelectDevice
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectDevice));
            listDevices = new ListBox();
            frmSelect = new Button();
            frmClose = new Button();
            SuspendLayout();
            // 
            // listDevices
            // 
            listDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listDevices.FormattingEnabled = true;
            listDevices.ItemHeight = 15;
            listDevices.Location = new Point(12, 23);
            listDevices.Name = "listDevices";
            listDevices.Size = new Size(600, 214);
            listDevices.TabIndex = 0;
            // 
            // frmSelect
            // 
            frmSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            frmSelect.Enabled = false;
            frmSelect.Location = new Point(456, 246);
            frmSelect.Name = "frmSelect";
            frmSelect.Size = new Size(75, 23);
            frmSelect.TabIndex = 1;
            frmSelect.Text = "Select";
            frmSelect.UseVisualStyleBackColor = true;
            frmSelect.Click += FrmSelect_Click;
            // 
            // frmClose
            // 
            frmClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            frmClose.Location = new Point(537, 246);
            frmClose.Name = "frmClose";
            frmClose.Size = new Size(75, 23);
            frmClose.TabIndex = 2;
            frmClose.Text = "Close";
            frmClose.UseVisualStyleBackColor = true;
            frmClose.Click += FrmClose_Click;
            // 
            // FormSelectDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = frmClose;
            ClientSize = new Size(624, 281);
            Controls.Add(frmClose);
            Controls.Add(frmSelect);
            Controls.Add(listDevices);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSelectDevice";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Device";
            TopMost = true;
            Load += FormSelectDevice_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listDevices;
        private Button frmSelect;
        private Button frmClose;
    }
}