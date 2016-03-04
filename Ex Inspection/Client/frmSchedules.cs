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
    public partial class frmSchedules : MetroForm
    {
        #region Variables

        public static int iID = 0;
        public static bool bIsQuestion = true;

        #endregion

        #region Form

        public frmSchedules()
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

            LoadSchedules();
            LoadQuestions();
            LoadNotes();
        }

        #endregion

        #region Loaders

        private void LoadSchedules()
        {
            if (nV.Nodes.Count > 0)
            {
                nV.Nodes.Clear();
            }
            if (nC.Nodes.Count > 0)
            {
                nC.Nodes.Clear();
            }
            if (nD.Nodes.Count > 0)
            {
                nD.Nodes.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT id,name,grade FROM schedules;");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DevComponents.AdvTree.Node n = new DevComponents.AdvTree.Node();
                    n.Tag = dr["id"];
                    n.Text = dr["name"].ToString();
                    n.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.CheckBox;
                    n.CheckBoxVisible = true;
                    if (dr["grade"].ToString() == "D")
                    {
                        nD.Nodes.Add(n);
                    }
                    else if (dr["grade"].ToString() == "C")
                    {
                        nC.Nodes.Add(n);
                    }
                    else if (dr["grade"].ToString() == "V")
                    {
                        nV.Nodes.Add(n);
                    }
                }
            }
        }

        private void LoadQuestions()
        {
            if (gQ.PrimaryGrid.Rows.Count > 0)
            {
                gQ.PrimaryGrid.Rows.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT id,section,letter,number,question,parts FROM schedules_questions ORDER BY letter,number,CAST(question as VARCHAR(100));");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string sSection = "";
                    if (dr["section"] != DBNull.Value && dr["section"].ToString().Length > 0)
                    {
                        DataSet d = Program.SQL.SelectAll("SELECT name FROM schedules_sections WHERE id=" + dr["section"].ToString() + ";");
                        if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                        {
                            sSection = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }

                    if (dr["parts"].ToString().Length > 0)
                    {
                        string[] sParts = dr["parts"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < sParts.Length; i++)
                        {
                            GridRow rQ = new GridRow(new object[] { dr["letter"].ToString(), dr["number"].ToString(), (i + 1), dr["question"].ToString() + " [" + sParts[i] + "]", sSection });
                            rQ.Tag = dr["id"].ToString() + ":" + (i + 1);
                            gQ.PrimaryGrid.Rows.Add(rQ);
                        }
                    }
                    else
                    {
                        GridRow rQ = new GridRow(new object[] { dr["letter"].ToString(), dr["number"].ToString(), "", dr["question"].ToString(), sSection });
                        rQ.Tag = dr["id"].ToString();
                        gQ.PrimaryGrid.Rows.Add(rQ);
                    }
                }
            }
        }

        private void LoadNotes()
        {
            if (gN.PrimaryGrid.Rows.Count > 0)
            {
                gN.PrimaryGrid.Rows.Clear();
            }

            DataSet ds = Program.SQL.SelectAll("SELECT id,note FROM schedules_notes ORDER BY CAST(note as VARCHAR(100));");
            if (ds.Tables.Count == 1)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    GridRow rN = new GridRow(new object[] { dr["note"].ToString() });
                    rN.Tag = dr["id"].ToString();
                    gN.PrimaryGrid.Rows.Add(rN);
                }
            }
        }

        #endregion

        #region Button Clicks

        private void btniSections_Click(object sender, EventArgs e)
        {
            Form frmSections = new frmSchedulesSections();
            frmSections.ShowDialog();
        }

        private void btniQuestions_Click(object sender, EventArgs e)
        {
            bIsQuestion = true;
            Form frmQuestions = new frmSchedulesQuestions();
            frmQuestions.ShowDialog();
        }

        private void btniNotes_Click(object sender, EventArgs e)
        {
            bIsQuestion = false;
            Form frmNotes = new frmSchedulesQuestions();
            frmNotes.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Enable(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("A name must be provided to continue.", "Name", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (cbxGrade.SelectedIndex < 0)
            {
                MessageBox.Show("A grade must be provided to continue.", "Grade", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            List<string> lQuestions = new List<string>();
            List<string> lNotes = new List<string>();

            foreach (GridRow r in gQ.PrimaryGrid.Rows)
            {
                if (r.Checked)
                {
                    if (r.Tag != null && r.Tag.ToString().Length > 0)
                    {
                        lQuestions.Add(r.Tag.ToString());
                    }
                }
            }

            foreach (GridRow r in gN.PrimaryGrid.Rows)
            {
                if (r.Checked)
                {
                    if (r.Tag != null && r.Tag.ToString().Length > 0)
                    {
                        lNotes.Add(r.Tag.ToString());
                    }
                }
            }

            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxGrade.Items[cbxGrade.SelectedIndex];
            string sGrade = i.Value.ToString();

            Program.SQL.AddParameter("name", txtName.Text.ToString());
            Program.SQL.AddParameter("type", sGrade);
            Program.SQL.AddParameter("questions", string.Join(",", lQuestions));
            Program.SQL.AddParameter("notes", string.Join(",", lNotes));
            Program.SQL.AddParameter("mod", DateTime.Now);

            if (iID > 0)
            {
                Program.SQL.AddParameter("id", iID);
                int iRes = Program.SQL.Update("UPDATE schedules SET name=@name,type=@type,questions=@questions,notes=@notes,modified=@mod WHERE id=@id;");
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
                int iRes = Program.SQL.Insert("INSERT INTO schedules (name,type,questions,notes,entered,modified) VALUES (@name,@type,@questions,@notes,@ent,@mod)");
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
            LoadSchedules();
        }

        #endregion

        #region Node Clicks

        private void tv_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString().All(char.IsDigit))
            {
                iID = Convert.ToInt32(e.Node.Tag);
                if (iID > 0)
                {
                    Program.SQL.AddParameter("id", iID);
                    DataSet ds = Program.SQL.SelectAll("SELECT * FROM schedules WHERE id=@id;");
                    if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];

                        txtName.Text = dr["name"].ToString();
                        foreach (DevComponents.Editors.ComboItem i in cbxGrade.Items)
                        {
                            if (i.Value.ToString() == dr["grade"].ToString())
                            {
                                cbxGrade.SelectedItem = i;
                                break;
                            }
                        }

                        if (dr["questions"] != DBNull.Value && dr["questions"].ToString().Length > 0)
                        {
                            string[] sQuestions = dr["questions"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (sQuestions.Length > 0)
                            {
                                foreach (GridRow r in gQ.PrimaryGrid.Rows)
                                {
                                    r.Checked = false;
                                    if (r.Tag != null && sQuestions.Contains(r.Tag.ToString()))
                                    {
                                        r.Checked = true;
                                    }
                                }
                            }
                        }

                        if (dr["notes"] != DBNull.Value && dr["notes"].ToString().Length > 0)
                        {
                            string[] sNotes = dr["notes"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (sNotes.Length > 0)
                            {
                                foreach (GridRow r in gN.PrimaryGrid.Rows)
                                {
                                    r.Checked = false;
                                    if (r.Tag != null && sNotes.Contains(r.Tag.ToString()))
                                    {
                                        r.Checked = true;
                                    }
                                }
                            }
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

        #region Menu Clicks

        private void cmAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cbxGrade.SelectedIndex = -1;
            foreach (GridRow r in gQ.PrimaryGrid.Rows)
            {
                r.Checked = false;
            }
            foreach (GridRow r in gQ.PrimaryGrid.Rows)
            {
                r.Checked = false;
            }
            Enable();
        }

        private void cmRemove_Click(object sender, EventArgs e)
        {
            string sIDs = "";
            int iCount = 0;

            foreach (DevComponents.AdvTree.Node n in nV.Nodes)
            {
                if (n.Checked && n.Tag != null && n.Tag.ToString().Length > 0)
                {
                    sIDs += sIDs.Length > 0 ? "," + n.Tag.ToString() : n.Tag.ToString();
                    iCount++;
                }
            }
            foreach (DevComponents.AdvTree.Node n in nC.Nodes)
            {
                if (n.Checked && n.Tag != null && n.Tag.ToString().Length > 0)
                {
                    sIDs += sIDs.Length > 0 ? "," + n.Tag.ToString() : n.Tag.ToString();
                    iCount++;
                }
            }
            foreach (DevComponents.AdvTree.Node n in nD.Nodes)
            {
                if (n.Checked && n.Tag != null && n.Tag.ToString().Length > 0)
                {
                    sIDs += sIDs.Length > 0 ? "," + n.Tag.ToString() : n.Tag.ToString();
                    iCount++;
                }
            }

            DialogResult dlg = MessageBox.Show("Are you sure you want to remove\nthe " + iCount.ToString() + " selected schedules?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.No)
            {
                return;
            }

            int i = Program.SQL.Delete("DELETE FROM schedules WHERE ID IN (" + sIDs + ");");
            if (i < 1)
            {
                MessageBox.Show("The removal failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                MessageBox.Show("The removal was successful.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Enable(false);
            LoadSchedules();
        }

        #endregion

        private void Enable(bool bEnable = true)
        {
            if (!bEnable)
            {
                iID = 0;
                txtName.Text = "";
                cbxGrade.SelectedIndex = -1;
                foreach (GridRow r in gQ.PrimaryGrid.Rows)
                {
                    r.Checked = false;
                }
                foreach (GridRow r in gQ.PrimaryGrid.Rows)
                {
                    r.Checked = false;
                }
                txtName.Enabled = false;
                cbxGrade.Enabled = false;
                gN.PrimaryGrid.ReadOnly = true;
                gQ.PrimaryGrid.ReadOnly = true;
                tv.Enabled = true;
                btnLists.Enabled = true;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                txtName.Enabled = true;
                cbxGrade.Enabled = true;
                gN.PrimaryGrid.ReadOnly = false;
                gQ.PrimaryGrid.ReadOnly = false;
                tv.Enabled = false;
                btnLists.Enabled = false;
                btnCancel.Enabled = true;
                btnSave.Enabled = true;
            }
        }
    }
}
