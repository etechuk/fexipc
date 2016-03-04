namespace Client
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tv = new DevComponents.AdvTree.AdvTree();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.pGeneral = new DevComponents.DotNetBar.PanelEx();
            this.btnGeneralPathData = new DevComponents.DotNetBar.ButtonX();
            this.txtGeneralPathData = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblGeneralPathData = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.pVisual = new DevComponents.DotNetBar.PanelEx();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourFgPriority5 = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnVisualColourFgPriority4 = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnVisualColourFgPriority3 = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnVisualColourFgPriority2 = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnVisualColourFgPriority1 = new DevComponents.DotNetBar.ColorPickerButton();
            this.btnVisualColourFgPriorityO = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriority5 = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriority4 = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriority3 = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriority2 = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriority1 = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourBgPriorityO = new DevComponents.DotNetBar.ColorPickerButton();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnVisualColourWindow = new DevComponents.DotNetBar.ColorPickerButton();
            this.lblVisualColourWindow = new DevComponents.DotNetBar.LabelX();
            this.btnVisualPathLogo = new DevComponents.DotNetBar.ButtonX();
            this.txtVisualPathLogo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblVisualPathLogo = new DevComponents.DotNetBar.LabelX();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.tv)).BeginInit();
            this.pGeneral.SuspendLayout();
            this.pVisual.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv
            // 
            this.tv.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tv.AllowDrop = true;
            this.tv.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.tv.BackgroundStyle.Class = "TreeBorderKey";
            this.tv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tv.ForeColor = System.Drawing.Color.Black;
            this.tv.HotTracking = true;
            this.tv.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.tv.Location = new System.Drawing.Point(13, 20);
            this.tv.Name = "tv";
            this.tv.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1,
            this.node2});
            this.tv.NodesConnector = this.nodeConnector1;
            this.tv.NodeStyle = this.elementStyle1;
            this.tv.PathSeparator = ";";
            this.tv.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.tv.Size = new System.Drawing.Size(250, 379);
            this.tv.Styles.Add(this.elementStyle1);
            this.tv.TabIndex = 0;
            this.tv.TabStop = false;
            this.tv.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.tv_NodeClick);
            // 
            // node1
            // 
            this.node1.Name = "node1";
            this.node1.TagString = "general";
            this.node1.Text = "General";
            // 
            // node2
            // 
            this.node2.Name = "node2";
            this.node2.TagString = "visual";
            this.node2.Text = "Visual";
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
            // pGeneral
            // 
            this.pGeneral.CanvasColor = System.Drawing.SystemColors.Control;
            this.pGeneral.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pGeneral.Controls.Add(this.btnGeneralPathData);
            this.pGeneral.Controls.Add(this.txtGeneralPathData);
            this.pGeneral.Controls.Add(this.lblGeneralPathData);
            this.pGeneral.Controls.Add(this.labelX2);
            this.pGeneral.DisabledBackColor = System.Drawing.Color.Empty;
            this.pGeneral.Location = new System.Drawing.Point(278, 20);
            this.pGeneral.Name = "pGeneral";
            this.pGeneral.Size = new System.Drawing.Size(494, 339);
            this.pGeneral.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pGeneral.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pGeneral.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pGeneral.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pGeneral.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pGeneral.Style.GradientAngle = 90;
            this.pGeneral.TabIndex = 0;
            // 
            // btnGeneralPathData
            // 
            this.btnGeneralPathData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGeneralPathData.BackColor = System.Drawing.Color.White;
            this.btnGeneralPathData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGeneralPathData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneralPathData.FocusCuesEnabled = false;
            this.btnGeneralPathData.Location = new System.Drawing.Point(454, 50);
            this.btnGeneralPathData.Name = "btnGeneralPathData";
            this.btnGeneralPathData.Size = new System.Drawing.Size(25, 25);
            this.btnGeneralPathData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGeneralPathData.TabIndex = 4;
            this.btnGeneralPathData.TabStop = false;
            this.btnGeneralPathData.Click += new System.EventHandler(this.btnGeneralPathData_Click);
            // 
            // txtGeneralPathData
            // 
            this.txtGeneralPathData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralPathData.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtGeneralPathData.Border.Class = "TextBoxBorder";
            this.txtGeneralPathData.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGeneralPathData.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtGeneralPathData.DisabledBackColor = System.Drawing.Color.White;
            this.txtGeneralPathData.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtGeneralPathData.ForeColor = System.Drawing.Color.Black;
            this.txtGeneralPathData.Location = new System.Drawing.Point(130, 50);
            this.txtGeneralPathData.Margin = new System.Windows.Forms.Padding(4);
            this.txtGeneralPathData.Name = "txtGeneralPathData";
            this.txtGeneralPathData.PreventEnterBeep = true;
            this.txtGeneralPathData.ReadOnly = true;
            this.txtGeneralPathData.Size = new System.Drawing.Size(318, 25);
            this.txtGeneralPathData.TabIndex = 3;
            // 
            // lblGeneralPathData
            // 
            this.lblGeneralPathData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblGeneralPathData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblGeneralPathData.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblGeneralPathData.ForeColor = System.Drawing.Color.Black;
            this.lblGeneralPathData.Location = new System.Drawing.Point(13, 48);
            this.lblGeneralPathData.Margin = new System.Windows.Forms.Padding(4);
            this.lblGeneralPathData.Name = "lblGeneralPathData";
            this.lblGeneralPathData.Size = new System.Drawing.Size(109, 28);
            this.lblGeneralPathData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblGeneralPathData.TabIndex = 305323;
            this.lblGeneralPathData.Text = "Path to Data:";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX2.FontBold = true;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(13, 9);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(466, 22);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX2.TabIndex = 305322;
            this.labelX2.Text = "General";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(680, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 34);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
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
            this.btnCancel.Location = new System.Drawing.Point(278, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 34);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pVisual
            // 
            this.pVisual.CanvasColor = System.Drawing.SystemColors.Control;
            this.pVisual.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pVisual.Controls.Add(this.labelX10);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriority5);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriority4);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriority3);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriority2);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriority1);
            this.pVisual.Controls.Add(this.btnVisualColourFgPriorityO);
            this.pVisual.Controls.Add(this.labelX9);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriority5);
            this.pVisual.Controls.Add(this.labelX7);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriority4);
            this.pVisual.Controls.Add(this.labelX8);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriority3);
            this.pVisual.Controls.Add(this.labelX5);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriority2);
            this.pVisual.Controls.Add(this.labelX6);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriority1);
            this.pVisual.Controls.Add(this.labelX4);
            this.pVisual.Controls.Add(this.btnVisualColourBgPriorityO);
            this.pVisual.Controls.Add(this.labelX3);
            this.pVisual.Controls.Add(this.labelX1);
            this.pVisual.Controls.Add(this.btnVisualColourWindow);
            this.pVisual.Controls.Add(this.lblVisualColourWindow);
            this.pVisual.Controls.Add(this.btnVisualPathLogo);
            this.pVisual.Controls.Add(this.txtVisualPathLogo);
            this.pVisual.Controls.Add(this.lblVisualPathLogo);
            this.pVisual.DisabledBackColor = System.Drawing.Color.Empty;
            this.pVisual.Location = new System.Drawing.Point(278, 20);
            this.pVisual.Name = "pVisual";
            this.pVisual.Size = new System.Drawing.Size(494, 339);
            this.pVisual.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pVisual.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pVisual.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pVisual.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pVisual.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pVisual.Style.GradientAngle = 90;
            this.pVisual.TabIndex = 0;
            // 
            // labelX10
            // 
            this.labelX10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX10.ForeColor = System.Drawing.Color.Black;
            this.labelX10.Location = new System.Drawing.Point(173, 112);
            this.labelX10.Margin = new System.Windows.Forms.Padding(4);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(38, 28);
            this.labelX10.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX10.TabIndex = 305341;
            this.labelX10.Text = "Text";
            // 
            // btnVisualColourFgPriority5
            // 
            this.btnVisualColourFgPriority5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriority5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriority5.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriority5.Image")));
            this.btnVisualColourFgPriority5.Location = new System.Drawing.Point(173, 297);
            this.btnVisualColourFgPriority5.Name = "btnVisualColourFgPriority5";
            this.btnVisualColourFgPriority5.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriority5.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriority5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriority5.TabIndex = 19;
            // 
            // btnVisualColourFgPriority4
            // 
            this.btnVisualColourFgPriority4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriority4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriority4.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriority4.Image")));
            this.btnVisualColourFgPriority4.Location = new System.Drawing.Point(173, 266);
            this.btnVisualColourFgPriority4.Name = "btnVisualColourFgPriority4";
            this.btnVisualColourFgPriority4.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriority4.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriority4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriority4.TabIndex = 17;
            // 
            // btnVisualColourFgPriority3
            // 
            this.btnVisualColourFgPriority3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriority3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriority3.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriority3.Image")));
            this.btnVisualColourFgPriority3.Location = new System.Drawing.Point(173, 235);
            this.btnVisualColourFgPriority3.Name = "btnVisualColourFgPriority3";
            this.btnVisualColourFgPriority3.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriority3.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriority3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriority3.TabIndex = 15;
            // 
            // btnVisualColourFgPriority2
            // 
            this.btnVisualColourFgPriority2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriority2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriority2.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriority2.Image")));
            this.btnVisualColourFgPriority2.Location = new System.Drawing.Point(173, 204);
            this.btnVisualColourFgPriority2.Name = "btnVisualColourFgPriority2";
            this.btnVisualColourFgPriority2.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriority2.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriority2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriority2.TabIndex = 13;
            // 
            // btnVisualColourFgPriority1
            // 
            this.btnVisualColourFgPriority1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriority1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriority1.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriority1.Image")));
            this.btnVisualColourFgPriority1.Location = new System.Drawing.Point(173, 173);
            this.btnVisualColourFgPriority1.Name = "btnVisualColourFgPriority1";
            this.btnVisualColourFgPriority1.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriority1.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriority1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriority1.TabIndex = 11;
            // 
            // btnVisualColourFgPriorityO
            // 
            this.btnVisualColourFgPriorityO.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourFgPriorityO.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourFgPriorityO.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourFgPriorityO.Image")));
            this.btnVisualColourFgPriorityO.Location = new System.Drawing.Point(173, 142);
            this.btnVisualColourFgPriorityO.Name = "btnVisualColourFgPriorityO";
            this.btnVisualColourFgPriorityO.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourFgPriorityO.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourFgPriorityO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourFgPriorityO.TabIndex = 9;
            // 
            // labelX9
            // 
            this.labelX9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX9.ForeColor = System.Drawing.Color.Black;
            this.labelX9.Location = new System.Drawing.Point(129, 112);
            this.labelX9.Margin = new System.Windows.Forms.Padding(4);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(38, 28);
            this.labelX9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX9.TabIndex = 305334;
            this.labelX9.Text = "Back";
            // 
            // btnVisualColourBgPriority5
            // 
            this.btnVisualColourBgPriority5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriority5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriority5.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriority5.Image")));
            this.btnVisualColourBgPriority5.Location = new System.Drawing.Point(129, 297);
            this.btnVisualColourBgPriority5.Name = "btnVisualColourBgPriority5";
            this.btnVisualColourBgPriority5.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriority5.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriority5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriority5.TabIndex = 18;
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX7.ForeColor = System.Drawing.Color.Black;
            this.labelX7.Location = new System.Drawing.Point(13, 296);
            this.labelX7.Margin = new System.Windows.Forms.Padding(4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(109, 28);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX7.TabIndex = 305333;
            this.labelX7.Text = "Priority 5:";
            // 
            // btnVisualColourBgPriority4
            // 
            this.btnVisualColourBgPriority4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriority4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriority4.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriority4.Image")));
            this.btnVisualColourBgPriority4.Location = new System.Drawing.Point(129, 266);
            this.btnVisualColourBgPriority4.Name = "btnVisualColourBgPriority4";
            this.btnVisualColourBgPriority4.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriority4.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriority4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriority4.TabIndex = 16;
            // 
            // labelX8
            // 
            this.labelX8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX8.ForeColor = System.Drawing.Color.Black;
            this.labelX8.Location = new System.Drawing.Point(13, 265);
            this.labelX8.Margin = new System.Windows.Forms.Padding(4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(109, 28);
            this.labelX8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX8.TabIndex = 305331;
            this.labelX8.Text = "Priority 4:";
            // 
            // btnVisualColourBgPriority3
            // 
            this.btnVisualColourBgPriority3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriority3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriority3.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriority3.Image")));
            this.btnVisualColourBgPriority3.Location = new System.Drawing.Point(129, 235);
            this.btnVisualColourBgPriority3.Name = "btnVisualColourBgPriority3";
            this.btnVisualColourBgPriority3.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriority3.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriority3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriority3.TabIndex = 14;
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(13, 234);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(109, 28);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX5.TabIndex = 305329;
            this.labelX5.Text = "Priority 3:";
            // 
            // btnVisualColourBgPriority2
            // 
            this.btnVisualColourBgPriority2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriority2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriority2.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriority2.Image")));
            this.btnVisualColourBgPriority2.Location = new System.Drawing.Point(129, 204);
            this.btnVisualColourBgPriority2.Name = "btnVisualColourBgPriority2";
            this.btnVisualColourBgPriority2.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriority2.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriority2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriority2.TabIndex = 12;
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(13, 203);
            this.labelX6.Margin = new System.Windows.Forms.Padding(4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(109, 28);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX6.TabIndex = 305327;
            this.labelX6.Text = "Priority 2:";
            // 
            // btnVisualColourBgPriority1
            // 
            this.btnVisualColourBgPriority1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriority1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriority1.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriority1.Image")));
            this.btnVisualColourBgPriority1.Location = new System.Drawing.Point(129, 173);
            this.btnVisualColourBgPriority1.Name = "btnVisualColourBgPriority1";
            this.btnVisualColourBgPriority1.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriority1.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriority1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriority1.TabIndex = 10;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(13, 172);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(109, 28);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX4.TabIndex = 305325;
            this.labelX4.Text = "Priority 1:";
            // 
            // btnVisualColourBgPriorityO
            // 
            this.btnVisualColourBgPriorityO.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourBgPriorityO.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourBgPriorityO.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourBgPriorityO.Image")));
            this.btnVisualColourBgPriorityO.Location = new System.Drawing.Point(129, 142);
            this.btnVisualColourBgPriorityO.Name = "btnVisualColourBgPriorityO";
            this.btnVisualColourBgPriorityO.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourBgPriorityO.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourBgPriorityO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourBgPriorityO.TabIndex = 8;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(13, 141);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(109, 28);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX3.TabIndex = 305323;
            this.labelX3.Text = "Priority OK:";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelX1.FontBold = true;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(13, 9);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(466, 22);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.labelX1.TabIndex = 305321;
            this.labelX1.Text = "Visual";
            // 
            // btnVisualColourWindow
            // 
            this.btnVisualColourWindow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualColourWindow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualColourWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualColourWindow.Image")));
            this.btnVisualColourWindow.Location = new System.Drawing.Point(130, 80);
            this.btnVisualColourWindow.Name = "btnVisualColourWindow";
            this.btnVisualColourWindow.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.btnVisualColourWindow.Size = new System.Drawing.Size(38, 25);
            this.btnVisualColourWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualColourWindow.TabIndex = 7;
            // 
            // lblVisualColourWindow
            // 
            this.lblVisualColourWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblVisualColourWindow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblVisualColourWindow.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVisualColourWindow.ForeColor = System.Drawing.Color.Black;
            this.lblVisualColourWindow.Location = new System.Drawing.Point(13, 79);
            this.lblVisualColourWindow.Margin = new System.Windows.Forms.Padding(4);
            this.lblVisualColourWindow.Name = "lblVisualColourWindow";
            this.lblVisualColourWindow.Size = new System.Drawing.Size(109, 28);
            this.lblVisualColourWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblVisualColourWindow.TabIndex = 305318;
            this.lblVisualColourWindow.Text = "Window Colour:";
            // 
            // btnVisualPathLogo
            // 
            this.btnVisualPathLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVisualPathLogo.BackColor = System.Drawing.Color.White;
            this.btnVisualPathLogo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVisualPathLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisualPathLogo.FocusCuesEnabled = false;
            this.btnVisualPathLogo.Location = new System.Drawing.Point(454, 50);
            this.btnVisualPathLogo.Name = "btnVisualPathLogo";
            this.btnVisualPathLogo.Size = new System.Drawing.Size(25, 25);
            this.btnVisualPathLogo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVisualPathLogo.TabIndex = 6;
            this.btnVisualPathLogo.TabStop = false;
            this.btnVisualPathLogo.Click += new System.EventHandler(this.btnVisualPathLogo_Click);
            // 
            // txtVisualPathLogo
            // 
            this.txtVisualPathLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVisualPathLogo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtVisualPathLogo.Border.Class = "TextBoxBorder";
            this.txtVisualPathLogo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVisualPathLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtVisualPathLogo.DisabledBackColor = System.Drawing.Color.White;
            this.txtVisualPathLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtVisualPathLogo.ForeColor = System.Drawing.Color.Black;
            this.txtVisualPathLogo.Location = new System.Drawing.Point(130, 50);
            this.txtVisualPathLogo.Margin = new System.Windows.Forms.Padding(4);
            this.txtVisualPathLogo.Name = "txtVisualPathLogo";
            this.txtVisualPathLogo.PreventEnterBeep = true;
            this.txtVisualPathLogo.ReadOnly = true;
            this.txtVisualPathLogo.Size = new System.Drawing.Size(318, 25);
            this.txtVisualPathLogo.TabIndex = 5;
            // 
            // lblVisualPathLogo
            // 
            this.lblVisualPathLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.lblVisualPathLogo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblVisualPathLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblVisualPathLogo.ForeColor = System.Drawing.Color.Black;
            this.lblVisualPathLogo.Location = new System.Drawing.Point(13, 48);
            this.lblVisualPathLogo.Margin = new System.Windows.Forms.Padding(4);
            this.lblVisualPathLogo.Name = "lblVisualPathLogo";
            this.lblVisualPathLogo.Size = new System.Drawing.Size(109, 28);
            this.lblVisualPathLogo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.lblVisualPathLogo.TabIndex = 324;
            this.lblVisualPathLogo.Text = "Path to Logo:";
            // 
            // ofd
            // 
            this.ofd.Filter = "Image files (*.png, *.jpg, *.gif)|*.png;*.jpg;*.gif;*.bmp";
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tv);
            this.Controls.Add(this.pGeneral);
            this.Controls.Add(this.pVisual);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.tv)).EndInit();
            this.pGeneral.ResumeLayout(false);
            this.pVisual.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.AdvTree.AdvTree tv;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.PanelEx pGeneral;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.AdvTree.Node node1;
        private DevComponents.AdvTree.Node node2;
        private DevComponents.DotNetBar.PanelEx pVisual;
        private DevComponents.DotNetBar.Controls.TextBoxX txtVisualPathLogo;
        private DevComponents.DotNetBar.LabelX lblVisualPathLogo;
        private DevComponents.DotNetBar.ButtonX btnVisualPathLogo;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourWindow;
        private DevComponents.DotNetBar.LabelX lblVisualColourWindow;
        private System.Windows.Forms.OpenFileDialog ofd;
        private DevComponents.DotNetBar.StyleManager sm;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnGeneralPathData;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGeneralPathData;
        private DevComponents.DotNetBar.LabelX lblGeneralPathData;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriority5;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriority4;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriority3;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriority2;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriority1;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourFgPriorityO;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriority5;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriority4;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriority3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriority2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriority1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.ColorPickerButton btnVisualColourBgPriorityO;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}