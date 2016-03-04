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
    public partial class frmSchedulesQuestions : MetroForm
    {

        #region Variables

        DataSet ds;
        int iID = 0;
        int iPart = -1;

        #endregion

        #region Form

        public frmSchedulesQuestions()
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

            if (!frmSchedules.bIsQuestion)
            {
                Text = "Manage Notes";
                lblEntry.Text = "Note:";
                cmAdd.Text = "Add note";
                cmRemove.Text = "Remove note";
                lblSection.Visible = false;
                lblLetter.Visible = false;
                lblNumber.Visible = false;
                cbxSection.Visible = false;
                cbxLetter.Visible = false;
                cbxNumber.Visible = false;
                chkMultiPart.Enabled = false;
                btnSections.Visible = false;
                tiParts.Visible = false;
            }
            else
            {
                DataSet d = Program.SQL.SelectAll("SELECT * FROM schedules_sections;");
                if (d.Tables.Count > 0)
                {
                    foreach (DataRow row in d.Tables[0].Rows)
                    {
                        DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                        i.Tag = row["id"];
                        i.Text = row["name"].ToString();
                        cbxSection.Items.Add(i);
                    }
                }

                for (int i = 65; i < 91; i++)
                {
                    cbxLetter.Items.Add((Char)i);
                }

                for (int i = 1; i < 100; i++)
                {
                    cbxNumber.Items.Add(i);
                }
            }

            LoadData();
        }

        #endregion

        #region Methods

        private void LoadData()
        {
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes.Clear();
            }

            ds = !frmSchedules.bIsQuestion ? Program.SQL.SelectAll("SELECT id,note FROM schedules_notes ORDER BY CAST(note as VARCHAR(100));") : Program.SQL.SelectAll("SELECT id,question,section,letter,number FROM schedules_questions ORDER BY letter,number,CAST(question as VARCHAR(100));");

            if (!frmSchedules.bIsQuestion)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node tn = new DevComponents.AdvTree.Node();
                    tn.Tag = dr["id"].ToString();
                    tn.Text = dr["note"].ToString();
                    tn.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    tn.CheckBoxVisible = true;
                    tv.Nodes.Add(tn);
                }
            }
            else
            {
                DataSet d = Program.SQL.SelectAll("SELECT id,name FROM schedules_sections;");
                if (d.Tables.Count > 0)
                {
                    foreach (DataRow sr in d.Tables[0].Rows)
                    {
                        DevComponents.AdvTree.Node tn = new DevComponents.AdvTree.Node();
                        tn.Tag = "s" + sr["id"].ToString();
                        tn.Text = sr["name"].ToString();

                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            if (dr["section"].ToString() == sr["id"].ToString())
                            {
                                DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                                string sRef = "";
                                if (dr["letter"].ToString().Length > 0)
                                {
                                    sRef = dr["letter"].ToString();
                                }
                                if (Convert.ToInt32(dr["number"]) > 0)
                                {
                                    sRef += Convert.ToInt32(dr["number"]).ToString("D2") + ": ";
                                }
                                n.Text = sRef + dr["question"].ToString();
                                n.Tag = dr["id"];
                                n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                                n.CheckBoxVisible = true;
                                tn.Nodes.Add(n);
                            }
                        }

                        tv.Nodes.Add(tn);
                    }
                }
            }

            tv.ExpandAll();
        }

        private void Enable(bool bEnable = true)
        {
            if (!bEnable)
            {
                iID = 0;
                txtEntry.Text = "";
                txtPart.Text = "";
                cbxLetter.SelectedIndex = -1;
                cbxNumber.SelectedIndex = -1;
                cbxSection.SelectedIndex = -1;
                txtEntry.Enabled = false;
                txtPart.Enabled = false;
                lbxParts.Enabled = false;
                cbxLetter.Enabled = false;
                cbxNumber.Enabled = false;
                cbxSection.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnSections.Enabled = false;
                tv.Enabled = true;
            }
            else
            {
                txtEntry.Enabled = true;
                lbxParts.Enabled = true;
                cbxLetter.Enabled = true;
                cbxNumber.Enabled = true;
                cbxSection.Enabled = true;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
                btnSections.Enabled = true;
                tv.Enabled = false;
            }
        }

        #endregion

        #region Node/List Clicks

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString().All(char.IsDigit))
            {
                iID = Convert.ToInt32(e.Node.Tag);
                txtPart.Text = "";
                chkMultiPart.Checked = false;
                cbxSection.SelectedItem = -1;
                cbxLetter.SelectedItem = -1;
                cbxNumber.SelectedItem = -1;

                Program.SQL.AddParameter("id", iID);
                DataSet d = !frmSchedules.bIsQuestion ? Program.SQL.SelectAll("SELECT note FROM schedules_notes WHERE id=@id;") : Program.SQL.SelectAll("SELECT section,letter,number,question,parts FROM schedules_questions WHERE id=@id;");
                if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                {
                    DataRow r = d.Tables[0].Rows[0];
                    txtEntry.Text = !frmSchedules.bIsQuestion ? r["note"].ToString() : r["question"].ToString();

                    if (frmSchedules.bIsQuestion)
                    {
                        foreach (DevComponents.Editors.ComboItem i in cbxSection.Items)
                        {
                            if (i.Tag != null && i.Tag.ToString() == r["section"].ToString())
                            {
                                cbxSection.SelectedItem = i;
                                break;
                            }
                        }

                        for (int i = 0; i < cbxLetter.Items.Count; i++)
                        {
                            if (cbxLetter.Items[i].ToString().Equals(r["letter"].ToString()))
                            {
                                cbxLetter.SelectedIndex = i;
                                break;
                            }
                        }

                        for (int i = 0; i < cbxNumber.Items.Count; i++)
                        {
                            if (cbxNumber.Items[i].ToString().Equals(r["number"].ToString()))
                            {
                                cbxNumber.SelectedIndex = i;
                                break;
                            }
                        }

                        if (r["parts"] != DBNull.Value && r["parts"].ToString().Length > 0)
                        {
                            string[] sParts = r["parts"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
                            for (int i = 0; i < sParts.Length; i++)
                            {
                                DevComponents.DotNetBar.ListBoxItem li = new DevComponents.DotNetBar.ListBoxItem();
                                li.Tag = sParts[i].Trim();
                                li.Text = sParts[i].Trim().Substring(0, sParts[i].Trim().Length > 50 ? 50 : sParts[i].Trim().Length);
                                lbxParts.Items.Add(li);
                            }

                            chkMultiPart.Checked = true;
                        }
                    }
                }
            }
        }

        private void tv_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            Enable();
        }

        private void lbxParts_ItemClick(object sender, EventArgs e)
        {
            iPart = lbxParts.SelectedIndex;
            if (iPart > -1)
            {
                DevComponents.DotNetBar.ListBoxItem i = (DevComponents.DotNetBar.ListBoxItem)lbxParts.Items[iPart];
                if (i.Tag != null && i.Tag.ToString().Length > 0)
                {
                    txtPart.Text = i.Tag.ToString();
                }
            }
        }

        private void lbxParts_ItemDoubleClick(object sender, MouseEventArgs e)
        {
            txtPart.Enabled = true;
        }

        #endregion

        #region Button Clicks

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        private void btnPartSave_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ListBoxItem i = (DevComponents.DotNetBar.ListBoxItem)lbxParts.Items[iPart];
            i.Tag = txtPart.Text.Trim();
            i.Text = txtPart.Text.Trim().Substring(0, txtPart.Text.Trim().Length > 50 ? 50 : txtPart.Text.Trim().Length);
        }

        private void btnPartCancel_Click(object sender, EventArgs e)
        {
            txtPart.Text = "";
            txtPart.Enabled = false;
        }

        #endregion

        #region Menu Clicks

        private void cmAdd_Click(object sender, EventArgs e)
        {
            txtEntry.Text = "";
            cbxLetter.SelectedIndex = -1;
            cbxNumber.SelectedIndex = -1;
            cbxSection.SelectedIndex = -1;
            Enable();
        }

        private void cmRemove_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        private void cmPartAdd_Click(object sender, EventArgs e)
        {
            txtPart.Text = "";
            txtPart.Enabled = true;
            ActiveControl = txtPart;
            txtPart.Focus();
        }

        private void cmPartRemove_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
    }
}
