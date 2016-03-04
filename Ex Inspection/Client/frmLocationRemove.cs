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
    public partial class frmLocationRemove : MetroForm
    {
        int iID = 0;

        public frmLocationRemove()
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

            DialogResult = DialogResult.Cancel;
            lblLocation.Text = SharedData.sLocationType.Substring(0, 1).ToUpper() + SharedData.sLocationType.Substring(1) + " Name:";

            DataSet ds = Program.SQL.SelectAll("SELECT id,name FROM locations_" + SharedData.sLocationType + "s;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = Convert.ToInt32(dr["id"]);
                    i.Text = dr["name"].ToString();
                    cbxLocations.Items.Add(i);
                }
            }

            switch (SharedData.sLocationType)
            {
                case "site":
                    iID = SharedData.iLocationSite;
                    break;
                case "area":
                    iID = SharedData.iLocationArea;
                    break;
                case "vessel":
                    iID = SharedData.iLocationVessel;
                    break;
                case "floor":
                    iID = SharedData.iLocationFloor;
                    break;
                case "grid":
                    iID = SharedData.iLocationGrid;
                    break;
            }

            if (iID < 1)
            {
                MessageBox.Show("Please select a valid location to continue.", "Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SharedData.sLocationType = "";
            SharedData.iLocationSite = 0;
            SharedData.iLocationArea = 0;
            SharedData.iLocationVessel = 0;
            SharedData.iLocationFloor = 0;
            SharedData.iLocationGrid = 0;
            SharedData.sLocationSite = "";
            SharedData.sLocationArea = "";
            SharedData.sLocationVessel = "";
            SharedData.sLocationFloor = "";
            SharedData.sLocationGrid = "";
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxLocations.SelectedIndex == -1)
            {
                MessageBox.Show("Choose a location to continue.", "Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                int iRes = 0;
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxLocations.Items[cbxLocations.SelectedIndex];
                DataSet ds = Program.SQL.SelectAll("SELECT id FROM items WHERE location" + SharedData.sLocationType + "=" + i.Value.ToString() + ";");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    string sNew = i.Value.ToString(), sIDs = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sIDs += sIDs.Length > 0 ? "," + dr["id"].ToString() : dr["id"].ToString();
                    }
                    if (sIDs.Length > 0)
                    {
                        iRes = Program.SQL.Update("UPDATE items SET location" + SharedData.sLocationType + "=" + sNew + " WHERE id IN (" + sIDs + ");");
                    }

                    if (iRes < 1)
                    {
                        MessageBox.Show("The process failed to complete.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    MessageBox.Show("The process completed successfully. " + iRes.ToString() + " items\nwere updated with the new location.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
    }
}
