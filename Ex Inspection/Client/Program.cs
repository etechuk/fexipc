using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

using Common;

namespace Client
{
    static class Program
    {
        public static Database SQL;
        public static Database SQLite;
        public static Globals Globals = new Globals();

        public static System.Drawing.Color cWindowColour = System.Drawing.ColorTranslator.FromHtml(Properties.Settings.Default.WindowColour.Length > 0 ? Properties.Settings.Default.WindowColour : "#80397B");
        public static bool bUserSignOut = false;
        public static Form frmCurrent;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.PathToData == "")
            {
                string sDir = Path.GetPathRoot(Environment.SystemDirectory) + @"\FES Data\";
                Properties.Settings.Default.PathToData = sDir;
                Properties.Settings.Default.Save();
            }

            if (!Directory.Exists(Properties.Settings.Default.PathToData))
            {
                DirectoryInfo inf = Directory.CreateDirectory(Properties.Settings.Default.PathToData);
            }

            if (!File.Exists(Properties.Settings.Default.PathToData + @"exinspection.apk"))
            {
                Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream("Client.Resources.exinspection.apk");
                FileStream fs = new FileStream(Properties.Settings.Default.PathToData + @"exinspection.apk", FileMode.CreateNew);
                for (int i = 0; i < s.Length; i++)
                {
                    fs.WriteByte((byte)s.ReadByte());
                }
                fs.Close();
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            SQL = new Database(
                SqlProviders.SqlServer,
                Properties.Settings.Default.DataHost.Length > 0 ? Properties.Settings.Default.DataHost : "localhost",
                Properties.Settings.Default.DataPort.Length > 0 ? Properties.Settings.Default.DataPort : "",
                Properties.Settings.Default.DataUser.Length > 0 ? Properties.Settings.Default.DataUser : "",
                Properties.Settings.Default.DataPass.Length > 0 ? Properties.Settings.Default.DataPass : "",
                Properties.Settings.Default.DataName.Length > 0 ? Properties.Settings.Default.DataName : "exinspection"
            );

            SQLite = new Database(
                SqlProviders.SQLite, 
                @Properties.Settings.Default.PathToData
            );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Globals.UserIsSigned)
            {
                frmCurrent = new frmSignIn();
                Application.Run(frmCurrent);
            }
        }
    }

    public static class SharedData
    {
        public static bool bExportMultiple = false;
        public static DataRow drExportInspection;
        public static DataRow drExportItem;

        public static string sEmail = "";
        public static string sPhone = "";
        public static string sPostal = "";
        public static string sPassword = "";

        public static string sLocationType = "";
        public static bool bLocationEdit = false;
        public static string sLocationSite = "";
        public static string sLocationArea = "";
        public static string sLocationVessel = "";
        public static string sLocationFloor = "";
        public static string sLocationGrid = "";
        public static int iLocationSite = 0;
        public static int iLocationArea = 0;
        public static int iLocationVessel = 0;
        public static int iLocationFloor = 0;
        public static int iLocationGrid = 0;

        public static int iManufacturer = 0;
        public static int iDrawing = 0;
        public static int iDrawingHac = 0;
    }
}
