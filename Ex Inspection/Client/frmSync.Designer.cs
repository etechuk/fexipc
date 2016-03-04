namespace Client
{
    partial class frmSync
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
            this.components = new System.ComponentModel.Container();
            this.cpMain = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.btnSync = new DevComponents.DotNetBar.ButtonX();
            this.lbxDevice = new System.Windows.Forms.ListBox();
            this.lblSerial = new DevComponents.DotNetBar.LabelX();
            this.bwSQLite = new System.ComponentModel.BackgroundWorker();
            this.bwAndroid = new System.ComponentModel.BackgroundWorker();
            this.lblDeviceSerial = new DevComponents.DotNetBar.LabelX();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // cpMain
            // 
            this.cpMain.AnimationSpeed = 125;
            this.cpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.cpMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpMain.FocusCuesEnabled = false;
            this.cpMain.Location = new System.Drawing.Point(138, 98);
            this.cpMain.Name = "cpMain";
            this.cpMain.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(159)))));
            this.cpMain.Size = new System.Drawing.Size(128, 128);
            this.cpMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpMain.TabIndex = 14;
            this.cpMain.Value = 80;
            // 
            // btnSync
            // 
            this.btnSync.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSync.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnSync.Enabled = false;
            this.btnSync.EnableMarkup = false;
            this.btnSync.FocusCuesEnabled = false;
            this.btnSync.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.Location = new System.Drawing.Point(153, 280);
            this.btnSync.Name = "btnSync";
            this.btnSync.ShowSubItems = false;
            this.btnSync.Size = new System.Drawing.Size(98, 33);
            this.btnSync.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSync.TabIndex = 1;
            this.btnSync.TabStop = false;
            this.btnSync.Text = "Synchronise";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lbxDevice
            // 
            this.lbxDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbxDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxDevice.Enabled = false;
            this.lbxDevice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxDevice.ForeColor = System.Drawing.Color.Black;
            this.lbxDevice.FormattingEnabled = true;
            this.lbxDevice.Location = new System.Drawing.Point(12, 38);
            this.lbxDevice.Name = "lbxDevice";
            this.lbxDevice.Size = new System.Drawing.Size(381, 236);
            this.lbxDevice.TabIndex = 0;
            this.lbxDevice.TabStop = false;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblSerial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.ForeColor = System.Drawing.Color.Black;
            this.lblSerial.Location = new System.Drawing.Point(12, 12);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(78, 20);
            this.lblSerial.TabIndex = 11;
            this.lblSerial.Text = "Device Serial:";
            // 
            // bwSQLite
            // 
            this.bwSQLite.WorkerSupportsCancellation = true;
            this.bwSQLite.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSQLite_DoWork);
            this.bwSQLite.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSQLite_RunWorkerCompleted);
            // 
            // bwAndroid
            // 
            this.bwAndroid.WorkerSupportsCancellation = true;
            this.bwAndroid.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAndroid_DoWork);
            this.bwAndroid.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAndroid_RunWorkerCompleted);
            // 
            // lblDeviceSerial
            // 
            this.lblDeviceSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblDeviceSerial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDeviceSerial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceSerial.ForeColor = System.Drawing.Color.Black;
            this.lblDeviceSerial.Location = new System.Drawing.Point(96, 12);
            this.lblDeviceSerial.Name = "lblDeviceSerial";
            this.lblDeviceSerial.Size = new System.Drawing.Size(297, 20);
            this.lblDeviceSerial.TabIndex = 15;
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmSync
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(404, 325);
            this.Controls.Add(this.cpMain);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lbxDevice);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblDeviceSerial);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSync";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Synchronise Device";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSync_FormClosed);
            this.Shown += new System.EventHandler(this.frmSync_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.CircularProgress cpMain;
        private DevComponents.DotNetBar.ButtonX btnSync;
        private System.Windows.Forms.ListBox lbxDevice;
        private DevComponents.DotNetBar.LabelX lblSerial;
        private System.ComponentModel.BackgroundWorker bwSQLite;
        private System.ComponentModel.BackgroundWorker bwAndroid;
        private DevComponents.DotNetBar.LabelX lblDeviceSerial;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}