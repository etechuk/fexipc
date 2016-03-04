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
    public partial class frmSiteChoose : MetroForm
    {
        public frmSiteChoose()
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

            DialogResult = DialogResult.Abort;

            DataSet ds = Program.SQL.SelectAll("SELECT id,name FROM locations_sites;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = r["name"].ToString();
                    cbxSites.Items.Add(i);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxSites.Items[cbxSites.SelectedIndex];
            SharedData.iLocationSite = Convert.ToInt32(i.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbxSites_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
