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
    public partial class frmLocations : MetroForm
    {
        #region Form

        public frmLocations()
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

            LoadLocations();
        }

        private void frmLocations_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Loader

        private void LoadLocations()
        {
            DataSet ds;
            string query = "";

            cbxSite.Items.Clear();
            cbxArea.Items.Clear();
            cbxVessel.Items.Clear();
            cbxFloor.Items.Clear();
            cbxGrid.Items.Clear();

            ds = Program.SQL.SelectAll("SELECT id,name FROM locations_sites;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                int iSelected = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = Convert.ToInt32(dr["id"]);
                    i.Text = dr["name"].ToString();
                    cbxSite.Items.Add(i);
                    if (SharedData.iLocationSite > 0 && Convert.ToInt32(dr["id"]) == SharedData.iLocationSite)
                    {
                        iSelected = cbxSite.Items.Count - 1;
                    }
                }
                if (iSelected > -1)
                {
                    cbxSite.SelectedIndex = iSelected;
                }
            }

            if (SharedData.iLocationSite > 0)
            {
                query = " WHERE site=@site";
                Program.SQL.AddParameter("site", SharedData.iLocationSite);
                ds = Program.SQL.SelectAll("SELECT id,name FROM locations_areas" + (query != " WHERE " ? query : "") + ";");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    int iSelected = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Value = Convert.ToInt32(dr["id"]);
                        i.Text = dr["name"].ToString();
                        cbxArea.Items.Add(i);
                        if (SharedData.iLocationArea > 0 && Convert.ToInt32(dr["id"]) == SharedData.iLocationArea)
                        {
                            iSelected = cbxArea.Items.Count - 1;
                        }
                    }
                    if (iSelected > -1)
                    {
                        cbxArea.SelectedIndex = iSelected;
                    }
                }
            }

            if (SharedData.iLocationSite > 0 && SharedData.iLocationArea > 0)
            {
                query = " WHERE site=@site AND area=@area";
                Program.SQL.AddParameter("site", SharedData.iLocationSite);
                Program.SQL.AddParameter("area", SharedData.iLocationArea);
                ds = Program.SQL.SelectAll("SELECT id,name FROM locations_vessels" + (query != " WHERE " ? query : "") + ";");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    int iSelected = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Value = Convert.ToInt32(dr["id"]);
                        i.Text = dr["name"].ToString();
                        cbxVessel.Items.Add(i);
                        if (SharedData.iLocationVessel > 0 && Convert.ToInt32(dr["id"]) == SharedData.iLocationVessel)
                        {
                            iSelected = cbxVessel.Items.Count - 1;
                        }
                    }
                    if (iSelected > -1)
                    {
                        cbxVessel.SelectedIndex = iSelected;
                    }
                }
            }

            if (SharedData.iLocationSite > 0 && SharedData.iLocationArea > 0 && SharedData.iLocationVessel > 0)
            {
                query = " WHERE site=@site AND area=@area AND vessel=@vessel";
                Program.SQL.AddParameter("site", SharedData.iLocationSite);
                Program.SQL.AddParameter("area", SharedData.iLocationArea);
                Program.SQL.AddParameter("vessel", SharedData.iLocationVessel);
                ds = Program.SQL.SelectAll("SELECT id,name FROM locations_floors" + (query != " WHERE " ? query : "") + ";");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    int iSelected = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Value = Convert.ToInt32(dr["id"]);
                        i.Text = dr["name"].ToString();
                        cbxFloor.Items.Add(i);
                        if (SharedData.iLocationFloor > 0 && Convert.ToInt32(dr["id"]) == SharedData.iLocationFloor)
                        {
                            iSelected = cbxFloor.Items.Count - 1;
                        }
                    }
                    if (iSelected > -1)
                    {
                        cbxFloor.SelectedIndex = iSelected;
                    }
                }
            }

            if (SharedData.iLocationSite > 0 && SharedData.iLocationArea > 0 && SharedData.iLocationVessel > 0 && SharedData.iLocationFloor > 0)
            {
                query = " WHERE site=@site AND area=@area AND vessel=@vessel AND floor=@floor";
                Program.SQL.AddParameter("site", SharedData.iLocationSite);
                Program.SQL.AddParameter("area", SharedData.iLocationArea);
                Program.SQL.AddParameter("vessel", SharedData.iLocationVessel);
                Program.SQL.AddParameter("floor", SharedData.iLocationFloor);
                ds = Program.SQL.SelectAll("SELECT id,name FROM locations_grids" + (query != " WHERE " ? query : "") + ";");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    int iSelected = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Value = Convert.ToInt32(dr["id"]);
                        i.Text = dr["name"].ToString();
                        cbxGrid.Items.Add(i);
                        if (SharedData.iLocationGrid > 0 && Convert.ToInt32(dr["id"]) == SharedData.iLocationGrid)
                        {
                            iSelected = cbxGrid.Items.Count - 1;
                        }
                    }
                    if (iSelected > -1)
                    {
                        cbxGrid.SelectedIndex = iSelected;
                    }
                }
            }
        }

        #endregion

        #region Clicks

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            SharedData.iLocationSite = 0;
            SharedData.sLocationType = "site";

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                SharedData.iLocationArea = 0;
                SharedData.iLocationVessel = 0;
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                if (cbxSite.Items.Count > 0)
                {
                    foreach (DevComponents.Editors.ComboItem i in cbxSite.Items)
                    {
                        if (i.Value.ToString() == SharedData.iLocationSite.ToString())
                        {
                            cbxSite.SelectedItem = i;
                            break;
                        }
                    }
                }
                LoadLocations();
            }
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            if (SharedData.iLocationSite < 1)
            {
                MessageBox.Show("Choose a site to add an area to.", "Choose Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SharedData.iLocationArea = 0;
            SharedData.sLocationType = "area";

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationArea > 0)
            {
                SharedData.iLocationVessel = 0;
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                if (cbxArea.Items.Count > 0)
                {
                    foreach (DevComponents.Editors.ComboItem i in cbxArea.Items)
                    {
                        if (i.Value.ToString() == SharedData.iLocationSite.ToString())
                        {
                            cbxArea.SelectedItem = i;
                            break;
                        }
                    }
                }
                LoadLocations();
            }
        }

        private void btnAddVessel_Click(object sender, EventArgs e)
        {
            if (SharedData.iLocationSite < 1)
            {
                MessageBox.Show("Choose a site to add an area to.", "Choose Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationArea < 1)
            {
                MessageBox.Show("Choose an area to add a vessel to.", "Choose Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SharedData.iLocationVessel = 0;
            SharedData.sLocationType = "vessel";

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationVessel > 0)
            {
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                if (cbxVessel.Items.Count > 0)
                {
                    foreach (DevComponents.Editors.ComboItem i in cbxVessel.Items)
                    {
                        if (i.Value.ToString() == SharedData.iLocationSite.ToString())
                        {
                            cbxVessel.SelectedItem = i;
                            break;
                        }
                    }
                }
                LoadLocations();
            }
        }

        private void btnAddFloor_Click(object sender, EventArgs e)
        {
            if (SharedData.iLocationSite < 1)
            {
                MessageBox.Show("Choose a site to add an area to.", "Choose Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationArea < 1)
            {
                MessageBox.Show("Choose an area to add a vessel to.", "Choose Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationArea < 1)
            {
                MessageBox.Show("Choose a vessel to add a floor to.", "Choose Vessel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SharedData.iLocationFloor = 0;
            SharedData.sLocationType = "floor";

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationFloor > 0)
            {
                SharedData.iLocationGrid = 0;
                if (cbxFloor.Items.Count > 0)
                {
                    foreach (DevComponents.Editors.ComboItem i in cbxFloor.Items)
                    {
                        if (i.Value.ToString() == SharedData.iLocationSite.ToString())
                        {
                            cbxFloor.SelectedItem = i;
                            break;
                        }
                    }
                }
                LoadLocations();
            }
        }

        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            if (SharedData.iLocationSite < 1)
            {
                MessageBox.Show("Choose a site to add an area to.", "Choose Site", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationArea < 1)
            {
                MessageBox.Show("Choose an area to add a vessel to.", "Choose Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationVessel < 1)
            {
                MessageBox.Show("Choose a vessel to add a floor to.", "Choose Vessel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (SharedData.iLocationFloor < 1)
            {
                MessageBox.Show("Choose a floor to add a grid to.", "Choose Floor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SharedData.iLocationGrid = 0;
            SharedData.sLocationType = "grid";

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationGrid > 0)
            {
                if (cbxGrid.Items.Count > 0)
                {
                    foreach (DevComponents.Editors.ComboItem i in cbxGrid.Items)
                    {
                        if (i.Value.ToString() == SharedData.iLocationSite.ToString())
                        {
                            cbxGrid.SelectedItem = i;
                            break;
                        }
                    }
                }
                LoadLocations();
            }
        }

        private void btnEditSite_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxSite.Items[cbxSite.SelectedIndex];
            SharedData.iLocationSite = Convert.ToInt32(i.Value);
            SharedData.sLocationSite = i.Text.ToString();
            SharedData.sLocationType = "site";
            SharedData.bLocationEdit = true;

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                LoadLocations();
            }

            SharedData.iLocationSite = 0;
            SharedData.sLocationSite = "";
            SharedData.sLocationType = "";
            SharedData.bLocationEdit = false;
        }

        private void btnEditArea_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxArea.Items[cbxArea.SelectedIndex];
            SharedData.iLocationArea = Convert.ToInt32(i.Value);
            SharedData.sLocationArea = i.Text.ToString();
            SharedData.sLocationType = "area";
            SharedData.bLocationEdit = true;

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                LoadLocations();
            }

            SharedData.iLocationArea = 0;
            SharedData.sLocationArea = "";
            SharedData.sLocationType = "";
            SharedData.bLocationEdit = false;
        }

        private void btnEditVessel_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxVessel.Items[cbxVessel.SelectedIndex];
            SharedData.iLocationVessel = Convert.ToInt32(i.Value);
            SharedData.sLocationVessel = i.Text.ToString();
            SharedData.sLocationType = "vessel";
            SharedData.bLocationEdit = true;

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                LoadLocations();
            }

            SharedData.iLocationVessel = 0;
            SharedData.sLocationVessel = "";
            SharedData.sLocationType = "";
            SharedData.bLocationEdit = false;
        }

        private void btnEditFloor_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxFloor.Items[cbxFloor.SelectedIndex];
            SharedData.iLocationFloor = Convert.ToInt32(i.Value);
            SharedData.sLocationFloor = i.Text.ToString();
            SharedData.sLocationType = "floor";
            SharedData.bLocationEdit = true;

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                LoadLocations();
            }

            SharedData.iLocationFloor = 0;
            SharedData.sLocationFloor = "";
            SharedData.sLocationType = "";
            SharedData.bLocationEdit = false;
        }

        private void btnEditGrid_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxGrid.Items[cbxGrid.SelectedIndex];
            SharedData.iLocationGrid = Convert.ToInt32(i.Value);
            SharedData.sLocationGrid = i.Text.ToString();
            SharedData.sLocationType = "grid";
            SharedData.bLocationEdit = true;

            Form frmLocation = new frmLocationAdd();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iLocationSite > 0)
            {
                LoadLocations();
            }

            SharedData.iLocationGrid = 0;
            SharedData.sLocationGrid = "";
            SharedData.sLocationType = "";
            SharedData.bLocationEdit = false;
        }

        private void btnDeleteSite_Click(object sender, EventArgs e)
        {
            if (cbxSite.SelectedIndex > 0)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxSite.Items[cbxSite.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove this entry?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM locations_sites WHERE id=" + i.Value.ToString() + ";");
                        if (iRes < 1)
                        {
                            MessageBox.Show("The site removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dlg = MessageBox.Show("The site was removed successfully. Do you want\nto update related items to another location?", "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == DialogResult.Yes)
                            {
                                SharedData.iLocationSite = Convert.ToInt32(i.Value);
                                SharedData.sLocationType = "site";
                                Form frmLocationRemove = new frmLocationRemove();
                                frmLocationRemove.ShowDialog();
                            }

                            LoadLocations();
                        }
                    }
                }
            }
        }

        private void btnDeleteArea_Click(object sender, EventArgs e)
        {
            if (cbxArea.SelectedIndex > 0)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxArea.Items[cbxArea.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove this entry?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM locations_areas WHERE id=" + i.Value.ToString() + ";");
                        if (iRes < 1)
                        {
                            MessageBox.Show("The area removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dlg = MessageBox.Show("The site was removed successfully. Do you want\nto update related items to another location?", "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == DialogResult.Yes)
                            {
                                SharedData.iLocationArea = Convert.ToInt32(i.Value);
                                SharedData.sLocationType = "area";
                                Form frmLocationRemove = new frmLocationRemove();
                                frmLocationRemove.ShowDialog();
                            }

                            LoadLocations();
                        }
                    }
                }
            }
        }

        private void btnDeleteVessel_Click(object sender, EventArgs e)
        {
            if (cbxVessel.SelectedIndex > 0)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxVessel.Items[cbxVessel.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove this entry?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM locations_vessels WHERE id=" + i.Value.ToString() + ";");
                        if (iRes < 1)
                        {
                            MessageBox.Show("The vessel removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dlg = MessageBox.Show("The site was removed successfully. Do you want\nto update related items to another location?", "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == DialogResult.Yes)
                            {
                                SharedData.iLocationVessel = Convert.ToInt32(i.Value);
                                SharedData.sLocationType = "vessel";
                                Form frmLocationRemove = new frmLocationRemove();
                                frmLocationRemove.ShowDialog();
                            }

                            LoadLocations();
                        }
                    }
                }
            }
        }

        private void btnDeleteFloor_Click(object sender, EventArgs e)
        {
            if (cbxFloor.SelectedIndex > 0)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxFloor.Items[cbxFloor.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove this entry?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM locations_floors WHERE id=" + i.Value.ToString() + ";");
                        if (iRes < 1)
                        {
                            MessageBox.Show("The floor removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dlg = MessageBox.Show("The site was removed successfully. Do you want\nto update related items to another location?", "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == DialogResult.Yes)
                            {
                                SharedData.iLocationFloor = Convert.ToInt32(i.Value);
                                SharedData.sLocationType = "floor";
                                Form frmLocationRemove = new frmLocationRemove();
                                frmLocationRemove.ShowDialog();
                            }

                            LoadLocations();
                        }
                    }
                }
            }
        }

        private void btnDeleteGrid_Click(object sender, EventArgs e)
        {
            if (cbxGrid.SelectedIndex > 0)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxGrid.Items[cbxGrid.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove this entry?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM locations_grids WHERE id=" + i.Value.ToString() + ";");
                        if (iRes < 1)
                        {
                            MessageBox.Show("The grid removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            dlg = MessageBox.Show("The site was removed successfully. Do you want\nto update related items to another location?", "Update?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlg == DialogResult.Yes)
                            {
                                SharedData.iLocationGrid = Convert.ToInt32(i.Value);
                                SharedData.sLocationType = "grid";
                                Form frmLocationRemove = new frmLocationRemove();
                                frmLocationRemove.ShowDialog();
                            }

                            LoadLocations();
                        }
                    }
                }
            }
        }

        #endregion

        #region Changes

        private void cbxSite_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxSite.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxSite.Items[cbxSite.SelectedIndex];
                SharedData.iLocationSite = Convert.ToInt32(i.Value);
                SharedData.iLocationArea = 0;
                SharedData.iLocationVessel = 0;
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                LoadLocations();
            }
        }

        private void cbxArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxArea.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxArea.Items[cbxArea.SelectedIndex];
                SharedData.iLocationArea = Convert.ToInt32(i.Value);
                SharedData.iLocationVessel = 0;
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                LoadLocations();
            }
        }

        private void cbxVessel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxVessel.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxVessel.Items[cbxVessel.SelectedIndex];
                SharedData.iLocationVessel = Convert.ToInt32(i.Value);
                SharedData.iLocationFloor = 0;
                SharedData.iLocationGrid = 0;
                LoadLocations();
            }
        }

        private void cbxFloor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxFloor.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxFloor.Items[cbxFloor.SelectedIndex];
                SharedData.iLocationFloor = Convert.ToInt32(i.Value);
                SharedData.iLocationGrid = 0;
                LoadLocations();
            }
        }

        private void cbxGrid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxGrid.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxGrid.Items[cbxGrid.SelectedIndex];
                SharedData.iLocationGrid = Convert.ToInt32(i.Value);
            }
        }

        #endregion
    }
}
