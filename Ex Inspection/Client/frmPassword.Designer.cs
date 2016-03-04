namespace Client
{
    partial class frmPassword
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
            this.txtPass1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPass1 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtPass2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPass2 = new DevComponents.DotNetBar.LabelX();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // txtPass1
            // 
            this.txtPass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass1.Border.Class = "TextBoxBorder";
            this.txtPass1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass1.DisabledBackColor = System.Drawing.Color.White;
            this.txtPass1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPass1.ForeColor = System.Drawing.Color.Black;
            this.txtPass1.Location = new System.Drawing.Point(142, 20);
            this.txtPass1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass1.MaxLength = 24;
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.PreventEnterBeep = true;
            this.txtPass1.Size = new System.Drawing.Size(180, 25);
            this.txtPass1.TabIndex = 1;
            this.txtPass1.UseSystemPasswordChar = true;
            this.txtPass1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass1_KeyDown);
            // 
            // lblPass1
            // 
            this.lblPass1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblPass1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPass1.ForeColor = System.Drawing.Color.Black;
            this.lblPass1.Location = new System.Drawing.Point(12, 18);
            this.lblPass1.Margin = new System.Windows.Forms.Padding(4);
            this.lblPass1.Name = "lblPass1";
            this.lblPass1.Size = new System.Drawing.Size(122, 28);
            this.lblPass1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPass1.TabIndex = 326;
            this.lblPass1.Text = "New Password:";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(230, 97);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 34);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 3;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 34);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPass2
            // 
            this.txtPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass2.Border.Class = "TextBoxBorder";
            this.txtPass2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass2.DisabledBackColor = System.Drawing.Color.White;
            this.txtPass2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPass2.ForeColor = System.Drawing.Color.Black;
            this.txtPass2.Location = new System.Drawing.Point(142, 51);
            this.txtPass2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass2.MaxLength = 24;
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.PreventEnterBeep = true;
            this.txtPass2.Size = new System.Drawing.Size(180, 25);
            this.txtPass2.TabIndex = 2;
            this.txtPass2.UseSystemPasswordChar = true;
            this.txtPass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass2_KeyDown);
            // 
            // lblPass2
            // 
            this.lblPass2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblPass2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPass2.ForeColor = System.Drawing.Color.Black;
            this.lblPass2.Location = new System.Drawing.Point(12, 49);
            this.lblPass2.Margin = new System.Windows.Forms.Padding(4);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(122, 28);
            this.lblPass2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPass2.TabIndex = 328;
            this.lblPass2.Text = "Confirm Password:";
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmPassword
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(334, 143);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.lblPass2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.lblPass1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPassword";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set/Reset Password";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtPass1;
        private DevComponents.DotNetBar.LabelX lblPass1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass2;
        private DevComponents.DotNetBar.LabelX lblPass2;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}