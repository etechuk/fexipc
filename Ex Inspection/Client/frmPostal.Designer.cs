namespace Client
{
    partial class frmPostal
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
            this.txtLine1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLine1 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtLine2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLine2 = new DevComponents.DotNetBar.LabelX();
            this.txtLine3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblLine3 = new DevComponents.DotNetBar.LabelX();
            this.txtTown = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTown = new DevComponents.DotNetBar.LabelX();
            this.txtCounty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCounty = new DevComponents.DotNetBar.LabelX();
            this.txtPostcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPostcode = new DevComponents.DotNetBar.LabelX();
            this.lblCountry = new DevComponents.DotNetBar.LabelX();
            this.cbxCountry = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // txtLine1
            // 
            this.txtLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLine1.Border.Class = "TextBoxBorder";
            this.txtLine1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLine1.DisabledBackColor = System.Drawing.Color.White;
            this.txtLine1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLine1.ForeColor = System.Drawing.Color.Black;
            this.txtLine1.Location = new System.Drawing.Point(128, 20);
            this.txtLine1.Margin = new System.Windows.Forms.Padding(4);
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.PreventEnterBeep = true;
            this.txtLine1.Size = new System.Drawing.Size(294, 25);
            this.txtLine1.TabIndex = 1;
            // 
            // lblLine1
            // 
            this.lblLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblLine1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLine1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLine1.ForeColor = System.Drawing.Color.Black;
            this.lblLine1.Location = new System.Drawing.Point(12, 18);
            this.lblLine1.Margin = new System.Windows.Forms.Padding(4);
            this.lblLine1.Name = "lblLine1";
            this.lblLine1.Size = new System.Drawing.Size(109, 28);
            this.lblLine1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblLine1.TabIndex = 330;
            this.lblLine1.Text = "Line 1:";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(330, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 34);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 8;
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
            this.btnCancel.Location = new System.Drawing.Point(12, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 34);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtLine2
            // 
            this.txtLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLine2.Border.Class = "TextBoxBorder";
            this.txtLine2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLine2.DisabledBackColor = System.Drawing.Color.White;
            this.txtLine2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLine2.ForeColor = System.Drawing.Color.Black;
            this.txtLine2.Location = new System.Drawing.Point(128, 51);
            this.txtLine2.Margin = new System.Windows.Forms.Padding(4);
            this.txtLine2.Name = "txtLine2";
            this.txtLine2.PreventEnterBeep = true;
            this.txtLine2.Size = new System.Drawing.Size(294, 25);
            this.txtLine2.TabIndex = 2;
            // 
            // lblLine2
            // 
            this.lblLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblLine2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLine2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLine2.ForeColor = System.Drawing.Color.Black;
            this.lblLine2.Location = new System.Drawing.Point(13, 49);
            this.lblLine2.Margin = new System.Windows.Forms.Padding(4);
            this.lblLine2.Name = "lblLine2";
            this.lblLine2.Size = new System.Drawing.Size(109, 28);
            this.lblLine2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblLine2.TabIndex = 332;
            this.lblLine2.Text = "Line 2:";
            // 
            // txtLine3
            // 
            this.txtLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLine3.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtLine3.Border.Class = "TextBoxBorder";
            this.txtLine3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLine3.DisabledBackColor = System.Drawing.Color.White;
            this.txtLine3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtLine3.ForeColor = System.Drawing.Color.Black;
            this.txtLine3.Location = new System.Drawing.Point(128, 82);
            this.txtLine3.Margin = new System.Windows.Forms.Padding(4);
            this.txtLine3.Name = "txtLine3";
            this.txtLine3.PreventEnterBeep = true;
            this.txtLine3.Size = new System.Drawing.Size(294, 25);
            this.txtLine3.TabIndex = 3;
            // 
            // lblLine3
            // 
            this.lblLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblLine3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLine3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLine3.ForeColor = System.Drawing.Color.Black;
            this.lblLine3.Location = new System.Drawing.Point(13, 80);
            this.lblLine3.Margin = new System.Windows.Forms.Padding(4);
            this.lblLine3.Name = "lblLine3";
            this.lblLine3.Size = new System.Drawing.Size(109, 28);
            this.lblLine3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblLine3.TabIndex = 334;
            this.lblLine3.Text = "Line 3:";
            // 
            // txtTown
            // 
            this.txtTown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTown.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTown.Border.Class = "TextBoxBorder";
            this.txtTown.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTown.DisabledBackColor = System.Drawing.Color.White;
            this.txtTown.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTown.ForeColor = System.Drawing.Color.Black;
            this.txtTown.Location = new System.Drawing.Point(128, 113);
            this.txtTown.Margin = new System.Windows.Forms.Padding(4);
            this.txtTown.Name = "txtTown";
            this.txtTown.PreventEnterBeep = true;
            this.txtTown.Size = new System.Drawing.Size(294, 25);
            this.txtTown.TabIndex = 4;
            // 
            // lblTown
            // 
            this.lblTown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblTown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTown.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTown.ForeColor = System.Drawing.Color.Black;
            this.lblTown.Location = new System.Drawing.Point(13, 111);
            this.lblTown.Margin = new System.Windows.Forms.Padding(4);
            this.lblTown.Name = "lblTown";
            this.lblTown.Size = new System.Drawing.Size(109, 28);
            this.lblTown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblTown.TabIndex = 336;
            this.lblTown.Text = "Town/City:";
            // 
            // txtCounty
            // 
            this.txtCounty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCounty.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCounty.Border.Class = "TextBoxBorder";
            this.txtCounty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCounty.DisabledBackColor = System.Drawing.Color.White;
            this.txtCounty.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCounty.ForeColor = System.Drawing.Color.Black;
            this.txtCounty.Location = new System.Drawing.Point(128, 144);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(4);
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.PreventEnterBeep = true;
            this.txtCounty.Size = new System.Drawing.Size(294, 25);
            this.txtCounty.TabIndex = 5;
            // 
            // lblCounty
            // 
            this.lblCounty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblCounty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCounty.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCounty.ForeColor = System.Drawing.Color.Black;
            this.lblCounty.Location = new System.Drawing.Point(13, 142);
            this.lblCounty.Margin = new System.Windows.Forms.Padding(4);
            this.lblCounty.Name = "lblCounty";
            this.lblCounty.Size = new System.Drawing.Size(109, 28);
            this.lblCounty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCounty.TabIndex = 338;
            this.lblCounty.Text = "County/Region:";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostcode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPostcode.Border.Class = "TextBoxBorder";
            this.txtPostcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPostcode.DisabledBackColor = System.Drawing.Color.White;
            this.txtPostcode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPostcode.ForeColor = System.Drawing.Color.Black;
            this.txtPostcode.Location = new System.Drawing.Point(128, 175);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.PreventEnterBeep = true;
            this.txtPostcode.Size = new System.Drawing.Size(120, 25);
            this.txtPostcode.TabIndex = 6;
            // 
            // lblPostcode
            // 
            this.lblPostcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblPostcode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPostcode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPostcode.ForeColor = System.Drawing.Color.Black;
            this.lblPostcode.Location = new System.Drawing.Point(13, 173);
            this.lblPostcode.Margin = new System.Windows.Forms.Padding(4);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(109, 28);
            this.lblPostcode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPostcode.TabIndex = 340;
            this.lblPostcode.Text = "Postcode/Zip:";
            // 
            // lblCountry
            // 
            this.lblCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblCountry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCountry.ForeColor = System.Drawing.Color.Black;
            this.lblCountry.Location = new System.Drawing.Point(13, 204);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(109, 28);
            this.lblCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCountry.TabIndex = 342;
            this.lblCountry.Text = "Country:";
            // 
            // cbxCountry
            // 
            this.cbxCountry.DisplayMember = "Text";
            this.cbxCountry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxCountry.ForeColor = System.Drawing.Color.Black;
            this.cbxCountry.FormattingEnabled = true;
            this.cbxCountry.ItemHeight = 19;
            this.cbxCountry.Location = new System.Drawing.Point(128, 206);
            this.cbxCountry.Name = "cbxCountry";
            this.cbxCountry.Size = new System.Drawing.Size(294, 25);
            this.cbxCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxCountry.TabIndex = 7;
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmPostal
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(434, 297);
            this.Controls.Add(this.cbxCountry);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.lblPostcode);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.lblCounty);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.lblTown);
            this.Controls.Add(this.txtLine3);
            this.Controls.Add(this.lblLine3);
            this.Controls.Add(this.txtLine2);
            this.Controls.Add(this.lblLine2);
            this.Controls.Add(this.txtLine1);
            this.Controls.Add(this.lblLine1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPostal";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Postal Address";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtLine1;
        private DevComponents.DotNetBar.LabelX lblLine1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLine2;
        private DevComponents.DotNetBar.LabelX lblLine2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtLine3;
        private DevComponents.DotNetBar.LabelX lblLine3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTown;
        private DevComponents.DotNetBar.LabelX lblTown;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCounty;
        private DevComponents.DotNetBar.LabelX lblCounty;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPostcode;
        private DevComponents.DotNetBar.LabelX lblPostcode;
        private DevComponents.DotNetBar.LabelX lblCountry;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxCountry;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}