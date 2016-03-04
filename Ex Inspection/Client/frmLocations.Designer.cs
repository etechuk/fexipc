namespace Client
{
    partial class frmLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocations));
            this.lblSite = new DevComponents.DotNetBar.LabelX();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.lblArea = new DevComponents.DotNetBar.LabelX();
            this.lblVessel = new DevComponents.DotNetBar.LabelX();
            this.lblFloor = new DevComponents.DotNetBar.LabelX();
            this.lblGrid = new DevComponents.DotNetBar.LabelX();
            this.cbxSite = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxArea = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxVessel = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxFloor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxGrid = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnDeleteSite = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteArea = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteVessel = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteFloor = new DevComponents.DotNetBar.ButtonX();
            this.btnDeleteGrid = new DevComponents.DotNetBar.ButtonX();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnEditGrid = new DevComponents.DotNetBar.ButtonX();
            this.btnEditFloor = new DevComponents.DotNetBar.ButtonX();
            this.btnEditVessel = new DevComponents.DotNetBar.ButtonX();
            this.btnEditArea = new DevComponents.DotNetBar.ButtonX();
            this.btnEditSite = new DevComponents.DotNetBar.ButtonX();
            this.btnAddGrid = new DevComponents.DotNetBar.ButtonX();
            this.btnAddFloor = new DevComponents.DotNetBar.ButtonX();
            this.btnAddVessel = new DevComponents.DotNetBar.ButtonX();
            this.btnAddArea = new DevComponents.DotNetBar.ButtonX();
            this.btnAddSite = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblSite
            // 
            this.lblSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblSite.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSite.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSite.ForeColor = System.Drawing.Color.Black;
            this.lblSite.Location = new System.Drawing.Point(12, 18);
            this.lblSite.Margin = new System.Windows.Forms.Padding(4);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(67, 28);
            this.lblSite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSite.TabIndex = 330;
            this.lblSite.Text = "Site:";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(133, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 34);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 11;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblArea
            // 
            this.lblArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblArea.ForeColor = System.Drawing.Color.Black;
            this.lblArea.Location = new System.Drawing.Point(11, 50);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(67, 28);
            this.lblArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblArea.TabIndex = 332;
            this.lblArea.Text = "Area:";
            // 
            // lblVessel
            // 
            this.lblVessel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblVessel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblVessel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVessel.ForeColor = System.Drawing.Color.Black;
            this.lblVessel.Location = new System.Drawing.Point(11, 81);
            this.lblVessel.Margin = new System.Windows.Forms.Padding(4);
            this.lblVessel.Name = "lblVessel";
            this.lblVessel.Size = new System.Drawing.Size(67, 28);
            this.lblVessel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblVessel.TabIndex = 334;
            this.lblVessel.Text = "Vessel:";
            // 
            // lblFloor
            // 
            this.lblFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblFloor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFloor.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFloor.ForeColor = System.Drawing.Color.Black;
            this.lblFloor.Location = new System.Drawing.Point(11, 112);
            this.lblFloor.Margin = new System.Windows.Forms.Padding(4);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(67, 28);
            this.lblFloor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblFloor.TabIndex = 336;
            this.lblFloor.Text = "Floor:";
            // 
            // lblGrid
            // 
            this.lblGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblGrid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGrid.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGrid.ForeColor = System.Drawing.Color.Black;
            this.lblGrid.Location = new System.Drawing.Point(11, 143);
            this.lblGrid.Margin = new System.Windows.Forms.Padding(4);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(67, 28);
            this.lblGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblGrid.TabIndex = 338;
            this.lblGrid.Text = "Grid Ref.:";
            // 
            // cbxSite
            // 
            this.cbxSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxSite.DisplayMember = "Text";
            this.cbxSite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSite.ForeColor = System.Drawing.Color.Black;
            this.cbxSite.FormattingEnabled = true;
            this.cbxSite.ItemHeight = 19;
            this.cbxSite.Location = new System.Drawing.Point(85, 20);
            this.cbxSite.Name = "cbxSite";
            this.cbxSite.Size = new System.Drawing.Size(169, 25);
            this.cbxSite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxSite.TabIndex = 1;
            this.cbxSite.SelectionChangeCommitted += new System.EventHandler(this.cbxSite_SelectionChangeCommitted);
            // 
            // cbxArea
            // 
            this.cbxArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxArea.DisplayMember = "Text";
            this.cbxArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxArea.ForeColor = System.Drawing.Color.Black;
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.ItemHeight = 19;
            this.cbxArea.Location = new System.Drawing.Point(85, 51);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(169, 25);
            this.cbxArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxArea.TabIndex = 3;
            this.cbxArea.SelectionChangeCommitted += new System.EventHandler(this.cbxArea_SelectionChangeCommitted);
            // 
            // cbxVessel
            // 
            this.cbxVessel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVessel.DisplayMember = "Text";
            this.cbxVessel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVessel.ForeColor = System.Drawing.Color.Black;
            this.cbxVessel.FormattingEnabled = true;
            this.cbxVessel.ItemHeight = 19;
            this.cbxVessel.Location = new System.Drawing.Point(85, 82);
            this.cbxVessel.Name = "cbxVessel";
            this.cbxVessel.Size = new System.Drawing.Size(169, 25);
            this.cbxVessel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxVessel.TabIndex = 5;
            this.cbxVessel.SelectionChangeCommitted += new System.EventHandler(this.cbxVessel_SelectionChangeCommitted);
            // 
            // cbxFloor
            // 
            this.cbxFloor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFloor.DisplayMember = "Text";
            this.cbxFloor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxFloor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFloor.ForeColor = System.Drawing.Color.Black;
            this.cbxFloor.FormattingEnabled = true;
            this.cbxFloor.ItemHeight = 19;
            this.cbxFloor.Location = new System.Drawing.Point(85, 113);
            this.cbxFloor.Name = "cbxFloor";
            this.cbxFloor.Size = new System.Drawing.Size(169, 25);
            this.cbxFloor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxFloor.TabIndex = 7;
            this.cbxFloor.SelectionChangeCommitted += new System.EventHandler(this.cbxFloor_SelectionChangeCommitted);
            // 
            // cbxGrid
            // 
            this.cbxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxGrid.DisplayMember = "Text";
            this.cbxGrid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrid.ForeColor = System.Drawing.Color.Black;
            this.cbxGrid.FormattingEnabled = true;
            this.cbxGrid.ItemHeight = 19;
            this.cbxGrid.Location = new System.Drawing.Point(85, 144);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(169, 25);
            this.cbxGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxGrid.TabIndex = 9;
            this.cbxGrid.SelectionChangeCommitted += new System.EventHandler(this.cbxGrid_SelectionChangeCommitted);
            // 
            // btnDeleteSite
            // 
            this.btnDeleteSite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSite.BackColor = System.Drawing.Color.White;
            this.btnDeleteSite.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSite.FocusCuesEnabled = false;
            this.btnDeleteSite.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSite.Image")));
            this.btnDeleteSite.Location = new System.Drawing.Point(322, 20);
            this.btnDeleteSite.Name = "btnDeleteSite";
            this.btnDeleteSite.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteSite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteSite.TabIndex = 2;
            this.btnDeleteSite.TabStop = false;
            this.btnDeleteSite.Click += new System.EventHandler(this.btnDeleteSite_Click);
            // 
            // btnDeleteArea
            // 
            this.btnDeleteArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteArea.BackColor = System.Drawing.Color.White;
            this.btnDeleteArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteArea.FocusCuesEnabled = false;
            this.btnDeleteArea.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteArea.Image")));
            this.btnDeleteArea.Location = new System.Drawing.Point(322, 51);
            this.btnDeleteArea.Name = "btnDeleteArea";
            this.btnDeleteArea.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteArea.TabIndex = 4;
            this.btnDeleteArea.TabStop = false;
            this.btnDeleteArea.Click += new System.EventHandler(this.btnDeleteArea_Click);
            // 
            // btnDeleteVessel
            // 
            this.btnDeleteVessel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteVessel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteVessel.BackColor = System.Drawing.Color.White;
            this.btnDeleteVessel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteVessel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteVessel.FocusCuesEnabled = false;
            this.btnDeleteVessel.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteVessel.Image")));
            this.btnDeleteVessel.Location = new System.Drawing.Point(322, 82);
            this.btnDeleteVessel.Name = "btnDeleteVessel";
            this.btnDeleteVessel.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteVessel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteVessel.TabIndex = 6;
            this.btnDeleteVessel.TabStop = false;
            this.btnDeleteVessel.Click += new System.EventHandler(this.btnDeleteVessel_Click);
            // 
            // btnDeleteFloor
            // 
            this.btnDeleteFloor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFloor.BackColor = System.Drawing.Color.White;
            this.btnDeleteFloor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteFloor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteFloor.FocusCuesEnabled = false;
            this.btnDeleteFloor.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFloor.Image")));
            this.btnDeleteFloor.Location = new System.Drawing.Point(322, 113);
            this.btnDeleteFloor.Name = "btnDeleteFloor";
            this.btnDeleteFloor.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteFloor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteFloor.TabIndex = 8;
            this.btnDeleteFloor.TabStop = false;
            this.btnDeleteFloor.Click += new System.EventHandler(this.btnDeleteFloor_Click);
            // 
            // btnDeleteGrid
            // 
            this.btnDeleteGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDeleteGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteGrid.BackColor = System.Drawing.Color.White;
            this.btnDeleteGrid.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDeleteGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteGrid.FocusCuesEnabled = false;
            this.btnDeleteGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteGrid.Image")));
            this.btnDeleteGrid.Location = new System.Drawing.Point(322, 144);
            this.btnDeleteGrid.Name = "btnDeleteGrid";
            this.btnDeleteGrid.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDeleteGrid.TabIndex = 10;
            this.btnDeleteGrid.TabStop = false;
            this.btnDeleteGrid.Click += new System.EventHandler(this.btnDeleteGrid_Click);
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // btnEditGrid
            // 
            this.btnEditGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditGrid.BackColor = System.Drawing.Color.White;
            this.btnEditGrid.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditGrid.FocusCuesEnabled = false;
            this.btnEditGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGrid.Image")));
            this.btnEditGrid.Location = new System.Drawing.Point(291, 144);
            this.btnEditGrid.Name = "btnEditGrid";
            this.btnEditGrid.Size = new System.Drawing.Size(25, 25);
            this.btnEditGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditGrid.TabIndex = 343;
            this.btnEditGrid.TabStop = false;
            this.btnEditGrid.Click += new System.EventHandler(this.btnEditGrid_Click);
            // 
            // btnEditFloor
            // 
            this.btnEditFloor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditFloor.BackColor = System.Drawing.Color.White;
            this.btnEditFloor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditFloor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditFloor.FocusCuesEnabled = false;
            this.btnEditFloor.Image = ((System.Drawing.Image)(resources.GetObject("btnEditFloor.Image")));
            this.btnEditFloor.Location = new System.Drawing.Point(291, 113);
            this.btnEditFloor.Name = "btnEditFloor";
            this.btnEditFloor.Size = new System.Drawing.Size(25, 25);
            this.btnEditFloor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditFloor.TabIndex = 342;
            this.btnEditFloor.TabStop = false;
            this.btnEditFloor.Click += new System.EventHandler(this.btnEditFloor_Click);
            // 
            // btnEditVessel
            // 
            this.btnEditVessel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditVessel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditVessel.BackColor = System.Drawing.Color.White;
            this.btnEditVessel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditVessel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditVessel.FocusCuesEnabled = false;
            this.btnEditVessel.Image = ((System.Drawing.Image)(resources.GetObject("btnEditVessel.Image")));
            this.btnEditVessel.Location = new System.Drawing.Point(291, 82);
            this.btnEditVessel.Name = "btnEditVessel";
            this.btnEditVessel.Size = new System.Drawing.Size(25, 25);
            this.btnEditVessel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditVessel.TabIndex = 341;
            this.btnEditVessel.TabStop = false;
            this.btnEditVessel.Click += new System.EventHandler(this.btnEditVessel_Click);
            // 
            // btnEditArea
            // 
            this.btnEditArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditArea.BackColor = System.Drawing.Color.White;
            this.btnEditArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditArea.FocusCuesEnabled = false;
            this.btnEditArea.Image = ((System.Drawing.Image)(resources.GetObject("btnEditArea.Image")));
            this.btnEditArea.Location = new System.Drawing.Point(291, 51);
            this.btnEditArea.Name = "btnEditArea";
            this.btnEditArea.Size = new System.Drawing.Size(25, 25);
            this.btnEditArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditArea.TabIndex = 340;
            this.btnEditArea.TabStop = false;
            this.btnEditArea.Click += new System.EventHandler(this.btnEditArea_Click);
            // 
            // btnEditSite
            // 
            this.btnEditSite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditSite.BackColor = System.Drawing.Color.White;
            this.btnEditSite.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditSite.FocusCuesEnabled = false;
            this.btnEditSite.Image = ((System.Drawing.Image)(resources.GetObject("btnEditSite.Image")));
            this.btnEditSite.Location = new System.Drawing.Point(291, 20);
            this.btnEditSite.Name = "btnEditSite";
            this.btnEditSite.Size = new System.Drawing.Size(25, 25);
            this.btnEditSite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditSite.TabIndex = 339;
            this.btnEditSite.TabStop = false;
            this.btnEditSite.Click += new System.EventHandler(this.btnEditSite_Click);
            // 
            // btnAddGrid
            // 
            this.btnAddGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddGrid.BackColor = System.Drawing.Color.White;
            this.btnAddGrid.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGrid.FocusCuesEnabled = false;
            this.btnAddGrid.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGrid.Image")));
            this.btnAddGrid.Location = new System.Drawing.Point(260, 144);
            this.btnAddGrid.Name = "btnAddGrid";
            this.btnAddGrid.Size = new System.Drawing.Size(25, 25);
            this.btnAddGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddGrid.TabIndex = 348;
            this.btnAddGrid.TabStop = false;
            this.btnAddGrid.Click += new System.EventHandler(this.btnAddGrid_Click);
            // 
            // btnAddFloor
            // 
            this.btnAddFloor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFloor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFloor.BackColor = System.Drawing.Color.White;
            this.btnAddFloor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFloor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFloor.FocusCuesEnabled = false;
            this.btnAddFloor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFloor.Image")));
            this.btnAddFloor.Location = new System.Drawing.Point(260, 113);
            this.btnAddFloor.Name = "btnAddFloor";
            this.btnAddFloor.Size = new System.Drawing.Size(25, 25);
            this.btnAddFloor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddFloor.TabIndex = 347;
            this.btnAddFloor.TabStop = false;
            this.btnAddFloor.Click += new System.EventHandler(this.btnAddFloor_Click);
            // 
            // btnAddVessel
            // 
            this.btnAddVessel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddVessel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVessel.BackColor = System.Drawing.Color.White;
            this.btnAddVessel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddVessel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVessel.FocusCuesEnabled = false;
            this.btnAddVessel.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVessel.Image")));
            this.btnAddVessel.Location = new System.Drawing.Point(260, 82);
            this.btnAddVessel.Name = "btnAddVessel";
            this.btnAddVessel.Size = new System.Drawing.Size(25, 25);
            this.btnAddVessel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddVessel.TabIndex = 346;
            this.btnAddVessel.TabStop = false;
            this.btnAddVessel.Click += new System.EventHandler(this.btnAddVessel_Click);
            // 
            // btnAddArea
            // 
            this.btnAddArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddArea.BackColor = System.Drawing.Color.White;
            this.btnAddArea.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddArea.FocusCuesEnabled = false;
            this.btnAddArea.Image = ((System.Drawing.Image)(resources.GetObject("btnAddArea.Image")));
            this.btnAddArea.Location = new System.Drawing.Point(260, 51);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(25, 25);
            this.btnAddArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddArea.TabIndex = 345;
            this.btnAddArea.TabStop = false;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // btnAddSite
            // 
            this.btnAddSite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSite.BackColor = System.Drawing.Color.White;
            this.btnAddSite.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSite.FocusCuesEnabled = false;
            this.btnAddSite.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSite.Image")));
            this.btnAddSite.Location = new System.Drawing.Point(260, 20);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(25, 25);
            this.btnAddSite.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddSite.TabIndex = 344;
            this.btnAddSite.TabStop = false;
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            // 
            // frmLocations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(359, 236);
            this.Controls.Add(this.btnAddGrid);
            this.Controls.Add(this.btnAddFloor);
            this.Controls.Add(this.btnAddVessel);
            this.Controls.Add(this.btnAddArea);
            this.Controls.Add(this.btnAddSite);
            this.Controls.Add(this.btnEditGrid);
            this.Controls.Add(this.btnEditFloor);
            this.Controls.Add(this.btnEditVessel);
            this.Controls.Add(this.btnEditArea);
            this.Controls.Add(this.btnEditSite);
            this.Controls.Add(this.btnDeleteGrid);
            this.Controls.Add(this.btnDeleteFloor);
            this.Controls.Add(this.btnDeleteVessel);
            this.Controls.Add(this.btnDeleteArea);
            this.Controls.Add(this.btnDeleteSite);
            this.Controls.Add(this.cbxGrid);
            this.Controls.Add(this.cbxFloor);
            this.Controls.Add(this.cbxVessel);
            this.Controls.Add(this.cbxArea);
            this.Controls.Add(this.cbxSite);
            this.Controls.Add(this.lblGrid);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.lblVessel);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblSite);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLocations";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Locations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLocations_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX lblSite;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.LabelX lblArea;
        private DevComponents.DotNetBar.LabelX lblVessel;
        private DevComponents.DotNetBar.LabelX lblFloor;
        private DevComponents.DotNetBar.LabelX lblGrid;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxSite;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxArea;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxVessel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxFloor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxGrid;
        private DevComponents.DotNetBar.ButtonX btnDeleteSite;
        private DevComponents.DotNetBar.ButtonX btnDeleteArea;
        private DevComponents.DotNetBar.ButtonX btnDeleteVessel;
        private DevComponents.DotNetBar.ButtonX btnDeleteFloor;
        private DevComponents.DotNetBar.ButtonX btnDeleteGrid;
        private DevComponents.DotNetBar.StyleManager sm;
        private DevComponents.DotNetBar.ButtonX btnEditGrid;
        private DevComponents.DotNetBar.ButtonX btnEditFloor;
        private DevComponents.DotNetBar.ButtonX btnEditVessel;
        private DevComponents.DotNetBar.ButtonX btnEditArea;
        private DevComponents.DotNetBar.ButtonX btnEditSite;
        private DevComponents.DotNetBar.ButtonX btnAddGrid;
        private DevComponents.DotNetBar.ButtonX btnAddFloor;
        private DevComponents.DotNetBar.ButtonX btnAddVessel;
        private DevComponents.DotNetBar.ButtonX btnAddArea;
        private DevComponents.DotNetBar.ButtonX btnAddSite;
    }
}