namespace Client
{
    partial class frmDDBRebuild
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
            this.bwDDB = new System.ComponentModel.BackgroundWorker();
            this.pb = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.sm = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // bwDDB
            // 
            this.bwDDB.WorkerSupportsCancellation = true;
            this.bwDDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDDB_DoWork);
            this.bwDDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDDB_RunWorkerCompleted);
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.pb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pb.ForeColor = System.Drawing.Color.Black;
            this.pb.Location = new System.Drawing.Point(13, 22);
            this.pb.Name = "pb";
            this.pb.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.pb.Size = new System.Drawing.Size(359, 23);
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            // 
            // sm
            // 
            this.sm.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(57)))), ((int)(((byte)(123))))));
            // 
            // frmDDBRebuild
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.pb);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDDBRebuild";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rebuilding Device Database";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bwDDB;
        private DevComponents.DotNetBar.Controls.ProgressBarX pb;
        private DevComponents.DotNetBar.StyleManager sm;
    }
}