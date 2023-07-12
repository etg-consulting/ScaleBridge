namespace ETG.ScaleBridge
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            lblDevicee = new Label();
            txtDevice = new TextBox();
            txtStaus = new TextBox();
            lblStatus = new Label();
            txtWeight = new TextBox();
            lblWeight = new Label();
            txtUnit = new TextBox();
            lblUnit = new Label();
            btnSelect = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblDevicee
            // 
            lblDevicee.AutoSize = true;
            lblDevicee.Location = new Point(12, 9);
            lblDevicee.Name = "lblDevicee";
            lblDevicee.Size = new Size(42, 15);
            lblDevicee.TabIndex = 0;
            lblDevicee.Text = "Device";
            // 
            // txtDevice
            // 
            txtDevice.BackColor = SystemColors.Window;
            txtDevice.Location = new Point(12, 27);
            txtDevice.Name = "txtDevice";
            txtDevice.ReadOnly = true;
            txtDevice.Size = new Size(360, 23);
            txtDevice.TabIndex = 1;
            txtDevice.TabStop = false;
            // 
            // txtStaus
            // 
            txtStaus.BackColor = SystemColors.Window;
            txtStaus.Location = new Point(12, 78);
            txtStaus.Name = "txtStaus";
            txtStaus.ReadOnly = true;
            txtStaus.Size = new Size(230, 23);
            txtStaus.TabIndex = 3;
            txtStaus.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status";
            // 
            // txtWeight
            // 
            txtWeight.BackColor = SystemColors.Window;
            txtWeight.Location = new Point(248, 78);
            txtWeight.Name = "txtWeight";
            txtWeight.ReadOnly = true;
            txtWeight.Size = new Size(89, 23);
            txtWeight.TabIndex = 5;
            txtWeight.TabStop = false;
            txtWeight.TextAlign = HorizontalAlignment.Right;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(248, 60);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(45, 15);
            lblWeight.TabIndex = 4;
            lblWeight.Text = "Weight";
            // 
            // txtUnit
            // 
            txtUnit.BackColor = SystemColors.Window;
            txtUnit.Location = new Point(343, 78);
            txtUnit.Name = "txtUnit";
            txtUnit.ReadOnly = true;
            txtUnit.Size = new Size(29, 23);
            txtUnit.TabIndex = 7;
            txtUnit.TabStop = false;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(343, 60);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(29, 15);
            lblUnit.TabIndex = 6;
            lblUnit.Text = "Unit";
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(216, 116);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 23);
            btnSelect.TabIndex = 8;
            btnSelect.TabStop = false;
            btnSelect.Text = "Devices";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += BtnSelect_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(297, 116);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 9;
            btnClose.TabStop = false;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(384, 151);
            Controls.Add(btnClose);
            Controls.Add(btnSelect);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(txtWeight);
            Controls.Add(lblWeight);
            Controls.Add(txtStaus);
            Controls.Add(lblStatus);
            Controls.Add(txtDevice);
            Controls.Add(lblDevicee);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSettings";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Scale Bridge Settings ";
            TopMost = true;
            Load += FormSettings_Load;
            VisibleChanged += FormSettings_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDevicee;
        private TextBox txtDevice;
        private TextBox txtStaus;
        private Label lblStatus;
        private TextBox txtWeight;
        private Label lblWeight;
        private TextBox txtUnit;
        private Label lblUnit;
        private Button btnSelect;
        private Button btnClose;
    }
}