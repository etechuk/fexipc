using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Common;

using DevComponents.DotNetBar.Metro;

namespace Client
{
    public partial class frmSignIn : MetroForm
    {
        #region Form

        public frmSignIn()
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
            cpSign.ProgressColor = Program.cWindowColour;

            if (Properties.Settings.Default.PathToLogo.Length > 0 && File.Exists(Properties.Settings.Default.PathToLogo))
            {
                pbxLogo.Load(Properties.Settings.Default.PathToLogo);
            }
            else if (Properties.Settings.Default.PathToData.Length > 0 && File.Exists(Properties.Settings.Default.PathToData + "logo-signin.png"))
            {
                pbxLogo.Load(Properties.Settings.Default.PathToData + "logo-signin.png");
            }

            spData.Location = new Point(12, 8);
            spData.IsOpen = false;
        }

        private void frmSignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                return;
            }
            else if (txtDataHost.Text.Trim().Length == 0 || txtDataName.Text.Trim().Length == 0)
            {
                DialogResult dlg = MessageBox.Show("You haven't set required database details.\nAre you sure you want to exit?", "Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.No)
                {
                    e.Cancel = true;
                    spData.IsOpen = false;
                }
            }
        }

        private void frmSignIn_Shown(object sender, EventArgs e)
        {
            Activate();

            DialogResult dlg = DialogResult.Ignore;

            if (Properties.Settings.Default.DataHost.Length > 0 && Properties.Settings.Default.DataName.Length > 0)
            {
                txtDataHost.Text = Properties.Settings.Default.DataHost;
                txtDataPort.Text = Properties.Settings.Default.DataPort;
                txtDataUser.Text = Properties.Settings.Default.DataUser;
                txtDataPass.Text = Properties.Settings.Default.DataPass;
                txtDataName.Text = Properties.Settings.Default.DataName;
            }

            if (txtDataHost.Text.Trim().Length == 0)
            {
                dlg = MessageBox.Show("The database host needs to be specified.\nClick OK to enter it now.", "Database host", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!spData.IsOpen)
                {
                    spData.IsOpen = true;
                }
                ActiveControl = txtDataHost;
                txtDataHost.Focus();
            }
            else if (txtDataName.Text.Trim().Length == 0)
            {
                dlg = MessageBox.Show("The database name needs to be specified.\nClick OK to enter it now.", "Database name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!spData.IsOpen)
                {
                    spData.IsOpen = true;
                }
                ActiveControl = txtDataName;
                txtDataName.Focus();
            }
            else
            {
                if (Properties.Settings.Default.SignInRemember)
                {
                    if (Properties.Settings.Default.SignInUser.Length > 0)
                    {
                        txtUser.Text = Properties.Settings.Default.SignInUser;
                        ActiveControl = txtPass;
                        txtPass.Focus();
                    }
                    cbxRemember.Checked = true;
                }
                else
                {
                    ActiveControl = txtUser;
                    txtUser.Focus();
                }
            }

            // Temporary password encoding. Delete on publication of final product!
            //txtUser.Text = Program.Globals.EncodePassword("test");
        }

        #endregion

        #region Clicks

        private void btnDataCancel_Click(object sender, EventArgs e)
        {
            spData.IsOpen = false;
            txtDataHost.Text = Properties.Settings.Default.DataHost;
            txtDataPort.Text = Properties.Settings.Default.DataPort;
            txtDataUser.Text = Properties.Settings.Default.DataUser;
            txtDataPass.Text = Properties.Settings.Default.DataPass;
            txtDataName.Text = Properties.Settings.Default.DataName;
        }

        private void btnDataSave_Click(object sender, EventArgs e)
        {
            Database db = new Database(SqlProviders.SqlServer, txtDataHost.Text.Trim(), txtDataPort.Text.Trim(), txtDataUser.Text.Trim(), txtDataPass.Text.Trim(), txtDataName.Text.Trim());

            if (!db.IsConnected())
            {
                DialogResult dlg = MessageBox.Show("The connection failed. Would you like to\nredefine the connection details?", "Failed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.No)
                {
                    spData.IsOpen = false;
                    txtDataHost.Text = Properties.Settings.Default.DataHost;
                    txtDataPort.Text = Properties.Settings.Default.DataPort;
                    txtDataUser.Text = Properties.Settings.Default.DataUser;
                    txtDataPass.Text = Properties.Settings.Default.DataPass;
                    txtDataName.Text = Properties.Settings.Default.DataName;
                    db = null;
                }
                return;
            }
            else
            {
                MessageBox.Show("The connection was successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Properties.Settings.Default.DataHost = txtDataHost.Text.Trim();
            Properties.Settings.Default.DataPort = txtDataPort.Text.Trim();
            Properties.Settings.Default.DataUser = txtDataUser.Text.Trim();
            Properties.Settings.Default.DataPass = txtDataPass.Text.Trim();
            Properties.Settings.Default.DataName = txtDataName.Text.Trim();
            Properties.Settings.Default.Save();

            db = null;
            spData.IsOpen = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (spData.IsOpen)
            {
                spData.IsOpen = false;
            }
            spData.SlideOutButtonVisible = false;

            cpSign.IsRunning = true;
            cpSign.Visible = true;
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            btnSign.Enabled = false;

            bwSign.RunWorkerAsync();
        }

        #endregion

        #region Keys

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtUser.Text.Trim().Length > 0 && txtPass.Text.Trim().Length > 0)
                {
                    btnSign.PerformClick();
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtUser.Text.Trim().Length > 0 && txtPass.Text.Trim().Length > 0)
                {
                    btnSign.PerformClick();
                }
            }
        }

        private void cbxRemember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtUser.Text.Trim().Length > 0 && txtPass.Text.Trim().Length > 0)
                {
                    btnSign.PerformClick();
                }
            }
        }

        private void txtDataHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtDataHost.Text.Trim().Length > 0 && txtDataName.Text.Trim().Length > 0)
                {
                    btnDataSave.PerformClick();
                }
            }
        }

        private void txtDataPort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtDataHost.Text.Trim().Length > 0 && txtDataName.Text.Trim().Length > 0)
                {
                    btnDataSave.PerformClick();
                }
            }
        }

        private void txtDataUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtDataHost.Text.Trim().Length > 0 && txtDataName.Text.Trim().Length > 0)
                {
                    btnDataSave.PerformClick();
                }
            }
        }

        private void txtDataPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtDataHost.Text.Trim().Length > 0 && txtDataName.Text.Trim().Length > 0)
                {
                    btnDataSave.PerformClick();
                }
            }
        }

        private void txtDataName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (txtDataHost.Text.Trim().Length > 0 && txtDataName.Text.Trim().Length > 0)
                {
                    btnDataSave.PerformClick();
                }
            }
        }

        private void txtDataPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        #endregion

        #region Background Work

        private void bwSign_DoWork(object sender, DoWorkEventArgs e)
        {
            bool go = true;
            int status = 0;

            DataSet ds = Program.SQL.SelectAll("SELECT id FROM users WHERE username='" + txtUser.Text.Trim() + "';");
            if (ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("The username provided wasn't found.\nPlease check and try again.", "Username", MessageBoxButtons.OK, MessageBoxIcon.Information);
                go = false;
            }
            else
            {
                ds = Program.SQL.SelectAll("SELECT id,usergroup,status FROM users WHERE username='" + txtUser.Text.Trim() + "' AND password='" + Program.Globals.EncodePassword(txtPass.Text.Trim()) + "';");
                if (ds.Tables.Count < 1 || ds.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("You've entered an incorrect password.\nPlease check and try again.", "Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    go = false;
                }
                else
                {
                    status = Convert.ToInt32(ds.Tables[0].Rows[0]["status"].ToString());
                    switch (status)
                    {
                        case 2:
                            MessageBox.Show("The user you entered is currently disabled.\nPlease contact an administrator.", "Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            go = false;
                            break;
                        case 3:
                            MessageBox.Show("The user you entered is currently banned.\nPlease contact an administrator.", "Banned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            go = false;
                            break;
                        case 4:
                            MessageBox.Show("The user you entered has been deleted.\nPlease contact an administrator.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            go = false;
                            break;
                    }
                }
            }

            if (go)
            {
                if (txtUser.Text.Length > 0 && cbxRemember.Checked)
                {
                    Properties.Settings.Default.SignInUser = txtUser.Text.Trim();
                    Properties.Settings.Default.SignInRemember = cbxRemember.Checked;
                }
                else
                {
                    Properties.Settings.Default.SignInUser = "";
                    Properties.Settings.Default.SignInRemember = false;
                }
                Properties.Settings.Default.Save();

                int iUserGroup = Convert.ToInt32(ds.Tables[0].Rows[0]["usergroup"].ToString());
                Program.Globals.UserIsAdmin = iUserGroup == 3 || iUserGroup == 4 ? true : false;
                Program.Globals.UserID = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                Program.Globals.UserIsSigned = true;

                if (Properties.Settings.Default.FirstRun) // && Program.Globals.UserIsAdmin
                {
                    /*
                    DialogResult dlg = MessageBox.Show("Is this a multi-site installation?", "Multi-site?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        Properties.Settings.Default.IsMultiSite = true;
                    }
                    else
                    {
                        Properties.Settings.Default.IsMultiSite = false;
                    }
                    */

                    Properties.Settings.Default.FirstRun = false;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void bwSign_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            spData.SlideOutButtonVisible = true;
            cpSign.IsRunning = false;
            cpSign.Visible = false;
            btnSign.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            txtPass.Text = "";

            if (!Program.Globals.UserIsSigned)
            {
                txtPass.Focus();
            }
            else
            {
                Hide();
                Form frmMain = new frmMain();
                frmMain.Show();
            }
        }

        #endregion
    }
}
