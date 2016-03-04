using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.SuperGrid;

namespace Client
{
    public partial class frmMain : MetroAppForm
    {
        #region Variables

        CultureInfo cInf = new CultureInfo("en-GB");

        bool bMabIsOpen = false;
        bool bItemAdd = false;

        DataSet dsUsers, dsSchedules, dsDrawings, dsHacDrawings, dsManufacturers, dsImages, dsInspections, dsInspectionsFaults, dsItems, dsItemsFaults;
        string sSite = "", sArea = "", sVessel = "", sFloor = "", sGrid = "";
        int iSite = 0, iArea = 0, iVessel = 0, iFloor = 0, iGrid = 0;
        int iInspection = 0;
        int iItem = 0;

        GridRow grInspection, grInspectionAnswer, grInspectionFault, grItem;
        GridCell gcInspection, gcInspectionFault, gcItem;

        DevComponents.AdvTree.AdvTree tvCurrent = null;

        #endregion

        #region Form

        public frmMain()
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

            lblStatus.Text = "";
            ms.SelectedTab = mtHome;

            if (!Program.Globals.UserIsAdmin)
            {
                msbiInspectors.Enabled = false;
                msbiSchedules.Enabled = false;
                msbiDDRebuild.Enabled = false;
            }

            scInspections.SplitterDistance = (scInspectionsData.Height - 400);
            scItems.SplitterDistance = (scItemsData.Height - 400);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.bUserSignOut)
            {
                Application.Exit();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Activate();

            ms.Enabled = false;
            cpMain.BringToFront();

            dsUsers = Program.SQL.SelectAll("SELECT id,name_first,name_last FROM users;");
            dsSchedules = Program.SQL.SelectAll("SELECT id,name,grade FROM schedules;");
            dsDrawings = Program.SQL.SelectAll("SELECT id,name,revision,date FROM lists_drawings;");
            dsHacDrawings = Program.SQL.SelectAll("SELECT id,name,revision,date FROM lists_drawings_hac;");
            dsManufacturers = Program.SQL.SelectAll("SELECT id,name FROM lists_manufacturers;");
            dsImages = Program.SQL.SelectAll("SELECT id,type,typeid FROM images;");
            dsInspections = Program.SQL.SelectAll("SELECT * FROM inspections;");
            dsInspectionsFaults = Program.SQL.SelectAll("SELECT id,inspection,resolved FROM inspections_faults;");
            dsItems = Program.SQL.SelectAll("SELECT * FROM items;");
            dsItemsFaults = Program.SQL.SelectAll("SELECT id,item,resolved FROM items_faults;");

            dtInspectionsFilterFrom.Text = DateTime.Now.AddYears(-5).ToString();
            dtInspectionsFilterTo.Text = DateTime.Now.ToString();
            dtItemsFilterFrom.Text = DateTime.Now.AddYears(-5).ToString();
            dtItemsFilterTo.Text = DateTime.Now.ToString();

            LoadLists();
            LoadTreeData();
            if (tvInspections.Nodes.Count < 1)
            {
                gInspections.Enabled = false;
            }
            else
            {
                LoadInspections();
            }
            if (tvItems.Nodes.Count < 1)
            {
                gItems.Enabled = false;
            }
            else
            {
                LoadItems();
            }

            cpMain.SendToBack();
            ms.Enabled = true;
        }

        #endregion

        #region Shell

        private void ms_HelpButtonClick(object sender, EventArgs e)
        {
            if (bMabIsOpen)
            {
                mab.ClosePopup();
                mstc.SelectedTab = mstImpExp;
                bMabIsOpen = false;
            }
            else
            {
                mab.Popup(1, 60);
                mstc.SelectedTab = mstHelp;
                bMabIsOpen = true;
            }
        }

        private void msbSettings_Click(object sender, EventArgs e)
        {
            mab.ClosePopup();
            mstc.SelectedTab = mstImpExp;
            bMabIsOpen = false;
            Form frmSettings = new frmSettings();
            DialogResult dlg = frmSettings.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                sm.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters { CanvasColor = Color.White, BaseColor = Program.cWindowColour };
            }
        }

        private void msbSignOut_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to sign out?", "Sign out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                Program.bUserSignOut = true;
                Program.Globals.UserIsAdmin = false;
                Program.Globals.UserIsSigned = false;
                Close();
                Program.frmCurrent.Show();
            }
        }

        private void msbExit_Click(object sender, EventArgs e)
        {
            Program.bUserSignOut = false;
            Application.Exit();
        }

        private void msbSync_Click(object sender, EventArgs e)
        {
            Form frmSync = new frmSync();
            DialogResult dlg = frmSync.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                LoadLists();
                LoadTreeData();
                LoadInspections();
                LoadItems();
            }
        }

        private void msbiInspectors_Click(object sender, EventArgs e)
        {
            Form frmInspectors = new frmUsers();
            frmInspectors.ShowDialog();
            LoadLists();
        }

        private void msbiSchedules_Click(object sender, EventArgs e)
        {
            Form frmSchedules = new frmSchedules();
            frmSchedules.ShowDialog();
        }

        private void msbiLists_Click(object sender, EventArgs e)
        {
            Form frmLists = new frmLists();
            frmLists.ShowDialog();
        }

        private void msbiDDRebuild_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("This may take some time with larger databases.\nDo you want to continue?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                SharedData.iLocationSite = 0;

                Form frmSiteChoose = new frmSiteChoose();
                dlg = frmSiteChoose.ShowDialog();

                if (dlg == DialogResult.OK)
                {
                    if (SharedData.iLocationSite > 0)
                    {
                        Form frmDDBRebuild = new frmDDBRebuild();
                        frmDDBRebuild.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You must choose a site to\nperform a database rebuild.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
        }

        #endregion

        #region Loaders

        private void LoadLists()
        {
            if (dsUsers.Tables.Count == 1 && dsUsers.Tables[0].Rows.Count > 0)
            {
                if (cbxInspectionInspector.Items.Count > 0)
                {
                    cbxInspectionInspector.Items.Clear();
                }
                foreach (DataRow r in dsUsers.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = r["name_first"].ToString() + " " + r["name_last"].ToString();
                    cbxInspectionInspector.Items.Add(i);
                }
            }

            if (dsDrawings.Tables.Count == 1 && dsDrawings.Tables[0].Rows.Count > 0)
            {
                if (cbxItemDrawing.Items.Count > 0)
                {
                    cbxItemDrawing.Items.Clear();
                }
                foreach (DataRow r in dsDrawings.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = r["name"].ToString().Trim() + " (Rev." + r["revision"].ToString().Trim() + " - " + Convert.ToDateTime(r["date"].ToString()).ToShortDateString() + ")";
                    cbxItemDrawing.Items.Add(i);
                }
            }

            if (dsHacDrawings.Tables.Count == 1 && dsHacDrawings.Tables[0].Rows.Count > 0)
            {
                if (cbxItemDrawingHac.Items.Count > 0)
                {
                    cbxItemDrawingHac.Items.Clear();
                }
                foreach (DataRow r in dsHacDrawings.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = r["name"].ToString().Trim() + " (Rev." + r["revision"].ToString().Trim() + " - " + Convert.ToDateTime(r["date"].ToString()).ToShortDateString() + ")";
                    cbxItemDrawingHac.Items.Add(i);
                }
            }

            if (dsManufacturers.Tables.Count == 1 && dsManufacturers.Tables[0].Rows.Count > 0)
            {
                if (cbxItemManufacturer.Items.Count > 0)
                {
                    cbxItemManufacturer.Items.Clear();
                }
                foreach (DataRow r in dsManufacturers.Tables[0].Rows)
                {
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = r["name"].ToString();
                    cbxItemManufacturer.Items.Add(i);
                }
            }

            if (dsSchedules.Tables.Count == 1 && dsSchedules.Tables[0].Rows.Count > 0)
            {
                if (cbxInspectionSchedule.Items.Count > 0)
                {
                    cbxInspectionSchedule.Items.Clear();
                }
                foreach (DataRow r in dsSchedules.Tables[0].Rows)
                {
                    string sGrade = "";
                    switch (r["grade"].ToString())
                    {
                        case "C":
                            sGrade = "Close: ";
                            break;
                        case "D":
                            sGrade = "Detail: ";
                            break;
                        default:
                            sGrade = "Visual: ";
                            break;
                    }
                    DevComponents.Editors.ComboItem i = new DevComponents.Editors.ComboItem();
                    i.Value = r["id"];
                    i.Text = sGrade + r["name"].ToString();
                    cbxInspectionSchedule.Items.Add(i);
                }
            }
        }

        private void LoadTreeData()
        {
            if (tvInspections.Nodes.Count > 0)
            {
                tvInspections.Nodes.Clear();
            }
            if (tvItems.Nodes.Count > 0)
            {
                tvItems.Nodes.Clear();
            }

            DataSet dsS = Program.SQL.SelectAll("SELECT id,name FROM locations_sites;");
            DataSet dsA = Program.SQL.SelectAll("SELECT id,name,site FROM locations_areas;");
            DataSet dsV = Program.SQL.SelectAll("SELECT id,name,site,area FROM locations_vessels;");
            DataSet dsF = Program.SQL.SelectAll("SELECT id,name,site,area,vessel FROM locations_floors;");
            DataSet dsG = Program.SQL.SelectAll("SELECT id,name,site,area,vessel,floor FROM locations_grids;");

            if (dsS.Tables.Count > 0 && dsS.Tables[0].Rows.Count == 0)
            {
                Program.SQL.AddParameter("name", "Default");
                Program.SQL.AddParameter("date", DateTime.Now);
                int i = Program.SQL.Insert("INSERT INTO locations_sites (name,entered,modified) VALUES (@name,@date,@date)");
            }

            if (dsS.Tables.Count > 0 && dsS.Tables[0].Rows.Count > 0)
            {
                for (int s = 0; s < dsS.Tables[0].Rows.Count; s++)
                {
                    DataRow sr = dsS.Tables[0].Rows[s];
                    string sSite = sr["id"].ToString();

                    DevComponents.AdvTree.Node nInS = new DevComponents.AdvTree.Node();
                    nInS.Tag = "s:" + sSite;
                    nInS.Text = sr["name"].ToString();
                    tvInspections.Nodes.Add(nInS);
                    DevComponents.AdvTree.Node nInSr = tvInspections.Nodes[tvInspections.Nodes.Count - 1];

                    DevComponents.AdvTree.Node nItS = new DevComponents.AdvTree.Node();
                    nItS.Tag = "s:" + sSite;
                    nItS.Text = sr["name"].ToString();
                    tvItems.Nodes.Add(nItS);
                    DevComponents.AdvTree.Node nItSr = tvItems.Nodes[tvItems.Nodes.Count - 1];

                    if (dsA.Tables.Count > 0 && dsA.Tables[0].Rows.Count > 0)
                    {
                        for (int a = 0; a < dsA.Tables[0].Rows.Count; a++)
                        {
                            DataRow ar = dsA.Tables[0].Rows[a];
                            if (!ar["site"].ToString().Equals(sSite))
                            {
                                continue;
                            }
                            string sArea = ar["id"].ToString();

                            DevComponents.AdvTree.Node nInA = new DevComponents.AdvTree.Node();
                            nInA.Tag = "a:" + sArea;
                            nInA.Text = ar["name"].ToString();
                            nInSr.Nodes.Add(nInA);
                            DevComponents.AdvTree.Node nInAr = nInSr.Nodes[nInSr.Nodes.Count - 1];

                            DevComponents.AdvTree.Node nItA = new DevComponents.AdvTree.Node();
                            nItA.Tag = "a:" + sArea;
                            nItA.Text = ar["name"].ToString();
                            nItSr.Nodes.Add(nItA);
                            DevComponents.AdvTree.Node nItAr = nItSr.Nodes[nItSr.Nodes.Count - 1];

                            if (dsV.Tables.Count > 0 && dsV.Tables[0].Rows.Count > 0)
                            {
                                for (int v = 0; v < dsV.Tables[0].Rows.Count; v++)
                                {
                                    DataRow vr = dsV.Tables[0].Rows[v];
                                    if (!vr["site"].ToString().Equals(sSite) || !vr["area"].ToString().Equals(sArea))
                                    {
                                        continue;
                                    }
                                    string sVessel = vr["id"].ToString();

                                    DevComponents.AdvTree.Node nInV = new DevComponents.AdvTree.Node();
                                    nInV.Tag = "v:" + sVessel;
                                    nInV.Text = vr["name"].ToString();
                                    nInAr.Nodes.Add(nInV);
                                    DevComponents.AdvTree.Node nInVr = nInAr.Nodes[nInAr.Nodes.Count - 1];

                                    DevComponents.AdvTree.Node nItV = new DevComponents.AdvTree.Node();
                                    nItV.Tag = "v:" + sVessel;
                                    nItV.Text = vr["name"].ToString();
                                    nItAr.Nodes.Add(nItV);
                                    DevComponents.AdvTree.Node nItVr = nItAr.Nodes[nItAr.Nodes.Count - 1];

                                    if (dsF.Tables.Count > 0 && dsF.Tables[0].Rows.Count > 0)
                                    {
                                        for (int f = 0; f < dsF.Tables[0].Rows.Count; f++)
                                        {
                                            DataRow fr = dsF.Tables[0].Rows[f];
                                            if (!fr["site"].ToString().Equals(sSite) || !fr["area"].ToString().Equals(sArea) || !fr["vessel"].ToString().Equals(sVessel))
                                            {
                                                continue;
                                            }
                                            string sFloor = fr["id"].ToString();

                                            DevComponents.AdvTree.Node nInF = new DevComponents.AdvTree.Node();
                                            nInF.Tag = "f:" + sFloor;
                                            nInF.Text = fr["name"].ToString();
                                            nInVr.Nodes.Add(nInF);
                                            DevComponents.AdvTree.Node nInFr = nInVr.Nodes[nInVr.Nodes.Count - 1];

                                            DevComponents.AdvTree.Node nItF = new DevComponents.AdvTree.Node();
                                            nItF.Tag = "f:" + sFloor;
                                            nItF.Text = fr["name"].ToString();
                                            nItVr.Nodes.Add(nItF);
                                            DevComponents.AdvTree.Node nItFr = nItVr.Nodes[nItVr.Nodes.Count - 1];

                                            if (dsG.Tables.Count > 0 && dsG.Tables[0].Rows.Count > 0)
                                            {
                                                for (int g = 0; g < dsG.Tables[0].Rows.Count; g++)
                                                {
                                                    DataRow gr = dsG.Tables[0].Rows[g];
                                                    if (!gr["site"].ToString().Equals(sSite) || !gr["area"].ToString().Equals(sArea) || !gr["vessel"].ToString().Equals(sVessel) || !gr["floor"].ToString().Equals(sFloor))
                                                    {
                                                        continue;
                                                    }
                                                    string sGrid = gr["id"].ToString();

                                                    DevComponents.AdvTree.Node nInG = new DevComponents.AdvTree.Node();
                                                    nInG.Tag = "g:" + sGrid;
                                                    nInG.Text = gr["name"].ToString();
                                                    nInFr.Nodes.Add(nInG);

                                                    DevComponents.AdvTree.Node nItG = new DevComponents.AdvTree.Node();
                                                    nItG.Tag = "g:" + sGrid;
                                                    nItG.Text = gr["name"].ToString();
                                                    nItFr.Nodes.Add(nItG);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            sSite = "";
            sArea = "";
            sVessel = "";
            sFloor = "";
            sGrid = "";
        }

        private void LoadInspections()
        {
            if (tvInspections.Nodes.Count < 1)
            {
                return;
            }
            gInspections.PrimaryGrid.Rows.Clear();
            dsInspections = Program.SQL.SelectAll("SELECT * FROM inspections;");

            DateTime dtFrom = DateTime.Now.Date.AddDays(-7);
            DateTime dtTo = DateTime.Now.Date;
            if (dtInspectionsFilterFrom.Value != null && dtInspectionsFilterTo.Value != null)
            {
                dtFrom = dtInspectionsFilterFrom.Value;
                dtTo = dtInspectionsFilterTo.Value;
            }

            string sType = "", sItem = "";

            if (tvInspections.Nodes.Count > 0 && tvInspections.SelectedNode != null)
            {
                string[] sNode = tvInspections.SelectedNode.Tag.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                switch (sNode[0])
                {
                    case "a":
                        sType = "area";
                        sSite = tvInspections.SelectedNode.Parent.Tag.ToString().Replace("s:", "");
                        sArea = sNode[1].ToString();
                        break;
                    case "v":
                        sType = "vessel";
                        sSite = tvInspections.SelectedNode.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvInspections.SelectedNode.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = sNode[1].ToString();
                        break;
                    case "f":
                        sType = "floor";
                        sSite = tvInspections.SelectedNode.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvInspections.SelectedNode.Parent.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = tvInspections.SelectedNode.Parent.Tag.ToString().Replace("v:", "");
                        sFloor = sNode[1].ToString();
                        break;
                    case "g":
                        sType = "grid";
                        sSite = tvInspections.SelectedNode.Parent.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvInspections.SelectedNode.Parent.Parent.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = tvInspections.SelectedNode.Parent.Parent.Tag.ToString().Replace("v:", "");
                        sFloor = tvInspections.SelectedNode.Parent.Tag.ToString().Replace("f:", "");
                        sGrid = sNode[1].ToString();
                        break;
                    default:
                        sType = "site";
                        sSite = sNode[1].ToString();
                        break;
                }
            }

            foreach (DataRow r in dsItems.Tables[0].Rows)
            {
                bool go = false;

                switch (sType)
                {
                    case "area":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea))
                        {
                            go = true;
                        }
                        break;
                    case "vessel":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel))
                        {
                            go = true;
                        }
                        break;
                    case "floor":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor))
                        {
                            go = true;
                        }
                        break;
                    case "grid":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor) && r["locationgrid"].ToString().Equals(sGrid))
                        {
                            go = true;
                        }
                        break;
                    default:
                        if (r["locationsite"].ToString().Equals(sSite))
                        {
                            go = true;
                        }
                        break;
                }

                if (go)
                {
                    foreach (DataRow dr in dsInspections.Tables[0].Rows)
                    {
                        if (Convert.ToDateTime(dr["entered"]) < dtFrom || Convert.ToDateTime(dr["entered"]) > dtTo)
                        {
                            continue;
                        }

                        if (dr["item"].ToString().Equals(r["id"].ToString()))
                        {
                            string sUser = "";
                            if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow ir in dsUsers.Tables[0].Rows)
                                {
                                    if (ir["id"].ToString() == dr["inspector"].ToString())
                                    {
                                        sUser = (ir["name_first"] + " " + ir["name_last"].ToString()).Trim();
                                    }
                                }
                            }

                            if (dsItems.Tables.Count > 0 && dsItems.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow ir in dsItems.Tables[0].Rows)
                                {
                                    if (ir["id"].ToString() == dr["item"].ToString())
                                    {
                                        sItem = ir["tag"].ToString().Length > 0 ? ir["tag"].ToString() : (ir["barcode"].ToString().Length > 0 ? ir["barcode"].ToString() : "Item ID: " + ir["id"].ToString());
                                    }
                                }
                            }

                            string sSchedule = "";
                            if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                                {
                                    if (ir["id"].ToString() == dr["schedule"].ToString())
                                    {
                                        switch (ir["grade"].ToString())
                                        {
                                            case "C":
                                                sSchedule = "Close: ";
                                                break;
                                            case "D":
                                                sSchedule = "Detail: ";
                                                break;
                                            default:
                                                sSchedule = "Visual: ";
                                                break;
                                        }
                                        sSchedule += ir["name"].ToString().Trim();
                                    }
                                }
                            }

                            string sImages = "No";
                            if (dsImages.Tables.Count == 1 && dsImages.Tables[0].Rows.Count > 0)
                            {
                                List<string> lImages = new List<string>();

                                for (int i = 0; i < dsImages.Tables[0].Rows.Count; i++)
                                {
                                    if (dsImages.Tables[0].Rows[i]["type"].ToString() == "1" && dsImages.Tables[0].Rows[i]["typeid"].ToString() == dr["id"].ToString())
                                    {
                                        lImages.Add(dsImages.Tables[0].Rows[i]["id"].ToString());
                                    }
                                }

                                if (lImages.Count > 0)
                                {
                                    sImages = "Yes";
                                }
                            }

                            string sFaults = "No";
                            if (dsInspectionsFaults.Tables.Count == 1 && dsInspectionsFaults.Tables[0].Rows.Count > 0)
                            {
                                List<string> lFaults = new List<string>();

                                for (int i = 0; i < dsInspectionsFaults.Tables[0].Rows.Count; i++)
                                {
                                    if (dsInspectionsFaults.Tables[0].Rows[i]["inspection"].ToString() == dr["id"].ToString())
                                    {
                                        lFaults.Add(dsInspectionsFaults.Tables[0].Rows[i]["resolved"].ToString() == "y" ? "Yes" : "No");
                                    }
                                }

                                if (lFaults.Count > 0 && lFaults.Last() == "No")
                                {
                                    sFaults = "Yes";
                                }
                            }

                            string sPriority = "";
                            if (dr["priority"] != DBNull.Value)
                            {
                                if (dr["priority"].ToString() == "o")
                                {
                                    sPriority = "OK";
                                }
                                else
                                {
                                    sPriority = "Priority: " + dr["priority"].ToString();
                                }
                            }

                            GridRow gr = new GridRow(new object[] {
                                dr["entered"].ToString(), dr["workorder"].ToString(), sUser, sItem, sSchedule, dr["electrical"].ToString(),
                                dr["mechanical"].ToString(), sPriority, dr["comments"].ToString().Length > 0 ? "Yes" : "No", sImages, sFaults
                            });
                            gr.Tag = dr["id"];

                            if (sFaults == "Yes")
                            {
                                gr.CellStyles.Default.Background.Color1 = Color.Red;
                                gr.CellStyles.Default.Background.Color2 = Color.Red;
                                gr.CellStyles.Default.TextColor = Color.White;
                            }

                            DevComponents.Editors.ComboItem ci;

                            GridComboBoxExEditControl ce = (GridComboBoxExEditControl)gInspections.PrimaryGrid.Columns[4].EditControl;
                            if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                                {
                                    ci = new DevComponents.Editors.ComboItem();
                                    ci.Tag = ir["id"].ToString();
                                    switch (ir["grade"].ToString())
                                    {
                                        case "C":
                                            ci.Text = "Close: ";
                                            break;
                                        case "D":
                                            ci.Text = "Detail: ";
                                            break;
                                        default:
                                            ci.Text = "Visual: ";
                                            break;
                                    }
                                    ci.Text += ir["name"].ToString().Trim();
                                    ce.Items.Add(ci);
                                }
                            }

                            ce = (GridComboBoxExEditControl)gInspections.PrimaryGrid.Columns[7].EditControl;
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "OK";
                            ci.Value = "o";
                            ce.Items.Add(ci);
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "Priority 1";
                            ci.Value = "1";
                            ce.Items.Add(ci);
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "Priority 2";
                            ci.Value = "2";
                            ce.Items.Add(ci);
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "Priority 3";
                            ci.Value = "3";
                            ce.Items.Add(ci);
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "Priority 4";
                            ci.Value = "4";
                            ce.Items.Add(ci);
                            ci = new DevComponents.Editors.ComboItem();
                            ci.Text = "Priority 5";
                            ci.Value = "5";
                            ce.Items.Add(ci);
                            ce.SelectedIndex = -1;

                            gInspections.PrimaryGrid.Rows.Add(gr);

                            break;
                        }
                    }
                }
            }

            sSite = "";
            sArea = "";
            sVessel = "";
            sFloor = "";
            sGrid = "";
        }

        private void LoadItems()
        {
            if (tvItems.Nodes.Count < 1)
            {
                return;
            }
            gItems.PrimaryGrid.Rows.Clear();
            dsItems = Program.SQL.SelectAll("SELECT * FROM items;");

            DateTime dtFrom = DateTime.Now.Date.AddDays(-7);
            DateTime dtTo = DateTime.Now.Date;
            if (dtItemsFilterFrom.Value != null && dtItemsFilterTo.Value != null)
            {
                dtFrom = dtItemsFilterFrom.Value;
                dtTo = dtItemsFilterTo.Value;
            }

            string sType = "";

            if (tvItems.Nodes.Count > 0 && tvItems.SelectedNode != null)
            {
                string[] sNode = tvItems.SelectedNode.Tag.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                switch (sNode[0])
                {
                    case "a":
                        sType = "area";
                        sSite = tvItems.SelectedNode.Parent.Tag.ToString().Replace("s:", "");
                        sArea = sNode[1].ToString();
                        break;
                    case "v":
                        sType = "vessel";
                        sSite = tvItems.SelectedNode.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvItems.SelectedNode.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = sNode[1].ToString();
                        break;
                    case "f":
                        sType = "floor";
                        sSite = tvItems.SelectedNode.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvItems.SelectedNode.Parent.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = tvItems.SelectedNode.Parent.Tag.ToString().Replace("v:", "");
                        sFloor = sNode[1].ToString();
                        break;
                    case "g":
                        sType = "grid";
                        sSite = tvItems.SelectedNode.Parent.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                        sArea = tvItems.SelectedNode.Parent.Parent.Parent.Tag.ToString().Replace("a:", "");
                        sVessel = tvItems.SelectedNode.Parent.Parent.Tag.ToString().Replace("v:", "");
                        sFloor = tvItems.SelectedNode.Parent.Tag.ToString().Replace("f:", "");
                        sGrid = sNode[1].ToString();
                        break;
                    default:
                        sType = "site";
                        sSite = sNode[1].ToString();
                        break;
                }
            }

            foreach (DataRow r in dsItems.Tables[0].Rows)
            {
                bool go = false;

                switch (sType)
                {
                    case "area":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea))
                        {
                            go = true;
                        }
                        break;
                    case "vessel":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel))
                        {
                            go = true;
                        }
                        break;
                    case "floor":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor))
                        {
                            go = true;
                        }
                        break;
                    case "grid":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor) && r["locationgrid"].ToString().Equals(sGrid))
                        {
                            go = true;
                        }
                        break;
                    default:
                        if (r["locationsite"].ToString().Equals(sSite))
                        {
                            go = true;
                        }
                        break;
                }

                if (!go)
                {
                    continue;
                }

                string sSchedule = "";
                if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["epl"].ToString())
                        {
                            sSchedule = ir["name"].ToString().Trim();
                            switch (ir["grade"].ToString())
                            {
                                case "C":
                                    sSchedule += " (C)";
                                    break;
                                case "D":
                                    sSchedule += " (D)";
                                    break;
                                default:
                                    sSchedule += " (V)";
                                    break;
                            }
                        }
                    }
                }

                string sDrawing = "";
                if (dsDrawings.Tables.Count > 0 && dsDrawings.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsDrawings.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["drawing"].ToString())
                        {
                            sDrawing = ir["name"].ToString().Trim() + " (Rev." + ir["revision"].ToString().Trim() + " - " + Convert.ToDateTime(ir["date"].ToString()).ToShortDateString() + ")";
                        }
                    }
                }

                string sHacDrawing = "";
                if (dsHacDrawings.Tables.Count > 0 && dsHacDrawings.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsHacDrawings.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["drawing_hac"].ToString())
                        {
                            sHacDrawing = ir["name"].ToString().Trim() + " (Rev." + ir["revision"].ToString().Trim() + " - " + Convert.ToDateTime(ir["date"].ToString()).ToShortDateString() + ")";
                        }
                    }
                }

                string sManufacturer = "";
                if (dsManufacturers.Tables.Count > 0 && dsManufacturers.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsManufacturers.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["manufacturer"].ToString())
                        {
                            sManufacturer = ir["name"].ToString().Trim();
                        }
                    }
                }

                string sImages = "No";
                if (dsImages.Tables.Count == 1 && dsImages.Tables[0].Rows.Count > 0)
                {
                    List<string> lImages = new List<string>();

                    for (int i = 0; i < dsImages.Tables[0].Rows.Count; i++)
                    {
                        if (dsImages.Tables[0].Rows[i]["type"].ToString() == "2" && dsImages.Tables[0].Rows[i]["typeid"].ToString() == r["id"].ToString())
                        {
                            lImages.Add(dsImages.Tables[0].Rows[i]["id"].ToString());
                        }
                    }

                    if (lImages.Count > 0)
                    {
                        sImages = "Yes";
                    }
                }

                string sFaults = "No";
                if (dsItemsFaults.Tables.Count == 1 && dsItemsFaults.Tables[0].Rows.Count > 0)
                {
                    List<string> lFaults = new List<string>();

                    for (int i = 0; i < dsItemsFaults.Tables[0].Rows.Count; i++)
                    {
                        if (dsItemsFaults.Tables[0].Rows[i]["item"].ToString() == r["id"].ToString())
                        {
                            lFaults.Add(dsItemsFaults.Tables[0].Rows[i]["resolved"].ToString() == "y" ? "Yes" : "No");
                        }
                    }

                    if (lFaults.Count > 0 && lFaults.Last() == "No")
                    {
                        sFaults = "Yes";
                    }
                }

                GridRow gr = new GridRow(new object[] {
                    r["entered"].ToString(), r["tag"].ToString(), r["barcode"].ToString(), r["cableid"].ToString(), r["serial"].ToString(),
                    r["type_equipment"].ToString(), sDrawing, sManufacturer, r["type_model"].ToString(),
                    r["description"].ToString(), r["cert_equipment"].ToString(), r["barrier"].ToString(), r["type_device"].ToString(),
                    r["type_protection"].ToString(), r["group_equipment"].ToString(), r["trating"].ToString(), r["atex_group"].ToString(),
                    r["atex_category"].ToString(), r["atex_protection"].ToString(), r["epl"].ToString(), r["ip_rating"].ToString(),
                    r["ce_number"].ToString(), sHacDrawing, r["drawing_device_loop"].ToString(), r["temp_range"].ToString(),
                    r["area_zone"].ToString(), r["area_group"].ToString(), r["area_trating"].ToString(), r["access_req"].ToString(),
                    r["suitable"].ToString(), sImages, sFaults,
                });
                gr.Tag = r["id"];
                if (sFaults == "Yes")
                {
                    gr.CellStyles.Default.Background.Color1 = Color.Red;
                    gr.CellStyles.Default.Background.Color2 = Color.Red;
                    gr.CellStyles.Default.TextColor = Color.White;
                }
                gItems.PrimaryGrid.Rows.Add(gr);
            }
        }

        #endregion

        #region Other Methods

        private void EnableInspection(bool bEnable = true)
        {
            if (!bEnable)
            {
                txtInspectionComments.Text = "";
                txtInspectionElectrical.Text = "";
                txtInspectionMechanical.Text = "";
                txtInspectionTag.Text = "";
                txtInspectionWorkOrder.Text = "";
                cbxInspectionInspector.SelectedIndex = -1;
                cbxInspectionSchedule.SelectedIndex = -1;
                cbxInspectionPriority.SelectedIndex = -1;
                gInspectionAnswers.PrimaryGrid.Rows.Clear();
                gInspectionFaults.PrimaryGrid.Rows.Clear();
                txtInspectionComments.Enabled = false;
                txtInspectionElectrical.Enabled = false;
                txtInspectionMechanical.Enabled = false;
                txtInspectionTag.Enabled = false;
                txtInspectionWorkOrder.Enabled = false;
                cbxInspectionInspector.Enabled = false;
                cbxInspectionSchedule.Enabled = false;
                cbxInspectionPriority.Enabled = false;
                gInspectionAnswers.PrimaryGrid.ReadOnly = true;
                gInspectionFaults.PrimaryGrid.ReadOnly = true;
                gInspections.Enabled = true;
                tvInspections.Enabled = true;
                btnInspectionCancel.Enabled = false;
                btnInspectionSave.Enabled = false;
            }
            else
            {
                txtInspectionComments.Enabled = true;
                txtInspectionElectrical.Enabled = true;
                txtInspectionMechanical.Enabled = true;
                txtInspectionTag.Enabled = true;
                txtInspectionWorkOrder.Enabled = true;
                cbxInspectionInspector.Enabled = true;
                cbxInspectionSchedule.Enabled = true;
                cbxInspectionPriority.Enabled = true;
                gInspectionAnswers.PrimaryGrid.ReadOnly = false;
                gInspectionFaults.PrimaryGrid.ReadOnly = false;
                gInspections.Enabled = false;
                tvInspections.Enabled = false;
                btnInspectionCancel.Enabled = true;
                btnInspectionSave.Enabled = true;
            }
        }

        private void EnableItem(bool bEnable = true)
        {
            if (!bEnable)
            {
                txtItemACat.Text = "";
                txtItemAccess.Text = "";
                txtItemAGroup.Text = "";
                txtItemATRating.Text = "";
                txtItemAZone.Text = "";
                txtItemBarcode.Text = "";
                txtItemCableID.Text = "";
                txtItemCE.Text = "";
                txtItemDescription.Text = "";
                txtItemDLDrawing.Text = "";
                txtItemDType.Text = "";
                txtItemECert.Text = "";
                txtItemIP.Text = "";
                txtItemMType.Text = "";
                txtItemPType.Text = "";
                txtItemSerial.Text = "";
                txtItemTag.Text = "";
                txtItemTemp.Text = "";
                txtItemTRating.Text = "";
                txtItemCPRef.Text = "";
                cbxItemAGroup.SelectedIndex = -1;
                cbxItemAProt.SelectedIndex = -1;
                cbxItemBarrier.SelectedIndex = -1;
                cbxItemDrawing.SelectedIndex = -1;
                cbxItemEGroup.SelectedIndex = -1;
                cbxItemEPL.SelectedIndex = -1;
                cbxItemEType.SelectedIndex = -1;
                cbxItemDrawingHac.SelectedIndex = -1;
                cbxItemManufacturer.SelectedIndex = -1;
                cbxItemSuitable.SelectedIndex = -1;
                cbxItemTraceHC.SelectedIndex = -1;
                txtItemACat.Enabled = false;
                txtItemAccess.Enabled = false;
                txtItemAGroup.Enabled = false;
                txtItemATRating.Enabled = false;
                txtItemAZone.Enabled = false;
                txtItemBarcode.Enabled = false;
                txtItemCableID.Enabled = false;
                txtItemCE.Enabled = false;
                txtItemDescription.Enabled = false;
                txtItemDLDrawing.Enabled = false;
                txtItemDType.Enabled = false;
                txtItemECert.Enabled = false;
                txtItemIP.Enabled = false;
                txtItemMType.Enabled = false;
                txtItemPType.Enabled = false;
                txtItemSerial.Enabled = false;
                txtItemTag.Enabled = false;
                txtItemTemp.Enabled = false;
                txtItemTRating.Enabled = false;
                txtItemCPRef.Enabled = false;
                cbxItemAGroup.Enabled = false;
                cbxItemAProt.Enabled = false;
                cbxItemBarrier.Enabled = false;
                cbxItemDrawing.Enabled = false;
                cbxItemEGroup.Enabled = false;
                cbxItemEPL.Enabled = false;
                cbxItemEType.Enabled = false;
                cbxItemDrawingHac.Enabled = false;
                cbxItemManufacturer.Enabled = false;
                cbxItemSuitable.Enabled = false;
                cbxItemTraceHC.Enabled = false;
                gItems.Enabled = true;
                tvItems.Enabled = true;
                btnItemCancel.Enabled = false;
                btnItemSave.Enabled = false;
            }
            else
            {
                txtItemACat.Enabled = true;
                txtItemAccess.Enabled = true;
                txtItemAGroup.Enabled = true;
                txtItemATRating.Enabled = true;
                txtItemAZone.Enabled = true;
                txtItemBarcode.Enabled = true;
                txtItemCableID.Enabled = true;
                txtItemCE.Enabled = true;
                txtItemDescription.Enabled = true;
                txtItemDLDrawing.Enabled = true;
                txtItemDType.Enabled = true;
                txtItemECert.Enabled = true;
                txtItemIP.Enabled = true;
                txtItemMType.Enabled = true;
                txtItemPType.Enabled = true;
                txtItemSerial.Enabled = true;
                txtItemTag.Enabled = true;
                txtItemTemp.Enabled = true;
                txtItemTRating.Enabled = true;
                txtItemCPRef.Enabled = true;
                cbxItemAGroup.Enabled = true;
                cbxItemAProt.Enabled = true;
                cbxItemBarrier.Enabled = true;
                cbxItemDrawing.Enabled = true;
                cbxItemEGroup.Enabled = true;
                cbxItemEPL.Enabled = true;
                cbxItemEType.Enabled = true;
                cbxItemDrawingHac.Enabled = true;
                cbxItemManufacturer.Enabled = true;
                cbxItemSuitable.Enabled = true;
                cbxItemTraceHC.Enabled = true;
                gItems.Enabled = false;
                tvItems.Enabled = false;
                btnItemCancel.Enabled = true;
                btnItemSave.Enabled = true;
            }
        }

        #endregion

        #region Node Clicks

        private void tvInspections_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            tvCurrent = tvInspections;
            gInspections.PrimaryGrid.Rows.Clear();

            string sType = "", sItem = "";
            string[] sNode = e.Node.Tag.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            switch (sNode[0])
            {
                case "a":
                    sType = "area";
                    sSite = e.Node.Parent.Tag.ToString().Replace("s:", "");
                    sArea = sNode[1].ToString();
                    break;
                case "v":
                    sType = "vessel";
                    sSite = e.Node.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = sNode[1].ToString();
                    break;
                case "f":
                    sType = "floor";
                    sSite = e.Node.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = e.Node.Parent.Tag.ToString().Replace("v:", "");
                    sFloor = sNode[1].ToString();
                    break;
                case "g":
                    sType = "grid";
                    sSite = e.Node.Parent.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Parent.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = e.Node.Parent.Parent.Tag.ToString().Replace("v:", "");
                    sFloor = e.Node.Parent.Tag.ToString().Replace("f:", "");
                    sGrid = sNode[1].ToString();
                    break;
                case "s":
                    sType = "site";
                    sSite = sNode[1].ToString();
                    break;
            }

            foreach (DataRow r in dsItems.Tables[0].Rows)
            {
                bool go = false;

                switch (sType)
                {
                    case "area":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea))
                        {
                            go = true;
                        }
                        break;
                    case "vessel":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel))
                        {
                            go = true;
                        }
                        break;
                    case "floor":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor))
                        {
                            go = true;
                        }
                        break;
                    case "grid":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor) && r["locationgrid"].ToString().Equals(sGrid))
                        {
                            go = true;
                        }
                        break;
                    case "site":
                        if (r["locationsite"].ToString().Equals(sSite))
                        {
                            go = true;
                        }
                        break;
                }

                if (!go)
                {
                    continue;
                }

                foreach (DataRow dr in dsInspections.Tables[0].Rows)
                {
                    if (dr["item"].ToString().Equals(r["id"].ToString()))
                    {
                        string sUser = "";
                        if (dsUsers.Tables.Count > 0 && dsUsers.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow ir in dsUsers.Tables[0].Rows)
                            {
                                if (ir["id"].ToString() == dr["inspector"].ToString())
                                {
                                    sUser = (ir["name_first"] + " " + ir["name_last"].ToString()).Trim();
                                }
                            }
                        }

                        if (dsItems.Tables.Count > 0 && dsItems.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow ir in dsItems.Tables[0].Rows)
                            {
                                if (ir["id"].ToString() == dr["item"].ToString())
                                {
                                    sItem = ir["tag"].ToString().Length > 0 ? ir["tag"].ToString() : (ir["barcode"].ToString().Length > 0 ? ir["barcode"].ToString() : "Item ID: " + ir["id"].ToString());
                                }
                            }
                        }

                        string sSchedule = "";
                        if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                            {
                                if (ir["id"].ToString() == dr["schedule"].ToString())
                                {
                                    switch (ir["grade"].ToString())
                                    {
                                        case "C":
                                            sSchedule = "Close: ";
                                            break;
                                        case "D":
                                            sSchedule = "Detail: ";
                                            break;
                                        default:
                                            sSchedule = "Visual: ";
                                            break;
                                    }
                                    sSchedule += ir["name"].ToString().Trim();
                                }
                            }
                        }

                        string sImages = "No";
                        if (dsImages.Tables.Count == 1 && dsImages.Tables[0].Rows.Count > 0)
                        {
                            List<string> lImages = new List<string>();

                            for (int i = 0; i < dsImages.Tables[0].Rows.Count; i++)
                            {
                                if (dsImages.Tables[0].Rows[i]["type"].ToString() == "1" && dsImages.Tables[0].Rows[i]["typeid"].ToString() == dr["id"].ToString())
                                {
                                    lImages.Add(dsImages.Tables[0].Rows[i]["id"].ToString());
                                }
                            }

                            if (lImages.Count > 0)
                            {
                                sImages = "Yes";
                            }
                        }

                        string sFaults = "No";
                        if (dsInspectionsFaults.Tables.Count == 1 && dsInspectionsFaults.Tables[0].Rows.Count > 0)
                        {
                            List<string> lFaults = new List<string>();

                            for (int i = 0; i < dsInspectionsFaults.Tables[0].Rows.Count; i++)
                            {
                                if (dsInspectionsFaults.Tables[0].Rows[i]["inspection"].ToString() == dr["id"].ToString())
                                {
                                    lFaults.Add(dsInspectionsFaults.Tables[0].Rows[i]["resolved"].ToString() == "y" ? "Yes" : "No");
                                }
                            }

                            if (lFaults.Count > 0 && lFaults.Last() == "No")
                            {
                                sFaults = "Yes";
                            }
                        }

                        string sPriority = "";
                        if (dr["priority"] != DBNull.Value)
                        {
                            if (dr["priority"].ToString() == "o")
                            {
                                sPriority = "OK";
                            }
                            else
                            {
                                sPriority = "P" + dr["priority"].ToString();
                            }
                        }

                        GridRow gr = new GridRow(new object[] {
                            dr["entered"].ToString(), dr["workorder"].ToString(), sUser, sItem, sSchedule, dr["electrical"].ToString(),
                            dr["mechanical"].ToString(), sPriority, dr["comments"].ToString().Length > 0 ? "Yes" : "No", sImages, sFaults
                        });
                        gr.Tag = dr["id"];
                        if (sFaults == "Yes")
                        {
                            gr.CellStyles.Default.Background.Color1 = Color.Red;
                            gr.CellStyles.Default.Background.Color2 = Color.Red;
                            gr.CellStyles.Default.TextColor = Color.White;
                        }

                        /*
                        DevComponents.Editors.ComboItem ci;

                        GridComboBoxExEditControl ce = (GridComboBoxExEditControl)gInspections.PrimaryGrid.Columns[4].EditControl;
                        if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                            {
                                ci = new DevComponents.Editors.ComboItem();
                                ci.Tag = ir["id"].ToString();
                                switch (ir["grade"].ToString())
                                {
                                    case "C":
                                        ci.Text = "Close: ";
                                        break;
                                    case "D":
                                        ci.Text = "Detail: ";
                                        break;
                                    default:
                                        ci.Text = "Visual: ";
                                        break;
                                }
                                ci.Text += ir["name"].ToString().Trim();
                                ce.Items.Add(ci);
                            }
                        }

                        ce = (GridComboBoxExEditControl)gInspections.PrimaryGrid.Columns[7].EditControl;
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "OK";
                        ci.Value = "o";
                        ce.Items.Add(ci);
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "Priority 1";
                        ci.Value = "1";
                        ce.Items.Add(ci);
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "Priority 2";
                        ci.Value = "2";
                        ce.Items.Add(ci);
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "Priority 3";
                        ci.Value = "3";
                        ce.Items.Add(ci);
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "Priority 4";
                        ci.Value = "4";
                        ce.Items.Add(ci);
                        ci = new DevComponents.Editors.ComboItem();
                        ci.Text = "Priority 5";
                        ci.Value = "5";
                        ce.Items.Add(ci);
                        ce.SelectedIndex = -1;
                        */
                        gInspections.PrimaryGrid.Rows.Add(gr);

                        break;
                    }
                }
            }

            sSite = "";
            sArea = "";
            sVessel = "";
            sFloor = "";
            sGrid = "";
        }

        private void tvItems_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            tvCurrent = tvItems;
            gItems.PrimaryGrid.Rows.Clear();

            string sType = "";
            string[] sNode = e.Node.Tag.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            switch (sNode[0])
            {
                case "a":
                    sType = "area";
                    sSite = e.Node.Parent.Tag.ToString().Replace("s:", "");
                    sArea = sNode[1].ToString();
                    break;
                case "v":
                    sType = "vessel";
                    sSite = e.Node.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = sNode[1].ToString();
                    break;
                case "f":
                    sType = "floor";
                    sSite = e.Node.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = e.Node.Parent.Tag.ToString().Replace("v:", "");
                    sFloor = sNode[1].ToString();
                    break;
                case "g":
                    sType = "grid";
                    sSite = e.Node.Parent.Parent.Parent.Parent.Tag.ToString().Replace("s:", "");
                    sArea = e.Node.Parent.Parent.Parent.Tag.ToString().Replace("a:", "");
                    sVessel = e.Node.Parent.Parent.Tag.ToString().Replace("v:", "");
                    sFloor = e.Node.Parent.Tag.ToString().Replace("f:", "");
                    sGrid = sNode[1].ToString();
                    break;
                case "s":
                    sType = "site";
                    sSite = sNode[1].ToString();
                    break;
            }

            iSite = !sSite.Equals("") ? Convert.ToInt32(sSite) : 0;
            iArea = !sArea.Equals("") ? Convert.ToInt32(sArea) : 0;
            iVessel = !sVessel.Equals("") ? Convert.ToInt32(sVessel) : 0;
            iFloor = !sFloor.Equals("") ? Convert.ToInt32(sFloor) : 0;
            iGrid = !sGrid.Equals("") ? Convert.ToInt32(sGrid) : 0;

            foreach (DataRow r in dsItems.Tables[0].Rows)
            {
                bool go = false;

                switch (sType)
                {
                    case "area":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea))
                        {
                            go = true;
                        }
                        break;
                    case "vessel":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel))
                        {
                            go = true;
                        }
                        break;
                    case "floor":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor))
                        {
                            go = true;
                        }
                        break;
                    case "grid":
                        if (r["locationsite"].ToString().Equals(sSite) && r["locationarea"].ToString().Equals(sArea) && r["locationvessel"].ToString().Equals(sVessel) && r["locationfloor"].ToString().Equals(sFloor) && r["locationgrid"].ToString().Equals(sGrid))
                        {
                            go = true;
                        }
                        break;
                    case "site":
                        if (r["locationsite"].ToString().Equals(sSite))
                        {
                            go = true;
                        }
                        break;
                }

                if (!go)
                {
                    continue;
                }

                string sSchedule = "";
                if (dsSchedules.Tables.Count > 0 && dsSchedules.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsSchedules.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["epl"].ToString())
                        {
                            sSchedule = ir["name"].ToString().Trim();
                            switch (ir["grade"].ToString())
                            {
                                case "C":
                                    sSchedule += " (C)";
                                    break;
                                case "D":
                                    sSchedule += " (D)";
                                    break;
                                default:
                                    sSchedule += " (V)";
                                    break;
                            }
                        }
                    }
                }

                string sDrawing = "";
                if (dsDrawings.Tables.Count > 0 && dsDrawings.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsDrawings.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["drawing"].ToString())
                        {
                            sDrawing = ir["name"].ToString().Trim() + " (Rev." + ir["revision"].ToString().Trim() + " - " + Convert.ToDateTime(ir["date"].ToString()).ToShortDateString() + ")";
                        }
                    }
                }

                string sHacDrawing = "";
                if (dsHacDrawings.Tables.Count > 0 && dsHacDrawings.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsHacDrawings.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["drawing_hac"].ToString())
                        {
                            sHacDrawing = ir["name"].ToString().Trim() + " (Rev." + ir["revision"].ToString().Trim() + " - " + Convert.ToDateTime(ir["date"].ToString()).ToShortDateString() + ")";
                        }
                    }
                }

                string sManufacturer = "";
                if (dsManufacturers.Tables.Count > 0 && dsManufacturers.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow ir in dsManufacturers.Tables[0].Rows)
                    {
                        if (ir["id"].ToString() == r["manufacturer"].ToString())
                        {
                            sManufacturer = ir["name"].ToString().Trim();
                        }
                    }
                }

                string sImages = "No";
                if (dsImages.Tables.Count == 1 && dsImages.Tables[0].Rows.Count > 0)
                {
                    List<string> lImages = new List<string>();

                    for (int i = 0; i < dsImages.Tables[0].Rows.Count; i++)
                    {
                        if (dsImages.Tables[0].Rows[i]["type"].ToString() == "2" && dsImages.Tables[0].Rows[i]["typeid"].ToString() == r["id"].ToString())
                        {
                            lImages.Add(dsImages.Tables[0].Rows[i]["id"].ToString());
                        }
                    }

                    if (lImages.Count > 0)
                    {
                        sImages = "Yes";
                    }
                }

                string sFaults = "No";
                if (dsItemsFaults.Tables.Count == 1 && dsItemsFaults.Tables[0].Rows.Count > 0)
                {
                    List<string> lFaults = new List<string>();

                    for (int i = 0; i < dsItemsFaults.Tables[0].Rows.Count; i++)
                    {
                        if (dsItemsFaults.Tables[0].Rows[i]["item"].ToString() == r["id"].ToString())
                        {
                            lFaults.Add(dsItemsFaults.Tables[0].Rows[i]["resolved"].ToString() == "y" ? "Yes" : "No");
                        }
                    }

                    if (lFaults.Count > 0 && lFaults.Last() == "No")
                    {
                        sFaults = "Yes";
                    }
                }

                GridRow gr = new GridRow(new object[] {
                    r["entered"].ToString(), r["tag"].ToString(), r["barcode"].ToString(), r["cableid"].ToString(), r["serial"].ToString(),
                    r["type_equipment"].ToString(), r["type_model"].ToString(), sManufacturer, r["description"].ToString(), sDrawing, sHacDrawing,
                    r["drawing_device_loop"].ToString(), r["cert_equipment"].ToString(), r["barrier"].ToString(), r["type_device"].ToString(),
                    r["type_protection"].ToString(), r["group_equipment"].ToString(), r["trating"].ToString(), r["atex_group"].ToString(),
                    r["atex_category"].ToString(), r["atex_protection"].ToString(), r["epl"].ToString(), r["ip_rating"].ToString(),
                    r["ce_number"].ToString(), r["temp_range"].ToString(), r["area_zone"].ToString(), r["area_group"].ToString(),
                    r["area_trating"].ToString(), r["access_req"].ToString(), r["suitable"].ToString(), sImages, sFaults,
                });
                gr.Tag = r["id"];
                if (sFaults == "Yes")
                {
                    gr.CellStyles.Default.Background.Color1 = Color.Red;
                    gr.CellStyles.Default.Background.Color2 = Color.Red;
                    gr.CellStyles.Default.TextColor = Color.White;
                }
                gItems.PrimaryGrid.Rows.Add(gr);
            }

            sSite = "";
            sArea = "";
            sVessel = "";
            sFloor = "";
            sGrid = "";
        }

        #endregion

        #region List Clicks

        private void gInspections_CellActivated(object sender, GridCellActivatedEventArgs e)
        {
            gcInspection = e.NewActiveCell;
        }

        private void gInspections_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {

        }

        private void gInspections_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            grInspection = (GridRow)e.NewActiveRow;
        }

        private void gInspections_RowClick(object sender, GridRowClickEventArgs e)
        {
            if (e.MouseEventArgs.Button == MouseButtons.Right)
            {
                Point pos = gInspections.PointToClient(Cursor.Position);
                cmInspections.Show(gInspections, pos);
            }
            else if (e.MouseEventArgs.Button == MouseButtons.Left)
            {
                if (e.GridRow.RowIndex > -1 && e.MouseEventArgs.Button == MouseButtons.Left)
                {
                    iInspection = Convert.ToInt32(e.GridRow.Tag);
                    GridElement row = gInspections.PrimaryGrid.Rows[e.GridRow.RowIndex];

                    Program.SQL.AddParameter("@id", row.Tag.ToString());
                    DataSet d = Program.SQL.SelectAll("SELECT * FROM inspections WHERE id=@id;");
                    if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                    {
                        if (gInspectionAnswers.PrimaryGrid.Rows.Count > 0)
                        {
                            gInspectionAnswers.PrimaryGrid.Rows.Clear();
                        }

                        DataRow r = d.Tables[0].Rows[0];

                        txtInspectionWorkOrder.Text = r["workorder"].ToString();
                        txtInspectionElectrical.Text = r["electrical"].ToString();
                        txtInspectionMechanical.Text = r["mechanical"].ToString();
                        txtInspectionComments.Text = r["comments"].ToString();

                        foreach (DataRow dr in dsItems.Tables[0].Rows)
                        {
                            if (dr["id"].ToString().Equals(r["item"].ToString()))
                            {
                                txtInspectionTag.Text = dr["tag"].ToString().Length > 0 ? dr["tag"].ToString() : (dr["barcode"].ToString().Length > 0 ? dr["barcode"].ToString() : dr["id"].ToString());
                                break;
                            }
                        }

                        foreach (DevComponents.Editors.ComboItem i in cbxInspectionInspector.Items)
                        {
                            if (i.Value.ToString().Equals(r["inspector"].ToString()))
                            {
                                cbxInspectionInspector.SelectedItem = i;
                                break;
                            }
                        }

                        foreach (DevComponents.Editors.ComboItem i in cbxInspectionSchedule.Items)
                        {
                            if (i.Value.ToString().Equals(r["schedule"].ToString()))
                            {
                                cbxInspectionSchedule.SelectedItem = i;
                                break;
                            }
                        }

                        foreach (DevComponents.Editors.ComboItem i in cbxInspectionPriority.Items)
                        {
                            if (i.Value.ToString().Equals(r["priority"].ToString()))
                            {
                                cbxInspectionPriority.SelectedItem = i;
                                break;
                            }
                        }

                        DataSet at = Program.SQL.SelectAll("SELECT id,question,part,answer FROM inspections_answers WHERE inspection=" + iInspection + ";");
                        DataSet ft = Program.SQL.SelectAll("SELECT id,question,part,fault FROM inspections_faults WHERE inspection=" + iInspection + ";");
                        if (at.Tables.Count == 1 && at.Tables[0].Rows.Count > 0)
                        {
                            DataSet st = Program.SQL.SelectAll("SELECT questions FROM schedules WHERE id=" + r["schedule"].ToString() + ";");
                            if (st.Tables.Count == 1 && st.Tables[0].Rows.Count > 0 && st.Tables[0].Rows[0]["questions"].ToString() != "")
                            {
                                List<string> lQuestions = new List<string>();
                                string[] sQIDs = st.Tables[0].Rows[0]["questions"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string sQ in sQIDs)
                                {
                                    string sQuestion = sQ.IndexOf(':') > 0 ? sQ.Substring(0, sQ.IndexOf(':')) : sQ;
                                    if (!lQuestions.Contains(sQuestion))
                                    {
                                        lQuestions.Add(sQuestion);
                                    }
                                }

                                DataSet qt = Program.SQL.SelectAll("SELECT id,section,letter,number,question,parts FROM schedules_questions WHERE id IN (" + string.Join(",", lQuestions) + ");");
                                if (qt.Tables.Count == 1 && qt.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow qr in qt.Tables[0].Rows)
                                    {
                                        bool bHasFault = false;
                                        if (ft.Tables.Count == 1 && ft.Tables[0].Rows.Count > 0)
                                        {
                                            foreach (DataRow fr in ft.Tables[0].Rows)
                                            {
                                                if (fr["question"].ToString().Equals(qr["id"].ToString()))
                                                {
                                                    bHasFault = true;
                                                    break;
                                                }
                                            }
                                        }

                                        string sQuestion = qr["question"].ToString(), sAnswer = "";
                                        string sQRef = qr["letter"].ToString() + Convert.ToInt32(qr["number"]).ToString("D2");
                                        string[] sParts = qr["parts"] != DBNull.Value ? qr["parts"].ToString().TrimStart('{').TrimEnd('}').Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { };

                                        foreach (DataRow ar in at.Tables[0].Rows)
                                        {
                                            if (ar["question"].ToString() == qr["id"].ToString())
                                            {
                                                sAnswer = ar["answer"].ToString();
                                                if (sParts.Length > 0)
                                                {
                                                    for (int i = 0; i < sParts.Length; i++)
                                                    {
                                                        if (ar["part"].ToString() != (i + 1).ToString())
                                                        {
                                                            continue;
                                                        }
                                                        sQRef = qr["letter"].ToString() + Convert.ToInt32(qr["number"]).ToString("D2") + " P" + (i + 1);
                                                        sQuestion = qr["question"].ToString() + " [" + sParts[i] + "]";
                                                        GridRow ir = new GridRow(new object[] { qr["id"].ToString(), sQRef, sQuestion, sAnswer });
                                                        ir.Tag = ar["id"].ToString();
                                                        if (bHasFault)
                                                        {
                                                            ir.CellStyles.Default.Background.Color1 = Color.Red;
                                                            ir.CellStyles.Default.Background.Color2 = Color.Red;
                                                            ir.CellStyles.Default.TextColor = Color.White;
                                                        }
                                                        gInspectionAnswers.PrimaryGrid.Rows.Add(ir);
                                                    }
                                                }
                                                else
                                                {
                                                    GridRow ir = new GridRow(new object[] { qr["id"].ToString(), sQRef, sQuestion, sAnswer });
                                                    ir.Tag = ar["id"].ToString();
                                                    if (bHasFault)
                                                    {
                                                        ir.CellStyles.Default.Background.Color1 = Color.Red;
                                                        ir.CellStyles.Default.Background.Color2 = Color.Red;
                                                        ir.CellStyles.Default.TextColor = Color.White;
                                                    }
                                                    gInspectionAnswers.PrimaryGrid.Rows.Add(ir);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void gInspections_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            EnableInspection();
        }

        private void gInspectionAnswers_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            if (grInspectionAnswer != null && grInspectionAnswer.Tag.ToString().All(char.IsDigit))
            {
                Program.SQL.AddParameter("id", Convert.ToInt32(grInspectionAnswer.Tag));
                Program.SQL.AddParameter("answer", grInspectionAnswer.Cells[3].Value.ToString());
                Program.SQL.AddParameter("mod", DateTime.Now);
                int iRes = Program.SQL.Update("UPDATE inspections_answers SET answer=@answer,modified=@mod WHERE id=@id");
                if (iRes < 1)
                {
                    MessageBox.Show("The answer update failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void gInspectionAnswers_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            grInspectionAnswer = (GridRow)e.NewActiveRow;
        }

        private void gInspectionFaults_CellActivated(object sender, GridCellActivatedEventArgs e)
        {
            gcInspectionFault = e.NewActiveCell;
        }

        private void gInspectionFaults_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {
            Program.SQL.AddParameter("id", Convert.ToInt32(grInspectionAnswer.Tag));
            Program.SQL.AddParameter("fault", grInspectionAnswer.Cells[1].Value.ToString());
            Program.SQL.AddParameter("priority", grInspectionAnswer.Cells[2].Value.ToString());
            Program.SQL.AddParameter("resolved", grInspectionAnswer.Cells[3].Value.ToString());
            string sResDate = "";
            if (grInspectionAnswer.Cells[3].Value.ToString().ToLower() == "y")
            {
                sResDate = " AND resolveddate=@resolveddate";
                Program.SQL.AddParameter("resolveddate", DateTime.Now);
            }
            Program.SQL.AddParameter("mod", DateTime.Now);
            int iRes = Program.SQL.Update("UPDATE inspections_faults SET fault=@fault,priority=@priority,resolved=@resolved" + sResDate + " WHERE id=@id");
            if (iRes < 1)
            {
                MessageBox.Show("The fault update failed. Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void gInspectionFaults_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            grInspectionFault = (GridRow)e.NewActiveRow;
        }

        private void gItems_CellActivated(object sender, GridCellActivatedEventArgs e)
        {
            gcItem = e.NewActiveCell;
        }

        private void gItems_CellValueChanged(object sender, GridCellValueChangedEventArgs e)
        {

        }

        private void gItems_RowActivated(object sender, GridRowActivatedEventArgs e)
        {
            grItem = (GridRow)e.NewActiveRow;
        }

        private void gItems_RowClick(object sender, GridRowClickEventArgs e)
        {
            if (e.MouseEventArgs.Button == MouseButtons.Right)
            {
                Point pos = gItems.PointToClient(Cursor.Position);
                cmItems.Show(gItems, pos);
            }
            else if (e.MouseEventArgs.Button == MouseButtons.Left)
            {
                if (e.GridRow.RowIndex > -1 && e.MouseEventArgs.Button == MouseButtons.Left)
                {
                    iItem = Convert.ToInt32(e.GridRow.Tag);
                    GridElement row = gItems.PrimaryGrid.Rows[e.GridRow.RowIndex];

                    Program.SQL.AddParameter("@id", row.Tag.ToString());
                    DataSet d = Program.SQL.SelectAll("SELECT * FROM items WHERE id=@id;");
                    if (d.Tables.Count > 0 && d.Tables[0].Rows.Count > 0)
                    {
                        DataRow r = d.Tables[0].Rows[0];

                        txtItemACat.Text = r["atex_category"].ToString();
                        txtItemAccess.Text = r["access_req"].ToString();
                        txtItemAGroup.Text = r["area_group"].ToString();
                        txtItemATRating.Text = r["area_trating"].ToString();
                        txtItemAZone.Text = r["area_zone"].ToString();
                        txtItemBarcode.Text = r["barcode"].ToString();
                        txtItemCableID.Text = r["cableid"].ToString();
                        txtItemCE.Text = r["ce_number"].ToString();
                        txtItemDescription.Text = r["description"].ToString();
                        txtItemDLDrawing.Text = r["drawing_device_loop"].ToString();
                        txtItemDType.Text = r["type_device"].ToString();
                        txtItemECert.Text = r["cert_equipment"].ToString();
                        txtItemIP.Text = r["ip_rating"].ToString();
                        txtItemMType.Text = r["type_model"].ToString();
                        txtItemPType.Text = r["type_protection"].ToString();
                        txtItemSerial.Text = r["serial"].ToString();
                        txtItemTag.Text = r["tag"].ToString();
                        txtItemTemp.Text = r["temp_range"].ToString();
                        txtItemTRating.Text = r["trating"].ToString();

                        cbxItemAGroup.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemAGroup.Items)
                        {
                            if (i.Text == r["atex_group"].ToString())
                            {
                                cbxItemAGroup.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemAProt.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemAProt.Items)
                        {
                            if (i.Text == r["atex_protection"].ToString())
                            {
                                cbxItemAProt.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemBarrier.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemBarrier.Items)
                        {
                            if (i.Text == r["barrier"].ToString())
                            {
                                cbxItemBarrier.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemDrawing.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemDrawing.Items)
                        {
                            if (i.Value.ToString().Equals(r["drawing"].ToString()))
                            {
                                cbxItemDrawing.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemEGroup.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemEGroup.Items)
                        {
                            if (i.Text == r["group_equipment"].ToString())
                            {
                                cbxItemEGroup.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemEPL.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemEPL.Items)
                        {
                            if (i.Text == r["epl"].ToString())
                            {
                                cbxItemEPL.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemEType.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemEType.Items)
                        {
                            if (i.Text == r["type_equipment"].ToString())
                            {
                                cbxItemEType.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemDrawingHac.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemDrawingHac.Items)
                        {
                            if (i.Value.ToString().Equals(r["drawing_hac"].ToString()))
                            {
                                cbxItemDrawingHac.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemManufacturer.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemManufacturer.Items)
                        {
                            if (i.Value.ToString().Equals(r["manufacturer"].ToString()))
                            {
                                cbxItemManufacturer.SelectedItem = i;
                                break;
                            }
                        }
                        cbxItemSuitable.SelectedIndex = -1;
                        foreach (DevComponents.Editors.ComboItem i in cbxItemSuitable.Items)
                        {
                            if (i.Text == r["suitable"].ToString())
                            {
                                cbxItemSuitable.SelectedItem = i;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void gItems_RowDoubleClick(object sender, GridRowDoubleClickEventArgs e)
        {
            EnableItem();
        }

        #endregion

        #region Menu Clicks

        private void cmLocationsManage_Click(object sender, EventArgs e)
        {
            Form frmLocation = new frmLocations();
            DialogResult dlg = frmLocation.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                gInspections.PrimaryGrid.Rows.Clear();
                gItems.PrimaryGrid.Rows.Clear();
                tvInspections.Nodes.Clear();
                tvItems.Nodes.Clear();
                LoadTreeData();
            }
        }

        private void cmLocationsExpand_Click(object sender, EventArgs e)
        {
            if (tvCurrent != null)
            {
                DevComponents.AdvTree.Node n = tvCurrent.SelectedNode;
                n.Expand();
            }
        }

        private void cmLocationsCollapse_Click(object sender, EventArgs e)
        {
            if (tvCurrent != null)
            {
                DevComponents.AdvTree.Node n = tvCurrent.SelectedNode;
                n.Collapse();
            }
        }

        private void cmLocationsExpandAll_Click(object sender, EventArgs e)
        {
            if (tvCurrent != null)
            {
                DevComponents.AdvTree.Node n = tvCurrent.SelectedNode;
                n.ExpandAll();
            }
        }

        private void cmLocationsCollapseAll_Click(object sender, EventArgs e)
        {
            if (tvCurrent != null)
            {
                DevComponents.AdvTree.Node n = tvCurrent.SelectedNode;
                n.CollapseAll();
            }
        }

        private void cmItemsAdd_Click(object sender, EventArgs e)
        {
            if (tvItems.SelectedNodes.Count == 0)
            {
                MessageBox.Show("Please select a location on the\nleft before adding an item.", "Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (tvItems.SelectedNode.Tag.ToString().Substring(0, 1) == "s")
            {
                iSite = Convert.ToInt32(tvItems.SelectedNode.Tag.ToString().Substring(2));
            }
            if (tvItems.SelectedNode.Tag.ToString().Substring(0, 1) == "a")
            {
                iSite = Convert.ToInt32((tvItems.SelectedNode.Parent).Tag.ToString().Substring(2));
                iArea = Convert.ToInt32(tvItems.SelectedNode.Tag.ToString().Substring(2));
            }
            if (tvItems.SelectedNode.Tag.ToString().Substring(0, 1) == "v")
            {
                iSite = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent).Tag.ToString().Substring(2));
                iArea = Convert.ToInt32((tvItems.SelectedNode.Parent).Tag.ToString().Substring(2));
                iVessel = Convert.ToInt32(tvItems.SelectedNode.Tag.ToString().Substring(2));
            }
            if (tvItems.SelectedNode.Tag.ToString().Substring(0, 1) == "f")
            {
                iSite = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent.Parent).Tag.ToString().Substring(2));
                iArea = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent).Tag.ToString().Substring(2));
                iVessel = Convert.ToInt32((tvItems.SelectedNode.Parent).Tag.ToString().Substring(2));
                iFloor = Convert.ToInt32(tvItems.SelectedNode.Tag.ToString().Substring(2));
            }
            if (tvItems.SelectedNode.Tag.ToString().Substring(0, 1) == "g")
            {
                iSite = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent.Parent.Parent).Tag.ToString().Substring(2));
                iArea = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent.Parent).Tag.ToString().Substring(2));
                iVessel = Convert.ToInt32((tvItems.SelectedNode.Parent.Parent).Tag.ToString().Substring(2));
                iFloor = Convert.ToInt32((tvItems.SelectedNode.Parent).Tag.ToString().Substring(2));
                iGrid = Convert.ToInt32(tvItems.SelectedNode.Tag.ToString().Substring(2));
            }

            txtItemACat.Text = "";
            txtItemAccess.Text = "";
            txtItemAGroup.Text = "";
            txtItemATRating.Text = "";
            txtItemAZone.Text = "";
            txtItemBarcode.Text = "";
            txtItemCableID.Text = "";
            txtItemCE.Text = "";
            txtItemDescription.Text = "";
            txtItemDLDrawing.Text = "";
            txtItemDType.Text = "";
            txtItemECert.Text = "";
            txtItemIP.Text = "";
            txtItemMType.Text = "";
            txtItemPType.Text = "";
            txtItemSerial.Text = "";
            txtItemTag.Text = "";
            txtItemTemp.Text = "";
            txtItemTRating.Text = "";
            txtItemCPRef.Text = "";
            cbxItemAGroup.SelectedIndex = -1;
            cbxItemAProt.SelectedIndex = -1;
            cbxItemBarrier.SelectedIndex = -1;
            cbxItemDrawing.SelectedIndex = -1;
            cbxItemEGroup.SelectedIndex = -1;
            cbxItemEPL.SelectedIndex = -1;
            cbxItemEType.SelectedIndex = -1;
            cbxItemDrawingHac.SelectedIndex = -1;
            cbxItemManufacturer.SelectedIndex = -1;
            cbxItemSuitable.SelectedIndex = -1;
            cbxItemTraceHC.SelectedIndex = -1;
            EnableItem();
        }

        private void cmItemsRemove_Click(object sender, EventArgs e)
        {
            if (gItems.PrimaryGrid.Rows.Count > 0)
            {
                string sItems = "";
                int iItemsSelected = 0;
                foreach (GridRow r in gItems.PrimaryGrid.Rows)
                {
                    if (r.Checked)
                    {
                        sItems += sItems.Length > 0 ? "," + r.Tag.ToString() : r.Tag.ToString();
                        iItemsSelected++;
                    }
                }

                if (sItems.Length > 0)
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove the " + iItemsSelected + " selected items?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM items WHERE id IN (" + sItems + ");");
                        if (iRes < 1)
                        {
                            MessageBox.Show("Removal of the selected items failed.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("The selected items were removed successfully.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadItems();
                        }
                    }
                }
            }
        }

        private void cmInspectionsAdd_Click(object sender, EventArgs e)
        {
            txtInspectionComments.Text = "";
            txtInspectionElectrical.Text = "";
            txtInspectionMechanical.Text = "";
            txtInspectionTag.Text = "";
            txtInspectionWorkOrder.Text = "";
            cbxInspectionInspector.SelectedIndex = -1;
            cbxInspectionSchedule.SelectedIndex = -1;
            gInspectionAnswers.PrimaryGrid.Rows.Clear();
            gInspectionFaults.PrimaryGrid.Rows.Clear();
            EnableInspection();
        }

        private void cmInspectionsRemove_Click(object sender, EventArgs e)
        {
            if (gInspections.PrimaryGrid.Rows.Count > 0)
            {
                string sInspections = "";
                int iInspectionsSelected = 0;
                foreach (GridRow r in gInspections.PrimaryGrid.Rows)
                {
                    if (r.Checked)
                    {
                        sInspections += sInspections.Length > 0 ? "," + r.Tag.ToString() : r.Tag.ToString();
                        iInspectionsSelected++;
                    }
                }

                if (sInspections.Length > 0)
                {
                    DialogResult dlg = MessageBox.Show("Are you sure you want to remove the " + iInspectionsSelected + " selected inspections?", "Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlg == DialogResult.Yes)
                    {
                        int iRes = Program.SQL.Delete("DELETE FROM inspections WHERE id IN (" + sInspections + ");");
                        if (iRes < 1)
                        {
                            MessageBox.Show("Removal of the selected inspections failed.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("The selected inspections were removed successfully.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadInspections();
                        }
                    }
                }
            }
        }

        private void cmInspectionsExport_Click(object sender, EventArgs e)
        {
            if (grInspection != null && dsInspections.Tables.Count == 1 && dsInspections.Tables[0].Rows.Count > 0 && dsItems.Tables.Count == 1 && dsItems.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in dsInspections.Tables[0].Rows)
                {
                    if (r["id"].ToString() == grInspection.Tag.ToString())
                    {
                        SharedData.drExportInspection = r;
                        break;
                    }
                }
                foreach (DataRow r in dsItems.Tables[0].Rows)
                {
                    if (r["id"].ToString() == grItem.Tag.ToString())
                    {
                        SharedData.drExportItem = r;
                        break;
                    }
                }

                Form frmReport = new frmReport();
                frmReport.ShowDialog();
            }
        }

        #endregion

        #region Button Clicks

        private void btnInspectionCancel_Click(object sender, EventArgs e)
        {
            EnableInspection(false);
        }

        private void btnInspectionSave_Click(object sender, EventArgs e)
        {
            if (txtInspectionTag.Text.Trim() == "")
            {
                MessageBox.Show("Please enter an item tag to continue.", "Item Tag", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tcInspections.SelectedTab = tiInspectionGeneral;
                ActiveControl = txtInspectionTag;
                txtInspectionTag.Focus();
                return;
            }

            string sTagID = "";
            Program.SQL.AddParameter("tag", Convert.ToInt32(txtInspectionTag.Text.Trim()));
            DataSet ds = Program.SQL.SelectAll("SELECT id FROM items WHERE tag=@tag;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sTagID = ds.Tables[0].Rows[0]["id"].ToString();
            }
            else
            {
                DialogResult dlg = MessageBox.Show("The item doesn't exist. Would you like to\nadd the item now after this inspection?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    bItemAdd = true;
                }
            }


            if (cbxInspectionInspector.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose an inspector to continue.", "Inspector", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tcInspections.SelectedTab = tiInspectionGeneral;
                ActiveControl = cbxInspectionInspector;
                cbxInspectionInspector.Focus();
                return;
            }

            if (cbxInspectionSchedule.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a schedule to continue.", "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tcInspections.SelectedTab = tiInspectionGeneral;
                ActiveControl = cbxInspectionSchedule;
                cbxInspectionSchedule.Focus();
                return;
            }

            if (sTagID != "" && cbxInspectionPriority.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a priority to continue.", "Priority", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tcInspections.SelectedTab = tiInspectionGeneral;
                ActiveControl = cbxInspectionPriority;
                cbxInspectionPriority.Focus();
                return;
            }

            Program.SQL.AddParameter("item", sTagID);
            Program.SQL.AddParameter("workorder", txtInspectionWorkOrder.Text.Trim());
            Program.SQL.AddParameter("electrical", txtInspectionElectrical.Text.Trim());
            Program.SQL.AddParameter("mechanical", txtInspectionMechanical.Text.Trim());
            Program.SQL.AddParameter("comments", txtInspectionComments.Text.Trim());
            DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxInspectionInspector.Items[cbxInspectionInspector.SelectedIndex];
            Program.SQL.AddParameter("inspector", Convert.ToInt32(i.Value));
            i = (DevComponents.Editors.ComboItem)cbxInspectionSchedule.Items[cbxInspectionSchedule.SelectedIndex];
            Program.SQL.AddParameter("schedule", Convert.ToInt32(i.Value));
            string sPriority = "";
            if (cbxInspectionPriority.SelectedIndex > -1)
            {
                i = (DevComponents.Editors.ComboItem)cbxInspectionPriority.Items[cbxInspectionPriority.SelectedIndex];
                sPriority = i.Value.ToString();
            }
            Program.SQL.AddParameter("priority", sPriority);
            Program.SQL.AddParameter("mod", DateTime.Now);

            int iRes = 0;
            if (iInspection > 0)
            {
                Program.SQL.AddParameter("id", iInspection);
                iRes = Program.SQL.Update("UPDATE inspections SET item=@item,workorder=@workorder,electrical=@electrical,mechanical=@mechanical,comments=@comments,inspector=@inspector,schedule=@schedule,priority=@priority,modified=@mod WHERE id=@id;");
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
                iRes = Program.SQL.Insert("INSERT INTO inspections (item,workorder,electrical,mechanical,comments,inspector,schedule,priority,modified,entered) VALUES (@item,@workorder,@electrical,@mechanical,@comments,@inspector,@schedule,@priority,@mod,@ent)");
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

            foreach (GridRow gr in gInspectionAnswers.PrimaryGrid.Rows)
            {
                DataSet d = Program.SQL.SelectAll("SELECT id,answer FROM inspections_answers WHERE inspection=" + iInspection + ";");
                if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in d.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["id"]).Equals(Convert.ToInt32(gr.Tag)))
                        {
                            //gr.Cells[3].Value;
                            Program.SQL.AddParameter("id", Convert.ToInt32(dr["id"]));
                            Program.SQL.AddParameter("answer", gr.Cells[3].ToString());
                            int a = Program.SQL.Update("UPDATE inspections_answers SET answer=@answer WHERE id=@id");
                        }
                    }
                }
            }

            foreach (GridRow gr in gInspectionFaults.PrimaryGrid.Rows)
            {
                DataSet d = Program.SQL.SelectAll("SELECT id,answer FROM inspections_faults WHERE inspection=" + iInspection + ";");
                if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in d.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["id"]).Equals(Convert.ToInt32(gr.Tag)) && ((gr.Cells[1] != null && dr["fault"].ToString() != gr.Cells[3].ToString()) || (gr.Cells[1] != null && dr["fault"].ToString() != gr.Cells[3].ToString())))
                        {
                            Program.SQL.AddParameter("id", Convert.ToInt32(dr["id"]));
                            Program.SQL.AddParameter("fault", gr.Cells[1].ToString());
                            Program.SQL.AddParameter("resolved", gr.Cells[2].ToString());
                            int f = Program.SQL.Update("UPDATE inspections_faults SET fault=@fault,resolved=@resolved WHERE id=@id");
                        }
                    }
                }
            }

            if (bItemAdd)
            {
                txtItemACat.Text = "";
                txtItemAccess.Text = "";
                txtItemAGroup.Text = "";
                txtItemATRating.Text = "";
                txtItemAZone.Text = "";
                txtItemBarcode.Text = "";
                txtItemCableID.Text = "";
                txtItemCE.Text = "";
                txtItemDescription.Text = "";
                txtItemDLDrawing.Text = "";
                txtItemDType.Text = "";
                txtItemECert.Text = "";
                txtItemIP.Text = "";
                txtItemMType.Text = "";
                txtItemPType.Text = "";
                txtItemSerial.Text = "";
                txtItemTag.Text = "";
                txtItemTemp.Text = "";
                txtItemTRating.Text = "";
                cbxItemAGroup.SelectedIndex = -1;
                cbxItemAProt.SelectedIndex = -1;
                cbxItemBarrier.SelectedIndex = -1;
                cbxItemDrawing.SelectedIndex = -1;
                cbxItemEGroup.SelectedIndex = -1;
                cbxItemEPL.SelectedIndex = -1;
                cbxItemEType.SelectedIndex = -1;
                cbxItemDrawingHac.SelectedIndex = -1;
                cbxItemManufacturer.SelectedIndex = -1;
                cbxItemSuitable.SelectedIndex = -1;
                ms.SelectedTab = mtItems;
                EnableItem();
            }
            else
            {
                iInspection = 0;
                if (iRes > 0)
                {
                    LoadInspections();
                }
            }

            EnableInspection(false);
        }

        private void btnItemCancel_Click(object sender, EventArgs e)
        {
            EnableItem(false);
        }

        private void btnItemSave_Click(object sender, EventArgs e)
        {
            Program.SQL.AddParameter("locationsite", iSite);
            Program.SQL.AddParameter("locationarea", iArea);
            Program.SQL.AddParameter("locationvessel", iVessel);
            Program.SQL.AddParameter("locationfloor", iFloor);
            Program.SQL.AddParameter("locationgrid", iGrid);

            DevComponents.Editors.ComboItem ci;
            int iManufacturer = 0, iDrawing = 0, iDrawingHac = 0;
            string sEType = "", sBarrier = "", sEGroup = "", sAtexGroup = "", sAtexProtection = "", sEPL = "", sSuitable = "", sTraceHC = "";

            if (cbxItemEType.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemEType.Items[cbxItemEType.SelectedIndex];
                sEType = ci.Text.ToString();
            }
            Program.SQL.AddParameter("type_equipment", sEType);
            Program.SQL.AddParameter("tag", txtItemTag.Text.Trim());
            Program.SQL.AddParameter("barcode", txtItemBarcode.Text.Trim());
            Program.SQL.AddParameter("cableid", txtItemCableID.Text.Trim());
            if (cbxItemManufacturer.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemManufacturer.Items[cbxItemManufacturer.SelectedIndex];
                iManufacturer = Convert.ToInt32(ci.Value);
            }
            Program.SQL.AddParameter("manufacturer", iManufacturer);
            Program.SQL.AddParameter("type_model", txtItemMType.Text.Trim());
            Program.SQL.AddParameter("serial", txtItemSerial.Text.Trim());
            Program.SQL.AddParameter("description", txtItemDescription.Text.Trim());
            Program.SQL.AddParameter("cert_equipment", txtItemECert.Text.Trim());
            if (cbxItemBarrier.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemBarrier.Items[cbxItemBarrier.SelectedIndex];
                sBarrier = ci.Text.ToString();
            }
            Program.SQL.AddParameter("barrier", sBarrier);
            Program.SQL.AddParameter("type_device", txtItemDType.Text.Trim());
            Program.SQL.AddParameter("type_protection", txtItemPType.Text.Trim());
            if (cbxItemEGroup.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemEGroup.Items[cbxItemEGroup.SelectedIndex];
                sEGroup = ci.Text.ToString();
            }
            Program.SQL.AddParameter("group_equipment", sEGroup);
            Program.SQL.AddParameter("trating", txtItemTRating.Text.Trim());
            if (cbxItemAGroup.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemAGroup.Items[cbxItemAGroup.SelectedIndex];
                sAtexGroup = ci.Text.ToString();
            }
            Program.SQL.AddParameter("atex_group", sAtexGroup);
            Program.SQL.AddParameter("atex_category", txtItemTRating.Text.Trim());
            if (cbxItemAProt.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemAProt.Items[cbxItemAProt.SelectedIndex];
                sAtexProtection = ci.Text.ToString();
            }
            Program.SQL.AddParameter("atex_protection", sAtexProtection);
            if (cbxItemEPL.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemEPL.Items[cbxItemEPL.SelectedIndex];
                sEPL = ci.Text.ToString();
            }
            Program.SQL.AddParameter("epl", sEPL);
            Program.SQL.AddParameter("ip_rating", txtItemIP.Text.Trim());
            Program.SQL.AddParameter("ce_number", txtItemCE.Text.Trim());
            if (cbxItemDrawing.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemDrawing.Items[cbxItemDrawing.SelectedIndex];
                iDrawing = Convert.ToInt32(ci.Value);
            }
            Program.SQL.AddParameter("drawing", iDrawing);
            if (cbxItemDrawingHac.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemDrawingHac.Items[cbxItemDrawingHac.SelectedIndex];
                iDrawingHac = Convert.ToInt32(ci.Value);
            }
            Program.SQL.AddParameter("drawing_hac", iDrawingHac);
            Program.SQL.AddParameter("drawing_device_loop", txtItemDLDrawing.Text.Trim());
            Program.SQL.AddParameter("temp_range", txtItemTemp.Text.Trim());
            Program.SQL.AddParameter("area_zone", txtItemAZone.Text.Trim());
            Program.SQL.AddParameter("area_group", txtItemAGroup.Text.Trim());
            Program.SQL.AddParameter("area_trating", txtItemATRating.Text.Trim());
            Program.SQL.AddParameter("access_req", txtItemAccess.Text.Trim());
            if (cbxItemSuitable.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemSuitable.Items[cbxItemSuitable.SelectedIndex];
                sSuitable = ci.Text.ToString();
            }
            Program.SQL.AddParameter("suitable", sSuitable);

            if (cbxItemTraceHC.SelectedIndex > -1)
            {
                ci = (DevComponents.Editors.ComboItem)cbxItemTraceHC.Items[cbxItemTraceHC.SelectedIndex];
                sTraceHC = ci.Value.ToString();
            }
            Program.SQL.AddParameter("tracehc", sTraceHC);
            Program.SQL.AddParameter("cpref", txtItemCPRef.Text.Trim());
            Program.SQL.AddParameter("ent", DateTime.Now);

            int iRes = 0;
            if (iItem > 0)
            {
                Program.SQL.AddParameter("id", iItem);
                iRes = Program.SQL.Update("UPDATE items SET locationsite=@locationsite,locationarea=@locationarea,locationvessel=@locationvessel,locationfloor=@locationfloor,locationgrid=@locationgrid,type_equipment=@type_equipment,tag=@tag,barcode=@barcode,cableid=@cableid,manufacturer=@manufacturer,type_model=@type_model,serial=@serial, description=@description,cert_equipment=@cert_equipment,barrier=@barrier,type_device=@type_device,type_protection=@type_protection,group_equipment=@group_equipment,trating=@trating,atex_group=@atex_group,atex_category=@atex_category,atex_protection=@atex_protection,epl=@epl,ip_rating=@ip_rating,ce_number=@ce_number,drawing=@drawing,drawing_hac=@drawing_hac,drawing_device_loop=@drawing_device_loop,temp_range=@temp_range,area_zone=@area_zone,area_group=@area_group,area_trating=@area_trating,access_req=@access_req,suitable=@suitable,tracehc=@tracehc,cpref=@cpref,modified=@ent WHERE id=@id");
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
                iRes = Program.SQL.Insert("INSERT INTO items (locationsite,locationarea,locationvessel,locationfloor,locationgrid,type_equipment,tag,barcode,cableid,manufacturer,type_model,serial,description,cert_equipment,barrier,type_device,type_protection,group_equipment,trating,atex_group,atex_category,atex_protection,epl,ip_rating,ce_number,drawing,drawing_hac,drawing_device_loop,temp_range,area_zone,area_group,area_trating,access_req,suitable,tracehc,cpref,entered,modified) VALUES (@locationsite,@locationarea,@locationvessel,@locationfloor,@locationgrid,@type_equipment,@tag,@barcode,@cableid,@manufacturer,@type_model,@serial,@description,@cert_equipment,@barrier,@type_device,@type_protection,@group_equipment,@trating,@atex_group,@atex_category,@atex_protection,@epl,@ip_rating,@ce_number,@drawing,@drawing_hac,@drawing_device_loop,@temp_range,@area_zone,@area_group,@area_trating,@access_req,@suitable,@tracehc,@cpref,@ent,@ent)");
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

            if (bItemAdd)
            {
                Program.SQL.AddParameter("id", iInspection);
                Program.SQL.AddParameter("item", iItem);
                iRes = Program.SQL.Update("UPDATE inspections SET item=@item WHERE id=@id");

                iInspection = 0;
                bItemAdd = false;
                EnableInspection(false);
                ms.SelectedTab = mtInspections;
                if (iRes > 0)
                {
                    LoadInspections();
                }
            }

            iItem = 0;
            iSite = 0;
            iArea = 0;
            iVessel = 0;
            iFloor = 0;
            iGrid = 0;
            EnableItem(false);
            if (iRes > 0)
            {
                LoadItems();
            }
        }

        private void btnItemManufacturer_Click(object sender, EventArgs e)
        {
            Form frmManufacturer = new frmManufacturer();
            DialogResult dlg = frmManufacturer.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iManufacturer > 0)
            {
                LoadLists();
                foreach (DevComponents.Editors.ComboItem i in cbxItemManufacturer.Items)
                {
                    if (Convert.ToInt32(i.Value) == SharedData.iManufacturer)
                    {
                        cbxItemManufacturer.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        private void btnItemDrawing_Click(object sender, EventArgs e)
        {
            Form frmDrawing = new frmDrawing();
            DialogResult dlg = frmDrawing.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iDrawing > 0)
            {
                LoadLists();
                foreach (DevComponents.Editors.ComboItem i in cbxItemDrawing.Items)
                {
                    if (Convert.ToInt32(i.Value) == SharedData.iDrawing)
                    {
                        cbxItemDrawing.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        private void btnItemDrawingHac_Click(object sender, EventArgs e)
        {
            Form frmDrawingHac = new frmDrawingHac();
            DialogResult dlg = frmDrawingHac.ShowDialog();
            if (dlg == DialogResult.OK && SharedData.iDrawingHac > 0)
            {
                LoadLists();
                foreach (DevComponents.Editors.ComboItem i in cbxItemDrawingHac.Items)
                {
                    if (Convert.ToInt32(i.Value) == SharedData.iDrawingHac)
                    {
                        cbxItemDrawingHac.SelectedItem = i;
                        break;
                    }
                }
            }
        }

        #endregion

        #region Changed

        private void btnItemManufacturer_MouseEnter(object sender, EventArgs e)
        {
            btnItemManufacturer.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnItemManufacturer_MouseLeave(object sender, EventArgs e)
        {
            btnItemManufacturer.Image = Properties.Resources.btn_data_add_16_off;
        }

        private void btnItemDrawing_MouseEnter(object sender, EventArgs e)
        {
            btnItemDrawing.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnItemDrawing_MouseLeave(object sender, EventArgs e)
        {
            btnItemDrawing.Image = Properties.Resources.btn_data_add_16_off;
        }

        private void btnItemDrawingHac_MouseEnter(object sender, EventArgs e)
        {
            btnItemDrawingHac.Image = Properties.Resources.btn_data_add_16_on;
        }

        private void btnItemDrawingHac_MouseLeave(object sender, EventArgs e)
        {
            btnItemDrawingHac.Image = Properties.Resources.btn_data_add_16_off;
        }

        private void cbxItemDrawing_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxItemDrawing.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxItemDrawing.Items[cbxItemDrawing.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    Program.SQL.AddParameter("id", Convert.ToInt32(i.Value));
                    DataSet ds = Program.SQL.SelectAll("SELECT revision,date FROM lists_drawings WHERE id=@id");
                    if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblItemDrawingRevVal.Text = ds.Tables[0].Rows[0]["revision"].ToString();
                        lblItemDrawingDateVal.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"].ToString()).ToShortDateString();
                    }
                }
            }
        }

        private void cbxItemHACDrawing_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxItemDrawingHac.SelectedIndex > -1)
            {
                DevComponents.Editors.ComboItem i = (DevComponents.Editors.ComboItem)cbxItemDrawingHac.Items[cbxItemDrawingHac.SelectedIndex];
                if (i.Value.ToString() != "")
                {
                    Program.SQL.AddParameter("id", Convert.ToInt32(i.Value));
                    DataSet ds = Program.SQL.SelectAll("SELECT revision,date FROM lists_drawings_hac WHERE id=@id");
                    if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblItemHACDrawingRevVal.Text = ds.Tables[0].Rows[0]["revision"].ToString();
                        lblItemHACDrawingDateVal.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"].ToString()).ToShortDateString();
                    }
                }
            }
        }

        private void dtInspectionsFilterFrom_TextChanged(object sender, EventArgs e)
        {
            LoadInspections();
        }

        private void dtInspectionsFilterTo_TextChanged(object sender, EventArgs e)
        {
            LoadInspections();
        }

        private void dtItemsFilterFrom_TextChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void dtItemsFilterTo_TextChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        #endregion
    }
}
