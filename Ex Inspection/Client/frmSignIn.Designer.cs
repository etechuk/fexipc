namespace Client
{
    partial class frmSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSignIn));
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnSign = new DevComponents.DotNetBar.ButtonX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPass = new DevComponents.DotNetBar.LabelX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblUser = new DevComponents.DotNetBar.LabelX();
            this.lblSign = new DevComponents.DotNetBar.LabelX();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.cbxRemember = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cpSign = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.spData = new DevComponents.DotNetBar.Controls.SlidePanel();
            this.pData = new DevComponents.DotNetBar.PanelEx();
            this.btnDataSave = new DevComponents.DotNetBar.ButtonX();
            this.btnDataCancel = new DevComponents.DotNetBar.ButtonX();
            this.txtDataName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDataName = new DevComponents.DotNetBar.LabelX();
            this.txtDataPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDataPass = new DevComponents.DotNetBar.LabelX();
            this.txtDataUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDataUser = new DevComponents.DotNetBar.LabelX();
            this.txtDataPort = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDataPort = new DevComponents.DotNetBar.LabelX();
            this.txtDataHost = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDataHost = new DevComponents.DotNetBar.LabelX();
            this.lblDataInstructions = new DevComponents.DotNetBar.LabelX();
            this.lblDataHeader = new DevComponents.DotNetBar.LabelX();
            this.bwSign = new System.ComponentModel.BackgroundWorker();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.spData.SuspendLayout();
            this.pData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(12, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 31);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSign
            // 
            this.btnSign.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSign.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSign.Location = new System.Drawing.Point(237, 363);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(75, 31);
            this.btnSign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSign.TabIndex = 4;
            this.btnSign.TabStop = false;
            this.btnSign.Text = "Sign In";
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // txtPass
            // 
            this.txtPass.AutoSelectAll = true;
            this.txtPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.DisabledBackColor = System.Drawing.Color.White;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(117, 278);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(157, 25);
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // lblPass
            // 
            this.lblPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.Black;
            this.lblPass.Location = new System.Drawing.Point(46, 277);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(69, 23);
            this.lblPass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPass.TabIndex = 55;
            this.lblPass.Text = "Password:";
            // 
            // txtUser
            // 
            this.txtUser.AutoSelectAll = true;
            this.txtUser.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.DisabledBackColor = System.Drawing.Color.White;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(117, 246);
            this.txtUser.Name = "txtUser";
            this.txtUser.PreventEnterBeep = true;
            this.txtUser.Size = new System.Drawing.Size(157, 25);
            this.txtUser.TabIndex = 1;
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Black;
            this.lblUser.Location = new System.Drawing.Point(46, 245);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(69, 23);
            this.lblUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblUser.TabIndex = 54;
            this.lblUser.Text = "Username:";
            // 
            // lblSign
            // 
            this.lblSign.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblSign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSign.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.ForeColor = System.Drawing.Color.Black;
            this.lblSign.Location = new System.Drawing.Point(51, 198);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(215, 32);
            this.lblSign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSign.TabIndex = 53;
            this.lblSign.Text = "Sign into an account";
            this.lblSign.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLogo.ErrorImage = null;
            this.pbxLogo.ForeColor = System.Drawing.Color.Black;
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.ImageLocation = "";
            this.pbxLogo.InitialImage = null;
            this.pbxLogo.Location = new System.Drawing.Point(12, 8);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(300, 175);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxLogo.TabIndex = 52;
            this.pbxLogo.TabStop = false;
            // 
            // cbxRemember
            // 
            this.cbxRemember.AutoSize = true;
            this.cbxRemember.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.cbxRemember.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbxRemember.EnableMarkup = false;
            this.cbxRemember.FocusCuesEnabled = false;
            this.cbxRemember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRemember.ForeColor = System.Drawing.Color.Black;
            this.cbxRemember.Location = new System.Drawing.Point(117, 309);
            this.cbxRemember.Name = "cbxRemember";
            this.cbxRemember.Size = new System.Drawing.Size(139, 18);
            this.cbxRemember.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.cbxRemember.TabIndex = 3;
            this.cbxRemember.Text = " Remember username";
            this.cbxRemember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxRemember_KeyDown);
            // 
            // cpSign
            // 
            this.cpSign.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cpSign.AnimationSpeed = 125;
            this.cpSign.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.cpSign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cpSign.FocusCuesEnabled = false;
            this.cpSign.Location = new System.Drawing.Point(145, 359);
            this.cpSign.Name = "cpSign";
            this.cpSign.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(159)))));
            this.cpSign.Size = new System.Drawing.Size(35, 35);
            this.cpSign.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.cpSign.TabIndex = 57;
            this.cpSign.TabStop = false;
            this.cpSign.Value = 80;
            this.cpSign.Visible = false;
            // 
            // spData
            // 
            this.spData.BackColor = System.Drawing.Color.White;
            this.spData.Controls.Add(this.pData);
            this.spData.ForeColor = System.Drawing.Color.Black;
            this.spData.Location = new System.Drawing.Point(318, 8);
            this.spData.Name = "spData";
            this.spData.Size = new System.Drawing.Size(300, 386);
            this.spData.SlideOutActiveButtonSize = new System.Drawing.Size(15, 50);
            this.spData.SlideOutButtonSize = new System.Drawing.Size(10, 50);
            this.spData.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
            this.spData.TabIndex = 0;
            this.spData.TabStop = false;
            this.spData.UsesBlockingAnimation = false;
            // 
            // pData
            // 
            this.pData.CanvasColor = System.Drawing.SystemColors.Control;
            this.pData.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pData.Controls.Add(this.btnDataSave);
            this.pData.Controls.Add(this.btnDataCancel);
            this.pData.Controls.Add(this.txtDataName);
            this.pData.Controls.Add(this.lblDataName);
            this.pData.Controls.Add(this.txtDataPass);
            this.pData.Controls.Add(this.lblDataPass);
            this.pData.Controls.Add(this.txtDataUser);
            this.pData.Controls.Add(this.lblDataUser);
            this.pData.Controls.Add(this.txtDataPort);
            this.pData.Controls.Add(this.lblDataPort);
            this.pData.Controls.Add(this.txtDataHost);
            this.pData.Controls.Add(this.lblDataHost);
            this.pData.Controls.Add(this.lblDataInstructions);
            this.pData.Controls.Add(this.lblDataHeader);
            this.pData.DisabledBackColor = System.Drawing.Color.Empty;
            this.pData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pData.Location = new System.Drawing.Point(0, 0);
            this.pData.Name = "pData";
            this.pData.Size = new System.Drawing.Size(300, 386);
            this.pData.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pData.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pData.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pData.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pData.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pData.Style.GradientAngle = 90;
            this.pData.TabIndex = 0;
            // 
            // btnDataSave
            // 
            this.btnDataSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDataSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDataSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataSave.Location = new System.Drawing.Point(211, 342);
            this.btnDataSave.Name = "btnDataSave";
            this.btnDataSave.Size = new System.Drawing.Size(75, 31);
            this.btnDataSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDataSave.TabIndex = 10;
            this.btnDataSave.TabStop = false;
            this.btnDataSave.Text = "Save";
            this.btnDataSave.Click += new System.EventHandler(this.btnDataSave_Click);
            // 
            // btnDataCancel
            // 
            this.btnDataCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDataCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDataCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDataCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataCancel.Location = new System.Drawing.Point(14, 342);
            this.btnDataCancel.Name = "btnDataCancel";
            this.btnDataCancel.Size = new System.Drawing.Size(75, 31);
            this.btnDataCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDataCancel.TabIndex = 11;
            this.btnDataCancel.TabStop = false;
            this.btnDataCancel.Text = "Cancel";
            this.btnDataCancel.Click += new System.EventHandler(this.btnDataCancel_Click);
            // 
            // txtDataName
            // 
            this.txtDataName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataName.Border.Class = "TextBoxBorder";
            this.txtDataName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataName.DisabledBackColor = System.Drawing.Color.White;
            this.txtDataName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataName.ForeColor = System.Drawing.Color.Black;
            this.txtDataName.Location = new System.Drawing.Point(111, 264);
            this.txtDataName.Name = "txtDataName";
            this.txtDataName.PreventEnterBeep = true;
            this.txtDataName.Size = new System.Drawing.Size(175, 25);
            this.txtDataName.TabIndex = 9;
            this.txtDataName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataName_KeyDown);
            // 
            // lblDataName
            // 
            // 
            // 
            // 
            this.lblDataName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataName.ForeColor = System.Drawing.Color.Black;
            this.lblDataName.Location = new System.Drawing.Point(13, 263);
            this.lblDataName.Name = "lblDataName";
            this.lblDataName.Size = new System.Drawing.Size(94, 23);
            this.lblDataName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataName.TabIndex = 81;
            this.lblDataName.Text = "Database:";
            // 
            // txtDataPass
            // 
            this.txtDataPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataPass.Border.Class = "TextBoxBorder";
            this.txtDataPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataPass.DisabledBackColor = System.Drawing.Color.White;
            this.txtDataPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataPass.ForeColor = System.Drawing.Color.Black;
            this.txtDataPass.Location = new System.Drawing.Point(111, 233);
            this.txtDataPass.Name = "txtDataPass";
            this.txtDataPass.PreventEnterBeep = true;
            this.txtDataPass.Size = new System.Drawing.Size(175, 25);
            this.txtDataPass.TabIndex = 8;
            this.txtDataPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataPass_KeyDown);
            // 
            // lblDataPass
            // 
            // 
            // 
            // 
            this.lblDataPass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataPass.ForeColor = System.Drawing.Color.Black;
            this.lblDataPass.Location = new System.Drawing.Point(13, 232);
            this.lblDataPass.Name = "lblDataPass";
            this.lblDataPass.Size = new System.Drawing.Size(94, 23);
            this.lblDataPass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataPass.TabIndex = 80;
            this.lblDataPass.Text = "Password:";
            // 
            // txtDataUser
            // 
            this.txtDataUser.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataUser.Border.Class = "TextBoxBorder";
            this.txtDataUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataUser.DisabledBackColor = System.Drawing.Color.White;
            this.txtDataUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataUser.ForeColor = System.Drawing.Color.Black;
            this.txtDataUser.Location = new System.Drawing.Point(111, 202);
            this.txtDataUser.Name = "txtDataUser";
            this.txtDataUser.PreventEnterBeep = true;
            this.txtDataUser.Size = new System.Drawing.Size(175, 25);
            this.txtDataUser.TabIndex = 7;
            this.txtDataUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataUser_KeyDown);
            // 
            // lblDataUser
            // 
            // 
            // 
            // 
            this.lblDataUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataUser.ForeColor = System.Drawing.Color.Black;
            this.lblDataUser.Location = new System.Drawing.Point(13, 202);
            this.lblDataUser.Name = "lblDataUser";
            this.lblDataUser.Size = new System.Drawing.Size(94, 23);
            this.lblDataUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataUser.TabIndex = 79;
            this.lblDataUser.Text = "Username:";
            // 
            // txtDataPort
            // 
            this.txtDataPort.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataPort.Border.Class = "TextBoxBorder";
            this.txtDataPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataPort.DisabledBackColor = System.Drawing.Color.White;
            this.txtDataPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataPort.ForeColor = System.Drawing.Color.Black;
            this.txtDataPort.Location = new System.Drawing.Point(111, 171);
            this.txtDataPort.Name = "txtDataPort";
            this.txtDataPort.PreventEnterBeep = true;
            this.txtDataPort.Size = new System.Drawing.Size(175, 25);
            this.txtDataPort.TabIndex = 6;
            this.txtDataPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataPort_KeyDown);
            this.txtDataPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDataPort_KeyPress);
            // 
            // lblDataPort
            // 
            // 
            // 
            // 
            this.lblDataPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataPort.ForeColor = System.Drawing.Color.Black;
            this.lblDataPort.Location = new System.Drawing.Point(13, 170);
            this.lblDataPort.Name = "lblDataPort";
            this.lblDataPort.Size = new System.Drawing.Size(94, 23);
            this.lblDataPort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataPort.TabIndex = 78;
            this.lblDataPort.Text = "Host port:";
            // 
            // txtDataHost
            // 
            this.txtDataHost.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDataHost.Border.Class = "TextBoxBorder";
            this.txtDataHost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataHost.DisabledBackColor = System.Drawing.Color.White;
            this.txtDataHost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataHost.ForeColor = System.Drawing.Color.Black;
            this.txtDataHost.Location = new System.Drawing.Point(111, 140);
            this.txtDataHost.Name = "txtDataHost";
            this.txtDataHost.PreventEnterBeep = true;
            this.txtDataHost.Size = new System.Drawing.Size(175, 25);
            this.txtDataHost.TabIndex = 5;
            this.txtDataHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataHost_KeyDown);
            // 
            // lblDataHost
            // 
            // 
            // 
            // 
            this.lblDataHost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataHost.ForeColor = System.Drawing.Color.Black;
            this.lblDataHost.Location = new System.Drawing.Point(13, 139);
            this.lblDataHost.Name = "lblDataHost";
            this.lblDataHost.Size = new System.Drawing.Size(94, 23);
            this.lblDataHost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataHost.TabIndex = 77;
            this.lblDataHost.Text = "Host address:";
            // 
            // lblDataInstructions
            // 
            // 
            // 
            // 
            this.lblDataInstructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataInstructions.ForeColor = System.Drawing.Color.Black;
            this.lblDataInstructions.Location = new System.Drawing.Point(13, 51);
            this.lblDataInstructions.Name = "lblDataInstructions";
            this.lblDataInstructions.Size = new System.Drawing.Size(274, 72);
            this.lblDataInstructions.TabIndex = 71;
            this.lblDataInstructions.Text = "Enter the connection details for the\r\ndatabase below. To check the details\r\nwork," +
    " click the Save button.";
            this.lblDataInstructions.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblDataHeader
            // 
            // 
            // 
            // 
            this.lblDataHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDataHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataHeader.ForeColor = System.Drawing.Color.Black;
            this.lblDataHeader.Location = new System.Drawing.Point(13, 8);
            this.lblDataHeader.Name = "lblDataHeader";
            this.lblDataHeader.Size = new System.Drawing.Size(274, 23);
            this.lblDataHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDataHeader.TabIndex = 70;
            this.lblDataHeader.Text = "Database Connection Details";
            this.lblDataHeader.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // bwSign
            // 
            this.bwSign.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSign_DoWork);
            this.bwSign.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSign_RunWorkerCompleted);
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.White);
            // 
            // frmSignIn
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(324, 406);
            this.ControlBox = false;
            this.Controls.Add(this.spData);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.cbxRemember);
            this.Controls.Add(this.cpSign);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSignIn";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ex Inspection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSignIn_FormClosing);
            this.Shown += new System.EventHandler(this.frmSignIn_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.spData.ResumeLayout(false);
            this.pData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnSign;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.LabelX lblPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.LabelX lblUser;
        private DevComponents.DotNetBar.LabelX lblSign;
        private System.Windows.Forms.PictureBox pbxLogo;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbxRemember;
        private DevComponents.DotNetBar.Controls.CircularProgress cpSign;
        private DevComponents.DotNetBar.Controls.SlidePanel spData;
        private DevComponents.DotNetBar.PanelEx pData;
        private DevComponents.DotNetBar.ButtonX btnDataSave;
        private DevComponents.DotNetBar.ButtonX btnDataCancel;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataName;
        private DevComponents.DotNetBar.LabelX lblDataName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataPass;
        private DevComponents.DotNetBar.LabelX lblDataPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataUser;
        private DevComponents.DotNetBar.LabelX lblDataUser;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataPort;
        private DevComponents.DotNetBar.LabelX lblDataPort;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataHost;
        private DevComponents.DotNetBar.LabelX lblDataHost;
        private DevComponents.DotNetBar.LabelX lblDataInstructions;
        private DevComponents.DotNetBar.LabelX lblDataHeader;
        private System.ComponentModel.BackgroundWorker bwSign;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}