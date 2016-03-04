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
    public partial class frmSchedulesSections : MetroForm
    {
        #region Variables

        DataSet ds;
        int iID = 0;

        #endregion

        #region Form

        public frmSchedulesSections()
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

            LoadData();
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            tv.Nodes.Clear();
            cbxParent.Items.Clear();

            ds = Program.SQL.SelectAll("SELECT * FROM schedules_sections;");
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node tn = new DevComponents.AdvTree.Node();
                    string sName = row["name"].ToString();
                    if (Convert.ToInt32(row["parent"]) == 0)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Tag = row["id"];
                        i.Text = sName;
                        cbxParent.Items.Add(i);
                    }
                    tn.Text = sName;
                    tn.Tag = row["id"].ToString();
                    tv.Nodes.Add(tn);
                }
            }
        }

        private void Enable(bool bEnable = true)
        {
            if (!bEnable)
            {
                iID = 0;
                txtName.Text = "";
                cbxParent.SelectedIndex = -1;
                txtName.Enabled = false;
                cbxParent.Enabled = false;
                tv.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
                cbxParent.Enabled = true;
                tv.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        #endregion

        #region Node Clicks

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag.ToString() != "")
            {
                iID = Convert.ToInt32(e.Node.Tag);
            }

            if (iID > 0 && ds.Tables.Count == 1)
            {
                cbxParent.SelectedIndex = -1;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (Convert.ToInt32(row["id"]) == iID)
                    {
                        txtName.Text = row["name"].ToString();
                        DataSet d = Program.SQL.SelectAll("SELECT id,name FROM schedules_sections WHERE ID=" + row["parent"].ToString() + ";");
                        if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                        {
                            foreach (DevComponents.Editors.ComboItem i in cbxParent.Items)
                            {
                                if (i.Tag.ToString() == d.Tables[0].Rows[0]["id"].ToString())
                                {
                                    cbxParent.SelectedItem = i;
                                    break;
                                }
                            }
                        }
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
            Program.SQL.AddParameter("@name", txtName.Text.Trim());
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxParent.Items[cbxParent.SelectedIndex];
            Program.SQL.AddParameter("@parent", i != null && i.Tag != null ? Convert.ToInt32(i.Tag) : 0);
            Program.SQL.AddParameter("@mod", DateTime.Now);

            if (iID > 0)
            {
                Program.SQL.AddParameter("@ent", DateTime.Now);
                iID = Program.SQL.Insert("INSERT INTO schedules_sections (name,parent,entered,modified) VALUES (@name,@parent,@ent,@mod)");
                if (iID < 1)
                {
                    MessageBox.Show("The addition failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Program.SQL.AddParameter("@id", tv.SelectedNode.Tag);
                iID = Program.SQL.Update("UPDATE schedules_sections SET name=@name,parent=@parent,modified=@mod WHERE id=@id;");
                if (iID < 1)
                {
                    MessageBox.Show("The update failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Enable(false);
        }

        #endregion

        #region Menu Clicks

        private void cmAdd_Click(object sender, EventArgs e)
        {
            iID = 0;
            txtName.Text = "";
            cbxParent.SelectedIndex = -1;
            Enable();
        }

        private void cmRemove_Click(object sender, EventArgs e)
        {
            iID = Program.SQL.Delete("DELETE FROM schedules_sections WHERE id=" + tv.SelectedNode.Tag + ";");
            if (iID < 1)
            {
                MessageBox.Show("The removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("The removal was successful.");
            Enable(false);
            LoadData();
        }

        #endregion
    }
}
