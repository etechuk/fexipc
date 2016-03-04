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
    public partial class frmManufacturer : MetroForm
    {
        public frmManufacturer()
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtManufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtManufacturer.Text.Trim() == "")
            {
                MessageBox.Show("Enter a manufacturer name to continue.", "Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                DataSet ds;
                Program.SQL.AddParameter("name", txtManufacturer.Text.Trim().ToLower());
                ds = Program.SQL.SelectAll("SELECT id FROM lists_manufacturers WHERE LOWER(name)=@name;");
                if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("The manufacturer already exists.\nPlease try again.", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Program.SQL.AddParameter("name", txtManufacturer.Text.Trim());
                Program.SQL.AddParameter("ent", txtManufacturer.Text.Trim());
                int i = Program.SQL.Insert("INSERT INTO lists_manufacturers (name,entered,modified) VALUES (@name,@ent,@ent)");
                if (i < 1)
                {
                    MessageBox.Show("Failed to add the manufacturer.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SharedData.iManufacturer = i;
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
