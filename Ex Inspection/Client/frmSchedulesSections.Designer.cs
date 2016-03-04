namespace Client
{
    partial class frmSchedulesSections
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
            this.cbxParent = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxiVisual = new DevComponents.Editors.ComboItem();
            this.cbxiClose = new DevComponents.Editors.ComboItem();
            this.cbxiDetail = new DevComponents.Editors.ComboItem();
            this.lblParent = new DevComponents.DotNetBar.LabelX();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.tiGeneral = new DevComponents.DotNetBar.SuperTabItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc)).BeginInit();
            this.tc.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.cm.SuspendLayout();
            this.SuspendLayout();
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
            this.tv.Size = new System.Drawing.Size(250, 280);
            this.tv.Styles.Add(this.elementStyle1);
            this.tv.TabIndex = 2;
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
            this.tc.Controls.Add(this.tpGeneral);
            this.tc.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.ForeColor = System.Drawing.Color.Black;
            this.tc.Location = new System.Drawing.Point(277, 19);
            this.tc.Name = "tc";
            this.tc.ReorderTabsEnabled = true;
            this.tc.SelectedTabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.SelectedTabIndex = 0;
            this.tc.Size = new System.Drawing.Size(415, 242);
            this.tc.TabFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tc.TabIndex = 318;
            this.tc.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tiGeneral});
            this.tc.TabStop = false;
            this.tc.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.tc.TabVerticalSpacing = 3;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.cbxParent);
            this.tpGeneral.Controls.Add(this.lblParent);
            this.tpGeneral.Controls.Add(this.txtName);
            this.tpGeneral.Controls.Add(this.lblName);
            this.tpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpGeneral.Location = new System.Drawing.Point(0, 28);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Size = new System.Drawing.Size(415, 214);
            this.tpGeneral.TabIndex = 1;
            this.tpGeneral.TabItem = this.tiGeneral;
            // 
            // cbxParent
            // 
            this.cbxParent.DisplayMember = "Text";
            this.cbxParent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParent.Enabled = false;
            this.cbxParent.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cbxParent.ForeColor = System.Drawing.Color.Black;
            this.cbxParent.FormattingEnabled = true;
            this.cbxParent.ItemHeight = 19;
            this.cbxParent.Items.AddRange(new object[] {
            this.cbxiVisual,
            this.cbxiClose,
            this.cbxiDetail});
            this.cbxParent.Location = new System.Drawing.Point(79, 43);
            this.cbxParent.Margin = new System.Windows.Forms.Padding(4);
            this.cbxParent.Name = "cbxParent";
            this.cbxParent.Size = new System.Drawing.Size(323, 25);
            this.cbxParent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxParent.TabIndex = 2;
            // 
            // cbxiVisual
            // 
            this.cbxiVisual.Text = "V - Visual";
            this.cbxiVisual.Value = "V";
            // 
            // cbxiClose
            // 
            this.cbxiClose.Text = "C - Close";
            this.cbxiClose.Value = "C";
            // 
            // cbxiDetail
            // 
            this.cbxiDetail.Text = "D - Detail";
            this.cbxiDetail.Value = "D";
            // 
            // lblParent
            // 
            this.lblParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblParent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblParent.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblParent.ForeColor = System.Drawing.Color.Black;
            this.lblParent.Location = new System.Drawing.Point(14, 42);
            this.lblParent.Margin = new System.Windows.Forms.Padding(4);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(57, 28);
            this.lblParent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblParent.TabIndex = 32;
            this.lblParent.Text = "Parent:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.DisabledBackColor = System.Drawing.Color.White;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(79, 12);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.PreventEnterBeep = true;
            this.txtName.Size = new System.Drawing.Size(323, 25);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(14, 11);
            this.lblName.Margin = new System.Windows.Forms.Padding(4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 28);
            this.lblName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblName.TabIndex = 30;
            this.lblName.Text = "Name:";
            // 
            // tiGeneral
            // 
            this.tiGeneral.AttachedControl = this.tpGeneral;
            this.tiGeneral.GlobalItem = false;
            this.tiGeneral.Name = "tiGeneral";
            this.tiGeneral.Text = "  General";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(619, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 32);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 320;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(277, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 32);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 321;
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
            this.cm.Size = new System.Drawing.Size(159, 48);
            // 
            // cmAdd
            // 
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(158, 22);
            this.cmAdd.Text = "Add section";
            this.cmAdd.Click += new System.EventHandler(this.cmAdd_Click);
            // 
            // cmRemove
            // 
            this.cmRemove.Name = "cmRemove";
            this.cmRemove.Size = new System.Drawing.Size(158, 22);
            this.cmRemove.Text = "Remove section";
            this.cmRemove.Click += new System.EventHandler(this.cmRemove_Click);
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmSchedulesSections
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(704, 311);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tc);
            this.Controls.Add(this.tv);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSchedulesSections";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Sections";
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tc)).EndInit();
            this.tc.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.cm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree tv;
        private DevComponents.AdvTree.ColumnHeader tvc;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.SuperTabControl tc;
        private DevComponents.DotNetBar.SuperTabControlPanel tpGeneral;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxParent;
        private DevComponents.Editors.ComboItem cbxiVisual;
        private DevComponents.Editors.ComboItem cbxiClose;
        private DevComponents.Editors.ComboItem cbxiDetail;
        private DevComponents.DotNetBar.LabelX lblParent;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.SuperTabItem tiGeneral;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem cmAdd;
        private System.Windows.Forms.ToolStripMenuItem cmRemove;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}