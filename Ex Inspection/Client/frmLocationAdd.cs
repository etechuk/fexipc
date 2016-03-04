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
    public partial class frmLocationAdd : MetroForm
    {
        public frmLocationAdd()
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

            DialogResult = DialogResult.Cancel;
            lblLocation.Text = SharedData.sLocationType.Substring(0, 1).ToUpper() + SharedData.sLocationType.Substring(1) + " Name:";

            if (SharedData.bLocationEdit)
            {
                switch (SharedData.sLocationType)
                {
                    case "area":
                        txtLocation.Text = SharedData.sLocationArea;
                        break;
                    case "vessel":
                        txtLocation.Text = SharedData.sLocationVessel;
                        break;
                    case "floor":
                        txtLocation.Text = SharedData.sLocationFloor;
                        break;
                    case "grid":
                        txtLocation.Text = SharedData.sLocationGrid;
                        break;
                    default:
                        txtLocation.Text = SharedData.sLocationSite;
                        break;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SharedData.sLocationType = "";
            SharedData.iLocationSite = 0;
            SharedData.iLocationArea = 0;
            SharedData.iLocationVessel = 0;
            SharedData.iLocationFloor = 0;
            SharedData.iLocationGrid = 0;
            SharedData.sLocationSite = "";
            SharedData.sLocationArea = "";
            SharedData.sLocationVessel = "";
            SharedData.sLocationFloor = "";
            SharedData.sLocationGrid = "";
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text.Trim() == "")
            {
                MessageBox.Show("Enter a location to continue.", "Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                if (!SharedData.bLocationEdit)
                {
                    DataSet ds;
                    Program.SQL.AddParameter("name", txtLocation.Text.Trim().ToLower());
                    ds = Program.SQL.SelectAll("SELECT id FROM locations_" + SharedData.sLocationType + "s WHERE LOWER(name)=@name;");
                    if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("The " + SharedData.sLocationType + " already exists.\nPlease try again.", SharedData.sLocationType.Substring(0, 1).ToUpper() + SharedData.sLocationType.Substring(1), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                string sInsertCols = "name", sInsertVals = "@name", sUpdate = "name=@name";
                switch (SharedData.sLocationType)
                {
                    case "area":
                        sInsertCols += ",site";
                        sInsertVals += ",@site";
                        sUpdate += ",site=@site";
                        Program.SQL.AddParameter("site", SharedData.iLocationSite);
                        break;

                    case "vessel":
                        sInsertCols += ",site,area";
                        sInsertVals += ",@site,@area";
                        sUpdate += ",site=@site,area=@area";
                        Program.SQL.AddParameter("site", SharedData.iLocationSite);
                        Program.SQL.AddParameter("area", SharedData.iLocationArea);
                        break;

                    case "floor":
                        sInsertCols += ",site,area,vessel";
                        sInsertVals += ",@site,@area,@vessel";
                        sUpdate += ",site=@site,area=@area,vessel=@vessel";
                        Program.SQL.AddParameter("site", SharedData.iLocationSite);
                        Program.SQL.AddParameter("area", SharedData.iLocationArea);
                        Program.SQL.AddParameter("vessel", SharedData.iLocationVessel);
                        break;

                    case "grid":
                        sInsertCols += ",site,area,vessel,floor";
                        sInsertVals += ",@site,@area,@vessel,@floor";
                        sUpdate += ",site=@site,area=@area,vessel=@vessel,floor=@floor";
                        Program.SQL.AddParameter("site", SharedData.iLocationSite);
                        Program.SQL.AddParameter("area", SharedData.iLocationArea);
                        Program.SQL.AddParameter("vessel", SharedData.iLocationVessel);
                        Program.SQL.AddParameter("floor", SharedData.iLocationFloor);
                        break;
                }

                Program.SQL.AddParameter("name", txtLocation.Text.Trim());
                Program.SQL.AddParameter("ent", DateTime.Now);
                int iRes = 0;

                if (SharedData.bLocationEdit)
                {
                    int iID = 0;
                    switch (SharedData.sLocationType)
                    {
                        case "area":
                            iID = SharedData.iLocationArea;
                            break;
                        case "vessel":
                            iID = SharedData.iLocationVessel;
                            break;
                        case "floor":
                            iID = SharedData.iLocationFloor;
                            break;
                        case "grid":
                            iID = SharedData.iLocationGrid;
                            break;
                        default:
                            iID = SharedData.iLocationSite;
                            break;
                    }
                    Program.SQL.AddParameter("id", iID);
                    sUpdate += ",modified=@ent";
                    iRes = Program.SQL.Update("UPDATE locations_" + SharedData.sLocationType + "s SET " + sUpdate + " WHERE id=@id");
                }
                else
                {
                    sInsertCols += ",entered,modified";
                    sInsertVals += ",@ent,@ent";
                    iRes = Program.SQL.Insert("INSERT INTO locations_" + SharedData.sLocationType + "s (" + sInsertCols + ") VALUES (" + sInsertVals + ")");
                }

                if (iRes < 1)
                {
                    MessageBox.Show("Failed to " + (SharedData.bLocationEdit ? "update" : "add") + " the location.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    switch (SharedData.sLocationType)
                    {
                        case "area":
                            SharedData.iLocationArea = iRes;
                            break;
                        case "vessel":
                            SharedData.iLocationVessel = iRes;
                            break;
                        case "floor":
                            SharedData.iLocationFloor = iRes;
                            break;
                        case "grid":
                            SharedData.iLocationGrid = iRes;
                            break;
                        default:
                            SharedData.iLocationSite = iRes;
                            break;
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
