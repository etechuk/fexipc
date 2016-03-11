using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;

namespace Client
{
    public partial class frmSettings : MetroForm
    {
        public frmSettings()
        {
            InitializeComponent();
            if (Properties.Settings.Default.PathToData.Length > 0 && System.IO.File.Exists(Properties.Settings.Default.PathToData + "logo.ico"))
            {
                Icon = Icon.ExtractAssociatedIcon(Properties.Settings.Default.PathToData + "logo.ico");
            }
            else
            {
                Icon = Properties.Resources.logo_fes;
            }
            sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters { CanvasColor = Color.White, BaseColor = Program.cWindowColour };

            txtGeneralPathData.Text = Properties.Settings.Default.PathToData.Replace(@"\\", @"\");

            txtVisualPathLogo.Text = @Properties.Settings.Default.PathToLogo;
            btnVisualColourWindow.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.WindowColour.Length > 0 ? Properties.Settings.Default.WindowColour : "#80397B");
            btnVisualColourBgPriorityO.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourPO.Length > 0 ? Properties.Settings.Default.RowColourPO : "#FFFFFF");
            btnVisualColourBgPriority1.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP1.Length > 0 ? Properties.Settings.Default.RowColourP1 : "#D93A32");
            btnVisualColourBgPriority2.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP2.Length > 0 ? Properties.Settings.Default.RowColourP2 : "#FF6961");
            btnVisualColourBgPriority3.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP3.Length > 0 ? Properties.Settings.Default.RowColourP3 : "#FF8D87");
            btnVisualColourBgPriority4.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP4.Length > 0 ? Properties.Settings.Default.RowColourP4 : "#FFB2AE");
            btnVisualColourBgPriority5.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP5.Length > 0 ? Properties.Settings.Default.RowColourP5 : "#FFD6D4");
            btnVisualColourFgPriorityO.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourPOT.Length > 0 ? Properties.Settings.Default.RowColourPOT : "#646464");
            btnVisualColourFgPriority1.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP1T.Length > 0 ? Properties.Settings.Default.RowColourP1T : "#FFFFFF");
            btnVisualColourFgPriority2.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP2T.Length > 0 ? Properties.Settings.Default.RowColourP2T : "#FFFFFF");
            btnVisualColourFgPriority3.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP3T.Length > 0 ? Properties.Settings.Default.RowColourP3T : "#404040");
            btnVisualColourFgPriority4.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP4T.Length > 0 ? Properties.Settings.Default.RowColourP4T : "#404040");
            btnVisualColourFgPriority5.SelectedColor = ColorTranslator.FromHtml(Properties.Settings.Default.RowColourP5T.Length > 0 ? Properties.Settings.Default.RowColourP5T : "#404040");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtGeneralPathData.Text.Trim().Length > 0)
            {
                string sSep = !txtGeneralPathData.Text.Trim().EndsWith("\\") ? @"\" : "";
                Properties.Settings.Default.PathToData = txtGeneralPathData.Text.Trim() + sSep;
            }

            if (txtVisualPathLogo.Text.Trim().Length > 0)
            {
                Properties.Settings.Default.PathToLogo = txtVisualPathLogo.Text.Trim();
            }
            if (btnVisualColourWindow.SelectedColor != null)
            {
                Properties.Settings.Default.WindowColour = ColorTranslator.ToHtml(btnVisualColourWindow.SelectedColor);
                Program.cWindowColour = btnVisualColourWindow.SelectedColor;
            }
            if (btnVisualColourBgPriority1.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP1 = ColorTranslator.ToHtml(btnVisualColourBgPriority1.SelectedColor);
            }
            if (btnVisualColourBgPriority2.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP2 = ColorTranslator.ToHtml(btnVisualColourBgPriority2.SelectedColor);
            }
            if (btnVisualColourBgPriority3.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP3 = ColorTranslator.ToHtml(btnVisualColourBgPriority3.SelectedColor);
            }
            if (btnVisualColourBgPriority4.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP4 = ColorTranslator.ToHtml(btnVisualColourBgPriority4.SelectedColor);
            }
            if (btnVisualColourBgPriority5.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP5 = ColorTranslator.ToHtml(btnVisualColourBgPriority5.SelectedColor);
            }
            if (btnVisualColourBgPriorityO.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourPO = ColorTranslator.ToHtml(btnVisualColourBgPriorityO.SelectedColor);
            }
            if (btnVisualColourFgPriority1.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP1T = ColorTranslator.ToHtml(btnVisualColourFgPriority1.SelectedColor);
            }
            if (btnVisualColourFgPriority2.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP2T = ColorTranslator.ToHtml(btnVisualColourFgPriority2.SelectedColor);
            }
            if (btnVisualColourFgPriority3.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP3T = ColorTranslator.ToHtml(btnVisualColourFgPriority3.SelectedColor);
            }
            if (btnVisualColourFgPriority4.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP4T = ColorTranslator.ToHtml(btnVisualColourFgPriority4.SelectedColor);
            }
            if (btnVisualColourFgPriority5.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourP5T = ColorTranslator.ToHtml(btnVisualColourFgPriority5.SelectedColor);
            }
            if (btnVisualColourFgPriorityO.SelectedColor != null)
            {
                Properties.Settings.Default.RowColourPOT = ColorTranslator.ToHtml(btnVisualColourFgPriorityO.SelectedColor);
            }

            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGeneralPathData_Click(object sender, EventArgs e)
        {
            DialogResult dlg = fbd.ShowDialog();
            if (dlg == DialogResult.OK && fbd.SelectedPath.Length > 0)
            {
                txtGeneralPathData.Text = @fbd.SelectedPath;
            }
        }

        private void btnVisualPathLogo_Click(object sender, EventArgs e)
        {
            DialogResult dlg = ofd.ShowDialog();
            if (dlg == DialogResult.OK && ofd.FileName.Length > 0)
            {
                txtVisualPathLogo.Text = @ofd.FileName;
            }
        }

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            switch (e.Node.TagString)
            {
                case "visual":
                    pGeneral.Visible = false;
                    pVisual.Visible = true;
                    break;
                default:
                    pGeneral.Visible = true;
                    pVisual.Visible = false;
                    break;
            }
        }
    }
}
