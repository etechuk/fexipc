using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace Client
{
    public partial class frmUsers : MetroForm
    {
        #region Variables

        int iID = 0;

        #endregion

        #region Form

        public frmUsers()
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

            LoadUsers();
            LoadLocations();
            Enable(false);
        }

        #endregion

        #region Loaders

        private void LoadUsers()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT id,name_first,name_last FROM users;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name_first"].ToString() + " " + dr["name_last"].ToString();
                    tv.Nodes.Add(n);
                }
            }
        }

        private void LoadLocations()
        {
            if (cbxLocation.Items.Count > 0)
            {
                cbxLocation.Items.Clear();
            }

            DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
            i.Value = "0";
            i.Text = "All Locations";
            cbxLocation.Items.Add(i);

            DataSet ds = Program.SQL.SelectAll("SELECT id,name FROM locations_sites;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    i = new DevComponents.Editors.ComboItem();
                    i.Value = dr["id"].ToString();
                    i.Text = dr["name"].ToString();
                    cbxLocation.Items.Add(i);
                }
            }
        }

        #endregion

        #region Node Clicks

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (tv.SelectedNode.Tag != null)
            {
                iID = Convert.ToInt32(tv.SelectedNode.Tag);

                Program.SQL.AddParameter("@id", iID);
                DataSet d = Program.SQL.SelectAll("SELECT * FROM users WHERE id=@id;");
                if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                {
                    DataRow r = d.Tables[0].Rows[0];

                    txtUsername.Text = r["username"].ToString();
                    txtNameFirst.Text = r["name_first"].ToString();
                    txtNameLast.Text = r["name_last"].ToString();
                    txtNotes.Text = r["notes"].ToString();
                    txtSuperCode.Text = r["supercode"].ToString();

                    foreach (DevComponents.Editors.ComboItem i in cbxGroup.Items)
                    {
                        if (i.Value.Equals(r["usergroup"].ToString()))
                        {
                            cbxGroup.SelectedItem = i;
                            break;
                        }
                    }

                    foreach (DevComponents.Editors.ComboItem i in cbxStatus.Items)
                    {
                        if (i.Value.Equals(r["status"].ToString()))
                        {
                            cbxStatus.SelectedItem = i;
                            break;
                        }
                    }
                    
                    foreach (DevComponents.Editors.ComboItem i in cbxLocation.Items)
                    {
                        if (i.Value.Equals(r["location"].ToString()))
                        {
                            cbxLocation.SelectedItem = i;
                            break;
                        }
                    }

                    cbxEmail.Items.Clear();
                    string[] sEmails = r["emails"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sEmails.Length > 0)
                    {
                        foreach (string sEmail in sEmails)
                        {
                            cbxEmail.Items.Add(sEmail);
                        }
                        if (cbxEmail.Items.Count > 0)
                        {
                            cbxEmail.SelectedIndex = 0;
                        }
                    }

                    cbxPhone.Items.Clear();
                    string[] sPhones = r["phones"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sPhones.Length > 0)
                    {
                        foreach (string sPhone in sPhones)
                        {
                            cbxPhone.Items.Add(sPhone);
                        }
                        if (cbxPhone.Items.Count > 0)
                        {
                            cbxPhone.SelectedIndex = 0;
                        }
                    }

                    cbxPostal.Items.Clear();
                    string[] sAddresses = r["addresses"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sAddresses.Length > 0)
                    {
                        foreach (string sAddress in sAddresses)
                        {
                            string[] sPostal = sAddress.Split(new char[] { '|' });
                            DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                            i.Value = sAddress;
                            i.Text = sPostal[0].Trim() + (sPostal[5].Trim() != "" ? ", " + sPostal[5].Trim() : "") + ", " + sPostal[6].Trim();
                            cbxPostal.Items.Add(i);
                        }
                        if (cbxPostal.Items.Count > 0)
                        {
                            cbxPostal.SelectedIndex = 0;
                        }
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
            if (txtUsername.Text.Trim().Length < 1)
            {
                MessageBox.Show("A username must be provided to continue.", "Username", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (iID == 0 && SharedData.sPassword.Trim().Length < 1)
            {
                MessageBox.Show("A password must be provided to continue.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (txtNameFirst.Text.Trim().Length < 1)
            {
                MessageBox.Show("A first name must be provided to continue.", "First Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (txtNameLast.Text.Trim().Length < 1)
            {
                MessageBox.Show("A last name must be provided to continue.", "Last Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (cbxGroup.SelectedIndex < 0)
            {
                MessageBox.Show("A group must be provided to continue.", "Group", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (cbxStatus.SelectedIndex < 0)
            {
                MessageBox.Show("A status must be provided to continue.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            string sInsertCols = "name_first,name_last,username,supercode,notes";
            string sInsertVals = "@name_first,@name_last,@username,@supercode,@notes";
            string sUpdate = "name_first=@name_first,name_last=@name_last,username=@username,supercode=@supercode,notes=@notes";

            Program.SQL.AddParameter("name_first", txtNameFirst.Text.Trim());
            Program.SQL.AddParameter("name_last", txtNameLast.Text.Trim());
            Program.SQL.AddParameter("username", txtUsername.Text.Trim());
            Program.SQL.AddParameter("supercode", txtSuperCode.Text.Trim());
            Program.SQL.AddParameter("notes", txtNotes.Text.Trim());
            Program.SQL.AddParameter("mod", DateTime.Now);

            DevComponents.Editors.ComboItem i;

            sInsertCols += ",usergroup";
            sInsertVals += ",@usergroup";
            sUpdate += ",usergroup=@usergroup";
            i = (DevComponents.Editors.ComboItem)cbxGroup.Items[cbxGroup.SelectedIndex];
            Program.SQL.AddParameter("usergroup", Convert.ToInt32(i.Value));

            sInsertCols += ",status";
            sInsertVals += ",@status";
            sUpdate += ",status=@status";
            i = (DevComponents.Editors.ComboItem)cbxStatus.Items[cbxStatus.SelectedIndex];
            Program.SQL.AddParameter("status", Convert.ToInt32(i.Value));

            if (cbxLocation.SelectedIndex > -1)
            {
                sInsertCols += ",location";
                sInsertVals += ",@location";
                sUpdate += ",location=@location";
                i = (DevComponents.Editors.ComboItem)cbxLocation.Items[cbxLocation.SelectedIndex];
                Program.SQL.AddParameter("location", Convert.ToInt32(i.Value));
            }

            if (cbxEmail.Items.Count > 0)
            {
                string sEmails = "";
                foreach (string ci in cbxEmail.Items)
                {
                    sEmails += "{" + ci + "}";
                }
                sInsertCols += ",emails";
                sInsertVals += ",@emails";
                sUpdate += ",emails=@emails";
                Program.SQL.AddParameter("emails", sEmails);
            }

            if (cbxPhone.Items.Count > 0)
            {
                string sPhones = "";
                foreach (string ci in cbxPhone.Items)
                {
                    sPhones += "{" + ci + "}";
                }
                sInsertCols += ",phones";
                sInsertVals += ",@phones";
                sUpdate += ",phones=@phones";
                Program.SQL.AddParameter("phones", sPhones);
            }

            if (cbxPostal.Items.Count > 0)
            {
                string sPostal = "";
                foreach (DevComponents.Editors.ComboItem ci in cbxPostal.Items)
                {
                    sPostal += "{" + ci.Value + "}";
                }
                sInsertCols += ",addresses";
                sInsertVals += ",@addresses";
                sUpdate += ",addresses=@addresses";
                Program.SQL.AddParameter("addresses", sPostal);
            }

            if (SharedData.sPassword.Length > 0)
            {
                sInsertCols += ",password";
                sInsertVals += ",@password";
                sUpdate += ",password=@password";
                Program.SQL.AddParameter("password", Program.Globals.EncodePassword(SharedData.sPassword));
            }

            if (iID > 0)
            {
                Program.SQL.AddParameter("id", iID);
                int iRes = Program.SQL.Update("UPDATE users SET " + sUpdate + " WHERE id=@id;");
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
                Program.SQL.AddParameter("ent", DateTime.Now);
                int iRes = Program.SQL.Insert("INSERT INTO users (" + sInsertCols + ",ent) VALUES (" + sInsertVals + ",@ent)");
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

            SharedData.sPassword = "";
            Enable(false);
            LoadUsers();
        }

        private void btnPassReset_Click(object sender, EventArgs e)
        {
            Form frmPassword = new frmPassword();
            DialogResult dlg = frmPassword.ShowDialog();
            if (dlg != DialogResult.OK)
            {
                SharedData.sPassword = "";
            }
            return;
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            Form frmPhone = new frmPhone();
            DialogResult dlg = frmPhone.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.sPhone.Length > 0)
            {
                bool bExists = false;

                foreach (string s in cbxPhone.Items)
                {
                    if (s.ToLower() == SharedData.sPhone.ToLower())
                    {
                        bExists = true;
                    }
                }

                if (bExists)
                {
                    MessageBox.Show("The number entered already exists.", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    cbxPhone.Items.Add(SharedData.sPhone);
                    cbxPhone.SelectedIndex = cbxPhone.Items.Count - 1;
                }

                SharedData.sPhone = "";
            }
            return;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Form frmEmail = new frmEmail();
            DialogResult dlg = frmEmail.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.sEmail.Length > 0)
            {
                bool bExists = false;

                foreach (string s in cbxEmail.Items)
                {
                    if (s.ToLower() == SharedData.sEmail.ToLower())
                    {
                        bExists = true;
                    }
                }

                if (bExists)
                {
                    MessageBox.Show("The address entered already exists.", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    cbxEmail.Items.Add(SharedData.sEmail);
                    cbxEmail.SelectedIndex = cbxEmail.Items.Count - 1;
                }

                SharedData.sEmail = "";
            }
            return;
        }

        private void btnPostal_Click(object sender, EventArgs e)
        {
            Form frmPostal = new frmPostal();
            DialogResult dlg = frmPostal.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.sPostal.Length > 0)
            {
                bool bExists = false;

                foreach (DevComponents.Editors.ComboItem i in cbxPostal.Items)
                {
                    if (i.Value.ToString().ToLower() == SharedData.sPostal.ToLower())
                    {
                        bExists = true;
                    }
                }

                if (bExists)
                {
                    MessageBox.Show("The address entered already exists.", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string[] sPostal = SharedData.sPostal.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = SharedData.sPostal;
                    i.Text = sPostal[0] + ", " + sPostal[5];
                    cbxPostal.Items.Add(i);
                    cbxPostal.SelectedIndex = cbxPostal.Items.Count - 1;
                }

                SharedData.sPostal = "";
            }
            return;
        }

        #endregion

        private void Enable(bool bEnable = true)
        {
            if (!bEnable)
            {
                iID = 0;
                txtNameFirst.Text = "";
                txtNameLast.Text = "";
                txtNotes.Text = "";
                txtSuperCode.Text = "";
                txtUsername.Text = "";
                cbxGroup.SelectedIndex = -1;
                cbxStatus.SelectedIndex = -1;
                cbxLocation.SelectedIndex = -1;
                cbxEmail.Items.Clear();
                cbxPhone.Items.Clear();
                cbxPostal.Items.Clear();
                gDocs.PrimaryGrid.Rows.Clear();
                foreach (GridRow i in gCaps.PrimaryGrid.Rows)
                {
                    i.Checked = false;
                }
                foreach (GridRow i in gQuals.PrimaryGrid.Rows)
                {
                    i.Checked = false;
                }
                txtNameFirst.Enabled = false;
                txtNameLast.Enabled = false;
                txtNotes.Enabled = false;
                txtSuperCode.Enabled = false;
                txtUsername.Enabled = false;
                cbxEmail.Enabled = false;
                cbxGroup.Enabled = false;
                cbxLocation.Enabled = false;
                cbxPhone.Enabled = false;
                cbxPostal.Enabled = false;
                cbxStatus.Enabled = false;
                btnCancel.Enabled = false;
                btnEmail.Enabled = false;
                btnPassReset.Enabled = false;
                btnPhone.Enabled = false;
                btnPostal.Enabled = false;
                btnSave.Enabled = false;
                gCaps.Enabled = false;
                gDocs.Enabled = false;
                gQuals.Enabled = false;
            }
            else
            {
                txtNameFirst.Enabled = true;
                txtNameLast.Enabled = true;
                txtNotes.Enabled = true;
                txtSuperCode.Enabled = true;
                txtUsername.Enabled = true;
                cbxEmail.Enabled = true;
                cbxGroup.Enabled = true;
                cbxLocation.Enabled = true;
                cbxPhone.Enabled = true;
                cbxPostal.Enabled = true;
                cbxStatus.Enabled = true;
                btnCancel.Enabled = true;
                btnEmail.Enabled = true;
                btnPassReset.Enabled = true;
                btnPhone.Enabled = true;
                btnPostal.Enabled = true;
                btnSave.Enabled = true;
                gCaps.Enabled = true;
                gDocs.Enabled = true;
                gQuals.Enabled = true;
            }
        }

        #region Menu Clicks

        private void cmiUserAdd_Click(object sender, EventArgs e)
        {
            iID = 0;
            txtNameFirst.Text = "";
            txtNameLast.Text = "";
            txtNotes.Text = "";
            txtSuperCode.Text = "";
            txtUsername.Text = "";
            cbxGroup.SelectedIndex = -1;
            cbxStatus.SelectedIndex = -1;
            cbxLocation.SelectedIndex = -1;
            cbxEmail.Items.Clear();
            cbxPhone.Items.Clear();
            cbxPostal.Items.Clear();
            gDocs.PrimaryGrid.Rows.Clear();
            foreach (GridRow i in gCaps.PrimaryGrid.Rows)
            {
                i.Checked = false;
            }
            foreach (GridRow i in gQuals.PrimaryGrid.Rows)
            {
                i.Checked = false;
            }
            Enable();
        }

        private void cmiUserRemove_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        #endregion

        #region Changed

        private void btnPhone_MouseEnter(object sender, EventArgs e)
        {
            btnPhone.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnPhone_MouseLeave(object sender, EventArgs e)
        {
            btnPhone.Image = Properties.Resources.btn_data_add_16_off;
        }

        private void btnEmail_MouseEnter(object sender, EventArgs e)
        {
            btnEmail.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnEmail_MouseLeave(object sender, EventArgs e)
        {
            btnEmail.Image = Properties.Resources.btn_data_add_16_off;
        }

        private void btnPostal_MouseEnter(object sender, EventArgs e)
        {
            btnPostal.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnPostal_MouseLeave(object sender, EventArgs e)
        {
            btnPostal.Image = Properties.Resources.btn_data_add_16_off;
        }

        #endregion
    }
}
