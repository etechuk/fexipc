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
    public partial class frmPostal : MetroForm
    {
        public frmPostal()
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

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_countries;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = dr["code"].ToString();
                    i.Text = dr["name"].ToString();
                    cbxCountry.Items.Add(i);
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
            if (txtLine1.Text.Trim().Length > 0)
            {
                MessageBox.Show("Enter the first line of the address to continue.", "Address", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SharedData.sPostal = txtLine1.Text.Trim();
            SharedData.sPostal += "|" + txtLine2.Text.Trim();
            SharedData.sPostal += "|" + txtLine3.Text.Trim();
            SharedData.sPostal += "|" + txtTown.Text.Trim();
            SharedData.sPostal += "|" + txtCounty.Text.Trim();
            SharedData.sPostal += "|" + txtPostcode.Text.Trim();
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxCountry.SelectedItem;
            SharedData.sPostal += "|" + i.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
