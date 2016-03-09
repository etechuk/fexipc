using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using DevComponents.DotNetBar.Metro;

namespace Client
{
    public partial class frmReport : MetroForm
    {
        public frmReport()
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

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (!SharedData.bExportMultiple && SharedData.drExportInspection != null)
            {
                int iItem = SharedData.drExportInspection["item"] != DBNull.Value ? Convert.ToInt32(SharedData.drExportInspection["item"]) : 0;
                int iSchedule = SharedData.drExportInspection["schedule"] != DBNull.Value ? Convert.ToInt32(SharedData.drExportInspection["schedule"]) : 0;

                DataSet dItem = Program.SQL.SelectAll("SELECT * FROM items WHERE id=" + iItem + ";");
                DataSet dSchedule = Program.SQL.SelectAll("SELECT grade,type FROM schedules WHERE id=" + iSchedule + ";");
                if (dItem.Tables.Count < 1 || dItem.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("No item was found for the selected inspection.", "No Item", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (dSchedule.Tables.Count < 1 || dSchedule.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("No schedule was found for the selected inspection.", "No Schedule", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                DataRow dIn = SharedData.drExportInspection;
                SharedData.drExportInspection = null;

                int iInspection = dIn["id"] != DBNull.Value ? Convert.ToInt32(dIn["id"]) : 0;
                if (iInspection > 0 && iItem > 0 && iSchedule > 0)
                {
                    DataSet ds = new DataSet(), d;
                    DataTable dt = new DataTable("inspection");
                    dt.Columns.Add("inspection");
                    ds.Tables.Add(dt);
                    DataRow dIt = dItem.Tables[0].Rows[0], dSc = dSchedule.Tables[0].Rows[0];

                    //rv.LocalReport.ReportPath = Properties.Settings.Default.PathToData + @"\templates\inspections_" + dSchedule.Tables[0].Rows[0]["type"].ToString().ToLower();
                    rv.LocalReport.ReportEmbeddedResource = "Client.Reports.rptInspectionI.rdlc";
                    rv.LocalReport.DataSources.Clear();

                    string sInspector = "";
                    int iInspector = dIn["inspector"] != DBNull.Value ? Convert.ToInt32(dIn["inspector"]) : 0;
                    if (iInspector > 0)
                    {
                        d = Program.SQL.SelectAll("SELECT name_first,name_last FROM users WHERE id=" + iInspector + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sInspector = d.Tables[0].Rows[0]["name_first"].ToString() + " " + d.Tables[0].Rows[0]["name_last"].ToString();
                        }
                    }

                    string sLocation = "", sLocationSite = "", sLocationArea = "", sLocationVessel = "", sLocationFloor = "", sLocationGrid = "";
                    if (dIt["locationsite"] != DBNull.Value && dIt["locationsite"].ToString().All(char.IsDigit))
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM locations_sites WHERE id=" + dIt["locationsite"].ToString() + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sLocationSite = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }
                    if (dIt["locationarea"] != DBNull.Value && dIt["locationarea"].ToString().All(char.IsDigit))
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM locations_areas WHERE id=" + dIt["locationarea"].ToString() + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sLocationArea = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }
                    if (dIt["locationvessel"] != DBNull.Value && dIt["locationvessel"].ToString().All(char.IsDigit))
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM locations_vessels WHERE id=" + dIt["locationvessel"].ToString() + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sLocationVessel = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }
                    if (dIt["locationfloor"] != DBNull.Value && dIt["locationfloor"].ToString().All(char.IsDigit))
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM locations_floors WHERE id=" + dIt["locationfloor"].ToString() + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sLocationFloor = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }
                    if (dIt["locationgrid"] != DBNull.Value && dIt["locationgrid"].ToString().All(char.IsDigit))
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM locations_grids WHERE id=" + dIt["locationgrid"].ToString() + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sLocationGrid = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }

                    sLocation = sLocationSite.Length > 0 ? sLocationSite : "";
                    sLocation += sLocationArea.Length > 0 ? " " + sLocationArea : "";
                    sLocation += sLocationVessel.Length > 0 ? " " + sLocationVessel : "";
                    sLocation += sLocationFloor.Length > 0 ? " " + sLocationFloor : "";
                    sLocation += sLocationGrid.Length > 0 ? " " + sLocationGrid : "";

                    string sManufacturer = "";
                    int iManufacturer = dIt["manufacturer"] != DBNull.Value ? Convert.ToInt32(dIt["manufacturer"]) : 0;
                    if (iManufacturer > 0)
                    {
                        d = Program.SQL.SelectAll("SELECT name FROM lists_manufacturers WHERE id=" + iManufacturer + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sManufacturer = d.Tables[0].Rows[0]["name"].ToString();
                        }
                    }

                    string sDrawingHac = "";
                    int iDrawingHac = dIt["drawing_hac"] != DBNull.Value ? Convert.ToInt32(dIt["drawing_hac"]) : 0;
                    if (iDrawingHac > 0)
                    {
                        d = Program.SQL.SelectAll("SELECT name,revision,date FROM lists_drawings_hac WHERE id=" + iDrawingHac + ";");
                        if (d.Tables.Count == 1 && d.Tables[0].Rows.Count == 1)
                        {
                            sDrawingHac = d.Tables[0].Rows[0]["name"].ToString();
                            sDrawingHac += d.Tables[0].Rows[0]["revision"] != DBNull.Value ? " Rev. " + d.Tables[0].Rows[0]["revision"].ToString() : "";
                            sDrawingHac += d.Tables[0].Rows[0]["date"] != DBNull.Value ? " (" + Convert.ToDateTime(d.Tables[0].Rows[0]["date"]).ToShortDateString() + ")" : "";
                        }
                    }

                    string sAtexProtection = dIt["atex_protection"] != DBNull.Value ? dIt["atex_protection"].ToString() : "";
                    sAtexProtection += dIt["atex_group"] != DBNull.Value ? " " + dIt["atex_group"].ToString() : "";
                    sAtexProtection += dIt["atex_category"] != DBNull.Value ? " " + dIt["atex_category"].ToString() : "";

                    string sHacZone = dIt["area_zone"] != DBNull.Value ? dIt["area_zone"].ToString() : "";
                    sHacZone += dIt["area_group"] != DBNull.Value ? " " + dIt["area_group"].ToString() : "";
                    sHacZone += dIt["area_trating"] != DBNull.Value ? " " + dIt["area_trating"].ToString() : "";

                    ReportParameterCollection p = new ReportParameterCollection();

                    // INSPECTION
                    p.Add(new ReportParameter("inspection", iInspection.ToString()));
                    p.Add(new ReportParameter("workorder", dIn["workorder"] != DBNull.Value ? dIn["workorder"].ToString() : ""));
                    p.Add(new ReportParameter("inspector", sInspector));

                    // ITEM
                    p.Add(new ReportParameter("locationsite", sLocationSite));
                    p.Add(new ReportParameter("locationarea", sLocationArea));
                    p.Add(new ReportParameter("locationvessel", sLocationVessel));
                    p.Add(new ReportParameter("locationfloor", sLocationFloor));
                    p.Add(new ReportParameter("locationgrid", sLocationGrid));
                    p.Add(new ReportParameter("location3", sLocation));
                    p.Add(new ReportParameter("description", dIt["description"] != DBNull.Value ? dIt["description"].ToString() : ""));
                    p.Add(new ReportParameter("manufacturer", sManufacturer));
                    p.Add(new ReportParameter("serial", dIt["serial"] != DBNull.Value ? dIt["serial"].ToString() : ""));
                    p.Add(new ReportParameter("barrier", dIt["barrier"] != DBNull.Value ? dIt["barrier"].ToString() : ""));
                    p.Add(new ReportParameter("typemodel", dIt["type_model"] != DBNull.Value ? dIt["type_model"].ToString() : ""));
                    p.Add(new ReportParameter("drawinghac", sManufacturer));
                    p.Add(new ReportParameter("drawingdl", dIt["drawing_device_loop"] != DBNull.Value ? dIt["drawing_device_loop"].ToString() : ""));
                    p.Add(new ReportParameter("atexprotection", sAtexProtection));
                    p.Add(new ReportParameter("protectioneq", dIt["type_protection"] != DBNull.Value ? dIt["type_protection"].ToString() : ""));
                    p.Add(new ReportParameter("haczone", sAtexProtection));
                    p.Add(new ReportParameter("cpref", dIt["cpref"] != DBNull.Value ? dIt["cpref"].ToString() : ""));

                    // ANSWERS
                    DataSet at = Program.SQL.SelectAll("SELECT id,question,part,answer FROM inspections_answers WHERE inspection=" + iInspection + ";");
                    if (at.Tables.Count == 1 && at.Tables[0].Rows.Count > 0)
                    {
                        DataSet st = Program.SQL.SelectAll("SELECT questions FROM schedules WHERE id=" + iSchedule + ";");
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
                                    string sAnswer = "";
                                    string sQRef = qr["letter"].ToString() + dSc["grade"] + Convert.ToInt32(qr["number"]).ToString();
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
                                                    sQRef = qr["letter"].ToString() + dSc["grade"] + Convert.ToInt32(qr["number"]).ToString() + "_" + (i + 1);
                                                    p.Add(new ReportParameter(sQRef, sAnswer));
                                                }
                                            }
                                            else
                                            {
                                                p.Add(new ReportParameter(sQRef, sAnswer));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // FAULTS
                    DataSet ft = Program.SQL.SelectAll("SELECT id,question,part,fault FROM inspections_faults WHERE inspection=" + iInspection + ";");

                    rv.LocalReport.SetParameters(p);
                    rv.LocalReport.DataSources.Add(new ReportDataSource("Inspection", ds.Tables[0]));
                    rv.RefreshReport();
                }
            }
        }
    }
}
