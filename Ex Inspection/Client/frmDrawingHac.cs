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
    public partial class frmDrawingHac : MetroForm
    {
        public frmDrawingHac()
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
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtRevision_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Enter a drawing name to continue.", "Drawing", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (txtRevision.Text.Trim() == "")
            {
                MessageBox.Show("Enter a revision to continue.", "Revision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (dtDate.Value.ToString() == "")
            {
                MessageBox.Show("Enter a date to continue.", "Date", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                DataSet ds;
                Program.SQL.AddParameter("name", txtName.Text.Trim().ToLower());
                Program.SQL.AddParameter("revision", txtRevision.Text.Trim().ToLower());
                Program.SQL.AddParameter("date", dtDate.ToString());
                ds = Program.SQL.SelectAll("SELECT id FROM lists_drawings_hac WHERE LOWER(name)=@name AND LOWER(revision)=@revision AND date=@date;");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("The drawing already exists.\nPlease try again.", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Program.SQL.AddParameter("name", txtName.Text.Trim());
                Program.SQL.AddParameter("revision", txtRevision.Text.Trim());
                Program.SQL.AddParameter("date", dtDate.Value);
                Program.SQL.AddParameter("ent", DateTime.Now);
                int i = Program.SQL.Insert("INSERT INTO lists_drawings_hac (name,revision,date,entered,modified) VALUES (@name,@revision,@date,@ent,@ent)");
                if (i < 1)
                {
                    MessageBox.Show("Failed to add the drawing.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SharedData.iDrawingHac = i;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
