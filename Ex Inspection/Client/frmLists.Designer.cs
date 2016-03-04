namespace Client
{
    partial class frmLists
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
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.tc = new DevComponents.DotNetBar.SuperTabControl();
            this.tpCountry = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtCountryCode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCountryCode = new DevComponents.DotNetBar.LabelX();
            this.txtCountry = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblCountry = new DevComponents.DotNetBar.LabelX();
            this.tiCountry = new DevComponents.DotNetBar.SuperTabItem();
            this.tpFault = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtFault = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblFault = new DevComponents.DotNetBar.LabelX();
            this.tiFault = new DevComponents.DotNetBar.SuperTabItem();
            this.tpTypesProtection = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtTypesProtection = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTypesProtection = new DevComponents.DotNetBar.LabelX();
            this.tiTypesProtection = new DevComponents.DotNetBar.SuperTabItem();
            this.tpTypesDevice = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtTypesDevice = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTypesDevice = new DevComponents.DotNetBar.LabelX();
            this.tiTypesDevice = new DevComponents.DotNetBar.SuperTabItem();
            this.tpManufacturer = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtManufacturer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblManufacturer = new DevComponents.DotNetBar.LabelX();
            this.tiManufacturer = new DevComponents.DotNetBar.SuperTabItem();
            this.tpDrawing = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dtDrawingDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.lblDrawingDate = new DevComponents.DotNetBar.LabelX();
            this.txtDrawingRev = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDrawingRev = new DevComponents.DotNetBar.LabelX();
            this.txtDrawing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblDrawing = new DevComponents.DotNetBar.LabelX();
            this.tiDrawing = new DevComponents.DotNetBar.SuperTabItem();
            this.tpHacDrawing = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dtHacDrawingDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.txtHacDrawingRev = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblHacDrawingDate = new DevComponents.DotNetBar.LabelX();
            this.lblHacDrawingRev = new DevComponents.DotNetBar.LabelX();
            this.txtHacDrawing = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblHacDrawing = new DevComponents.DotNetBar.LabelX();
            this.tiHacDrawing = new DevComponents.DotNetBar.SuperTabItem();
            this.tv = new DevComponents.AdvTree.AdvTree();
            this.tvc = new DevComponents.AdvTree.ColumnHeader();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.cbxType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxiTypeCountries = new DevComponents.Editors.ComboItem();
            this.cbxiTypeDrawings = new DevComponents.Editors.ComboItem();
            this.cbxiTypeHacDrawings = new DevComponents.Editors.ComboItem();
            this.cbxiTypeManufacturers = new DevComponents.Editors.ComboItem();
            this.cbxiTypeFaults = new DevComponents.Editors.ComboItem();
            this.cbxiTypeDevices = new DevComponents.Editors.ComboItem();
            this.cbxiTypeProtections = new DevComponents.Editors.ComboItem();
            this.lblType = new DevComponents.DotNetBar.LabelX();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tc)).BeginInit();
            this.tc.SuspendLayout();
            this.tpCountry.SuspendLayout();
            this.tpFault.SuspendLayout();
            this.tpTypesProtection.SuspendLayout();
            this.tpTypesDevice.SuspendLayout();
            this.tpManufacturer.SuspendLayout();
            this.tpDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDrawingDate)).BeginInit();
            this.tpHacDrawing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtHacDrawingDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.cm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(748, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 32);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(278, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.tc.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tc.ControlBox.MenuBox.Name = "";
            this.tc.ControlBox.Name = "";
            this.tc.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tc.ControlBox.MenuBox,
            this.tc.ControlBox.CloseBox});
            this.tc.ControlBox.Visible = false;
            this.tc.Controls.Add(this.tpCountry);
            this.tc.Controls.Add(this.tpTypesProtection);
            this.tc.Controls.Add(this.tpTypesDevice);
            this.tc.Controls.Add(this.tpFault);
            this.tc.Controls.Add(this.tpManufacturer);
            this.tc.Controls.Add(this.tpHacDrawing);
            this.tc.Controls.Add(this.tpDrawing);
            this.tc.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.ForeColor = System.Drawing.Color.Black;
            this.tc.Location = new System.Drawing.Point(278, 20);
            this.tc.Name = "tc";
            this.tc.ReorderTabsEnabled = true;
            this.tc.SelectedTabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.SelectedTabIndex = 0;
            this.tc.Size = new System.Drawing.Size(543, 391);
            this.tc.TabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.TabIndex = 321;
            this.tc.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit;
            this.tc.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tiCountry,
            this.tiDrawing,
            this.tiHacDrawing,
            this.tiManufacturer,
            this.tiFault,
            this.tiTypesDevice,
            this.tiTypesProtection});
            this.tc.TabStop = false;
            this.tc.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.tc.TabVerticalSpacing = 3;
            this.tc.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.tc_SelectedTabChanged);
            // 
            // tpCountry
            // 
            this.tpCountry.Controls.Add(this.txtCountryCode);
            this.tpCountry.Controls.Add(this.lblCountryCode);
            this.tpCountry.Controls.Add(this.txtCountry);
            this.tpCountry.Controls.Add(this.lblCountry);
            this.tpCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpCountry.Location = new System.Drawing.Point(0, 54);
            this.tpCountry.Name = "tpCountry";
            this.tpCountry.Size = new System.Drawing.Size(543, 337);
            this.tpCountry.TabIndex = 1;
            this.tpCountry.TabItem = this.tiCountry;
            // 
            // txtCountryCode
            // 
            this.txtCountryCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountryCode.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCountryCode.Border.Class = "TextBoxBorder";
            this.txtCountryCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCountryCode.DisabledBackColor = System.Drawing.Color.White;
            this.txtCountryCode.Enabled = false;
            this.txtCountryCode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCountryCode.ForeColor = System.Drawing.Color.Black;
            this.txtCountryCode.Location = new System.Drawing.Point(81, 52);
            this.txtCountryCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountryCode.Name = "txtCountryCode";
            this.txtCountryCode.PreventEnterBeep = true;
            this.txtCountryCode.Size = new System.Drawing.Size(78, 25);
            this.txtCountryCode.TabIndex = 4;
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblCountryCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCountryCode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCountryCode.ForeColor = System.Drawing.Color.Black;
            this.lblCountryCode.Location = new System.Drawing.Point(16, 50);
            this.lblCountryCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(57, 28);
            this.lblCountryCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCountryCode.TabIndex = 330;
            this.lblCountryCode.Text = "Code:";
            // 
            // txtCountry
            // 
            this.txtCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCountry.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtCountry.Border.Class = "TextBoxBorder";
            this.txtCountry.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCountry.DisabledBackColor = System.Drawing.Color.White;
            this.txtCountry.Enabled = false;
            this.txtCountry.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCountry.ForeColor = System.Drawing.Color.Black;
            this.txtCountry.Location = new System.Drawing.Point(81, 21);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.PreventEnterBeep = true;
            this.txtCountry.Size = new System.Drawing.Size(445, 25);
            this.txtCountry.TabIndex = 3;
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
            this.lblCountry.Location = new System.Drawing.Point(16, 19);
            this.lblCountry.Margin = new System.Windows.Forms.Padding(4);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(57, 28);
            this.lblCountry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblCountry.TabIndex = 328;
            this.lblCountry.Text = "Name:";
            // 
            // tiCountry
            // 
            this.tiCountry.AttachedControl = this.tpCountry;
            this.tiCountry.GlobalItem = false;
            this.tiCountry.Name = "tiCountry";
            this.tiCountry.Text = "  Country";
            // 
            // tpFault
            // 
            this.tpFault.Controls.Add(this.txtFault);
            this.tpFault.Controls.Add(this.lblFault);
            this.tpFault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpFault.Location = new System.Drawing.Point(0, 54);
            this.tpFault.Name = "tpFault";
            this.tpFault.Size = new System.Drawing.Size(543, 337);
            this.tpFault.TabIndex = 0;
            this.tpFault.TabItem = this.tiFault;
            // 
            // txtFault
            // 
            this.txtFault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFault.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFault.Border.Class = "TextBoxBorder";
            this.txtFault.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFault.DisabledBackColor = System.Drawing.Color.White;
            this.txtFault.Enabled = false;
            this.txtFault.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtFault.ForeColor = System.Drawing.Color.Black;
            this.txtFault.Location = new System.Drawing.Point(81, 21);
            this.txtFault.Margin = new System.Windows.Forms.Padding(4);
            this.txtFault.Multiline = true;
            this.txtFault.Name = "txtFault";
            this.txtFault.PreventEnterBeep = true;
            this.txtFault.Size = new System.Drawing.Size(445, 85);
            this.txtFault.TabIndex = 12;
            // 
            // lblFault
            // 
            this.lblFault.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblFault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFault.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFault.ForeColor = System.Drawing.Color.Black;
            this.lblFault.Location = new System.Drawing.Point(16, 19);
            this.lblFault.Margin = new System.Windows.Forms.Padding(4);
            this.lblFault.Name = "lblFault";
            this.lblFault.Size = new System.Drawing.Size(57, 28);
            this.lblFault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblFault.TabIndex = 332;
            this.lblFault.Text = "Fault:";
            // 
            // tiFault
            // 
            this.tiFault.AttachedControl = this.tpFault;
            this.tiFault.GlobalItem = false;
            this.tiFault.Name = "tiFault";
            this.tiFault.Text = "  Fault Type";
            // 
            // tpTypesProtection
            // 
            this.tpTypesProtection.Controls.Add(this.txtTypesProtection);
            this.tpTypesProtection.Controls.Add(this.lblTypesProtection);
            this.tpTypesProtection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpTypesProtection.Location = new System.Drawing.Point(0, 54);
            this.tpTypesProtection.Name = "tpTypesProtection";
            this.tpTypesProtection.Size = new System.Drawing.Size(543, 337);
            this.tpTypesProtection.TabIndex = 0;
            this.tpTypesProtection.TabItem = this.tiTypesProtection;
            // 
            // txtTypesProtection
            // 
            this.txtTypesProtection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypesProtection.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTypesProtection.Border.Class = "TextBoxBorder";
            this.txtTypesProtection.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTypesProtection.DisabledBackColor = System.Drawing.Color.White;
            this.txtTypesProtection.Enabled = false;
            this.txtTypesProtection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTypesProtection.ForeColor = System.Drawing.Color.Black;
            this.txtTypesProtection.Location = new System.Drawing.Point(81, 21);
            this.txtTypesProtection.Margin = new System.Windows.Forms.Padding(4);
            this.txtTypesProtection.Name = "txtTypesProtection";
            this.txtTypesProtection.PreventEnterBeep = true;
            this.txtTypesProtection.Size = new System.Drawing.Size(445, 25);
            this.txtTypesProtection.TabIndex = 14;
            // 
            // lblTypesProtection
            // 
            this.lblTypesProtection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblTypesProtection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTypesProtection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTypesProtection.ForeColor = System.Drawing.Color.Black;
            this.lblTypesProtection.Location = new System.Drawing.Point(16, 19);
            this.lblTypesProtection.Margin = new System.Windows.Forms.Padding(4);
            this.lblTypesProtection.Name = "lblTypesProtection";
            this.lblTypesProtection.Size = new System.Drawing.Size(57, 28);
            this.lblTypesProtection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblTypesProtection.TabIndex = 332;
            this.lblTypesProtection.Text = "Name:";
            // 
            // tiTypesProtection
            // 
            this.tiTypesProtection.AttachedControl = this.tpTypesProtection;
            this.tiTypesProtection.GlobalItem = false;
            this.tiTypesProtection.Name = "tiTypesProtection";
            this.tiTypesProtection.Text = "  Protection Type";
            // 
            // tpTypesDevice
            // 
            this.tpTypesDevice.Controls.Add(this.txtTypesDevice);
            this.tpTypesDevice.Controls.Add(this.lblTypesDevice);
            this.tpTypesDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpTypesDevice.Location = new System.Drawing.Point(0, 54);
            this.tpTypesDevice.Name = "tpTypesDevice";
            this.tpTypesDevice.Size = new System.Drawing.Size(543, 337);
            this.tpTypesDevice.TabIndex = 0;
            this.tpTypesDevice.TabItem = this.tiTypesDevice;
            // 
            // txtTypesDevice
            // 
            this.txtTypesDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypesDevice.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTypesDevice.Border.Class = "TextBoxBorder";
            this.txtTypesDevice.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTypesDevice.DisabledBackColor = System.Drawing.Color.White;
            this.txtTypesDevice.Enabled = false;
            this.txtTypesDevice.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTypesDevice.ForeColor = System.Drawing.Color.Black;
            this.txtTypesDevice.Location = new System.Drawing.Point(81, 21);
            this.txtTypesDevice.Margin = new System.Windows.Forms.Padding(4);
            this.txtTypesDevice.Name = "txtTypesDevice";
            this.txtTypesDevice.PreventEnterBeep = true;
            this.txtTypesDevice.Size = new System.Drawing.Size(445, 25);
            this.txtTypesDevice.TabIndex = 13;
            // 
            // lblTypesDevice
            // 
            this.lblTypesDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblTypesDevice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTypesDevice.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTypesDevice.ForeColor = System.Drawing.Color.Black;
            this.lblTypesDevice.Location = new System.Drawing.Point(16, 19);
            this.lblTypesDevice.Margin = new System.Windows.Forms.Padding(4);
            this.lblTypesDevice.Name = "lblTypesDevice";
            this.lblTypesDevice.Size = new System.Drawing.Size(57, 28);
            this.lblTypesDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblTypesDevice.TabIndex = 334;
            this.lblTypesDevice.Text = "Name:";
            // 
            // tiTypesDevice
            // 
            this.tiTypesDevice.AttachedControl = this.tpTypesDevice;
            this.tiTypesDevice.GlobalItem = false;
            this.tiTypesDevice.Name = "tiTypesDevice";
            this.tiTypesDevice.Text = "  Device Type";
            // 
            // tpManufacturer
            // 
            this.tpManufacturer.Controls.Add(this.txtManufacturer);
            this.tpManufacturer.Controls.Add(this.lblManufacturer);
            this.tpManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpManufacturer.Location = new System.Drawing.Point(0, 54);
            this.tpManufacturer.Name = "tpManufacturer";
            this.tpManufacturer.Size = new System.Drawing.Size(543, 337);
            this.tpManufacturer.TabIndex = 0;
            this.tpManufacturer.TabItem = this.tiManufacturer;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManufacturer.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtManufacturer.Border.Class = "TextBoxBorder";
            this.txtManufacturer.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtManufacturer.DisabledBackColor = System.Drawing.Color.White;
            this.txtManufacturer.Enabled = false;
            this.txtManufacturer.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtManufacturer.ForeColor = System.Drawing.Color.Black;
            this.txtManufacturer.Location = new System.Drawing.Point(81, 21);
            this.txtManufacturer.Margin = new System.Windows.Forms.Padding(4);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.PreventEnterBeep = true;
            this.txtManufacturer.Size = new System.Drawing.Size(445, 25);
            this.txtManufacturer.TabIndex = 11;
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblManufacturer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblManufacturer.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblManufacturer.ForeColor = System.Drawing.Color.Black;
            this.lblManufacturer.Location = new System.Drawing.Point(16, 19);
            this.lblManufacturer.Margin = new System.Windows.Forms.Padding(4);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(57, 28);
            this.lblManufacturer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblManufacturer.TabIndex = 332;
            this.lblManufacturer.Text = "Name:";
            // 
            // tiManufacturer
            // 
            this.tiManufacturer.AttachedControl = this.tpManufacturer;
            this.tiManufacturer.GlobalItem = false;
            this.tiManufacturer.Name = "tiManufacturer";
            this.tiManufacturer.Text = "  Manufacturer";
            // 
            // tpDrawing
            // 
            this.tpDrawing.Controls.Add(this.dtDrawingDate);
            this.tpDrawing.Controls.Add(this.lblDrawingDate);
            this.tpDrawing.Controls.Add(this.txtDrawingRev);
            this.tpDrawing.Controls.Add(this.lblDrawingRev);
            this.tpDrawing.Controls.Add(this.txtDrawing);
            this.tpDrawing.Controls.Add(this.lblDrawing);
            this.tpDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpDrawing.Location = new System.Drawing.Point(0, 54);
            this.tpDrawing.Name = "tpDrawing";
            this.tpDrawing.Size = new System.Drawing.Size(543, 337);
            this.tpDrawing.TabIndex = 0;
            this.tpDrawing.TabItem = this.tiDrawing;
            // 
            // dtDrawingDate
            // 
            this.dtDrawingDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtDrawingDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtDrawingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDrawingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtDrawingDate.ButtonDropDown.Visible = true;
            this.dtDrawingDate.CustomFormat = "dd/MM/yyyy";
            this.dtDrawingDate.Enabled = false;
            this.dtDrawingDate.ForeColor = System.Drawing.Color.Black;
            this.dtDrawingDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtDrawingDate.IsPopupCalendarOpen = false;
            this.dtDrawingDate.Location = new System.Drawing.Point(81, 83);
            this.dtDrawingDate.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtDrawingDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtDrawingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDrawingDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtDrawingDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtDrawingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDrawingDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtDrawingDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtDrawingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtDrawingDate.MonthCalendar.TodayButtonVisible = true;
            this.dtDrawingDate.Name = "dtDrawingDate";
            this.dtDrawingDate.Size = new System.Drawing.Size(122, 25);
            this.dtDrawingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtDrawingDate.TabIndex = 7;
            // 
            // lblDrawingDate
            // 
            this.lblDrawingDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblDrawingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDrawingDate.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDrawingDate.ForeColor = System.Drawing.Color.Black;
            this.lblDrawingDate.Location = new System.Drawing.Point(16, 82);
            this.lblDrawingDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblDrawingDate.Name = "lblDrawingDate";
            this.lblDrawingDate.Size = new System.Drawing.Size(57, 28);
            this.lblDrawingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDrawingDate.TabIndex = 336;
            this.lblDrawingDate.Text = "Date:";
            // 
            // txtDrawingRev
            // 
            this.txtDrawingRev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDrawingRev.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDrawingRev.Border.Class = "TextBoxBorder";
            this.txtDrawingRev.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDrawingRev.DisabledBackColor = System.Drawing.Color.White;
            this.txtDrawingRev.Enabled = false;
            this.txtDrawingRev.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDrawingRev.ForeColor = System.Drawing.Color.Black;
            this.txtDrawingRev.Location = new System.Drawing.Point(81, 52);
            this.txtDrawingRev.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrawingRev.Name = "txtDrawingRev";
            this.txtDrawingRev.PreventEnterBeep = true;
            this.txtDrawingRev.Size = new System.Drawing.Size(122, 25);
            this.txtDrawingRev.TabIndex = 6;
            // 
            // lblDrawingRev
            // 
            this.lblDrawingRev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblDrawingRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDrawingRev.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDrawingRev.ForeColor = System.Drawing.Color.Black;
            this.lblDrawingRev.Location = new System.Drawing.Point(16, 50);
            this.lblDrawingRev.Margin = new System.Windows.Forms.Padding(4);
            this.lblDrawingRev.Name = "lblDrawingRev";
            this.lblDrawingRev.Size = new System.Drawing.Size(57, 28);
            this.lblDrawingRev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDrawingRev.TabIndex = 334;
            this.lblDrawingRev.Text = "Revision:";
            // 
            // txtDrawing
            // 
            this.txtDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDrawing.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDrawing.Border.Class = "TextBoxBorder";
            this.txtDrawing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDrawing.DisabledBackColor = System.Drawing.Color.White;
            this.txtDrawing.Enabled = false;
            this.txtDrawing.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDrawing.ForeColor = System.Drawing.Color.Black;
            this.txtDrawing.Location = new System.Drawing.Point(81, 21);
            this.txtDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.txtDrawing.Name = "txtDrawing";
            this.txtDrawing.PreventEnterBeep = true;
            this.txtDrawing.Size = new System.Drawing.Size(445, 25);
            this.txtDrawing.TabIndex = 5;
            // 
            // lblDrawing
            // 
            this.lblDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblDrawing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDrawing.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDrawing.ForeColor = System.Drawing.Color.Black;
            this.lblDrawing.Location = new System.Drawing.Point(16, 19);
            this.lblDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.lblDrawing.Name = "lblDrawing";
            this.lblDrawing.Size = new System.Drawing.Size(57, 28);
            this.lblDrawing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblDrawing.TabIndex = 332;
            this.lblDrawing.Text = "Name:";
            // 
            // tiDrawing
            // 
            this.tiDrawing.AttachedControl = this.tpDrawing;
            this.tiDrawing.GlobalItem = false;
            this.tiDrawing.Name = "tiDrawing";
            this.tiDrawing.Text = "  Drawing";
            // 
            // tpHacDrawing
            // 
            this.tpHacDrawing.Controls.Add(this.dtHacDrawingDate);
            this.tpHacDrawing.Controls.Add(this.txtHacDrawingRev);
            this.tpHacDrawing.Controls.Add(this.lblHacDrawingDate);
            this.tpHacDrawing.Controls.Add(this.lblHacDrawingRev);
            this.tpHacDrawing.Controls.Add(this.txtHacDrawing);
            this.tpHacDrawing.Controls.Add(this.lblHacDrawing);
            this.tpHacDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpHacDrawing.Location = new System.Drawing.Point(0, 54);
            this.tpHacDrawing.Name = "tpHacDrawing";
            this.tpHacDrawing.Size = new System.Drawing.Size(543, 337);
            this.tpHacDrawing.TabIndex = 0;
            this.tpHacDrawing.TabItem = this.tiHacDrawing;
            // 
            // dtHacDrawingDate
            // 
            this.dtHacDrawingDate.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.dtHacDrawingDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtHacDrawingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHacDrawingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtHacDrawingDate.ButtonDropDown.Visible = true;
            this.dtHacDrawingDate.CustomFormat = "dd/MM/yyyy";
            this.dtHacDrawingDate.Enabled = false;
            this.dtHacDrawingDate.ForeColor = System.Drawing.Color.Black;
            this.dtHacDrawingDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtHacDrawingDate.IsPopupCalendarOpen = false;
            this.dtHacDrawingDate.Location = new System.Drawing.Point(81, 83);
            this.dtHacDrawingDate.MaxDate = new System.DateTime(2200, 12, 31, 0, 0, 0, 0);
            this.dtHacDrawingDate.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtHacDrawingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHacDrawingDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtHacDrawingDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtHacDrawingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHacDrawingDate.MonthCalendar.DisplayMonth = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtHacDrawingDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtHacDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtHacDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtHacDrawingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtHacDrawingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtHacDrawingDate.MonthCalendar.TodayButtonVisible = true;
            this.dtHacDrawingDate.Name = "dtHacDrawingDate";
            this.dtHacDrawingDate.Size = new System.Drawing.Size(122, 25);
            this.dtHacDrawingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtHacDrawingDate.TabIndex = 10;
            // 
            // txtHacDrawingRev
            // 
            this.txtHacDrawingRev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHacDrawingRev.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtHacDrawingRev.Border.Class = "TextBoxBorder";
            this.txtHacDrawingRev.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHacDrawingRev.DisabledBackColor = System.Drawing.Color.White;
            this.txtHacDrawingRev.Enabled = false;
            this.txtHacDrawingRev.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtHacDrawingRev.ForeColor = System.Drawing.Color.Black;
            this.txtHacDrawingRev.Location = new System.Drawing.Point(81, 52);
            this.txtHacDrawingRev.Margin = new System.Windows.Forms.Padding(4);
            this.txtHacDrawingRev.Name = "txtHacDrawingRev";
            this.txtHacDrawingRev.PreventEnterBeep = true;
            this.txtHacDrawingRev.Size = new System.Drawing.Size(122, 25);
            this.txtHacDrawingRev.TabIndex = 9;
            // 
            // lblHacDrawingDate
            // 
            this.lblHacDrawingDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblHacDrawingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHacDrawingDate.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHacDrawingDate.ForeColor = System.Drawing.Color.Black;
            this.lblHacDrawingDate.Location = new System.Drawing.Point(16, 82);
            this.lblHacDrawingDate.Margin = new System.Windows.Forms.Padding(4);
            this.lblHacDrawingDate.Name = "lblHacDrawingDate";
            this.lblHacDrawingDate.Size = new System.Drawing.Size(57, 28);
            this.lblHacDrawingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblHacDrawingDate.TabIndex = 336;
            this.lblHacDrawingDate.Text = "Date:";
            // 
            // lblHacDrawingRev
            // 
            this.lblHacDrawingRev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblHacDrawingRev.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHacDrawingRev.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHacDrawingRev.ForeColor = System.Drawing.Color.Black;
            this.lblHacDrawingRev.Location = new System.Drawing.Point(16, 50);
            this.lblHacDrawingRev.Margin = new System.Windows.Forms.Padding(4);
            this.lblHacDrawingRev.Name = "lblHacDrawingRev";
            this.lblHacDrawingRev.Size = new System.Drawing.Size(57, 28);
            this.lblHacDrawingRev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblHacDrawingRev.TabIndex = 334;
            this.lblHacDrawingRev.Text = "Revision:";
            // 
            // txtHacDrawing
            // 
            this.txtHacDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHacDrawing.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtHacDrawing.Border.Class = "TextBoxBorder";
            this.txtHacDrawing.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHacDrawing.DisabledBackColor = System.Drawing.Color.White;
            this.txtHacDrawing.Enabled = false;
            this.txtHacDrawing.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtHacDrawing.ForeColor = System.Drawing.Color.Black;
            this.txtHacDrawing.Location = new System.Drawing.Point(81, 21);
            this.txtHacDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.txtHacDrawing.Name = "txtHacDrawing";
            this.txtHacDrawing.PreventEnterBeep = true;
            this.txtHacDrawing.Size = new System.Drawing.Size(445, 25);
            this.txtHacDrawing.TabIndex = 8;
            // 
            // lblHacDrawing
            // 
            this.lblHacDrawing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblHacDrawing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHacDrawing.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblHacDrawing.ForeColor = System.Drawing.Color.Black;
            this.lblHacDrawing.Location = new System.Drawing.Point(16, 19);
            this.lblHacDrawing.Margin = new System.Windows.Forms.Padding(4);
            this.lblHacDrawing.Name = "lblHacDrawing";
            this.lblHacDrawing.Size = new System.Drawing.Size(57, 28);
            this.lblHacDrawing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblHacDrawing.TabIndex = 332;
            this.lblHacDrawing.Text = "Name:";
            // 
            // tiHacDrawing
            // 
            this.tiHacDrawing.AttachedControl = this.tpHacDrawing;
            this.tiHacDrawing.GlobalItem = false;
            this.tiHacDrawing.Name = "tiHacDrawing";
            this.tiHacDrawing.Text = "  HAC Drawing";
            // 
            // tv
            // 
            this.tv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tv.AllowDrop = true;
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tv.BackgroundStyle.Class = "TreeBorderKey";
            this.tv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tv.Columns.Add(this.tvc);
            this.tv.ColumnsVisible = false;
            this.tv.ContextMenuStrip = this.cm;
            this.tv.DoubleClickTogglesNode = false;
            this.tv.DragDropEnabled = false;
            this.tv.DragDropNodeCopyEnabled = false;
            this.tv.ForeColor = System.Drawing.Color.Black;
            this.tv.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tv.GridRowLines = true;
            this.tv.HotTracking = true;
            this.tv.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.tv.Location = new System.Drawing.Point(12, 51);
            this.tv.Name = "tv";
            this.tv.NodesConnector = this.nodeConnector1;
            this.tv.NodeStyle = this.elementStyle1;
            this.tv.PathSeparator = ";";
            this.tv.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.tv.Size = new System.Drawing.Size(250, 398);
            this.tv.Styles.Add(this.elementStyle1);
            this.tv.TabIndex = 0;
            this.tv.TabStop = false;
            this.tv.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.tv_NodeClick);
            this.tv.NodeDoubleClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.tv_NodeDoubleClick);
            // 
            // tvc
            // 
            this.tvc.Editable = false;
            this.tvc.Name = "tvc";
            this.tvc.SortDirection = DevComponents.AdvTree.eSortDirection.Ascending;
            this.tvc.Text = "Items";
            this.tvc.Width.Relative = 101;
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAdd,
            this.cmRemove});
            this.cm.Name = "cm";
            this.cm.Size = new System.Drawing.Size(148, 48);
            // 
            // cmAdd
            // 
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(147, 22);
            this.cmAdd.Text = "Add entry";
            this.cmAdd.Click += new System.EventHandler(this.cmAdd_Click);
            // 
            // cmRemove
            // 
            this.cmRemove.Name = "cmRemove";
            this.cmRemove.Size = new System.Drawing.Size(147, 22);
            this.cmRemove.Text = "Remove entry";
            this.cmRemove.Click += new System.EventHandler(this.cmRemove_Click);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(135)))), ((int)(((byte)(135)))));
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.Black;
            // 
            // cbxType
            // 
            this.cbxType.DisplayMember = "Text";
            this.cbxType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbxType.ForeColor = System.Drawing.Color.Black;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.ItemHeight = 19;
            this.cbxType.Items.AddRange(new object[] {
            this.cbxiTypeCountries,
            this.cbxiTypeDrawings,
            this.cbxiTypeHacDrawings,
            this.cbxiTypeManufacturers,
            this.cbxiTypeFaults,
            this.cbxiTypeDevices,
            this.cbxiTypeProtections});
            this.cbxType.Location = new System.Drawing.Point(85, 20);
            this.cbxType.Margin = new System.Windows.Forms.Padding(4);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(177, 25);
            this.cbxType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxType.TabIndex = 0;
            this.cbxType.TabStop = false;
            this.cbxType.SelectionChangeCommitted += new System.EventHandler(this.cbxType_SelectionChangeCommitted);
            // 
            // cbxiTypeCountries
            // 
            this.cbxiTypeCountries.Text = "Countries";
            this.cbxiTypeCountries.Value = "lists_countries";
            // 
            // cbxiTypeDrawings
            // 
            this.cbxiTypeDrawings.Text = "Drawings";
            this.cbxiTypeDrawings.Value = "lists_drawings";
            // 
            // cbxiTypeHacDrawings
            // 
            this.cbxiTypeHacDrawings.Text = "HAC drawings";
            this.cbxiTypeHacDrawings.Value = "lists_drawings_hac";
            // 
            // cbxiTypeManufacturers
            // 
            this.cbxiTypeManufacturers.Text = "Manufacturers";
            this.cbxiTypeManufacturers.Value = "lists_manufacturers";
            // 
            // cbxiTypeFaults
            // 
            this.cbxiTypeFaults.Text = "Fault types";
            this.cbxiTypeFaults.Value = "lists_faults";
            // 
            // cbxiTypeDevices
            // 
            this.cbxiTypeDevices.Text = "Device types";
            this.cbxiTypeDevices.Value = "lists_types_device";
            // 
            // cbxiTypeProtections
            // 
            this.cbxiTypeProtections.Text = "Protection types";
            this.cbxiTypeProtections.Value = "lists_types_protection";
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblType.ForeColor = System.Drawing.Color.Black;
            this.lblType.Location = new System.Drawing.Point(12, 19);
            this.lblType.Margin = new System.Windows.Forms.Padding(4);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(64, 28);
            this.lblType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblType.TabIndex = 325;
            this.lblType.Text = "List Type:";
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmLists
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.tv);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLists";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Lists";
            ((System.ComponentModel.ISupportInitialize)(this.tc)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpCountry.ResumeLayout(false);
            this.tpFault.ResumeLayout(false);
            this.tpTypesProtection.ResumeLayout(false);
            this.tpTypesDevice.ResumeLayout(false);
            this.tpManufacturer.ResumeLayout(false);
            this.tpDrawing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDrawingDate)).EndInit();
            this.tpHacDrawing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtHacDrawingDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.cm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.SuperTabControl tc;
        private DevComponents.DotNetBar.SuperTabControlPanel tpCountry;
        private DevComponents.DotNetBar.SuperTabItem tiCountry;
        private DevComponents.DotNetBar.SuperTabControlPanel tpFault;
        private DevComponents.DotNetBar.SuperTabItem tiFault;
        private DevComponents.DotNetBar.SuperTabControlPanel tpManufacturer;
        private DevComponents.DotNetBar.SuperTabItem tiManufacturer;
        private DevComponents.DotNetBar.SuperTabControlPanel tpTypesProtection;
        private DevComponents.DotNetBar.SuperTabItem tiTypesProtection;
        private DevComponents.DotNetBar.SuperTabControlPanel tpDrawing;
        private DevComponents.DotNetBar.SuperTabItem tiDrawing;
        private DevComponents.DotNetBar.SuperTabControlPanel tpHacDrawing;
        private DevComponents.DotNetBar.SuperTabItem tiHacDrawing;
        private DevComponents.AdvTree.AdvTree tv;
        private DevComponents.AdvTree.ColumnHeader tvc;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxType;
        private DevComponents.DotNetBar.LabelX lblType;
        private DevComponents.Editors.ComboItem cbxiTypeCountries;
        private DevComponents.Editors.ComboItem cbxiTypeDrawings;
        private DevComponents.Editors.ComboItem cbxiTypeHacDrawings;
        private DevComponents.Editors.ComboItem cbxiTypeManufacturers;
        private DevComponents.Editors.ComboItem cbxiTypeFaults;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCountryCode;
        private DevComponents.DotNetBar.LabelX lblCountryCode;
        private DevComponents.DotNetBar.Controls.TextBoxX txtCountry;
        private DevComponents.DotNetBar.LabelX lblCountry;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem cmAdd;
        private System.Windows.Forms.ToolStripMenuItem cmRemove;
        private DevComponents.DotNetBar.LabelX lblDrawingDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDrawingRev;
        private DevComponents.DotNetBar.LabelX lblDrawingRev;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDrawing;
        private DevComponents.DotNetBar.LabelX lblDrawing;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFault;
        private DevComponents.DotNetBar.LabelX lblFault;
        private DevComponents.DotNetBar.Controls.TextBoxX txtManufacturer;
        private DevComponents.DotNetBar.LabelX lblManufacturer;
        private DevComponents.DotNetBar.LabelX lblHacDrawingDate;
        private DevComponents.DotNetBar.LabelX lblHacDrawingRev;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHacDrawing;
        private DevComponents.DotNetBar.LabelX lblHacDrawing;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTypesProtection;
        private DevComponents.DotNetBar.LabelX lblTypesProtection;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHacDrawingDate;
        private DevComponents.DotNetBar.Controls.TextBoxX txtHacDrawingRev;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtDrawingDate;
        private DevComponents.DotNetBar.StyleManager sm;
        private DevComponents.DotNetBar.SuperTabControlPanel tpTypesDevice;
        private DevComponents.DotNetBar.SuperTabItem tiTypesDevice;
        private DevComponents.Editors.ComboItem cbxiTypeDevices;
        private DevComponents.Editors.ComboItem cbxiTypeProtections;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTypesDevice;
        private DevComponents.DotNetBar.LabelX lblTypesDevice;
    }
}