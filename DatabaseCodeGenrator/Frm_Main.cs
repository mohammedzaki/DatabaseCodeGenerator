using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace DatabaseCodeGenrator
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
            rdo_WindowsAuthentication.Checked = true;
            rdo_WithDAL.Checked = true;
        }
        string FilePath = "";
        DB_OperationProcess DB = new DB_OperationProcess();
        StringWriter stream1namespace = new StringWriter();
        StringWriter stream2enumTablesNames = new StringWriter();
        StringWriter stream3namespaceClasses = new StringWriter();
        StringWriter stream4Endnamespace = new StringWriter();
        List<ClassStructure> ListCalsses = new List<ClassStructure>();
        string DatabaseName = "";
        DataTable myTableOfDatabases;
        private string CurrentColumn;
        private string CurrentTable;

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileLocation = new SaveFileDialog();
            saveFileLocation.Filter = "CS File (*.cs)|*.cs|Text File (*.txt)|*.txt";
            //saveFileLocation.ShowDialog();
            if (saveFileLocation.ShowDialog() != DialogResult.Cancel)
            {
                FilePath = saveFileLocation.FileName;
                stream1namespace.WriteLine("namespace N_Tier_Classes.ObjectLayer");
                stream1namespace.WriteLine("{");
                stream1namespace.WriteLine("    namespace " + cbo_DatabaseName.GetItemText(cbo_DatabaseName.SelectedItem));
                stream1namespace.WriteLine("    {");
                if (rdo_WithDAL.Checked)
                {
                    stream1namespace.WriteLine("        using N_Tier_Classes.DataAccessLayer;");
                    stream1namespace.WriteLine("   ");
                }
                stream1namespace.WriteLine("        public enum TablesNames");
                stream1namespace.WriteLine("        {");

                DataTable myTableOfTables = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from sys.tables where name != 'sysdiagrams'", DB_OperationProcess.ResultReturnedDataType.Table);
                //comboBox1.DataSource = myTable;
                //comboBox1.DisplayMember = "name";
                //comboBox1.ValueMember = "object_id";
                progressBar1.Maximum = myTableOfTables.Rows.Count;
                progressBar1.Maximum += ((DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from sys.views where name != 'sysdiagrams'", DB_OperationProcess.ResultReturnedDataType.Table)).Rows.Count;
                progressBar1.Maximum += ((DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from " + DatabaseName + ".information_schema.routines where routine_type = 'PROCEDURE'", DB_OperationProcess.ResultReturnedDataType.Table)).Rows.Count;
                ListBox TablesList = new ListBox();
                Form frm = new Form();
                frm.Controls.Add(TablesList);
                TablesList.DataSource = myTableOfTables;
                TablesList.DisplayMember = "name";
                TablesList.ValueMember = "object_id";
                for (int i = 0; i < TablesList.Items.Count; i++)
                {
                    CurrentTable = TablesList.GetItemText(TablesList.Items[i]);
                    AddenumTableName(CurrentTable);
                    ListCalsses.Add(new ClassStructure(CurrentTable));
                    DataTable myTableOfColumns = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from sys.all_columns where object_id = (select object_id from sys.tables where name = '" + CurrentTable + "')", DB_OperationProcess.ResultReturnedDataType.Table);
                    ListBox ColumnsList = new ListBox();
                    Form frm2 = new Form();
                    frm2.Controls.Add(ColumnsList);
                    ColumnsList.DataSource = myTableOfColumns;
                    ColumnsList.DisplayMember = "name";
                    ColumnsList.ValueMember = "column_id";
                    for (int x = 0; x < ColumnsList.Items.Count; x++)
                    {
                        CurrentColumn = ColumnsList.GetItemText(ColumnsList.Items[x]);
                        ListCalsses[ListCalsses.Count - 1].AddenumField(CurrentColumn);
                        string dataTypename = "";
                        dataTypename = DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select name from sys.types where user_type_id = (select user_type_id from sys.all_columns where object_id = (select object_id from sys.tables where name = '" + CurrentTable + "') and column_id = (select column_id from sys.all_columns where object_id = (select object_id from sys.tables where name = '" + CurrentTable + "') and name = '" + CurrentColumn + "'))", DB_OperationProcess.ResultReturnedDataType.Scalar).ToString();
                        dataTypename = GiveName(dataTypename);
                        ListCalsses[ListCalsses.Count - 1].AddClassField(CurrentColumn, GiveName(dataTypename));
                        ListCalsses[ListCalsses.Count - 1].AddClassProperty(CurrentColumn, GiveName(dataTypename));
                    }
                    ListCalsses[ListCalsses.Count - 1].CreateClassCode();
                    progressBar1.Value += 1;
                }

                #region Views
                myTableOfTables = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from sys.views where name != 'sysdiagrams'", DB_OperationProcess.ResultReturnedDataType.Table);
                //comboBox1.DataSource = myTable;
                //comboBox1.DisplayMember = "name";
                //comboBox1.ValueMember = "object_id";
                //progressBar1.Maximum = myTableOfTables.Rows.Count;
                TablesList = new ListBox();
                frm = new Form();
                frm.Controls.Add(TablesList);
                TablesList.DataSource = myTableOfTables;
                TablesList.DisplayMember = "name";
                TablesList.ValueMember = "object_id";
                for (int i = 0; i < TablesList.Items.Count; i++)
                {
                    CurrentTable = TablesList.GetItemText(TablesList.Items[i]);
                    AddenumTableName(CurrentTable);
                    ListCalsses.Add(new ClassStructure(CurrentTable));
                    DataTable myTableOfColumns = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from sys.all_columns where object_id = (select object_id from sys.views where name = '" + CurrentTable + "')", DB_OperationProcess.ResultReturnedDataType.Table);
                    ListBox ColumnsList = new ListBox();
                    Form frm2 = new Form();
                    frm2.Controls.Add(ColumnsList);
                    ColumnsList.DataSource = myTableOfColumns;
                    ColumnsList.DisplayMember = "name";
                    ColumnsList.ValueMember = "column_id";
                    for (int x = 0; x < ColumnsList.Items.Count; x++)
                    {
                        CurrentColumn = ColumnsList.GetItemText(ColumnsList.Items[x]);
                        ListCalsses[ListCalsses.Count - 1].AddenumField(CurrentColumn);
                        string dataTypename = "";
                        dataTypename = DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select name from sys.types where user_type_id = (select user_type_id from sys.all_columns where object_id = (select object_id from sys.views where name = '" + CurrentTable + "') and column_id = (select column_id from sys.all_columns where object_id = (select object_id from sys.views where name = '" + CurrentTable + "') and name = '" + CurrentColumn + "'))", DB_OperationProcess.ResultReturnedDataType.Scalar).ToString();
                        dataTypename = GiveName(dataTypename);
                        ListCalsses[ListCalsses.Count - 1].AddClassField(CurrentColumn, GiveName(dataTypename));
                        ListCalsses[ListCalsses.Count - 1].AddClassProperty(CurrentColumn, GiveName(dataTypename));
                    }
                    ListCalsses[ListCalsses.Count - 1].CreateClassCode();
                    progressBar1.Value += 1;
                }
                #endregion

                #region Storded Procedures
                //Get all stroded names
                myTableOfTables = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select * from " + DatabaseName + ".information_schema.routines where routine_type = 'PROCEDURE'", DB_OperationProcess.ResultReturnedDataType.Table);
                ListCalsses.Add(new ClassStructure("StordedProcedures"));
                //comboBox1.DataSource = myTable;
                //comboBox1.DisplayMember = "name";
                //comboBox1.ValueMember = "object_id";
                //progressBar1.Maximum = myTableOfTables.Rows.Count;
                TablesList = new ListBox();
                frm = new Form();
                frm.Controls.Add(TablesList);
                TablesList.DataSource = myTableOfTables;//Storded Procedures
                TablesList.DisplayMember = "specific_name";
                //TablesList.ValueMember = "ROUTINE_NAME";
                for (int i = 0; i < TablesList.Items.Count; i++)
                {
                    CurrentTable = TablesList.GetItemText(TablesList.Items[i]);
                    DataTable myTableOfPrams = (DataTable)DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select PARAMETER_NAME, DATA_TYPE from " + DatabaseName + ".information_schema.parameters where specific_name = '" + CurrentTable + "'", DB_OperationProcess.ResultReturnedDataType.Table);
                    ListBox ColumnsList = new ListBox();
                    Form frm2 = new Form();
                    frm2.Controls.Add(ColumnsList);
                    ColumnsList.DataSource = myTableOfPrams;
                    ColumnsList.DisplayMember = "PARAMETER_NAME";
                    //ColumnsList.ValueMember = "DATA_TYPE";
                    Dictionary<string, string> ListOfPrams = new Dictionary<string, string>();
                    for (int x = 0; x < ColumnsList.Items.Count; x++)
                    {
                        string CurrentPram = ColumnsList.GetItemText(ColumnsList.Items[x]);
                        string dataTypename = "";
                        dataTypename = DB.ExecuteSqlStatmentQuery(@"use " + DatabaseName + " select DATA_TYPE from " + DatabaseName + ".information_schema.parameters where specific_name = '" + CurrentTable + "' and PARAMETER_NAME = '" + CurrentPram + "'", DB_OperationProcess.ResultReturnedDataType.Scalar).ToString();
                        dataTypename = GiveName(dataTypename);
                        ListOfPrams.Add(CurrentPram, dataTypename);
                    }
                    ListCalsses[ListCalsses.Count - 1].AddClassStordedProcedure(CurrentTable, "DataSet", ListOfPrams);
                    progressBar1.Value += 1;
                }
                ListCalsses[ListCalsses.Count - 1].CreateClassCode();
                #endregion

                stream2enumTablesNames.Write("        }");
                stream2enumTablesNames.WriteLine();
                stream4Endnamespace.WriteLine("    }");
                stream4Endnamespace.WriteLine("}");

                StreamWriter st = new StreamWriter(FilePath);
                foreach (var item in ListCalsses)
                {
                    stream3namespaceClasses.Write(item.FullClassCode);
                }
                if (rdo_WithDAL.Checked)
                {
                    st.WriteLine("using N_Tier_Classes.ObjectLayer." + DatabaseName + ";");
                    st.Write(DatabaseCodeGenrator.Properties.Resources.DB_Class);
                    st.WriteLine("   ");
                }
                st.Write(stream1namespace);
                st.Write(stream2enumTablesNames);

                st.Write(stream3namespaceClasses);
                st.Write(stream4Endnamespace);
                stream1namespace.Close();
                stream2enumTablesNames.Close();
                stream3namespaceClasses.Close();
                stream4Endnamespace.Close();
                st.Close();
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    MessageBox.Show("Done");
                    progressBar1.Value = 0;
                }
            }
        }

        private string GiveName(string dataTypename)
        {
            if (dataTypename == "int" || dataTypename == "smallint" || dataTypename == "tinyint" || dataTypename == "bigint")
                return "int";
            else if (dataTypename == "nvarchar" || dataTypename == "text")
                return "string";
            else if (dataTypename == "time" || dataTypename == "datetime" || dataTypename == "datetime2" || dataTypename == "date" || dataTypename == "smalldatetime")
                return "DateTime";
            else if (dataTypename == "money" || dataTypename == "decimal" || dataTypename == "float")
                return "decimal";
            else if (dataTypename == "bit")
                return "bool";
            else if (dataTypename == "char")
                return "char";
            else if (dataTypename == "binary")
                return "byte";
            else
                return "string";
        }

        private void AddenumTableName(string name)
        {
            stream2enumTablesNames.WriteLine("            " + name + ",");
        }

        private void btn_DatabaseSearch_Click(object sender, EventArgs e)
        {
            if (rdo_WindowsAuthentication.Checked)
            {
                DB_OperationProcess.ConnectionString = @"Data Source=" + txt_ServerName.Text + ";Initial Catalog=master;Integrated Security=True";
            }
            else if (rdo_SQLAuthentication.Checked)
            {
                DB_OperationProcess.ConnectionString = @"Data Source=" + txt_ServerName.Text + ";Initial Catalog=master;Integrated Security=false;User Id=" + txt_UserName.Text + ";Password=" + txt_PassWord.Text + ";";
            }
            if (DB.TestConnection())
            {
                myTableOfDatabases = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from sys.databases", DB_OperationProcess.ResultReturnedDataType.Table);
                cbo_DatabaseName.DataSource = myTableOfDatabases;
                cbo_DatabaseName.DisplayMember = "name";
                cbo_DatabaseName.ValueMember = "database_id";
            }
        }

        private void cbo_DatabaseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseName = cbo_DatabaseName.GetItemText(cbo_DatabaseName.SelectedItem);
        }

        private void btn_TestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdo_WindowsAuthentication.Checked)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=" + txt_ServerName.Text + ";Initial Catalog=master;Integrated Security=True");
                    con.Open();
                    con.Close();
                }
                else if (rdo_SQLAuthentication.Checked)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=" + txt_ServerName.Text + ";Initial Catalog=master;Integrated Security=false;User Id=" + txt_UserName.Text + ";Password=" + txt_PassWord.Text + ";");
                    con.Open();
                    con.Close();
                }
                MessageBox.Show("Test Connection successed", "Code Genrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Test Connection fialed", "Code Genrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdo_WindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_WindowsAuthentication.Checked == true)
            {
                txt_UserName.Enabled = false;
                txt_PassWord.Enabled = false;
            }
            else
            {
                txt_UserName.Enabled = true;
                txt_PassWord.Enabled = true;
            }
        }

        private void fromMySqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Frm_MySql().ShowDialog();
        }
    }
    public class ClassStructure
    {
        private StringWriter stream3_1ClassName = new StringWriter();//Class Name
        private StringWriter stream3_2enumFields = new StringWriter();//enum Fields
        private StringWriter stream3_3ClassFields = new StringWriter();//Class Fields
        private StringWriter stream3_4ClassProperties = new StringWriter();//Class Properties
        private StringWriter stream3_5ClassStordedProcedures = new StringWriter();//Class Storded Procedures
        public StringWriter FullClassCode = new StringWriter();

        public ClassStructure(string ClassName)
        {
            this.stream3_1ClassName.WriteLine("        public class " + ClassName /*+ " : DB_OperationProcess"*/);
            this.stream3_1ClassName.WriteLine("        {");
            this.stream3_1ClassName.WriteLine("            private DB_OperationProcess DB = new DB_OperationProcess();");

            this.stream3_1ClassName.WriteLine("            public enum Fields");
            this.stream3_1ClassName.WriteLine("            {");
            this.stream3_1ClassName.WriteLine("                ALL,");
        }

        public void AddenumField(string name)
        {
            this.stream3_2enumFields.WriteLine("                " + name + ",");
        }

        public void AddClassField(string name, string dataType)
        {
            this.stream3_3ClassFields.WriteLine("            private " + dataType + " _" + name + ";");
        }

        public void AddClassProperty(string name, string dataType)
        {
            this.stream3_4ClassProperties.WriteLine("            public " + dataType + " " + name);
            this.stream3_4ClassProperties.WriteLine("            {");
            this.stream3_4ClassProperties.WriteLine("                get { return this._" + name + "; }");
            this.stream3_4ClassProperties.WriteLine("                set { this._" + name + " = value; }");
            this.stream3_4ClassProperties.WriteLine("            }");
        }

        public void AddClassStordedProcedure(string StordedProcedureName, string dataType, Dictionary<string, string> prams)
        {
            string StordedPrams = "";
            string StordedSqlParameter = "";
            foreach (KeyValuePair<string, string> pram in prams)
            {
                StordedPrams += pram.Value + " " + pram.Key.Remove(0, 1) + ", ";
                StordedSqlParameter += "@" + pram.Key.Remove(0, 1) + ", ";
            }
            StordedPrams = StordedPrams.Remove(StordedPrams.LastIndexOf(','));
            StordedSqlParameter = StordedSqlParameter.Remove(StordedSqlParameter.LastIndexOf(','));

            this.stream3_5ClassStordedProcedures.WriteLine("            public " + dataType + " " + StordedProcedureName + " (" + StordedPrams + ")");
            this.stream3_5ClassStordedProcedures.WriteLine("            {");
            foreach (KeyValuePair<string, string> pram in prams)
            {
                this.stream3_5ClassStordedProcedures.WriteLine("                DB.AddSqlParameter(\"@" + pram.Key.Remove(0, 1) + "\", " + pram.Key.Remove(0, 1) + ");");
            }
            this.stream3_5ClassStordedProcedures.WriteLine("                return (DataSet)DB.ExecuteSqlStatmentQuery(@\"EXECUTE " + StordedProcedureName + " " + StordedSqlParameter + " \", N_Tier_Classes.DataAccessLayer.DB_OperationProcess.ResultReturnedDataType.DataSet);");

            /*
             AddSqlParameter("@pram1", pram1);
             return (DataSet)ExecuteSqlStatmentQuery(@"EXECUTE spTest @pram1", ResultReturnedDataType.DataSet);
             * */

            this.stream3_5ClassStordedProcedures.WriteLine("            }");

        }

        public void CreateClassCode()
        {
            this.stream3_2enumFields.WriteLine("            }");
            this.stream3_2enumFields.WriteLine();
            this.stream3_2enumFields.WriteLine("            #region Fields");

            this.stream3_3ClassFields.WriteLine("            #endregion");
            this.stream3_3ClassFields.WriteLine();
            this.stream3_3ClassFields.WriteLine("            #region Properties");

            this.stream3_4ClassProperties.WriteLine("            #endregion");
            this.stream3_4ClassProperties.WriteLine();
            this.stream3_4ClassProperties.WriteLine("            #region Storded Procedures");

            this.stream3_5ClassStordedProcedures.WriteLine("            #endregion");
            this.stream3_5ClassStordedProcedures.WriteLine();
            this.stream3_5ClassStordedProcedures.WriteLine("        }");

            this.FullClassCode.Write(stream3_1ClassName);
            this.FullClassCode.Write(stream3_2enumFields);
            this.FullClassCode.Write(stream3_3ClassFields);
            this.FullClassCode.Write(stream3_4ClassProperties);
            this.FullClassCode.Write(stream3_5ClassStordedProcedures);
            this.stream3_1ClassName.Close();
            this.stream3_2enumFields.Close();
            this.stream3_3ClassFields.Close();
            this.stream3_4ClassProperties.Close();
            this.stream3_5ClassStordedProcedures.Close();
            this.FullClassCode.Close();
        }
    }

    public enum TablesNames
    {
        Tbl_Employee
    }

    public class DB_OperationProcess
    {
        #region Fields
        private string _QueryFields = "";
        private string _QueryFieldsAndValues = "";
        private string _QueryFieldsToWhere = "";
        private string _QueryValues = "";
        private List<SqlParameter> _SqlParameters = new List<SqlParameter>();
        private int _IndexOfValues = 0;
        private Enum _CurrentField;
        private static string _ConnectionString = "";
        private string _QueryTables = "";
        private string _FirstTable = "";
        private Type _Type;
        private SqlTransaction _Transaction = null;
        private SqlConnection _Connection = new SqlConnection();
        private SqlConnection _TestConnection = new SqlConnection();
        private bool _TransPeriod = false;
        private List<SqlCommand> _TransactionsCommands = new List<SqlCommand>();
        public static string ServerName = "";
        public static string DatabaseName = "";
        public static string UserID = "";
        public static string UserPassword = "";
        public static bool IntegratedSecurity = true;
        #endregion

        public DB_OperationProcess()
        {
        }

        public static string ConnectionString
        {
            set { _ConnectionString = value; }
            get { return _ConnectionString; }
        }

        #region Transactions
        public void StartTransaction()
        {
            _TransPeriod = true;
            _Connection.ConnectionString = _ConnectionString;
            _Connection.Open();
            _Transaction = _Connection.BeginTransaction(IsolationLevel.Serializable);
        }
        public void CommitTransaction()
        {
            _Transaction.Commit();
            _Connection.Close();
            _Connection.ConnectionString = "";
            _TransactionsCommands.Clear();
            _TransPeriod = false;
        }
        public void RollBackTransaction()
        {
            if (_TransPeriod == true)
                _Transaction.Rollback();
            _Connection.Close();
            _Connection.ConnectionString = "";
            _TransactionsCommands.Clear();
            _TransPeriod = false;
        }
        #endregion

        public bool TestConnection()
        {
            //try
            //{
            _TestConnection.ConnectionString = ConnectionString;
            _TestConnection.Open();
            _TestConnection.Close();
            return true;
            //}
            //catch (Exception)
            //{
            //    //MessageBox.Show("من فضلك تأكد الاتصال بالشبكة او قاعدة البيانات", "Connection Failer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return false;
            //}
        }

        public bool CheckExist(string DatabaseName)
        {
            if (ExecuteSqlStatmentQuery(@"select name from sys.databases where name = '" + DatabaseName + "'", ResultReturnedDataType.Scalar) == null)
                return false;
            else
                return true;
        }

        //public bool CreateDatabase(string ServerName, string DatabaseScript)
        //{
        //    SqlConnection masterConnection = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=master;Integrated Security=True");
        //    SqlCommand command;
        //    try
        //    {
        //        masterConnection.Open();
        //        string[] commands = DatabaseScript.Split(
        //            new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string c in commands)
        //        {
        //            command = new SqlCommand(c, masterConnection);
        //            command.ExecuteNonQuery();
        //        }
        //        masterConnection.Close();
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        masterConnection.Close();
        //        MessageBox.Show(exp.Message);
        //        return false;
        //    }
        //}

        //public bool CreateDatabase(string ServerName, string UserName, string Password, string DatabaseScript)
        //{
        //    SqlConnection masterConnection = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=master;User Id=" + UserName + ";Password=" + Password + ";");
        //    SqlCommand command;
        //    try
        //    {
        //        masterConnection.Open();
        //        string[] commands = DatabaseScript.Split(
        //            new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string c in commands)
        //        {
        //            command = new SqlCommand(c, masterConnection);
        //            command.ExecuteNonQuery();
        //        }
        //        masterConnection.Close();
        //        return true;
        //    }
        //    catch (Exception exp)
        //    {
        //        masterConnection.Close();
        //        MessageBox.Show(exp.Message);
        //        return false;
        //    }
        //}

        public enum ResultReturnedDataType
        {
            Table,
            Column,
            Row,
            Scalar,
            NumberOfRowsAffected,
            DataSet
        }

        public virtual object ExecuteSqlStatmentQuery(string SqlQureyStatment, ResultReturnedDataType ReturnType)
        {
            object Result = null;
            try
            {
                if (_TransPeriod == false)
                {
                    _Connection.ConnectionString = _ConnectionString;
                    _Connection.Open();
                }
                _TransactionsCommands.Add(new SqlCommand(SqlQureyStatment, _Connection));
                if (_SqlParameters.Count > 0)
                {
                    foreach (SqlParameter CurrentPar in _SqlParameters)
                    {
                        _TransactionsCommands[_TransactionsCommands.Count - 1].Parameters.Add(CurrentPar);
                    }
                }
                DataSet Dataset = new DataSet();
                SqlDataAdapter DataReader = new SqlDataAdapter();
                SqlCommandBuilder sqlbuilder = new SqlCommandBuilder();
                if (_TransPeriod)
                {
                    _TransactionsCommands[_TransactionsCommands.Count - 1].Transaction = _Transaction;
                    //command.Transaction = transaction;
                }
                switch (ReturnType)
                {
                    case ResultReturnedDataType.Table:
                        DataReader = new SqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
                        sqlbuilder = new SqlCommandBuilder(DataReader);
                        DataReader.Fill(Dataset);
                        Result = Dataset.Tables[0];
                        break;
                    case ResultReturnedDataType.Column:
                        DataReader = new SqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
                        sqlbuilder = new SqlCommandBuilder(DataReader);
                        DataReader.Fill(Dataset);
                        Result = Dataset.Tables[0].Columns[0];
                        break;
                    case ResultReturnedDataType.Row:
                        DataReader = new SqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
                        sqlbuilder = new SqlCommandBuilder(DataReader);
                        DataReader.Fill(Dataset);
                        if (Dataset.Tables[0].Rows.Count > 0)
                            Result = Dataset.Tables[0].Rows[0];
                        else
                            Result = null;
                        break;
                    case ResultReturnedDataType.Scalar:
                        Result = _TransactionsCommands[_TransactionsCommands.Count - 1].ExecuteScalar();
                        break;
                    case ResultReturnedDataType.NumberOfRowsAffected:
                        Result = _TransactionsCommands[_TransactionsCommands.Count - 1].ExecuteNonQuery();
                        break;
                    case ResultReturnedDataType.DataSet:
                        DataReader = new SqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
                        sqlbuilder = new SqlCommandBuilder(DataReader);
                        DataReader.Fill(Dataset);
                        Result = Dataset;
                        break;
                }
                if (_TransPeriod == false)
                {
                    _Connection.Close();
                    _Connection.ConnectionString = "";
                    _TransactionsCommands.Clear();
                }

            }
            catch (Exception Exp)
            {
                //_Connection.Close();
                //_Connection.ConnectionString = "";
                //RollBackTransaction();
                //Result = null;
                throw Exp;
            }
            _QueryValues = "";
            if (_SqlParameters.Count > 0)
                _SqlParameters.Clear();
            _QueryFieldsAndValues = "";
            _QueryFieldsToWhere = "";
            _QueryFields = "";
            _QueryTables = "";
            _FirstTable = "";
            _IndexOfValues = 0;
            return Result;
        }

        public virtual long NewID()
        {
            DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT PK_ID from " + this.GetType().Name, ResultReturnedDataType.Table);
            if (myTable.Rows.Count == 0)
                return 1;
            else
                return Convert.ToInt64(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + this.GetType().Name, ResultReturnedDataType.Scalar)) + 1;
        }

        public virtual long NewID(TablesNames TableName)
        {
            DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT * from " + TableName.ToString(), ResultReturnedDataType.Table);
            if (myTable.Rows.Count == 0)
                return 1;
            else
                return Convert.ToInt64(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + TableName.ToString(), ResultReturnedDataType.Scalar)) + 1;
        }

        public int MaxID
        {
            get
            {
                DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT PK_ID from " + this.GetType().Name, ResultReturnedDataType.Table);
                if (myTable.Rows.Count == 0)
                    return 0;
                else
                    return Convert.ToInt32(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + this.GetType().Name, ResultReturnedDataType.Scalar));
                //return -1;
            }
        }

        public virtual object Delete(TablesNames TableName, params object[] Fields)
        {
            foreach (var field in Fields)
            {
                try
                {
                    _CurrentField = (Enum)field;
                }
                catch (Exception)
                {
                    if (_QueryFieldsToWhere == "")
                    {
                        if (field.GetType() == typeof(String))
                            _QueryFieldsToWhere += " " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
                        else
                            _QueryFieldsToWhere += " " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
                    }
                    else
                    {
                        if (field.GetType() == typeof(String))
                            _QueryFieldsToWhere += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
                        else
                            _QueryFieldsToWhere += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
                    }
                }
                _IndexOfValues++;
            }
            return ExecuteSqlStatmentQuery("DELETE FROM " + TableName.ToString() + " WHERE " + _QueryFieldsToWhere, ResultReturnedDataType.NumberOfRowsAffected);
        }

        public virtual object DeleteALL(TablesNames TableName)
        {
            return ExecuteSqlStatmentQuery("DELETE FROM " + TableName.ToString(), ResultReturnedDataType.NumberOfRowsAffected);
        }

        public virtual object Select(params object[] Fields)
        {
            _FirstTable = Fields[0].GetType().DeclaringType.Name;
            foreach (var field in Fields)
            {
                if (field.GetType().BaseType == typeof(Enum))
                {
                    _CurrentField = (Enum)field;
                    _Type = field.GetType().DeclaringType;
                    if (field.ToString() == "ALL")
                    {
                        _QueryFields += " , * ";
                    }
                    else
                    {
                        _QueryFields += " , " + field.ToString() + " ";
                    }

                    if (_Type.Name != _FirstTable)
                        _QueryTables += " , " + _Type.Name;
                }
                else
                {
                    _QueryValues += " and " + _CurrentField + " = " + " @Where" + _CurrentField;
                    AddSqlParameter("@Where" + _CurrentField, field);
                }
                _IndexOfValues++;
            }

            _QueryTables = _QueryTables.Remove(1, 1);
            _QueryFields = _QueryFields.Remove(1, 1);
            _QueryValues = _QueryValues.Remove(1, 3);

            if (_QueryValues == "")
                return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables, ResultReturnedDataType.Table);
            else
                return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables + " Where " + _QueryValues, ResultReturnedDataType.Table);
        }

        public virtual object SelectScalar(params object[] Fields)
        {
            _FirstTable = Fields[0].GetType().DeclaringType.Name;
            foreach (var field in Fields)
            {
                if (field.GetType().BaseType == typeof(Enum))
                {
                    _CurrentField = (Enum)field;
                    _Type = field.GetType().DeclaringType;
                    if (field.ToString() == "ALL")
                    {
                        _QueryFields += " , * ";
                    }
                    else
                    {
                        _QueryFields += " , " + field.ToString() + " ";
                    }

                    if (_Type.Name != _FirstTable)
                        _QueryTables += " , " + _Type.Name;
                }
                else
                {
                    _QueryValues += " and " + _CurrentField + " = " + " @Where" + _CurrentField;
                    AddSqlParameter("@Where" + _CurrentField, field);
                }
                _IndexOfValues++;
            }

            _QueryTables = _QueryTables.Remove(1, 1);
            _QueryFields = _QueryFields.Remove(1, 1);
            _QueryValues = _QueryValues.Remove(1, 3);

            if (_QueryValues == "")
                return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables, ResultReturnedDataType.Scalar);
            else
                return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables + " Where " + _QueryValues, ResultReturnedDataType.Scalar);
        }

        public virtual object Update(TablesNames TableName, object[] UserFieldsAndValues, object[] FieldsToWhere)
        {
            #region FieldsAndValues
            foreach (var field in UserFieldsAndValues)
            {
                if (field.GetType().BaseType == typeof(Enum))
                {
                    _CurrentField = (Enum)field;
                }
                else
                {
                    _QueryFieldsAndValues += ", " + _CurrentField + " = @" + _CurrentField;
                    AddSqlParameter("@" + _CurrentField, field);
                }
                _IndexOfValues++;
            }
            #endregion

            #region FieldsToWhere
            _IndexOfValues = 0;
            foreach (var field in FieldsToWhere)
            {
                if (field.GetType().BaseType == typeof(Enum))
                {
                    _CurrentField = (Enum)field;
                }
                else
                {
                    _QueryFieldsToWhere += " and " + _CurrentField + " = " + " @Where" + _CurrentField;
                    AddSqlParameter("@Where" + _CurrentField, field);
                }
                _IndexOfValues++;
            }
            #endregion

            _QueryFieldsAndValues = _QueryFieldsAndValues.Remove(1, 1);
            _QueryFieldsToWhere = _QueryFieldsToWhere.Remove(1, 3);

            return ExecuteSqlStatmentQuery(@"UPDATE " + TableName.ToString() + " SET " + _QueryFieldsAndValues + " WHERE " + _QueryFieldsToWhere, ResultReturnedDataType.NumberOfRowsAffected);
        }

        public void AddSqlParameter(string Name, object value)
        {
            _SqlParameters.Add(new SqlParameter(Name, value));
        }

        public virtual object Insert(TablesNames TableName, params object[] FieldsAndValues)
        {
            foreach (var field in FieldsAndValues)
            {
                if (field.GetType().BaseType == typeof(Enum))
                {
                    _CurrentField = (Enum)field;
                    _QueryFields += " , " + field.ToString() + " ";
                }
                else
                {
                    _QueryValues += " , @" + _CurrentField;
                    AddSqlParameter("@" + _CurrentField, field);
                }
                _IndexOfValues++;
            }
            _QueryFields = _QueryFields.Remove(1, 1);
            _QueryValues = _QueryValues.Remove(1, 1);
            return ExecuteSqlStatmentQuery(@"INSERT INTO " + TableName.ToString() + " ( " + _QueryFields + " )VALUES ( " + _QueryValues + " )", ResultReturnedDataType.NumberOfRowsAffected); ;
        }
    }
}
