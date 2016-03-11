using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public class Globals
    {
        static bool _UserIsSigned = false;
        static bool _UserIsAdmin = false;
        static int _UserID = 0;
        static string _UserFirstName = "";
        static string _UserLastName = "";
        static int _UserLocation = 0;

        public bool UserIsSigned { get { return _UserIsSigned; } set { _UserIsSigned = value; } }
        public bool UserIsAdmin { get { return _UserIsAdmin; } set { _UserIsAdmin = value; } }
        public int UserID { get { return _UserID; } set { _UserID = value; } }
        public string UserFirstName { get { return _UserFirstName; } set { _UserFirstName = value; } }
        public string UserLastName { get { return _UserLastName; } set { _UserLastName = value; } }
        public int UserLocation { get { return _UserLocation; } set { _UserLocation = value; } }

        public string StringGetBetween(string sAll, string sFrom, string sTo)
        {
            string sOut;
            int p1 = sAll.IndexOf(sFrom) + sFrom.Length;
            int p2 = sAll.IndexOf(sTo);
            sOut = sAll.Substring(p1, p2 - p1);
            return sOut;
        }

        public string FileGetTypeFromExtension(string sExt = "")
        {
            string sOut;
            switch (sExt)
            {
                case "doc":
                case "docx": sOut = "Word document"; break;
                case "xls":
                case "xlsx": sOut = "Excel workbook"; break;
                case "rgf": sOut = "ExI Template file"; break;
                case "pdf": sOut = "Adobe PDF file"; break;
                case "txt": sOut = "Text file"; break;
                default: sOut = sExt + " file"; break;
            }
            return sOut;
        }

        public string EncodePassword(string sPass)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(sPass), 0, Encoding.UTF8.GetByteCount(sPass));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static void CopyResource(Stream input, Stream output)
        {
            // Insert null checking here for production
            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
    }

    public static class Extension
    {
        public static Form FormCentre(this Form fChild, Form fParent)
        {
            fChild.StartPosition = FormStartPosition.Manual;
            fChild.Location = new Point(fParent.Location.X + (fParent.Width - fChild.Width) / 2, fParent.Location.Y + (fParent.Height - fChild.Height) / 2);
            return fChild;
        }

        public static bool DirIsWritable(string sPath, bool bThrowIfFailed = false)
        {
            try
            {
                using (FileStream fs = File.Create(Path.Combine(sPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose)) { }
                return true;
            }
            catch
            {
                if (bThrowIfFailed)
                {
                    throw;
                }
                else
                {
                    return false;
                }
            }
        }

        public class AlphanumComparatorFast : IComparer
        {
            public int Compare(object x, object y)
            {
                string s1 = x as string;
                if (s1 == null)
                {
                    return 0;
                }

                string s2 = y as string;
                if (s2 == null)
                {
                    return 0;
                }

                int iLen1 = s1.Length;
                int iLen2 = s2.Length;
                int iMarker1 = 0;
                int iMarker2 = 0;

                // Walk through two the strings with two markers.
                while (iMarker1 < iLen1 && iMarker2 < iLen2)
                {
                    char cCh1 = s1[iMarker1];
                    char cCh2 = s2[iMarker2];

                    // Some buffers we can build up characters in for each chunk.
                    char[] cSpace1 = new char[iLen1];
                    int iLoc1 = 0;
                    char[] cSpace2 = new char[iLen2];
                    int iLoc2 = 0;

                    // Walk through all following characters that are digits or characters in BOTH strings starting at the appropriate marker.
                    // Collect char arrays.
                    do
                    {
                        cSpace1[iLoc1++] = cCh1;
                        iMarker1++;

                        if (iMarker1 < iLen1)
                        {
                            cCh1 = s1[iMarker1];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(cCh1) == char.IsDigit(cSpace1[0]));

                    do
                    {
                        cSpace2[iLoc2++] = cCh2;
                        iMarker2++;

                        if (iMarker2 < iLen2)
                        {
                            cCh2 = s2[iMarker2];
                        }
                        else
                        {
                            break;
                        }
                    } while (char.IsDigit(cCh2) == char.IsDigit(cSpace2[0]));

                    // If we have collected numbers, compare them numerically.
                    // Otherwise, if we have strings, compare them alphabetically.
                    string sStr1 = new string(cSpace1);
                    string sStr2 = new string(cSpace2);
                    int iResult;

                    if (char.IsDigit(cSpace1[0]) && char.IsDigit(cSpace2[0]))
                    {
                        int thisNumericChunk = int.Parse(sStr1);
                        int thatNumericChunk = int.Parse(sStr2);
                        iResult = thisNumericChunk.CompareTo(thatNumericChunk);
                    }
                    else
                    {
                        iResult = sStr1.CompareTo(sStr2);
                    }

                    if (iResult != 0)
                    {
                        return iResult;
                    }
                }
                return iLen1 - iLen2;
            }
        }
    }

    public static class Utils
    {
        public static bool Reg_TryGetAssociation(string sExt, out string sApp)
        {
            string sExtId = Reg_GetClassesRootValueDefault(sExt);
            if (sExtId == null)
            {
                sApp = null;
                return false;
            }

            string sOpenCmd = Reg_GetClassesRootValueDefault(Path.Combine(new[] { sExtId, "shell", "open", "command" }));

            if (sOpenCmd == null)
            {
                sApp = null;
                return false;
            }

            if (sOpenCmd.Contains("\""))
            {
                sOpenCmd = sOpenCmd.Split(new[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else
            {
                sOpenCmd = sOpenCmd.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            sApp = sOpenCmd;

            return true;
        }

        private static string Reg_GetClassesRootValueDefault(string sKeyPath)
        {
            using (var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(sKeyPath))
            {
                if (key == null)
                {
                    return null;
                }

                var defVal = key.GetValue(null);
                if (defVal == null)
                {
                    return null;
                }

                return defVal.ToString();
            }
        }
    }
}
