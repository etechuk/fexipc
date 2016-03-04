namespace Client
{
    partial class frmSchedulesQuestions
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
            this.tv = new DevComponents.AdvTree.AdvTree();
            this.tvc = new DevComponents.AdvTree.ColumnHeader();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.tc = new DevComponents.DotNetBar.SuperTabControl();
            this.tpGeneral = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.chkMultiPart = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbxNumber = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblNumber = new DevComponents.DotNetBar.LabelX();
            this.cbxLetter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblLetter = new DevComponents.DotNetBar.LabelX();
            this.btnSections = new DevComponents.DotNetBar.ButtonX();
            this.cbxSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblSection = new DevComponents.DotNetBar.LabelX();
            this.txtEntry = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblEntry = new DevComponents.DotNetBar.LabelX();
            this.tiGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.tpParts = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.btnPartCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnPartSave = new DevComponents.DotNetBar.ButtonX();
            this.txtPart = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblPartText = new DevComponents.DotNetBar.LabelX();
            this.lbxParts = new DevComponents.DotNetBar.ListBoxAdv();
            this.lblPartList = new DevComponents.DotNetBar.LabelX();
            this.tiParts = new DevComponents.DotNetBar.SuperTabItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmPartAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPartRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc)).BeginInit();
            this.tc.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpParts.SuspendLayout();
            this.cm.SuspendLayout();
            this.cmPart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tv.AllowDrop = true;
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tv.BackgroundStyle.Class = "TreeBorderKey";
            this.tv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tv.Columns.Add(this.tvc);
            this.tv.ColumnsVisible = false;
            this.tv.ForeColor = System.Drawing.Color.Black;
            this.tv.GridLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tv.GridRowLines = true;
            this.tv.HotTracking = true;
            this.tv.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.tv.Location = new System.Drawing.Point(12, 19);
            this.tv.Name = "tv";
            this.tv.NodesConnector = this.nodeConnector1;
            this.tv.NodeStyle = this.elementStyle1;
            this.tv.PathSeparator = ";";
            this.tv.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.tv.Size = new System.Drawing.Size(250, 450);
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
            this.tvc.Text = "Inspectors";
            this.tvc.Width.Relative = 101;
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
            // tc
            // 
            this.tc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tc.Controls.Add(this.tpGeneral);
            this.tc.Controls.Add(this.tpParts);
            this.tc.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.ForeColor = System.Drawing.Color.Black;
            this.tc.Location = new System.Drawing.Point(277, 19);
            this.tc.Name = "tc";
            this.tc.ReorderTabsEnabled = true;
            this.tc.SelectedTabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.SelectedTabIndex = 0;
            this.tc.Size = new System.Drawing.Size(513, 294);
            this.tc.TabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.TabIndex = 319;
            this.tc.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tiGeneral,
            this.tiParts});
            this.tc.TabStop = false;
            this.tc.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.tc.TabVerticalSpacing = 3;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.chkMultiPart);
            this.tpGeneral.Controls.Add(this.cbxNumber);
            this.tpGeneral.Controls.Add(this.lblNumber);
            this.tpGeneral.Controls.Add(this.cbxLetter);
            this.tpGeneral.Controls.Add(this.lblLetter);
            this.tpGeneral.Controls.Add(this.btnSections);
            this.tpGeneral.Controls.Add(this.cbxSection);
            this.tpGeneral.Controls.Add(this.lblSection);
            this.tpGeneral.Controls.Add(this.txtEntry);
            this.tpGeneral.Controls.Add(this.lblEntry);
            this.tpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(0, 28);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(513, 266);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.TabItem = this.tiGeneral;
            // 
            // chkMultiPart
            // 
            this.chkMultiPart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.chkMultiPart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkMultiPart.ForeColor = System.Drawing.Color.Black;
            this.chkMultiPart.Location = new System.Drawing.Point(101, 116);
            this.chkMultiPart.Name = "chkMultiPart";
            this.chkMultiPart.Size = new System.Drawing.Size(396, 23);
            this.chkMultiPart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkMultiPart.TabIndex = 4;
            this.chkMultiPart.Text = " This item has multiple parts";
            // 
            // cbxNumber
            // 
            this.cbxNumber.DisplayMember = "Text";
            this.cbxNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumber.Enabled = false;
            this.cbxNumber.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbxNumber.ForeColor = System.Drawing.Color.Black;
            this.cbxNumber.FormattingEnabled = true;
            this.cbxNumber.ItemHeight = 19;
            this.cbxNumber.Location = new System.Drawing.Point(101, 213);
            this.cbxNumber.Margin = new System.Windows.Forms.Padding(4);
            this.cbxNumber.Name = "cbxNumber";
            this.cbxNumber.Size = new System.Drawing.Size(83, 25);
            this.cbxNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxNumber.TabIndex = 8;
            // 
            // lblNumber
            // 
            this.lblNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNumber.ForeColor = System.Drawing.Color.Black;
            this.lblNumber.Location = new System.Drawing.Point(14, 213);
            this.lblNumber.Margin = new System.Windows.Forms.Padding(4);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(79, 28);
            this.lblNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblNumber.TabIndex = 305321;
            this.lblNumber.Text = "Number:";
            // 
            // cbxLetter
            // 
            this.cbxLetter.DisplayMember = "Text";
            this.cbxLetter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxLetter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLetter.Enabled = false;
            this.cbxLetter.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbxLetter.ForeColor = System.Drawing.Color.Black;
            this.cbxLetter.FormattingEnabled = true;
            this.cbxLetter.ItemHeight = 19;
            this.cbxLetter.Location = new System.Drawing.Point(101, 182);
            this.cbxLetter.Margin = new System.Windows.Forms.Padding(4);
            this.cbxLetter.Name = "cbxLetter";
            this.cbxLetter.Size = new System.Drawing.Size(83, 25);
            this.cbxLetter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxLetter.TabIndex = 7;
            // 
            // lblLetter
            // 
            this.lblLetter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblLetter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblLetter.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLetter.ForeColor = System.Drawing.Color.Black;
            this.lblLetter.Location = new System.Drawing.Point(14, 182);
            this.lblLetter.Margin = new System.Windows.Forms.Padding(4);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(79, 28);
            this.lblLetter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblLetter.TabIndex = 305319;
            this.lblLetter.Text = "Letter:";
            // 
            // btnSections
            // 
            this.btnSections.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSections.BackColor = System.Drawing.Color.White;
            this.btnSections.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSections.Enabled = false;
            this.btnSections.FocusCuesEnabled = false;
            this.btnSections.Location = new System.Drawing.Point(472, 151);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(25, 25);
            this.btnSections.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSections.TabIndex = 6;
            this.btnSections.TabStop = false;
            // 
            // cbxSection
            // 
            this.cbxSection.DisplayMember = "Text";
            this.cbxSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSection.Enabled = false;
            this.cbxSection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbxSection.ForeColor = System.Drawing.Color.Black;
            this.cbxSection.FormattingEnabled = true;
            this.cbxSection.ItemHeight = 19;
            this.cbxSection.Location = new System.Drawing.Point(101, 151);
            this.cbxSection.Margin = new System.Windows.Forms.Padding(4);
            this.cbxSection.Name = "cbxSection";
            this.cbxSection.Size = new System.Drawing.Size(364, 25);
            this.cbxSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxSection.TabIndex = 5;
            // 
            // lblSection
            // 
            this.lblSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblSection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSection.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSection.ForeColor = System.Drawing.Color.Black;
            this.lblSection.Location = new System.Drawing.Point(14, 151);
            this.lblSection.Margin = new System.Windows.Forms.Padding(4);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(79, 28);
            this.lblSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblSection.TabIndex = 32;
            this.lblSection.Text = "Section:";
            // 
            // txtEntry
            // 
            this.txtEntry.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtEntry.Border.Class = "TextBoxBorder";
            this.txtEntry.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEntry.DisabledBackColor = System.Drawing.Color.White;
            this.txtEntry.Enabled = false;
            this.txtEntry.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtEntry.ForeColor = System.Drawing.Color.Black;
            this.txtEntry.Location = new System.Drawing.Point(101, 11);
            this.txtEntry.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntry.Multiline = true;
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.PreventEnterBeep = true;
            this.txtEntry.Size = new System.Drawing.Size(396, 102);
            this.txtEntry.TabIndex = 3;
            // 
            // lblEntry
            // 
            this.lblEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblEntry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEntry.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblEntry.ForeColor = System.Drawing.Color.Black;
            this.lblEntry.Location = new System.Drawing.Point(14, 11);
            this.lblEntry.Margin = new System.Windows.Forms.Padding(4);
            this.lblEntry.Name = "lblEntry";
            this.lblEntry.Size = new System.Drawing.Size(79, 28);
            this.lblEntry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblEntry.TabIndex = 30;
            this.lblEntry.Text = "Question:";
            // 
            // tiGeneral
            // 
            this.tiGeneral.AttachedControl = this.tpGeneral;
            this.tiGeneral.GlobalItem = false;
            this.tiGeneral.Name = "tiGeneral";
            this.tiGeneral.Text = "  General";
            // 
            // tpParts
            // 
            this.tpParts.Controls.Add(this.btnPartCancel);
            this.tpParts.Controls.Add(this.btnPartSave);
            this.tpParts.Controls.Add(this.txtPart);
            this.tpParts.Controls.Add(this.lblPartText);
            this.tpParts.Controls.Add(this.lbxParts);
            this.tpParts.Controls.Add(this.lblPartList);
            this.tpParts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpParts.Location = new System.Drawing.Point(0, 28);
            this.tpParts.Name = "tpParts";
            this.tpParts.Size = new System.Drawing.Size(513, 266);
            this.tpParts.TabIndex = 0;
            this.tpParts.TabItem = this.tiParts;
            // 
            // btnPartCancel
            // 
            this.btnPartCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPartCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPartCancel.Enabled = false;
            this.btnPartCancel.Location = new System.Drawing.Point(408, 220);
            this.btnPartCancel.Name = "btnPartCancel";
            this.btnPartCancel.Size = new System.Drawing.Size(89, 32);
            this.btnPartCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPartCancel.TabIndex = 12;
            this.btnPartCancel.TabStop = false;
            this.btnPartCancel.Text = "Cancel Part";
            this.btnPartCancel.Click += new System.EventHandler(this.btnPartCancel_Click);
            // 
            // btnPartSave
            // 
            this.btnPartSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPartSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPartSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPartSave.Enabled = false;
            this.btnPartSave.Location = new System.Drawing.Point(101, 220);
            this.btnPartSave.Name = "btnPartSave";
            this.btnPartSave.Size = new System.Drawing.Size(79, 32);
            this.btnPartSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPartSave.TabIndex = 11;
            this.btnPartSave.TabStop = false;
            this.btnPartSave.Text = "Save Part";
            this.btnPartSave.Click += new System.EventHandler(this.btnPartSave_Click);
            // 
            // txtPart
            // 
            this.txtPart.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtPart.Border.Class = "TextBoxBorder";
            this.txtPart.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPart.DisabledBackColor = System.Drawing.Color.White;
            this.txtPart.Enabled = false;
            this.txtPart.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPart.ForeColor = System.Drawing.Color.Black;
            this.txtPart.Location = new System.Drawing.Point(101, 151);
            this.txtPart.Margin = new System.Windows.Forms.Padding(4);
            this.txtPart.Multiline = true;
            this.txtPart.Name = "txtPart";
            this.txtPart.PreventEnterBeep = true;
            this.txtPart.Size = new System.Drawing.Size(396, 63);
            this.txtPart.TabIndex = 10;
            // 
            // lblPartText
            // 
            this.lblPartText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblPartText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPartText.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPartText.ForeColor = System.Drawing.Color.Black;
            this.lblPartText.Location = new System.Drawing.Point(14, 151);
            this.lblPartText.Margin = new System.Windows.Forms.Padding(4);
            this.lblPartText.Name = "lblPartText";
            this.lblPartText.Size = new System.Drawing.Size(79, 28);
            this.lblPartText.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPartText.TabIndex = 35;
            this.lblPartText.Text = "Part Text:";
            // 
            // lbxParts
            // 
            this.lbxParts.AutoScroll = true;
            this.lbxParts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lbxParts.BackgroundStyle.Class = "ListBoxAdv";
            this.lbxParts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbxParts.ContainerControlProcessDialogKey = true;
            this.lbxParts.DragDropSupport = true;
            this.lbxParts.Enabled = false;
            this.lbxParts.ForeColor = System.Drawing.Color.Black;
            this.lbxParts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.lbxParts.Location = new System.Drawing.Point(101, 11);
            this.lbxParts.Name = "lbxParts";
            this.lbxParts.Size = new System.Drawing.Size(396, 134);
            this.lbxParts.TabIndex = 9;
            this.lbxParts.ItemClick += new System.EventHandler(this.lbxParts_ItemClick);
            this.lbxParts.ItemDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxParts_ItemDoubleClick);
            // 
            // lblPartList
            // 
            this.lblPartList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblPartList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPartList.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPartList.ForeColor = System.Drawing.Color.Black;
            this.lblPartList.Location = new System.Drawing.Point(14, 11);
            this.lblPartList.Margin = new System.Windows.Forms.Padding(4);
            this.lblPartList.Name = "lblPartList";
            this.lblPartList.Size = new System.Drawing.Size(80, 28);
            this.lblPartList.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblPartList.TabIndex = 32;
            this.lblPartList.Text = "Parts List:";
            // 
            // tiParts
            // 
            this.tiParts.AttachedControl = this.tpParts;
            this.tiParts.GlobalItem = false;
            this.tiParts.Name = "tiParts";
            this.tiParts.Text = "  Parts";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(717, 319);
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
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(277, 319);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmAdd,
            this.cmRemove});
            this.cm.Name = "mMain";
            this.cm.Size = new System.Drawing.Size(167, 48);
            // 
            // cmAdd
            // 
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(166, 22);
            this.cmAdd.Text = "Add question";
            this.cmAdd.Click += new System.EventHandler(this.cmAdd_Click);
            // 
            // cmRemove
            // 
            this.cmRemove.Name = "cmRemove";
            this.cmRemove.Size = new System.Drawing.Size(166, 22);
            this.cmRemove.Text = "Remove question";
            this.cmRemove.Click += new System.EventHandler(this.cmRemove_Click);
            // 
            // cmPart
            // 
            this.cmPart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmPartAdd,
            this.cmPartRemove});
            this.cmPart.Name = "mMain";
            this.cmPart.Size = new System.Drawing.Size(142, 48);
            // 
            // cmPartAdd
            // 
            this.cmPartAdd.Name = "cmPartAdd";
            this.cmPartAdd.Size = new System.Drawing.Size(141, 22);
            this.cmPartAdd.Text = "Add part";
            this.cmPartAdd.Click += new System.EventHandler(this.cmPartAdd_Click);
            // 
            // cmPartRemove
            // 
            this.cmPartRemove.Name = "cmPartRemove";
            this.cmPartRemove.Size = new System.Drawing.Size(141, 22);
            this.cmPartRemove.Text = "Remove part";
            this.cmPartRemove.Click += new System.EventHandler(this.cmPartRemove_Click);
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmSchedulesQuestions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(802, 481);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.tv);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmSchedulesQuestions";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Questions";
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpParts.ResumeLayout(false);
            this.cm.ResumeLayout(false);
            this.cmPart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree tv;
        private DevComponents.AdvTree.ColumnHeader tvc;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.SuperTabControl tc;
        private DevComponents.DotNetBar.SuperTabControlPanel tpGeneral;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxSection;
        private DevComponents.DotNetBar.LabelX lblSection;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEntry;
        private DevComponents.DotNetBar.LabelX lblEntry;
        private DevComponents.DotNetBar.SuperTabItem tiGeneral;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxNumber;
        private DevComponents.DotNetBar.LabelX lblNumber;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxLetter;
        private DevComponents.DotNetBar.LabelX lblLetter;
        private DevComponents.DotNetBar.ButtonX btnSections;
        private DevComponents.DotNetBar.SuperTabControlPanel tpParts;
        private DevComponents.DotNetBar.SuperTabItem tiParts;
        private DevComponents.DotNetBar.ListBoxAdv lbxParts;
        private DevComponents.DotNetBar.LabelX lblPartList;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPart;
        private DevComponents.DotNetBar.LabelX lblPartText;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem cmAdd;
        private System.Windows.Forms.ToolStripMenuItem cmRemove;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkMultiPart;
        private DevComponents.DotNetBar.ButtonX btnPartSave;
        private System.Windows.Forms.ContextMenuStrip cmPart;
        private System.Windows.Forms.ToolStripMenuItem cmPartAdd;
        private System.Windows.Forms.ToolStripMenuItem cmPartRemove;
        private DevComponents.DotNetBar.ButtonX btnPartCancel;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}