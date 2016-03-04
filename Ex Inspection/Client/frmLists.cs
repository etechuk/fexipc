using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;

namespace Client
{
    public partial class frmLists : MetroForm
    {
        #region Variables

        int iID = 0;
        CultureInfo ci = new CultureInfo("en-GB");

        #endregion

        #region Form

        public frmLists()
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

            cbxType.SelectedIndex = 0;
            LoadCountries();
        }

        #endregion

        #region Loaders

        private void LoadCountries()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_countries;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["code"].ToString() + ": " + dr["name"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadDrawings()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_drawings;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString() + " Rev." + dr["revision"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadHacDrawings()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_drawings_hac;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString() + " Rev." + dr["revision"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadManufacturers()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_manufacturers;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadFaults()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_faults;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["fault"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadTypesDevice()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_types_device;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadTypesProtection()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT * FROM lists_types_protection;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    tv.Nodes.Add(n);
                }
            }
        }

        #endregion

        #region Changes

        private void cbxType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }
            txtCountry.Text = "";
            txtCountryCode.Text = "";
            txtDrawing.Text = "";
            txtDrawingRev.Text = "";
            dtDrawingDate.Text = "";
            txtHacDrawing.Text = "";
            txtHacDrawingRev.Text = "";
            dtHacDrawingDate.Text = "";
            txtTypesProtection.Text = "";
            txtManufacturer.Text = "";
            txtFault.Text = "";

            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];

            switch (i.Value.ToString())
            {
                case "lists_drawings":
                    LoadDrawings();
                    tc.SelectedTab = tiDrawing;
                    break;
                case "lists_drawings_hac":
                    LoadHacDrawings();
                    tc.SelectedTab = tiHacDrawing;
                    break;
                case "lists_faults":
                    LoadFaults();
                    tc.SelectedTab = tiFault;
                    break;
                case "lists_manufacturers":
                    LoadManufacturers();
                    tc.SelectedTab = tiManufacturer;
                    break;
                case "lists_types_device":
                    LoadTypesDevice();
                    tc.SelectedTab = tiTypesDevice;
                    break;
                case "lists_types_protection":
                    LoadTypesProtection();
                    tc.SelectedTab = tiTypesProtection;
                    break;
                default:
                    LoadCountries();
                    tc.SelectedTab = tiCountry;
                    break;
            }
        }

        #endregion

        #region Node Clicks

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                iID = Convert.ToInt32(e.Node.Tag);
                Program.SQL.AddParameter("id", iID);

                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];
                string sTable = "", sListType = i.Value != null ? i.Value.ToString() : "";

                switch (sListType)
                {
                    case "lists_drawings":
                        sTable = "lists_drawings";
                        break;
                    case "lists_drawings_hac":
                        sTable = "lists_drawings_hac";
                        break;
                    case "lists_faults":
                        sTable = "lists_faults";
                        break;
                    case "lists_manufacturers":
                        sTable = "lists_manufacturers";
                        break;
                    case "lists_types_device":
                        sTable = "lists_types_device";
                        break;
                    case "lists_types_protection":
                        sTable = "lists_types_protection";
                        break;
                    default:
                        sTable = "lists_countries";
                        break;
                }

                DataSet ds = Program.SQL.SelectAll("SELECT * FROM " + sTable + " WHERE id=@id;");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = ds.Tables[0].Rows[0];

                    switch (sListType)
                    {
                        case "lists_drawings":
                            txtDrawing.Text = r["name"].ToString();
                            txtDrawingRev.Text = r["revision"].ToString();
                            dtDrawingDate.Value = DateTime.Parse(r["date"].ToString());
                            break;
                        case "lists_drawings_hac":
                            txtHacDrawing.Text = r["name"].ToString();
                            txtHacDrawingRev.Text = r["revision"].ToString();
                            dtHacDrawingDate.Value = DateTime.Parse(r["date"].ToString());
                            break;
                        case "lists_faults":
                            txtFault.Text = r["fault"].ToString();
                            break;
                        case "lists_manufacturers":
                            txtManufacturer.Text = r["name"].ToString();
                            break;
                        case "lists_types_device":
                            txtTypesDevice.Text = r["name"].ToString();
                            break;
                        case "lists_types_protection":
                            txtTypesProtection.Text = r["name"].ToString();
                            break;
                        default:
                            txtCountry.Text = r["name"].ToString();
                            txtCountryCode.Text = r["code"].ToString();
                            break;
                    }
                }
            }
        }

        private void tv_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            Enable();
        }

        #endregion

        #region Button Clicks

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];
            string sTable = "", sInsertCols = "", sInsertVals = "", sUpdate = "", sListType = i.Value != null ? i.Value.ToString() : "";

            switch (sListType)
            {
                case "lists_drawings":
                    if (txtDrawing.Text.Trim().Length == 0 || txtDrawingRev.Text.Trim().Length == 0 || dtDrawingDate.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("All drawing details must be provided to continue.", "Drawing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name,revision,date";
                    sInsertVals = "@name,@revision,@date";
                    sUpdate = "name=@name,revision=@revision,date=@date";
                    sTable = "lists_drawings";
                    Program.SQL.AddParameter("name", txtDrawing.Text.Trim());
                    Program.SQL.AddParameter("revision", txtDrawingRev.Text.Trim());
                    Program.SQL.AddParameter("date", dtDrawingDate.Value);
                    break;
                case "lists_drawings_hac":
                    if (txtHacDrawing.Text.Trim().Length == 0 || txtHacDrawingRev.Text.Trim().Length == 0 || dtHacDrawingDate.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("All HAC drawing details must be provided to continue.", "HAC Drawing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name,revision,date";
                    sInsertVals = "@name,@revision,@date";
                    sUpdate = "name=@name,revision=@revision,date=@date";
                    sTable = "lists_drawings_hac";
                    Program.SQL.AddParameter("name", txtHacDrawing.Text.Trim());
                    Program.SQL.AddParameter("revision", txtHacDrawingRev.Text.Trim());
                    Program.SQL.AddParameter("date", dtHacDrawingDate.Value);
                    break;
                case "lists_faults":
                    if (txtFault.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("A fault must be provided to continue.", "Fault", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "fault";
                    sInsertVals = "@fault";
                    sUpdate = "fault=@fault";
                    sTable = "lists_faults";
                    Program.SQL.AddParameter("fault", txtFault.Text.Trim());
                    break;
                case "lists_manufacturers":
                    if (txtManufacturer.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("A name must be provided to continue.", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name";
                    sInsertVals = "@name";
                    sUpdate = "name=@name";
                    sTable = "lists_manufacturers";
                    Program.SQL.AddParameter("name", txtManufacturer.Text.Trim());
                    break;
                case "lists_types_device":
                    if (txtTypesProtection.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("A name must be provided to continue.", "Device Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name";
                    sInsertVals = "@name";
                    sUpdate = "name=@name";
                    sTable = "lists_types_device";
                    Program.SQL.AddParameter("name", txtTypesProtection.Text.Trim());
                    break;
                case "lists_types_protection":
                    if (txtTypesProtection.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("A name must be provided to continue.", "Protection Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name";
                    sInsertVals = "@name";
                    sUpdate = "name=@name";
                    sTable = "lists_types_protection";
                    Program.SQL.AddParameter("name", txtTypesProtection.Text.Trim());
                    break;
                default:
                    if (txtCountry.Text.Trim().Length == 0 || txtCountryCode.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("All country details must be provided to continue.", "Country", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    sInsertCols = "name,code";
                    sInsertVals = "@name,@code";
                    sUpdate = "name=@name,code=@code";
                    sTable = "lists_countries";
                    Program.SQL.AddParameter("name", txtCountry.Text.Trim());
                    Program.SQL.AddParameter("code", txtCountryCode.Text.Trim());
                    break;
            }

            int iRes = 0;
            if (iID > 0)
            {
                Program.SQL.AddParameter("id", iID);
                iRes = Program.SQL.Update("UPDATE " + sTable + " SET " + sUpdate + " WHERE id=@id");
                if (iRes < 1)
                {
                    MessageBox.Show("The update failed. Please try again.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    MessageBox.Show("The update was successful.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                iRes = Program.SQL.Insert("INSERT INTO " + sTable + " (" + sInsertCols + ") VALUES (" + sInsertVals + ")");
                if (iRes < 1)
                {
                    MessageBox.Show("The addition failed. Please try again.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else
                {
                    MessageBox.Show("The addition was successful.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Enable(false);

            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            switch (sListType)
            {
                case "lists_drawings":
                    LoadDrawings();
                    break;
                case "lists_drawings_hac":
                    LoadHacDrawings();
                    break;
                case "lists_faults":
                    LoadFaults();
                    break;
                case "lists_manufacturers":
                    LoadManufacturers();
                    break;
                case "lists_types_device":
                    LoadTypesDevice();
                    break;
                case "lists_types_protection":
                    LoadTypesProtection();
                    break;
                default:
                    LoadCountries();
                    break;
            }
        }

        #endregion

        #region Menu Clicks

        private void cmAdd_Click(object sender, EventArgs e)
        {
            iID = 0;

            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];
            string sListType = i.Value != null ? i.Value.ToString() : "";

            switch (sListType)
            {
                case "lists_drawings":
                    txtDrawing.Text = "";
                    txtDrawingRev.Text = "";
                    dtDrawingDate.Text = "";
                    txtDrawing.Enabled = true;
                    txtDrawingRev.Enabled = true;
                    dtDrawingDate.Enabled = true;
                    break;
                case "lists_drawings_hac":
                    txtHacDrawing.Text = "";
                    txtHacDrawingRev.Text = "";
                    dtHacDrawingDate.Text = "";
                    txtHacDrawing.Enabled = true;
                    txtHacDrawingRev.Enabled = true;
                    dtHacDrawingDate.Enabled = true;
                    break;
                case "lists_faults":
                    txtFault.Text = "";
                    txtFault.Enabled = true;
                    break;
                case "lists_manufacturers":
                    txtManufacturer.Text = "";
                    txtManufacturer.Enabled = true;
                    break;
                case "lists_types_device":
                    txtTypesDevice.Text = "";
                    txtTypesDevice.Enabled = true;
                    break;
                case "lists_types_protection":
                    txtTypesProtection.Text = "";
                    txtTypesProtection.Enabled = true;
                    break;
                default:
                    txtCountry.Text = "";
                    txtCountryCode.Text = "";
                    txtCountry.Enabled = true;
                    txtCountryCode.Enabled = true;
                    break;
            }

            cbxType.Enabled = false;
            tv.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
        }

        private void cmRemove_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNodes.Count < 1)
            {
                return;
            }

            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];
            string sTable = "", sIDs = "", sListType = i.Value != null ? i.Value.ToString() : "";

            foreach (DevComponents.AdvTree.Node n in tv.Nodes)
            {
                if (n.Checked && n.Tag != null && n.Tag.ToString().All(char.IsDigit))
                {
                    sIDs += sIDs.Length > 0 ? "," + n.Tag.ToString() : n.Tag.ToString();
                }
            }

            switch (sListType)
            {
                case "lists_drawings":
                    sTable = "lists_drawings";
                    break;
                case "lists_drawings_hac":
                    sTable = "lists_drawings_hac";
                    break;
                case "lists_faults":
                    sTable = "lists_faults";
                    break;
                case "lists_manufacturers":
                    sTable = "lists_manufacturers";
                    break;
                case "lists_types_device":
                    sTable = "lists_types_device";
                    break;
                case "lists_types_protection":
                    sTable = "lists_types_protection";
                    break;
                default:
                    sTable = "lists_countries";
                    break;
            }

            int iRes = Program.SQL.Delete("DELETE FROM " + sTable + " WHERE id IN (" + sIDs + ");");
            if (iRes < 1)
            {
                MessageBox.Show("The removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                MessageBox.Show("The removal was successful.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            switch (sListType)
            {
                case "lists_drawings":
                    LoadDrawings();
                    break;
                case "lists_drawings_hac":
                    LoadHacDrawings();
                    break;
                case "lists_faults":
                    LoadFaults();
                    break;
                case "lists_manufacturers":
                    LoadManufacturers();
                    break;
                case "lists_types_device":
                    LoadTypesDevice();
                    break;
                case "lists_types_protection":
                    LoadTypesProtection();
                    break;
                default:
                    LoadCountries();
                    break;
            }
        }

        #endregion

        private void Enable(bool bEnable = true)
        {
            if (!bEnable)
            {
                txtDrawing.Text = "";
                txtDrawingRev.Text = "";
                dtDrawingDate.Text = "";
                txtHacDrawing.Text = "";
                txtHacDrawingRev.Text = "";
                dtHacDrawingDate.Text = "";
                txtFault.Text = "";
                txtManufacturer.Text = "";
                txtTypesDevice.Text = "";
                txtTypesProtection.Text = "";
                txtCountry.Text = "";
                txtCountryCode.Text = "";
                txtDrawing.Enabled = false;
                txtDrawingRev.Enabled = false;
                dtDrawingDate.Enabled = false;
                txtHacDrawing.Enabled = false;
                txtHacDrawingRev.Enabled = false;
                dtHacDrawingDate.Enabled = false;
                txtFault.Enabled = false;
                txtManufacturer.Enabled = false;
                txtTypesDevice.Enabled = false;
                txtTypesProtection.Enabled = false;
                txtCountry.Enabled = false;
                txtCountryCode.Enabled = false;
                cbxType.Enabled = true;
                tv.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxType.Items[cbxType.SelectedIndex];
                string sListType = i.Value != null ? i.Value.ToString() : "";

                switch (sListType)
                {
                    case "lists_drawings":
                        txtDrawing.Enabled = true;
                        txtDrawingRev.Enabled = true;
                        dtDrawingDate.Enabled = true;
                        ActiveControl = txtDrawing;
                        txtDrawing.Focus();
                        break;
                    case "lists_drawings_hac":
                        txtHacDrawing.Enabled = true;
                        txtHacDrawingRev.Enabled = true;
                        dtHacDrawingDate.Enabled = true;
                        ActiveControl = txtHacDrawing;
                        txtHacDrawing.Focus();
                        break;
                    case "lists_faults":
                        txtFault.Enabled = true;
                        ActiveControl = txtFault;
                        txtFault.Focus();
                        break;
                    case "lists_manufacturers":
                        txtManufacturer.Enabled = true;
                        ActiveControl = txtManufacturer;
                        txtManufacturer.Focus();
                        break;
                    case "lists_types_device":
                        txtTypesDevice.Enabled = true;
                        ActiveControl = txtTypesDevice;
                        txtTypesDevice.Focus();
                        break;
                    case "lists_types_protection":
                        txtTypesProtection.Enabled = true;
                        ActiveControl = txtTypesProtection;
                        txtTypesProtection.Focus();
                        break;
                    default:
                        txtCountry.Enabled = true;
                        txtCountryCode.Enabled = true;
                        ActiveControl = txtCountry;
                        txtCountry.Focus();
                        break;
                }

                cbxType.Enabled = false;
                tv.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void tc_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {
            switch (tc.SelectedTab.Name)
            {
                case "tiDrawing":
                    cbxType.SelectedItem = cbxiTypeDrawings;
                    LoadDrawings();
                    break;
                case "tiHacDrawing":
                    cbxType.SelectedItem = cbxiTypeHacDrawings;
                    LoadHacDrawings();
                    break;
                case "tiManufacturer":
                    cbxType.SelectedItem = cbxiTypeManufacturers;
                    LoadManufacturers();
                    break;
                case "tiFault":
                    cbxType.SelectedItem = cbxiTypeFaults;
                    LoadFaults();
                    break;
                case "tiTypesDevice":
                    cbxType.SelectedItem = cbxiTypeDevices;
                    LoadTypesDevice();
                    break;
                case "tiTypesProtection":
                    cbxType.SelectedItem = cbxiTypeProtections;
                    LoadTypesProtection();
                    break;
                default:
                    cbxType.SelectedItem = cbxiTypeCountries;
                    LoadCountries();
                    break;
            }
        }
    }
}
