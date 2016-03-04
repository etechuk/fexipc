using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Common;
using DevComponents.DotNetBar.Metro;

namespace Client
{
    public partial class frmDDBRebuild : MetroForm
    {
        string sDbFile = Properties.Settings.Default.PathToData + @"\fexi.db";

        public frmDDBRebuild()
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

            bwDDB.RunWorkerAsync();
        }

        private void bwDDB_DoWork(object sender, DoWorkEventArgs e)
        {
            Database db = new Database(SqlProviders.SQLite, Properties.Settings.Default.PathToData);
            db.SQLiteCreate(Properties.Settings.Default.PathToData);
            db.SQLiteDataRebuild(Properties.Settings.Default.PathToData, Program.SQL, SharedData.iLocationSite);
        }

        private void bwDDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string sTitle = "", sMessage = "";

            if (System.IO.File.Exists(sDbFile))
            {
                sMessage = "The device database was rebuilt successfully.";
                sTitle = "Rebuilt";
            }
            else
            {
                sMessage = "The device database was not rebuilt.\nPlease try again.";
                sTitle = "Failed";
            }

            MessageBox.Show(sMessage, sTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
