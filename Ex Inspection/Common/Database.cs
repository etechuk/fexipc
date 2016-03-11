using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace Common
{
    #region Enums

    public enum SqlProviders
    {
        SQLite, SqlServer
    }

    #endregion

    public class Database
    {
        #region Members

        private string sConnection;
        private string sDbPathSQLite = "";
        private string sDbFileSQLite = "fexi.db";

        private DbProviderFactory dbFactory;
        private DbCommand dbCommand;
        private DbConnection dbConnection;

        private SQLiteFactory sqlFactory;
        private SQLiteCommand sqlCommand;
        private SQLiteConnection sqlConnection;

        #endregion

        #region Properties

        public DbCommand Command
        {
            get
            {
                return dbCommand;
            }
        }

        public DbConnection Connection
        {
            get
            {
                return dbConnection;
            }
        }

        public SQLiteCommand Command2
        {
            get
            {
                return (SQLiteCommand)sqlCommand;
            }
        }

        public SQLiteConnection Connection2
        {
            get
            {
                return (SQLiteConnection)sqlConnection;
            }
        }

        public string ConnectionString
        {
            get
            {
                return sConnection;
            }
            set
            {
                if (value != "")
                {
                    sConnection = value;
                }
            }
        }

        #endregion

        #region Parameters

        public int AddParameter(DbParameter p)
        {
            return Command.Parameters.Add(p);
        }

        public int AddParameter(string name, object value, string type = "", int length = -1)
        {
            DbParameter p = dbFactory.CreateParameter();
            if (type == "image")
            {
                //p = new SqlParameter(name, SqlDbType.VarBinary, length);
                p.DbType = DbType.Binary;
            }
            else
            {
                //p.ParameterName = name;
            }
            p.ParameterName = name;
            p.Value = value;
            return Command.Parameters.Add(p);
        }

        #endregion

        public Database(SqlProviders pType, string sHost, string sPort = "", string sUser = "", string sPass = "", string sData = "")
        {
            SetSession(pType, sHost, sPort, sUser, sPass, sData);
        }

        #region Connection Methods

        public void SetSession(SqlProviders pType, string sHost, string sPort = "", string sUser = "", string sPass = "", string sData = "")
        {
            switch (pType)
            {
                case SqlProviders.SqlServer:
                    dbFactory = SqlClientFactory.Instance;

                    sConnection = "Server=" + sHost + (sPort.Length > 0 ? "," + sPort : "");
                    if (sUser != "")
                    {
                        sConnection += ";User Id=" + sUser;
                        if (sPass != "")
                        {
                            sConnection += ";Password=" + sPass;
                        }
                    }
                    else
                    {
                        sConnection += ";Integrated Security=True;Trusted_Connection=True";
                    }

                    sConnection += ";Initial Catalog=" + sData + ";";
                    dbConnection = dbFactory.CreateConnection();
                    dbCommand = dbFactory.CreateCommand();
                    dbConnection.ConnectionString = sConnection;
                    dbCommand.Connection = dbConnection;
                    break;

                case SqlProviders.SQLite:
                    sqlFactory = SQLiteFactory.Instance;
                    sDbPathSQLite = sHost + @"\" + sDbFileSQLite;

                    if (!Directory.Exists(sHost))
                    {
                        Directory.CreateDirectory(sHost);
                    }

                    SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
                    sb.DefaultTimeout = 5000;
                    sb.SyncMode = SynchronizationModes.Off;
                    sb.JournalMode = SQLiteJournalModeEnum.Memory;
                    sb.PageSize = 65536;
                    sb.CacheSize = 16777216;
                    sb.FailIfMissing = false;
                    sb.ReadOnly = false;

                    sConnection = "data source=" + @sDbPathSQLite + ";" + sb.ConnectionString;
                    sqlConnection = (SQLiteConnection)sqlFactory.CreateConnection();
                    sqlCommand = (SQLiteCommand)sqlFactory.CreateCommand();
                    sqlConnection.ConnectionString = sConnection;
                    sqlCommand.Connection = sqlConnection;
                    break;
            }

        }

        public bool IsConnected()
        {
            return dbConnection != null;
        }

        #endregion

        #region SQL Data Methods

        public int Delete(string query)
        {
            int iAffected = 0;
            DbDataAdapter adapter = dbFactory.CreateDataAdapter();
            Command.CommandType = CommandType.Text;
            Command.CommandText = query;
            adapter.DeleteCommand = Command;

            try
            {
                Connection.Open();
                iAffected = adapter.DeleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    //Connection.Dispose();
                    Command.Dispose();
                }
            }

            return iAffected;
        }

        public int Insert(string query, bool returnID = true)
        {
            int iInsertID = 0;
            DbDataAdapter adapter = dbFactory.CreateDataAdapter();
            Command.CommandType = CommandType.Text;
            Command.CommandText = query + ";" + (returnID == true ? " SELECT CAST(scope_identity() AS int);" : "");
            adapter.InsertCommand = Command;

            try
            {
                Connection.Open();
                iInsertID = (int)adapter.InsertCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    //Connection.Dispose();
                    Command.Dispose();
                }
            }

            return iInsertID;
        }

        public DataSet SelectAll(string query)
        {
            DbDataAdapter adapter = dbFactory.CreateDataAdapter();
            Command.CommandType = CommandType.Text;
            Command.CommandText = query;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();

            try
            {
                adapter.Fill(ds);
            }
            catch (SqlException se)
            {
                switch (se.Number)
                {
                    case 4060:
                        System.Windows.Forms.MessageBox.Show("Couldn't connect to the specified database.\nPlease check the details and try again." + "\n\n" + se.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(se.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    //Connection.Dispose();
                    Command.Dispose();
                }
            }

            return ds;
        }

        public int Update(string query)
        {
            int iAffected = 0;
            DbDataAdapter adapter = dbFactory.CreateDataAdapter();
            Command.CommandType = CommandType.Text;
            Command.CommandText = query;
            adapter.UpdateCommand = Command;

            try
            {
                Connection.Open();
                iAffected = adapter.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Parameters.Clear();

                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    //Connection.Dispose();
                    Command.Dispose();
                }
            }

            return iAffected;
        }

        #endregion

        #region SQLite Data Methods

        public void SQLiteCreate(string sFilePath = "")
        {
            Globals g = new Globals();
            SetSession(SqlProviders.SQLite, sFilePath);
            sqlConnection = (SQLiteConnection)sqlFactory.CreateConnection();
            sqlCommand = (SQLiteCommand)sqlFactory.CreateCommand();
            sqlConnection.ConnectionString = sConnection;
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            bool bExists = false;

            sqlCommand.CommandText = @"SELECT name FROM sqlite_master WHERE type='table' AND name='android_metadata';";
            SQLiteDataReader dr = sqlCommand.ExecuteReader();
            if (dr.HasRows)
            {
                bExists = true;
            }
            dr.Close();

            if (!bExists)
            {
                string[] sTables = new string[] {
                    @"CREATE TABLE android_metadata (locale TEXT NOT NULL PRIMARY KEY);",
                    @"CREATE TABLE settings (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, skey TEXT, sval TEXT);",
                    @"CREATE TABLE users (_id INTEGER, username TEXT, password TEXT, usergroup TEXT, status TEXT, name_first TEXT, name_last TEXT, supercode TEXT);",
                    @"CREATE TABLE schedules (_id INTEGER, name TEXT, grade TEXT, questions TEXT, notes TEXT);",
                    @"CREATE TABLE schedules_sections (_id INTEGER, name TEXT);",
                    @"CREATE TABLE schedules_notes (_id INTEGER, note TEXT);",
                    @"CREATE TABLE schedules_questions (_id INTEGER, section TEXT, letter TEXT, number TEXT, question TEXT, parts TEXT);",
                    @"CREATE TABLE lists_faults (_id INTEGER, fault TEXT);",
                    @"CREATE TABLE locations_sites (_id INTEGER, name TEXT);",

                    @"CREATE TABLE inspections (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, workorder TEXT, inspector TEXT, item TEXT, schedule TEXT, electrical TEXT, mechanical TEXT, priority TEXT, comments TEXT, entered TEXT);",
                    @"CREATE TABLE inspections_answers (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, inspection TEXT, question TEXT, part TEXT, answer TEXT);",
                    @"CREATE TABLE inspections_faults (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, inspection TEXT, question TEXT, part TEXT, fault TEXT, priority TEXT);",
                    @"CREATE TABLE items (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, schedule TEXT, locationsite TEXT, locationarea TEXT, locationvessel TEXT, locationfloor TEXT, locationgrid TEXT, type_equipment TEXT, tag TEXT, barcode TEXT, cableid TEXT, serial TEXT, description TEXT, manufacturer TEXT, type_model TEXT, drawing TEXT, drawing_hac TEXT, drawing_device_loop TEXT, cert_equipment TEXT, barrier TEXT, type_device TEXT, type_protection TEXT, group_equipment TEXT, trating TEXT, atex_group TEXT, atex_category TEXT, atex_protection TEXT, epl TEXT, ip_rating TEXT, ce_number TEXT, temp_range TEXT, area_zone TEXT, area_group TEXT, area_trating TEXT, access_req TEXT, suitable TEXT, entered TEXT, tracehc TEXT, cpref TEXT);",
                    @"CREATE TABLE items_faults (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, item TEXT, fault TEXT, priority TEXT);",
                    @"CREATE TABLE images (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, type TEXT, typeid TEXT, filename TEXT);",
                    @"CREATE TABLE locations_areas (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, site TEXT);",
                    @"CREATE TABLE locations_vessels (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, site TEXT, area TEXT);",
                    @"CREATE TABLE locations_floors (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, site TEXT, area TEXT, vessel TEXT);",
                    @"CREATE TABLE locations_grids (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, site TEXT, area TEXT, vessel TEXT, floor TEXT);",
                    @"CREATE TABLE lists_drawings (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, revision TEXT, date TEXT);",
                    @"CREATE TABLE lists_drawings_hac (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT, revision TEXT, date TEXT);",
                    @"CREATE TABLE lists_manufacturers (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT);",
                    @"CREATE TABLE lists_types_device (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT);",
                    @"CREATE TABLE lists_types_protection (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT);"
                };

                foreach (string s in sTables)
                {
                    sqlCommand.CommandText = s;
                    sqlCommand.ExecuteNonQuery();
                }

                sqlCommand.Parameters.Add(new SQLiteParameter("locale", "en_US"));
                sqlCommand.CommandText = @"INSERT INTO android_metadata (locale) VALUES (@locale);";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.Parameters.Add(new SQLiteParameter("id", 1));
                sqlCommand.Parameters.Add(new SQLiteParameter("username", "fes"));
                sqlCommand.Parameters.Add(new SQLiteParameter("usergroup", "1"));
                sqlCommand.Parameters.Add(new SQLiteParameter("status", "1"));
                sqlCommand.Parameters.Add(new SQLiteParameter("name_first", "F.E.S."));
                sqlCommand.Parameters.Add(new SQLiteParameter("name_last", "(EX) Ltd"));
                sqlCommand.Parameters.Add(new SQLiteParameter("password", g.EncodePassword("fes")));
                sqlCommand.CommandText = @"INSERT INTO users (_id,username,usergroup,status,name_first,name_last,password) VALUES (@id,@username,@usergroup,@status,@name_first,@name_last,@password)";
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void SQLiteDataRebuild(string sPath, Database db, int iSiteID = 1)
        {
            if (sqlFactory == null)
            {
                SetSession(SqlProviders.SQLite, sPath);
            }
            sqlConnection = (SQLiteConnection)sqlFactory.CreateConnection();
            sqlCommand = (SQLiteCommand)sqlFactory.CreateCommand();
            sqlConnection.ConnectionString = sConnection;
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            DataSet ds;

            sqlCommand.Parameters.Add(new SQLiteParameter("siteid", iSiteID));
            sqlCommand.CommandText = @"INSERT INTO settings (skey,sval) VALUES ('siteid',@siteid)";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Add(new SQLiteParameter("synclast", iSiteID));
            sqlCommand.CommandText = @"INSERT INTO settings (skey,sval) VALUES ('synclast',@synclast)";
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Add(new SQLiteParameter("synccount", iSiteID));
            sqlCommand.CommandText = @"INSERT INTO settings (skey,sval) VALUES ('synccount',@synccount)";
            sqlCommand.ExecuteNonQuery();

            ds = db.SelectAll("SELECT id,username,password,usergroup,status,name_first,name_last,supercode FROM users;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM users; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='users'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("username", dr["username"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("password", dr["password"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("usergroup", dr["usergroup"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("status", dr["status"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name_first", dr["name_first"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name_last", dr["name_last"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("supercode", dr["supercode"] != DBNull.Value ? dr["supercode"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO users (_id,username,password,usergroup,status,name_first,name_last,supercode) VALUES (@id,@username,@password,@usergroup,@status,@name_first,@name_last,@supercode);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,grade,questions,notes FROM schedules;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM schedules; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='schedules'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("grade", dr["grade"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("questions", dr["questions"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("notes", dr["notes"] != DBNull.Value ? dr["notes"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO schedules (_id,name,grade,questions,notes) VALUES (@id,@name,@grade,@questions,@notes);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name FROM schedules_sections;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM schedules_sections; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='schedules_sections'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO schedules_sections (_id,name) VALUES (@id,@name);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,note FROM schedules_notes;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM schedules_notes; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='schedules_notes'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("note", dr["note"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO schedules_notes (_id,note) VALUES (@id,@note);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,section,letter,number,question,parts FROM schedules_questions;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM schedules_questions; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='schedules_questions'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("section", dr["section"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("letter", dr["letter"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("number", dr["number"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("question", dr["question"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("parts", dr["parts"] != DBNull.Value ? dr["parts"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO schedules_questions (_id,section,letter,number,question,parts) VALUES (@id,@section,@letter,@number,@question,@parts);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name FROM locations_sites;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM locations_sites; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='locations_sites'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO locations_sites (_id,name) VALUES (@id,@name);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,site FROM locations_areas;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM locations_areas; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='locations_areas'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("site", dr["site"] != DBNull.Value ? dr["site"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO locations_areas (_id,name,site) VALUES (@id,@name,@site);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,site,area FROM locations_vessels;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM locations_vessels; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='locations_vessels'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("site", dr["site"] != DBNull.Value ? dr["site"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area", dr["area"] != DBNull.Value ? dr["area"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO locations_vessels (_id,name,site,area) VALUES (@id,@name,@site,@area);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,site,area,vessel FROM locations_floors;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM locations_floors; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='locations_floors'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("site", dr["site"] != DBNull.Value ? dr["site"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area", dr["area"] != DBNull.Value ? dr["area"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("vessel", dr["vessel"] != DBNull.Value ? dr["vessel"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO locations_floors (_id,name,site,area,vessel) VALUES (@id,@name,@site,@area,@vessel);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,site,area,vessel,floor FROM locations_grids;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM locations_grids; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='locations_grids'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("site", dr["site"] != DBNull.Value ? dr["site"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area", dr["area"] != DBNull.Value ? dr["area"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("vessel", dr["vessel"] != DBNull.Value ? dr["vessel"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("floor", dr["floor"] != DBNull.Value ? dr["floor"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO locations_grids (_id,name,site,area,vessel,floor) VALUES (@id,@name,@site,@area,@vessel,@floor);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,revision,date FROM lists_drawings;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_drawings; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_drawings'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("revision", dr["revision"] != DBNull.Value ? dr["revision"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("date", dr["date"] != DBNull.Value ? dr["date"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO lists_drawings (_id,name,revision,date) VALUES (@id,@name,@revision,@date);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name,revision,date FROM lists_drawings_hac;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_drawings_hac; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_drawings_hac'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.Parameters.Add(new SQLiteParameter("revision", dr["revision"] != DBNull.Value ? dr["revision"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("date", dr["date"] != DBNull.Value ? dr["date"].ToString() : ""));
                    sqlCommand.CommandText = @"INSERT INTO lists_drawings_hac (_id,name,revision,date) VALUES (@id,@name,@revision,@date);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,fault FROM lists_faults;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_faults; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_faults'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("fault", dr["fault"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO lists_faults (_id,fault) VALUES (@id,@fault);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name FROM lists_manufacturers;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_manufacturers; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_manufacturers'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO lists_manufacturers (_id,name) VALUES (@id,@name);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name FROM lists_types_device;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_types_device; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_types_device'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO lists_types_device (_id,name) VALUES (@id,@name);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,name FROM lists_types_protection;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM lists_types_protection; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='lists_types_protection'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("name", dr["name"].ToString()));
                    sqlCommand.CommandText = @"INSERT INTO lists_types_protection (_id,name) VALUES (@id,@name);";
                    sqlCommand.ExecuteNonQuery();
                }
            }

            ds = db.SelectAll("SELECT id,locationsite,locationarea,locationvessel,locationfloor,locationgrid,schedule,type_equipment,drawing,tag,barcode,cableid,manufacturer,type_model,serial,description,cert_equipment,barrier,type_device,type_protection,group_equipment,trating,atex_group,atex_category,atex_protection,epl,ip_rating,ce_number,drawing_hac,drawing_device_loop,temp_range,area_zone,area_group,area_trating,access_req,suitable,entered,tracehc,cpref FROM items;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                sqlCommand.CommandText = @"DELETE FROM items; UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name='items'; VACUUM;";
                sqlCommand.ExecuteNonQuery();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqlCommand.Parameters.Add(new SQLiteParameter("id", Convert.ToInt32(dr["id"])));
                    sqlCommand.Parameters.Add(new SQLiteParameter("schedule", dr["schedule"] != DBNull.Value ? dr["schedule"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("locationsite", dr["locationsite"] != DBNull.Value ? dr["locationsite"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("locationarea", dr["locationarea"] != DBNull.Value ? dr["locationarea"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("locationvessel", dr["locationvessel"] != DBNull.Value ? dr["locationvessel"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("locationfloor", dr["locationfloor"] != DBNull.Value ? dr["locationfloor"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("locationgrid", dr["locationgrid"] != DBNull.Value ? dr["locationgrid"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("type_equipment", dr["type_equipment"] != DBNull.Value ? dr["type_equipment"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("tag", dr["tag"] != DBNull.Value ? dr["tag"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("barcode", dr["barcode"] != DBNull.Value ? dr["barcode"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("cableid", dr["cableid"] != DBNull.Value ? dr["cableid"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("serial", dr["serial"] != DBNull.Value ? dr["serial"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("description", dr["description"] != DBNull.Value ? dr["description"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("manufacturer", dr["manufacturer"] != DBNull.Value ? dr["manufacturer"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("type_model", dr["type_model"] != DBNull.Value ? dr["type_model"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("drawing", dr["drawing"] != DBNull.Value ? dr["drawing"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("drawing_hac", dr["drawing_hac"] != DBNull.Value ? dr["drawing_hac"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("drawing_device_loop", dr["drawing_device_loop"] != DBNull.Value ? dr["drawing_device_loop"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("cert_equipment", dr["cert_equipment"] != DBNull.Value ? dr["cert_equipment"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("barrier", dr["barrier"] != DBNull.Value ? dr["barrier"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("type_device", dr["type_device"] != DBNull.Value ? dr["type_device"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("type_protection", dr["type_protection"] != DBNull.Value ? dr["type_protection"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("group_equipment", dr["group_equipment"] != DBNull.Value ? dr["group_equipment"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("trating", dr["trating"] != DBNull.Value ? dr["trating"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("atex_group", dr["atex_group"] != DBNull.Value ? dr["atex_group"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("atex_category", dr["atex_category"] != DBNull.Value ? dr["atex_category"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("atex_protection", dr["atex_protection"] != DBNull.Value ? dr["atex_protection"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("epl", dr["epl"] != DBNull.Value ? dr["epl"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("ip_rating", dr["ip_rating"] != DBNull.Value ? dr["ip_rating"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("ce_number", dr["ce_number"] != DBNull.Value ? dr["ce_number"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("temp_range", dr["temp_range"] != DBNull.Value ? dr["temp_range"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area_zone", dr["area_zone"] != DBNull.Value ? dr["area_zone"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area_group", dr["area_group"] != DBNull.Value ? dr["area_group"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("area_trating", dr["area_trating"] != DBNull.Value ? dr["area_trating"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("suitable", dr["suitable"] != DBNull.Value ? dr["suitable"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("access_req", dr["access_req"] != DBNull.Value ? dr["access_req"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("entered", dr["entered"] != DBNull.Value ? dr["entered"].ToString() : ""));

                    sqlCommand.Parameters.Add(new SQLiteParameter("tracehc", dr["tracehc"] != DBNull.Value ? dr["tracehc"].ToString() : ""));
                    sqlCommand.Parameters.Add(new SQLiteParameter("cpref", dr["cpref"] != DBNull.Value ? dr["cpref"].ToString() : ""));

                    sqlCommand.CommandText = @"INSERT INTO items (_id,schedule,locationsite,locationarea,locationvessel,locationfloor,locationgrid,type_equipment,drawing,tag,barcode,cableid,manufacturer,type_model,serial,description,cert_equipment,barrier,type_device,type_protection,group_equipment,trating,atex_group,atex_category,atex_protection,epl,ip_rating,ce_number,drawing_hac,drawing_device_loop,temp_range,area_zone,area_group,area_trating,access_req,suitable,entered) VALUES (@id,@schedule,@locationsite,@locationarea,@locationvessel,@locationfloor,@locationgrid,@type_equipment,@drawing,@tag,@barcode,@cableid,@manufacturer,@type_model,@serial,@description,@cert_equipment,@barrier,@type_device,@type_protection,@group_equipment,@trating,@atex_group,@atex_category,@atex_protection,@epl,@ip_rating,@ce_number,@drawing_hac,@drawing_device_loop,@temp_range,@area_zone,@area_group,@area_trating,@access_req,@suitable,@entered);";
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void SQLiteImport(string sSQLiteFile, Database db)
        {
            int iCInspections = 0, iCInspectionsAnswers = 0, iCInspectionsFaults = 0, iCItems = 0, iCItemsFaults = 0, iCImages = 0;
            int iCItemLocationsAreas = 0, iCItemLocationsVessels = 0, iCItemLocationsFloors = 0, iCItemLocationsGrids = 0;
            int iCItemManufacturers = 0, iCItemDrawings = 0, iCItemDrawingsHac = 0, iCItemDTypes = 0, iCItemPTypes = 0;

            List<string> lLocationsAreas = new List<string>();
            List<string> lLocationsVessels = new List<string>();
            List<string> lLocationsFloors = new List<string>();
            List<string> lLocationsGrids = new List<string>();
            List<string> lManufacturers = new List<string>();
            List<string> lDrawings = new List<string>();
            List<string> lDrawingsHac = new List<string>();
            List<string> lTypesDevice = new List<string>();
            List<string> lTypesProtection = new List<string>();
            List<string> lItems = new List<string>();
            List<string> lImages = new List<string>();

            DataSet ds = SelectAll("SELECT name FROM locations_areas;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lLocationsAreas.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM locations_vessels;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lLocationsVessels.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM locations_floors;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lLocationsFloors.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM locations_grids;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lLocationsGrids.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM lists_manufacturers;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lManufacturers.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name,revision,date FROM lists_drawings;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lDrawings.Add(r["name"].ToString() + "|" + r["revision"].ToString() + "|" + r["date"].ToString());
                }
            }
            ds = SelectAll("SELECT name,revision,date FROM lists_drawings_hac;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lDrawingsHac.Add(r["name"].ToString() + "|" + r["revision"].ToString() + "|" + r["date"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM lists_types_device;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lTypesDevice.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT name FROM lists_types_protection;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lTypesProtection.Add(r["name"].ToString());
                }
            }
            ds = SelectAll("SELECT tag,barcode FROM items;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lItems.Add(r["tag"].ToString() + "|" + r["barcode"].ToString());
                }
            }
            ds = SelectAll("SELECT filename FROM images;");
            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    lImages.Add(r["filename"].ToString());
                }
            }

            SQLiteConnection sc = new SQLiteConnection("Data Source=" + sSQLiteFile + ";Version=3");
            SQLiteCommand c;
            sc.Open();

            int iSiteID = 0;
            List<string[]> lSQLiteDrawings = new List<string[]>();
            List<string[]> lSQLiteDrawingsHac = new List<string[]>();
            List<string[]> lSQLiteManufacturers = new List<string[]>();

            c = sc.CreateCommand();
            c.CommandText = @"SELECT sval FROM settings WHERE skey='siteid';";
            SQLiteDataReader dr = c.ExecuteReader();
            if (dr.HasRows && dr.Read())
            {
                iSiteID = Convert.ToInt32(dr["sval"]);
            }
            dr.Close();

            c.CommandText = @"SELECT name,site FROM locations_areas;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lLocationsAreas.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("site", dr["site"].ToString());
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO locations_areas (name,site,entered,modified) VALUES (@name,@site,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemLocationsAreas++;
                                lLocationsAreas.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Areas were not updated.\nPlease try again.", "Areas", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT name,site,area FROM locations_vessels;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lLocationsVessels.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("site", dr["site"].ToString());
                        AddParameter("area", Convert.ToInt32(dr["area"]));
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO locations_vessels (name,site,area,entered,modified) VALUES (@name,@site,@area,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemLocationsVessels++;
                                lLocationsVessels.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Vessels were not updated.\nPlease try again.", "Vessels", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT name,site,area,vessel FROM locations_floors;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lLocationsFloors.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("site", dr["site"].ToString());
                        AddParameter("area", Convert.ToInt32(dr["area"]));
                        AddParameter("vessel", Convert.ToInt32(dr["vessel"]));
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO locations_floors (name,site,area,vessel,entered,modified) VALUES (@name,@site,@area,@vessel,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemLocationsFloors++;
                                lLocationsFloors.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Floors were not updated.\nPlease try again.", "Floors", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT name,site,area,vessel,floor FROM locations_grids;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lLocationsGrids.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("site", dr["site"].ToString());
                        AddParameter("area", Convert.ToInt32(dr["area"]));
                        AddParameter("vessel", Convert.ToInt32(dr["vessel"]));
                        AddParameter("floor", Convert.ToInt32(dr["floor"]));
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO locations_grids (name,site,area,vessel,floor,entered,modified) VALUES (@name,@site,@area,@vessel,@floor,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemLocationsGrids++;
                                lLocationsGrids.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Grids were not updated.\nPlease try again.", "Grids", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT _id,name FROM lists_manufacturers;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lManufacturers.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO lists_manufacturers (name,entered,modified) VALUES (@name,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemManufacturers++;
                                lManufacturers.Add(dr["name"].ToString());
                                lSQLiteManufacturers.Add(new string[] { dr["_id"].ToString(), dr["name"].ToString() });
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Manufacturers were not updated.\nPlease try again.", "Areas", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT _id,name,revision,date FROM lists_drawings;";
            using (dr = c.ExecuteReader())
            {
                DateTime dt = DateTime.Now;
                while (dr.Read())
                {
                    if (!lDrawings.Contains(dr["name"].ToString() + "|" + dr["revision"].ToString() + "|" + dr["date"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("revision", dr["revision"].ToString());
                        DateTime dn = dt;
                        bool bIsDate = true;
                        try
                        {
                            dt = DateTime.Parse(dr["date"].ToString());
                        }
                        catch
                        {
                            bIsDate = false;
                        }
                        AddParameter("date", bIsDate && dt != dn ? dt.ToString("yyyy-MM-dd") : "");
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO lists_drawings (name,revision,date,entered,modified) VALUES (@name,@revision,@date,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemDrawings++;
                                lDrawings.Add(dr["name"].ToString() + "|" + dr["revision"].ToString() + "|" + dr["date"].ToString());
                                lSQLiteDrawings.Add(new string[] { dr["_id"].ToString(), dr["name"].ToString(), dr["revision"].ToString(), dr["date"].ToString() });
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Drawings were not updated.\nPlease try again.", "Areas", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT _id,name,revision,date FROM lists_drawings_hac;";
            using (dr = c.ExecuteReader())
            {
                DateTime dt = DateTime.Now;
                while (dr.Read())
                {
                    if (!lDrawingsHac.Contains(dr["name"].ToString() + "|" + dr["revision"].ToString() + "|" + dr["date"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("revision", dr["revision"].ToString());
                        DateTime dn = dt;
                        bool bIsDate = true;
                        try
                        {
                            dt = DateTime.Parse(dr["date"].ToString());
                        }
                        catch
                        {
                            bIsDate = false;
                        }
                        AddParameter("date", bIsDate && dt != dn ? dt.ToString("yyyy-MM-dd") : "");
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO lists_drawings_hac (name,revision,date,entered,modified) VALUES (@name,@revision,@date,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemDrawingsHac++;
                                lDrawingsHac.Add(dr["name"].ToString() + "|" + dr["revision"].ToString() + "|" + dr["date"].ToString());
                                lSQLiteDrawingsHac.Add(new string[] { dr["_id"].ToString(), dr["name"].ToString(), dr["revision"].ToString(), dr["date"].ToString() });
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("HAC Drawings were not updated.\nPlease try again.", "Areas", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT name FROM lists_types_device;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lTypesDevice.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO lists_types_device (name,entered,modified) VALUES (@name,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemDTypes++;
                                lTypesDevice.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Device types were not updated.\nPlease try again.", "Device Types", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT name FROM lists_types_protection;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lTypesProtection.Contains(dr["name"].ToString()))
                    {
                        AddParameter("name", dr["name"].ToString());
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO lists_types_protection (name,entered,modified) VALUES (@name,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCItemPTypes++;
                                lTypesProtection.Add(dr["name"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Protection types were not updated.\nPlease try again.", "Protection Types", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT type,typeid,filename FROM images;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!lImages.Contains(dr["filename"].ToString()))
                    {
                        AddParameter("type", Convert.ToInt32(dr["type"]));
                        AddParameter("typeid", Convert.ToInt32(dr["typeid"]));
                        AddParameter("filename", dr["filename"].ToString());
                        AddParameter("ent", DateTime.Now);
                        try
                        {
                            int iRes = Insert("INSERT INTO images (type,typeid,filename,entered,modified) VALUES (@type,@typeid,@filename,@ent,@ent)");
                            if (iRes > 0)
                            {
                                iCImages++;
                                lImages.Add(dr["filename"].ToString());
                            }
                        }
                        catch (SQLiteException)
                        {
                            System.Windows.Forms.MessageBox.Show("Images were not updated.\nPlease try again.", "Images", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }

            c.CommandText = @"SELECT * FROM items;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    int iItemID = 0;
                    AddParameter("tag", dr["tag"].ToString());
                    AddParameter("barcode", dr["barcode"].ToString());
                    DataSet d = SelectAll("SELECT id FROM items WHERE tag=@tag AND barcode=@barcode;");
                    if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                    {
                        iItemID = Convert.ToInt32(d.Tables[0].Rows[0]["id"]);
                    }

                    string sInsertCols = "locationsite";
                    string sInsertVals = "@locationsite";
                    string sUpdate = "locationsite=@locationsite";
                    AddParameter("locationsite", iSiteID);

                    sInsertCols += ",locationarea";
                    sInsertVals += ",@locationarea";
                    sUpdate += ",locationarea=@locationarea";
                    AddParameter("locationarea", Convert.ToInt32(dr["locationarea"]));

                    sInsertCols += ",locationvessel";
                    sInsertVals += ",@locationvessel";
                    sUpdate += ",locationvessel=@locationvessel";
                    AddParameter("locationvessel", Convert.ToInt32(dr["locationvessel"]));

                    sInsertCols += ",locationfloor";
                    sInsertVals += ",@locationfloor";
                    sUpdate += ",locationfloor=@locationfloor";
                    AddParameter("locationfloor", Convert.ToInt32(dr["locationfloor"]));

                    sInsertCols += ",locationgrid";
                    sInsertVals += ",@locationgrid";
                    sUpdate += ",locationgrid=@locationgrid";
                    AddParameter("locationgrid", Convert.ToInt32(dr["locationgrid"]));

                    if (!dr["type_equipment"].ToString().Equals(""))
                    {
                        sInsertCols += ",type_equipment";
                        sInsertVals += ",@type_equipment";
                        sUpdate += ",type_equipment=@type_equipment";
                        AddParameter("type_equipment", dr["type_equipment"].ToString());
                    }

                    if (!dr["tag"].ToString().Equals(""))
                    {
                        sInsertCols += ",tag";
                        sInsertVals += ",@tag";
                        sUpdate += ",tag=@tag";
                        AddParameter("tag", dr["tag"].ToString());
                    }

                    if (!dr["barcode"].ToString().Equals(""))
                    {
                        sInsertCols += ",barcode";
                        sInsertVals += ",@barcode";
                        sUpdate += ",barcode=@barcode";
                        AddParameter("barcode", dr["barcode"].ToString());
                    }

                    if (!dr["cableid"].ToString().Equals(""))
                    {
                        sInsertCols += ",cableid";
                        sInsertVals += ",@cableid";
                        sUpdate += ",cableid=@cableid";
                        AddParameter("cableid", dr["cableid"].ToString());
                    }

                    if (!dr["manufacturer"].ToString().Equals(""))
                    {
                        sInsertCols += ",manufacturer";
                        sInsertVals += ",@manufacturer";
                        sUpdate += ",manufacturer=@manufacturer";
                        AddParameter("manufacturer", Convert.ToInt32(dr["manufacturer"]));
                    }

                    if (!dr["type_model"].ToString().Equals(""))
                    {
                        sInsertCols += ",type_model";
                        sInsertVals += ",@type_model";
                        sUpdate += ",type_model=@type_model";
                        AddParameter("type_model", dr["type_model"].ToString());
                    }

                    if (!dr["serial"].ToString().Equals(""))
                    {
                        sInsertCols += ",serial";
                        sInsertVals += ",@serial";
                        sUpdate += ",serial=@serial";
                        AddParameter("serial", dr["serial"].ToString());
                    }

                    if (!dr["description"].ToString().Equals(""))
                    {
                        sInsertCols += ",description";
                        sInsertVals += ",@description";
                        sUpdate += ",description=@description";
                        AddParameter("description", dr["description"].ToString());
                    }

                    if (!dr["cert_equipment"].ToString().Equals(""))
                    {
                        sInsertCols += ",cert_equipment";
                        sInsertVals += ",@cert_equipment";
                        sUpdate += ",cert_equipment=@cert_equipment";
                        AddParameter("cert_equipment", dr["cert_equipment"].ToString());
                    }

                    if (!dr["barrier"].ToString().Equals(""))
                    {
                        sInsertCols += ",barrier";
                        sInsertVals += ",@barrier";
                        sUpdate += ",barrier=@barrier";
                        AddParameter("barrier", dr["barrier"].ToString());
                    }

                    if (!dr["type_device"].ToString().Equals(""))
                    {
                        sInsertCols += ",type_device";
                        sInsertVals += ",@type_device";
                        sUpdate += ",type_device=@type_device";
                        AddParameter("type_device", dr["type_device"].ToString());
                    }

                    if (!dr["type_protection"].ToString().Equals(""))
                    {
                        sInsertCols += ",type_protection";
                        sInsertVals += ",@type_protection";
                        sUpdate += ",type_protection=@type_protection";
                        AddParameter("type_protection", dr["type_protection"].ToString());
                    }

                    if (!dr["group_equipment"].ToString().Equals(""))
                    {
                        sInsertCols += ",group_equipment";
                        sInsertVals += ",@group_equipment";
                        sUpdate += ",group_equipment=@group_equipment";
                        AddParameter("group_equipment", dr["group_equipment"].ToString());
                    }

                    if (!dr["trating"].ToString().Equals(""))
                    {
                        sInsertCols += ",trating";
                        sInsertVals += ",@trating";
                        sUpdate += ",trating=@trating";
                        AddParameter("trating", dr["trating"].ToString());
                    }

                    if (!dr["atex_group"].ToString().Equals(""))
                    {
                        sInsertCols += ",atex_group";
                        sInsertVals += ",@atex_group";
                        sUpdate += ",atex_group=@atex_group";
                        AddParameter("atex_group", dr["atex_group"].ToString());
                    }

                    if (!dr["atex_category"].ToString().Equals(""))
                    {
                        sInsertCols += ",atex_category";
                        sInsertVals += ",@atex_category";
                        sUpdate += ",atex_category=@atex_category";
                        AddParameter("atex_category", dr["atex_category"].ToString());
                    }

                    if (!dr["atex_protection"].ToString().Equals(""))
                    {
                        sInsertCols += ",atex_protection";
                        sInsertVals += ",@atex_protection";
                        sUpdate += ",atex_protection=@atex_protection";
                        AddParameter("atex_protection", dr["atex_protection"].ToString());
                    }

                    if (!dr["epl"].ToString().Equals(""))
                    {
                        sInsertCols += ",epl";
                        sInsertVals += ",@epl";
                        sUpdate += ",epl=@epl";
                        AddParameter("epl", dr["epl"].ToString());
                    }

                    if (!dr["ip_rating"].ToString().Equals(""))
                    {
                        sInsertCols += ",ip_rating";
                        sInsertVals += ",@ip_rating";
                        sUpdate += ",ip_rating=@ip_rating";
                        AddParameter("ip_rating", dr["ip_rating"].ToString());
                    }

                    if (!dr["ce_number"].ToString().Equals(""))
                    {
                        sInsertCols += ",ce_number";
                        sInsertVals += ",@ce_number";
                        sUpdate += ",ce_number=@ce_number";
                        AddParameter("ce_number", dr["ce_number"].ToString());
                    }

                    if (!dr["drawing"].ToString().Equals("") && dr["drawing"].ToString().All(char.IsDigit))
                    {
                        sInsertCols += ",drawing";
                        sInsertVals += ",@drawing";
                        sUpdate += ",drawing=@drawing";
                        AddParameter("drawing", Convert.ToInt32(dr["drawing"]));
                    }

                    if (!dr["drawing_hac"].ToString().Equals("") && dr["drawing"].ToString().All(char.IsDigit))
                    {
                        sInsertCols += ",drawing_hac";
                        sInsertVals += ",@drawing_hac";
                        sUpdate += ",drawing_hac=@drawing_hac";
                        AddParameter("drawing_hac", Convert.ToInt32(dr["drawing_hac"]));
                    }

                    if (!dr["drawing_device_loop"].ToString().Equals(""))
                    {
                        sInsertCols += ",drawing_device_loop";
                        sInsertVals += ",@drawing_device_loop";
                        sUpdate += ",drawing_device_loop=@drawing_device_loop";
                        AddParameter("drawing_device_loop", dr["drawing_device_loop"].ToString());
                    }

                    if (!dr["temp_range"].ToString().Equals(""))
                    {
                        sInsertCols += ",temp_range";
                        sInsertVals += ",@temp_range";
                        sUpdate += ",temp_range=@temp_range";
                        AddParameter("temp_range", dr["temp_range"].ToString());
                    }

                    if (!dr["area_zone"].ToString().Equals(""))
                    {
                        sInsertCols += ",area_zone";
                        sInsertVals += ",@area_zone";
                        sUpdate += ",area_zone=@area_zone";
                        AddParameter("area_zone", dr["area_zone"].ToString());
                    }

                    if (!dr["area_group"].ToString().Equals(""))
                    {
                        sInsertCols += ",area_group";
                        sInsertVals += ",@area_group";
                        sUpdate += ",area_group=@area_group";
                        AddParameter("area_group", dr["area_group"].ToString());
                    }

                    if (!dr["area_trating"].ToString().Equals(""))
                    {
                        sInsertCols += ",area_trating";
                        sInsertVals += ",@area_trating";
                        sUpdate += ",area_trating=@area_trating";
                        AddParameter("area_trating", dr["area_trating"].ToString());
                    }

                    if (!dr["access_req"].ToString().Equals(""))
                    {
                        sInsertCols += ",access_req";
                        sInsertVals += ",@access_req";
                        sUpdate += ",access_req=@access_req";
                        AddParameter("access_req", dr["access_req"].ToString());
                    }

                    if (!dr["suitable"].ToString().Equals(""))
                    {
                        sInsertCols += ",suitable";
                        sInsertVals += ",@suitable";
                        sUpdate += ",suitable=@suitable";
                        AddParameter("suitable", dr["suitable"].ToString());
                    }

                    if (!dr["tracehc"].ToString().Equals(""))
                    {
                        sInsertCols += ",tracehc";
                        sInsertVals += ",@tracehc";
                        sUpdate += ",tracehc=@tracehc";
                        AddParameter("tracehc", dr["tracehc"].ToString().Substring(0, 1).ToLower());
                    }

                    if (!dr["cpref"].ToString().Equals(""))
                    {
                        sInsertCols += ",cpref";
                        sInsertVals += ",@cpref";
                        sUpdate += ",cpref=@cpref";
                        AddParameter("cpref", dr["cpref"].ToString());
                    }

                    sInsertCols += ",modified";
                    sInsertVals += ",@ent";
                    sUpdate += ",modified=@ent";
                    AddParameter("ent", DateTime.Now);

                    try
                    {
                        if (iItemID > 0)
                        {
                            int iRes = Update("UPDATE items SET " + sUpdate + " WHERE id=" + iItemID + ";");
                        }
                        else
                        {
                            sInsertCols += ",entered";
                            sInsertVals += ",@ent";
                            sUpdate += ",entered=@ent";
                            int iRes = Insert("INSERT INTO items (" + sInsertCols + ") VALUES (" + sInsertVals + ")");
                            if (iRes > 0)
                            {
                                iCItems++;
                            }
                            lItems.Add(dr["tag"].ToString() + "|" + dr["barcode"].ToString());
                        }
                    }
                    catch (SQLiteException)
                    {
                        System.Windows.Forms.MessageBox.Show("Items were not updated.\nPlease try again.", "Items", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }

            c.CommandText = @"SELECT item,fault,priority FROM items_faults;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    AddParameter("item", dr["item"].ToString());
                    AddParameter("fault", dr["fault"].ToString());
                    string sPriority = dr["priority"].ToString().Equals("OK") ? "o" : dr["priority"].ToString().Substring(dr["priority"].ToString().Length - 1, 1);
                    AddParameter("priority", sPriority);
                    DataSet d = SelectAll("SELECT id FROM items_faults WHERE item=@item AND fault=@fault AND priority=@priority;");
                    if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                    {
                        continue;
                    }

                    AddParameter("item", Convert.ToInt32(dr["item"]));
                    AddParameter("fault", dr["fault"].ToString());
                    AddParameter("priority", sPriority);
                    AddParameter("ent", DateTime.Now);
                    try
                    {
                        int iRes = Insert("INSERT INTO items_faults (item,fault,priority,entered,modified) VALUES (@item,@fault,@priority,@ent,@ent)");
                        if (iRes > 0)
                        {
                            iCItemsFaults++;
                        }
                    }
                    catch (SQLiteException)
                    {
                        System.Windows.Forms.MessageBox.Show("Item faults were not updated.\nPlease try again.", "Item Faults", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }

            c.CommandText = @"SELECT workorder,inspector,item,schedule,electrical,mechanical,priority,comments,entered FROM inspections;";
            using (dr = c.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (dr["item"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                    int iItem = 0;
                    db.AddParameter("tag", Convert.ToInt32(dr["item"]));
                    DataSet t = db.SelectAll("SELECT id FROM items WHERE tag=@tag;");
                    if (t.Tables.Count == 1 && t.Tables[0].Rows.Count > 0)
                    {
                        iItem = Convert.ToInt32(t.Tables[0].Rows[0]["id"]);
                    }
                    else
                    {
                        continue;
                    }

                    AddParameter("workorder", dr["workorder"].ToString());
                    AddParameter("inspector", Convert.ToInt32(dr["inspector"]));
                    AddParameter("item", iItem);
                    AddParameter("schedule", Convert.ToInt32(dr["schedule"]));
                    AddParameter("electrical", dr["electrical"].ToString());
                    AddParameter("mechanical", dr["mechanical"].ToString());
                    string sPriority = dr["priority"].ToString().Equals("OK") ? "o" : dr["priority"].ToString().Substring(dr["priority"].ToString().Length - 1, 1);
                    AddParameter("priority", sPriority);
                    AddParameter("comments", dr["comments"].ToString());
                    DateTime dtCompleted = DateTime.Now;
                    try
                    {
                        dtCompleted = DateTime.Parse(dr["entered"].ToString());
                    }
                    catch
                    {
                    }
                    AddParameter("completed", dtCompleted);
                    AddParameter("ent", DateTime.Now);
                    try
                    {
                        int iRes = Insert("INSERT INTO inspections (workorder,inspector,item,schedule,electrical,mechanical,priority,comments,completed,entered,modified) VALUES (@workorder,@inspector,@item,@schedule,@electrical,@mechanical,@priority,@comments,@completed,@ent,@ent)");
                        if (iRes > 0)
                        {
                            iCInspections++;

                            c.CommandText = @"SELECT inspection,question,part,answer FROM inspections_answers;";
                            using (dr = c.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    int iInspectionID = 0;
                                    AddParameter("inspection", Convert.ToInt32(dr["inspection"]));
                                    AddParameter("question", Convert.ToInt32(dr["question"]));
                                    string sPart = " AND part=@part";
                                    if (dr["part"].ToString() == "" || dr["part"].ToString() == "0")
                                    {
                                        sPart = "";
                                    }
                                    else
                                    {
                                        AddParameter("part", Convert.ToInt32(dr["part"]));
                                    }
                                    DataSet d = SelectAll("SELECT id FROM inspections_answers WHERE inspection=@inspection AND question=@question" + sPart + ";");
                                    if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                                    {
                                        iInspectionID = Convert.ToInt32(d.Tables[0].Rows[0]["id"]);
                                    }

                                    AddParameter("inspection", Convert.ToInt32(dr["inspection"]));
                                    AddParameter("question", Convert.ToInt32(dr["question"]));
                                    AddParameter("part", Convert.ToInt32(dr["part"]));
                                    AddParameter("answer", dr["answer"].ToString());
                                    AddParameter("ent", dtCompleted);
                                    try
                                    {
                                        if (iInspectionID > 0)
                                        {
                                            int iT = Update("UPDATE inspections_answers SET answer=@answer,modified=@ent WHERE id=" + iInspectionID + ";");
                                        }
                                        else
                                        {
                                            int iT = Insert("INSERT INTO inspections_answers (inspection,question,part,answer,entered,modified) VALUES (@inspection,@question,@part,@answer,@ent,@ent)");
                                            if (iRes > 0)
                                            {
                                                iCInspectionsAnswers++;
                                            }
                                        }
                                    }
                                    catch (SQLiteException)
                                    {
                                        System.Windows.Forms.MessageBox.Show("Inspection answers were not updated.\nPlease try again.", "Inspection Answers", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                }
                            }

                            c.CommandText = @"SELECT inspection,question,part,fault,priority FROM inspections_faults;";
                            using (dr = c.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    int iFaultID = 0;
                                    AddParameter("inspection", Convert.ToInt32(dr["inspection"]));
                                    AddParameter("question", Convert.ToInt32(dr["question"]));
                                    string sPart = " AND part=@part";
                                    if (dr["part"].ToString() == "" || dr["part"].ToString() == "0")
                                    {
                                        sPart = "";
                                    }
                                    else
                                    {
                                        AddParameter("part", Convert.ToInt32(dr["part"]));
                                    }
                                    DataSet d = SelectAll("SELECT id FROM inspections_faults WHERE inspection=@inspection AND question=@question" + sPart + ";");
                                    if (d.Tables.Count == 1 && d.Tables[0].Rows.Count > 0)
                                    {
                                        iFaultID = Convert.ToInt32(d.Tables[0].Rows[0]["id"]);
                                    }

                                    AddParameter("inspection", Convert.ToInt32(dr["inspection"]));
                                    AddParameter("question", Convert.ToInt32(dr["question"]));
                                    AddParameter("part", Convert.ToInt32(dr["part"]));
                                    AddParameter("fault", dr["fault"].ToString());
                                    string sFaultPriority = dr["priority"].ToString().Equals("OK") ? "o" : dr["priority"].ToString().Substring(dr["priority"].ToString().Length - 1, 1);
                                    AddParameter("priority", sFaultPriority);
                                    AddParameter("ent", dtCompleted);
                                    try
                                    {
                                        if (iFaultID > 0)
                                        {
                                            int iT = Update("UPDATE inspections_faults SET fault=@fault,priority=@priority,modified=@ent WHERE id=" + iFaultID + ";");
                                        }
                                        else
                                        {
                                            int iT = Insert("INSERT INTO inspections_faults (inspection,question,part,fault,priority,entered,modified) VALUES (@inspection,@question,@part,@fault,@priority,@ent,@ent)");
                                            if (iRes > 0)
                                            {
                                                iCInspectionsFaults++;
                                            }
                                        }
                                    }
                                    catch (SQLiteException)
                                    {
                                        System.Windows.Forms.MessageBox.Show("Inspection faults were not updated.\nPlease try again.", "Inspection Faults", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                    catch (SQLiteException)
                    {
                        System.Windows.Forms.MessageBox.Show("Inspection answers were not updated.\nPlease try again.", "Inspection Answers", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}
