using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;
using RegawMOD.Android;

namespace Client
{
    public partial class frmSync : MetroForm
    {
        #region Members

        private AndroidController android = null;
        private Device device = null;

        private string sAndroidAction = "";
        private string sAndroidDataPath = "/storage/extSdCard/Android/data/com.etech.fes.fexian/files/";
        private string sLocalDataFile = "fexi.db";
        private string sAndroidDataFile = "data.db";
        private bool bAddedToDB = false;
        private bool bDataPulled = false;

        #endregion

        #region Form

        public frmSync()
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
            cpMain.ProgressColor = Program.cWindowColour;
        }

        private void frmSync_Shown(object sender, EventArgs e)
        {
            cpMain.Visible = true;
            cpMain.IsRunning = true;
            sAndroidAction = "checkDevices";
            bwAndroid.RunWorkerAsync();
        }

        private void frmSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (android != null)
            {
                android.Dispose();
            }
        }

        #endregion

        #region Clicked

        private void btnSync_Click(object sender, EventArgs e)
        {
            cpMain.Visible = true;
            cpMain.IsRunning = true;
            btnSync.Enabled = false;
            ControlBox = false;
            bwSQLite.RunWorkerAsync();
        }

        #endregion

        #region SQLite

        private void bwSQLite_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.PathToData + @"\" + sLocalDataFile))
            {
                Program.SQL.SQLiteCreate(Properties.Settings.Default.PathToData);
            }

            string sBakDir = Properties.Settings.Default.PathToData + @"\backups\" + DateTime.Now.ToString(@"ddmmyyyy_HHmmss\" + device.SerialNumber);
            if (!Directory.Exists(sBakDir))
            {
                Directory.CreateDirectory(sBakDir);
            }

            bDataPulled = device.PullDirectory(sAndroidDataPath, sBakDir);
            if (bDataPulled && File.Exists(sBakDir + @"\" + sAndroidDataFile))
            {
                Program.SQL.SQLiteImport(sBakDir + @"\" + sAndroidDataFile, Program.SQL);
                bool bImagesPulled = device.PullDirectory(sAndroidDataPath + "images/", sBakDir + @"\images");
            }

            Program.SQL.SQLiteDataRebuild(Properties.Settings.Default.PathToData, Program.SQL, 1);
        }

        private void bwSQLite_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message, "SQLite creation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("SQLite creation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cpMain.Visible = true;
                cpMain.IsRunning = true;

                if (bDataPulled)
                {
                    device.PushFile(Properties.Settings.Default.PathToData + @"\" + sLocalDataFile, sAndroidDataPath + sLocalDataFile);
                    device.PushFile(Properties.Settings.Default.PathToData + @"\main.t", sAndroidDataPath + "main.t");
                    MessageBox.Show("Sync successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sync unsuccessful.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DialogResult = DialogResult.OK;
                cpMain.IsRunning = false;
                cpMain.Visible = false;
                Close();
            }

            cpMain.IsRunning = false;
            cpMain.Visible = false;
        }

        #endregion

        #region Android

        private bool InstallAPK(bool bReinstall = false)
        {
            bool bReturn = false;

            if (!File.Exists(Properties.Settings.Default.PathToData + @"\exinspection.apk"))
            {
                MessageBox.Show("The Android package doesn't exist in the data folder.\nPlease make sure the file exists and try again.", "Missing APK", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool bNewInstall = device.InstallApk(Properties.Settings.Default.PathToData + @"\exinspection.apk");
                if (!bNewInstall && !bReinstall)
                {
                    MessageBox.Show("The Android package couldn't be installed.\nIt may already exist on the device.", "Installation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bReturn = true;
                }
                else
                {
                    if (!bReinstall)
                    {
                        MessageBox.Show("The device was authorised and the app installed successfully.\n\nThe app on the device needs to be run at least once for\nsynchronisation to work correctly.", "Installed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bReturn = true;
                    }
                }
            }

            return bReturn;
        }

        private void bwAndroid_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (sAndroidAction)
            {
                case "checkDevices":
                    android = AndroidController.Instance;
                    android.UpdateDeviceList();
                    break;
                case "installAPK":
                    InstallAPK();
                    break;
                case "reinstallAPK":
                    InstallAPK(true);
                    break;
            }
        }

        private void bwAndroid_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message, "Android Action Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Android action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (sAndroidAction)
                {
                    case "checkDevices":
                        DataSet ds = null;
                        string sSerial = "";

                        if (!android.HasConnectedDevices)
                        {
                            MessageBox.Show("No device found!\n\nClose the Sync window, reconnect the device\nand reopen the window to try again.", "No device", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cpMain.IsRunning = false;
                            cpMain.Visible = false;
                        }
                        else
                        {
                            for (int i = 0; i < android.ConnectedDevices.Count; i++)
                            {
                                string s = android.ConnectedDevices[i];
                                Program.SQL.AddParameter("@serial", s);
                                ds = Program.SQL.SelectAll("SELECT id FROM app_devices WHERE serial=@serial;");
                                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    sSerial = s;
                                    break;
                                }
                            }

                            if (sSerial.Length == 0)
                            {
                                sSerial = android.ConnectedDevices[0];
                            }
                            device = android.GetConnectedDevice(sSerial);
                        }

                        if (sSerial.Length > 0)
                        {
                            lblDeviceSerial.Text = device.SerialNumber;
                            lbxDevice.Items.AddRange(device.BuildProp.Keys.ToArray());
                            lbxDevice.SelectedIndex = -1;

                            if (Program.Globals.UserIsAdmin == true)
                            {
                                if (device != null && (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0))
                                {
                                    DialogResult dlg = MessageBox.Show("Would you like to add the device\nto the authorised devices list?", "Add device?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dlg == DialogResult.Yes)
                                    {
                                        Program.SQL.AddParameter("@serial", device.SerialNumber);
                                        Program.SQL.AddParameter("@ent", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        int iID = Program.SQL.Insert("INSERT INTO app_devices (serial,entered) VALUES (@serial,@ent)");
                                        if (iID < 1)
                                        {
                                            MessageBox.Show("The addition failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            bAddedToDB = true;
                                            sAndroidAction = "installAPK";
                                            bwAndroid.RunWorkerAsync();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("You must be an administrative user to install devices.", "Not admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            if (device != null && !bAddedToDB)
                            {
                                string sTempPath = Path.GetTempPath().TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                                bool bDataPulled = device.PullFile("/storage/extSdCard/Android/data/com.etech.fes.fexian/files/" + sAndroidDataFile, sTempPath);
                                if (!File.Exists(sTempPath + @"\" + sAndroidDataFile))
                                {
                                    cpMain.IsRunning = true;
                                    cpMain.Visible = true;
                                    sAndroidAction = "reinstallAPK";
                                    bwAndroid.RunWorkerAsync();
                                }
                                else
                                {
                                    File.Delete(sTempPath + @"\" + sAndroidDataFile);
                                    btnSync.Enabled = true;
                                }
                            }
                        }
                        break;

                    case "installAPK":
                        break;

                    case "reinstallAPK":
                        break;
                }
            }

            cpMain.IsRunning = false;
            cpMain.Visible = false;
        }

        #endregion
    }
}
