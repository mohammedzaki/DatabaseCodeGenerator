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
//using MySql.Data.MySqlClient;

namespace DatabaseCodeGenrator
{
    public partial class Frm_MySql : Form
    {
        public Frm_MySql()
        {
            InitializeComponent();
            rdo_WithDAL.Checked = true;
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {

        }
        
        //string FilePath = "";
        //DB_OperationProcessForMySql DB = new DB_OperationProcessForMySql();
        //StringWriter stream1namespace = new StringWriter();
        //StringWriter stream2enumTablesNames = new StringWriter();
        //StringWriter stream3namespaceClasses = new StringWriter();
        //StringWriter stream4Endnamespace = new StringWriter();
        //List<ClassStructure> ListCalsses = new List<ClassStructure>();
        //string DatabaseName = "";
        //DataTable myTableOfDatabases;
        //private string CurrentColumn;
        //private string CurrentTable;

        //private void btn_Generate_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileLocation = new SaveFileDialog();
        //    saveFileLocation.Filter = "CS File (*.cs)|*.cs|Text File (*.txt)|*.txt";
        //    //saveFileLocation.ShowDialog();
        //    if (saveFileLocation.ShowDialog() != DialogResult.Cancel)
        //    {
        //        FilePath = saveFileLocation.FileName;
        //        stream1namespace.WriteLine("namespace N_Tier_Classes.ObjectLayer");
        //        stream1namespace.WriteLine("{");
        //        stream1namespace.WriteLine("    namespace " + cbo_DatabaseName.GetItemText(cbo_DatabaseName.SelectedItem));
        //        stream1namespace.WriteLine("    {");
        //        if (rdo_WithDAL.Checked)
        //        {
        //            stream1namespace.WriteLine("        using N_Tier_Classes.DataAccessLayer;");
        //            stream1namespace.WriteLine("   ");
        //        }
        //        stream1namespace.WriteLine("        public enum TablesNames");
        //        stream1namespace.WriteLine("        {");

        //        DataTable myTableOfTables = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from information_schema.tables where Table_SCHEMA = '" + DatabaseName + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Table);
        //        //comboBox1.DataSource = myTable;
        //        //comboBox1.DisplayMember = "name";
        //        //comboBox1.ValueMember = "object_id";
        //        progressBar1.Maximum = myTableOfTables.Rows.Count;
        //        ListBox TablesList = new ListBox();
        //        Form frm = new Form();
        //        frm.Controls.Add(TablesList);
        //        TablesList.DataSource = myTableOfTables;
        //        TablesList.DisplayMember = "table_name";
        //        //TablesList.ValueMember = "object_id";
        //        for (int i = 0; i < TablesList.Items.Count; i++)
        //        {
        //            CurrentTable = TablesList.GetItemText(TablesList.Items[i]);
        //            AddenumTableName(CurrentTable);
        //            ListCalsses.Add(new ClassStructure(CurrentTable));
        //            DataTable myTableOfColumns = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from information_schema.columns where Table_SCHEMA = '" + DatabaseName + "' and Table_NAME = '" + CurrentTable + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Table);
        //            ListBox ColumnsList = new ListBox();
        //            Form frm2 = new Form();
        //            frm2.Controls.Add(ColumnsList);
        //            ColumnsList.DataSource = myTableOfColumns;
        //            ColumnsList.DisplayMember = "COLUMN_NAME";
        //            //ColumnsList.ValueMember = "column_id";
        //            for (int x = 0; x < ColumnsList.Items.Count; x++)
        //            {
        //                CurrentColumn = ColumnsList.GetItemText(ColumnsList.Items[x]);
        //                ListCalsses[ListCalsses.Count - 1].AddenumField(CurrentColumn);
        //                string dataTypename = "";
        //                dataTypename = DB.ExecuteSqlStatmentQuery(@"select DATA_TYPE from information_schema.columns where Table_SCHEMA = '" + DatabaseName + "' and Table_NAME = '" + CurrentTable + "' and COLUMN_NAME = '" + CurrentColumn + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Scalar).ToString();
        //                //dataTypename = GiveName(dataTypename);
        //                ListCalsses[ListCalsses.Count - 1].AddClassField(CurrentColumn, GiveName(dataTypename));
        //                ListCalsses[ListCalsses.Count - 1].AddClassProperty(CurrentColumn, GiveName(dataTypename));
        //            }
        //            ListCalsses[ListCalsses.Count - 1].CreateClassCode();
        //            progressBar1.Value += 1;
        //        }
        //        #region Views
        //        myTableOfTables = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from information_schema.views where Table_SCHEMA = '" + DatabaseName + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Table);
        //        //comboBox1.DataSource = myTable;
        //        //comboBox1.DisplayMember = "name";
        //        //comboBox1.ValueMember = "object_id";
        //        //progressBar1.Maximum = myTableOfTables.Rows.Count;
        //        TablesList = new ListBox();
        //        frm = new Form();
        //        frm.Controls.Add(TablesList);
        //        TablesList.DataSource = myTableOfTables;
        //        TablesList.DisplayMember = "Table_NAME";
        //        //TablesList.ValueMember = "object_id";
        //        for (int i = 0; i < TablesList.Items.Count; i++)
        //        {
        //            CurrentTable = TablesList.GetItemText(TablesList.Items[i]);
        //            AddenumTableName(CurrentTable);
        //            ListCalsses.Add(new ClassStructure(CurrentTable));
        //            DataTable myTableOfColumns = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from information_schema.columns where Table_SCHEMA = '" + DatabaseName + "' and Table_NAME = '" + CurrentTable + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Table);
        //            ListBox ColumnsList = new ListBox();
        //            Form frm2 = new Form();
        //            frm2.Controls.Add(ColumnsList);
        //            ColumnsList.DataSource = myTableOfColumns;
        //            ColumnsList.DisplayMember = "COLUMN_NAME";
        //            //ColumnsList.ValueMember = "column_id";
        //            for (int x = 0; x < ColumnsList.Items.Count; x++)
        //            {
        //                CurrentColumn = ColumnsList.GetItemText(ColumnsList.Items[x]);
        //                ListCalsses[ListCalsses.Count - 1].AddenumField(CurrentColumn);
        //                string dataTypename = "";
        //                dataTypename = DB.ExecuteSqlStatmentQuery(@"select DATA_TYPE from information_schema.columns where Table_SCHEMA = '" + DatabaseName + "' and Table_NAME = '" + CurrentTable + "' and COLUMN_NAME = '" + CurrentColumn + "'", DB_OperationProcessForMySql.ResultReturnedDataType.Scalar).ToString();
        //                //dataTypename = GiveName(dataTypename);
        //                ListCalsses[ListCalsses.Count - 1].AddClassField(CurrentColumn, GiveName(dataTypename));
        //                ListCalsses[ListCalsses.Count - 1].AddClassProperty(CurrentColumn, GiveName(dataTypename));
        //            }
        //            ListCalsses[ListCalsses.Count - 1].CreateClassCode();
        //            progressBar1.Value += 1;
        //        }
        //        #endregion
        //        stream2enumTablesNames.Write("        }");
        //        stream2enumTablesNames.WriteLine();
        //        stream4Endnamespace.WriteLine("    }");
        //        stream4Endnamespace.WriteLine("}");

        //        StreamWriter st = new StreamWriter(FilePath);
        //        foreach (var item in ListCalsses)
        //        {
        //            stream3namespaceClasses.Write(item.FullClassCode);
        //        }
        //        if (rdo_WithDAL.Checked)
        //        {
        //            st.WriteLine("using N_Tier_Classes.ObjectLayer." + DatabaseName + ";");
        //            st.Write(DatabaseCodeGenrator.Properties.Resources.DB_MySqlClass);
        //            st.WriteLine("   ");
        //        }
        //        st.Write(stream1namespace);
        //        st.Write(stream2enumTablesNames);

        //        st.Write(stream3namespaceClasses);
        //        st.Write(stream4Endnamespace);
        //        stream1namespace.Close();
        //        stream2enumTablesNames.Close();
        //        stream3namespaceClasses.Close();
        //        stream4Endnamespace.Close();
        //        st.Close();
        //        if (progressBar1.Value == progressBar1.Maximum)
        //        {
        //            MessageBox.Show("Done");
        //            progressBar1.Value = 0;
        //        }
        //    }
        //}

        //private string GiveName(string dataTypename)
        //{
        //    if (dataTypename == "int" || dataTypename == "smallint" || dataTypename == "tinyint" || dataTypename == "bigint")
        //        return "int";
        //    else if (dataTypename == "nvarchar" || dataTypename == "text")
        //        return "string";
        //    else if (dataTypename == "time" || dataTypename == "datetime" || dataTypename == "datetime2" || dataTypename == "date" || dataTypename == "smalldatetime")
        //        return "DateTime";
        //    else if (dataTypename == "money" || dataTypename == "decimal" || dataTypename == "float")
        //        return "decimal";
        //    else if (dataTypename == "bit")
        //        return "bool";
        //    else if (dataTypename == "char")
        //        return "char";
        //    else if (dataTypename == "binary")
        //        return "byte";
        //    else
        //        return "string";
        //}

        //private void AddenumTableName(string name)
        //{
        //    stream2enumTablesNames.WriteLine("            " + name + ",");
        //}

        //private void btn_DatabaseSearch_Click(object sender, EventArgs e)
        //{
        //    DB_OperationProcessForMySql.ConnectionString = @"Server=" + txt_ServerName.Text + ";DATABASE=information_schema;UID=" + txt_UserName.Text + ";PASSWORD=" + txt_PassWord.Text + ";";

        //    if (DB.TestConnection())
        //    {
        //        myTableOfDatabases = (DataTable)DB.ExecuteSqlStatmentQuery(@"select * from information_schema.schemata", DB_OperationProcessForMySql.ResultReturnedDataType.Table);
        //        cbo_DatabaseName.DataSource = myTableOfDatabases;
        //        cbo_DatabaseName.DisplayMember = "schema_Name";
        //        //cbo_DatabaseName.ValueMember = "database_id";
        //    }
        //}

        //private void cbo_DatabaseName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DatabaseName = cbo_DatabaseName.GetItemText(cbo_DatabaseName.SelectedItem);
        //}

        //private void btn_TestConnection_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        MySqlConnection con = new MySqlConnection(@"Server=" + txt_ServerName.Text + ";DATABASE=information_schema;UID=" + txt_UserName.Text + ";PASSWORD=" + txt_PassWord.Text + ";");
        //        con.Open();
        //        con.Close();
        //        MessageBox.Show("Test Connection successed", "Code Genrator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Test Connection fialed", "Code Genrator", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

    }

    //public class DB_OperationProcessForMySql
    //{
    //    #region Fields
    //    private string _QueryFields = "";
    //    private string _QueryFieldsAndValues = "";
    //    private string _QueryFieldsToWhere = "";
    //    private string _QueryValues = "";
    //    private List<MySqlParameter> _SqlParameters = new List<MySqlParameter>();
    //    private int _IndexOfValues = 0;
    //    private Enum _CurrentField;
    //    private static string _ConnectionString = "";
    //    private string _QueryTables = "";
    //    private string _FirstTable = "";
    //    private Type _Type;
    //    private MySqlTransaction _Transaction = null;
    //    private MySqlConnection _Connection = new MySqlConnection();
    //    private MySqlConnection _TestConnection = new MySqlConnection();
    //    private bool _TransPeriod = false;
    //    private List<MySqlCommand> _TransactionsCommands = new List<MySqlCommand>();
    //    public static string ServerName = "";
    //    public static string DatabaseName = "";
    //    public static string UserID = "";
    //    public static string UserPassword = "";
    //    #endregion

    //    public static string ConnectionString
    //    {
    //        set { _ConnectionString = value; }
    //        get { return _ConnectionString; }
    //    }

    //    #region Transactions
    //    public void StartTransaction()
    //    {
    //        _TransPeriod = true;
    //        _Connection.ConnectionString = _ConnectionString;
    //        _Connection.Open();
    //        _Transaction = _Connection.BeginTransaction(IsolationLevel.Serializable);
    //    }
    //    public void CommitTransaction()
    //    {
    //        _Transaction.Commit();
    //        _Connection.Close();
    //        _Connection.ConnectionString = "";
    //        _TransactionsCommands.Clear();
    //        _TransPeriod = false;
    //    }
    //    public void RollBackTransaction()
    //    {
    //        if (_TransPeriod == true)
    //            _Transaction.Rollback();
    //        _Connection.Close();
    //        _Connection.ConnectionString = "";
    //        _TransactionsCommands.Clear();
    //        _TransPeriod = false;
    //    }
    //    #endregion

    //    public bool TestConnection()
    //    {
    //        try
    //        {
    //            _TestConnection.ConnectionString = ConnectionString;
    //            _TestConnection.Open();
    //            _TestConnection.Close();
    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            MessageBox.Show("من فضلك تأكد الاتصال بالشبكة او قاعدة البيانات", "Connection Failer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //            return false;
    //        }
    //    }

    //    public bool CheckExist(string DatabaseName)
    //    {
    //        if (ExecuteSqlStatmentQuery(@"select name from sys.databases where name = '" + DatabaseName + "'", ResultReturnedDataType.Scalar) == null)
    //            return false;
    //        else
    //            return true;
    //    }

    //    //public bool CreateDatabase(string ServerName, string DatabaseScript)
    //    //{
    //    //    SqlConnection masterConnection = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=master;Integrated Security=True");
    //    //    SqlCommand command;
    //    //    try
    //    //    {
    //    //        masterConnection.Open();
    //    //        string[] commands = DatabaseScript.Split(
    //    //            new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
    //    //        foreach (string c in commands)
    //    //        {
    //    //            command = new SqlCommand(c, masterConnection);
    //    //            command.ExecuteNonQuery();
    //    //        }
    //    //        masterConnection.Close();
    //    //        return true;
    //    //    }
    //    //    catch (Exception exp)
    //    //    {
    //    //        masterConnection.Close();
    //    //        MessageBox.Show(exp.Message);
    //    //        return false;
    //    //    }
    //    //}

    //    //public bool CreateDatabase(string ServerName, string UserName, string Password, string DatabaseScript)
    //    //{
    //    //    SqlConnection masterConnection = new SqlConnection(@"Data Source=" + ServerName + ";Initial Catalog=master;User Id=" + UserName + ";Password=" + Password + ";");
    //    //    SqlCommand command;
    //    //    try
    //    //    {
    //    //        masterConnection.Open();
    //    //        string[] commands = DatabaseScript.Split(
    //    //            new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
    //    //        foreach (string c in commands)
    //    //        {
    //    //            command = new SqlCommand(c, masterConnection);
    //    //            command.ExecuteNonQuery();
    //    //        }
    //    //        masterConnection.Close();
    //    //        return true;
    //    //    }
    //    //    catch (Exception exp)
    //    //    {
    //    //        masterConnection.Close();
    //    //        MessageBox.Show(exp.Message);
    //    //        return false;
    //    //    }
    //    //}

    //    public enum ResultReturnedDataType
    //    {
    //        Table,
    //        Column,
    //        Row,
    //        Scalar,
    //        NumberOfRowsAffected,
    //        DataSet
    //    }

    //    public virtual object ExecuteSqlStatmentQuery(string SqlQureyStatment, ResultReturnedDataType ReturnType)
    //    {
    //        object Result = null;
    //        if (TestConnection())
    //        {
    //            try
    //            {
    //                if (_TransPeriod == false)
    //                {
    //                    _Connection.ConnectionString = _ConnectionString;
    //                    _Connection.Open();
    //                }
    //                _TransactionsCommands.Add(new MySqlCommand(SqlQureyStatment, _Connection));
    //                if (_SqlParameters.Count > 0)
    //                {
    //                    foreach (MySqlParameter CurrentPar in _SqlParameters)
    //                    {
    //                        _TransactionsCommands[_TransactionsCommands.Count - 1].Parameters.Add(CurrentPar);
    //                    }
    //                }
    //                DataSet Dataset = new DataSet();
    //                MySqlDataAdapter DataReader = new MySqlDataAdapter();
    //                MySqlCommandBuilder sqlbuilder = new MySqlCommandBuilder();
    //                if (_TransPeriod)
    //                {
    //                    _TransactionsCommands[_TransactionsCommands.Count - 1].Transaction = _Transaction;
    //                    //command.Transaction = transaction;
    //                }
    //                switch (ReturnType)
    //                {
    //                    case ResultReturnedDataType.Table:
    //                        DataReader = new MySqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
    //                        sqlbuilder = new MySqlCommandBuilder(DataReader);
    //                        DataReader.Fill(Dataset);
    //                        Result = Dataset.Tables[0];
    //                        break;
    //                    case ResultReturnedDataType.Column:
    //                        DataReader = new MySqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
    //                        sqlbuilder = new MySqlCommandBuilder(DataReader);
    //                        DataReader.Fill(Dataset);
    //                        Result = Dataset.Tables[0].Columns[0];
    //                        break;
    //                    case ResultReturnedDataType.Row:
    //                        DataReader = new MySqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
    //                        sqlbuilder = new MySqlCommandBuilder(DataReader);
    //                        DataReader.Fill(Dataset);
    //                        if (Dataset.Tables[0].Rows.Count > 0)
    //                            Result = Dataset.Tables[0].Rows[0];
    //                        else
    //                            Result = null;
    //                        break;
    //                    case ResultReturnedDataType.Scalar:
    //                        Result = _TransactionsCommands[_TransactionsCommands.Count - 1].ExecuteScalar();
    //                        break;
    //                    case ResultReturnedDataType.NumberOfRowsAffected:
    //                        Result = _TransactionsCommands[_TransactionsCommands.Count - 1].ExecuteNonQuery();
    //                        break;
    //                    case ResultReturnedDataType.DataSet:
    //                        DataReader = new MySqlDataAdapter(_TransactionsCommands[_TransactionsCommands.Count - 1]);
    //                        sqlbuilder = new MySqlCommandBuilder(DataReader);
    //                        DataReader.Fill(Dataset);
    //                        Result = Dataset;
    //                        break;
    //                }
    //                if (_TransPeriod == false)
    //                {
    //                    _Connection.Close();
    //                    _Connection.ConnectionString = "";
    //                    _TransactionsCommands.Clear();
    //                }

    //            }
    //            catch (Exception Exp)
    //            {
    //                //_Connection.Close();
    //                //_Connection.ConnectionString = "";
    //                RollBackTransaction();
    //                Result = null;
    //                MessageBox.Show(Exp.Message);
    //            }
    //            _QueryValues = "";
    //            if (_SqlParameters.Count > 0)
    //                _SqlParameters.Clear();
    //            _QueryFieldsAndValues = "";
    //            _QueryFieldsToWhere = "";
    //            _QueryFields = "";
    //            _QueryTables = "";
    //            _FirstTable = "";
    //            _IndexOfValues = 0;
    //        }
    //        return Result;
    //    }

    //    public virtual long NewID()
    //    {
    //        DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT PK_ID from " + this.GetType().Name, ResultReturnedDataType.Table);
    //        if (myTable.Rows.Count == 0)
    //            return 1;
    //        else
    //            return Convert.ToInt64(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + this.GetType().Name, ResultReturnedDataType.Scalar)) + 1;
    //    }

    //    public virtual long NewID(TablesNames TableName)
    //    {
    //        DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT * from " + TableName.ToString(), ResultReturnedDataType.Table);
    //        if (myTable.Rows.Count == 0)
    //            return 1;
    //        else
    //            return Convert.ToInt64(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + TableName.ToString(), ResultReturnedDataType.Scalar)) + 1;
    //    }

    //    public long MaxID
    //    {
    //        get
    //        {
    //            DataTable myTable = (DataTable)ExecuteSqlStatmentQuery("SELECT PK_ID from " + this.GetType().Name, ResultReturnedDataType.Table);
    //            if (myTable.Rows.Count == 0)
    //                return 0;
    //            else
    //                return Convert.ToInt64(ExecuteSqlStatmentQuery("SELECT MAX(PK_ID) from " + this.GetType().Name, ResultReturnedDataType.Scalar));
    //        }
    //    }

    //    public virtual object Delete(TablesNames TableName, params object[] Fields)
    //    {
    //        foreach (var field in Fields)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryValues == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryFieldsToWhere += " " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryFieldsToWhere += " " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryFieldsToWhere += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryFieldsToWhere += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        return ExecuteSqlStatmentQuery("DELETE FROM " + TableName.ToString() + " WHERE " + _QueryFieldsToWhere, ResultReturnedDataType.NumberOfRowsAffected);
    //    }

    //    public virtual object Select(params object[] Fields)
    //    {
    //        _FirstTable = Fields[0].GetType().DeclaringType.Name;
    //        foreach (var field in Fields)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //                _Type = field.GetType().DeclaringType;
    //                if (field.ToString() == "ALL")
    //                {
    //                    if (_QueryFields == "")
    //                        _QueryFields += " * ";
    //                    else
    //                        _QueryFields += " , * ";
    //                }
    //                else
    //                {
    //                    if (_QueryFields == "")
    //                        _QueryFields += " " + field.ToString() + " ";
    //                    else
    //                        _QueryFields += " , " + field.ToString() + " ";
    //                }
    //                if (_QueryTables == "")
    //                    _QueryTables += " " + _Type.Name;
    //                else if (_Type.Name != _FirstTable)
    //                    _QueryTables += " , " + _Type.Name;
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryValues == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryValues += " " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryValues += " " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryValues += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryValues += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        //if (QueryFields.Contains("ALL"))
    //        //    return ExecuteSqlStatmentQuery(@"select * from " + QueryTables, ResultReturnedDataType.Table);
    //        if (_QueryValues == "")
    //            return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables, ResultReturnedDataType.Table);
    //        else
    //            return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables + " Where " + _QueryValues, ResultReturnedDataType.Table);
    //    }

    //    public virtual object SelectScalar(params object[] Fields)
    //    {
    //        _FirstTable = Fields[0].GetType().DeclaringType.Name;
    //        foreach (var field in Fields)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //                _Type = field.GetType().DeclaringType;
    //                if (field.ToString() == "ALL")
    //                {
    //                    if (_QueryFields == "")
    //                        _QueryFields += " * ";
    //                    else
    //                        _QueryFields += " , * ";
    //                }
    //                else
    //                {
    //                    if (_QueryFields == "")
    //                        _QueryFields += " " + field.ToString() + " ";
    //                    else
    //                        _QueryFields += " , " + field.ToString() + " ";
    //                }
    //                if (_QueryTables == "")
    //                    _QueryTables += " " + _Type.Name;
    //                else if (_Type.Name != _FirstTable)
    //                    _QueryTables += " , " + _Type.Name;
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryValues == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryValues += " " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryValues += " " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryValues += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryValues += " and " + Fields[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        //if (QueryFields.Contains("ALL"))
    //        //    return ExecuteSqlStatmentQuery(@"select * from " + QueryTables, ResultReturnedDataType.Table);
    //        if (_QueryValues == "")
    //            return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables, ResultReturnedDataType.Table);
    //        else
    //            return ExecuteSqlStatmentQuery(@"select " + _QueryFields + " from " + _QueryTables + " Where " + _QueryValues, ResultReturnedDataType.Scalar);
    //    }

    //    public virtual object Update(TablesNames TableName, object[] UserFieldsAndValues, object[] FieldsToWhere)
    //    {
    //        #region FieldsAndValues
    //        foreach (var field in UserFieldsAndValues)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryFieldsAndValues == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                    {
    //                        if ((string)field == "NULL")
    //                            _QueryFieldsAndValues += " " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                        else
    //                            _QueryFieldsAndValues += " " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    }
    //                    else
    //                        _QueryFieldsAndValues += " " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                    {
    //                        if ((string)field == "NULL")
    //                            _QueryFieldsAndValues += " , " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                        else
    //                            _QueryFieldsAndValues += " , " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    }
    //                    else
    //                        _QueryFieldsAndValues += " , " + UserFieldsAndValues[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        #endregion
    //        _IndexOfValues = 0;
    //        #region FieldsToWhere
    //        foreach (var field in FieldsToWhere)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryFieldsToWhere == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryFieldsToWhere += " " + FieldsToWhere[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryFieldsToWhere += " " + FieldsToWhere[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                        _QueryFieldsToWhere += " and " + FieldsToWhere[_IndexOfValues - 1].ToString() + " = " + "'" + field + "'" + " ";
    //                    else
    //                        _QueryFieldsToWhere += " and " + FieldsToWhere[_IndexOfValues - 1].ToString() + " = " + field + " ";
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        #endregion
    //        return ExecuteSqlStatmentQuery(@"UPDATE " + TableName.ToString() + " SET " + _QueryFieldsAndValues + " WHERE " + _QueryFieldsToWhere, ResultReturnedDataType.NumberOfRowsAffected);
    //    }

    //    public virtual object Insert(TablesNames TableName, params object[] FieldsAndValues)
    //    {
    //        foreach (var field in FieldsAndValues)
    //        {
    //            try
    //            {
    //                _CurrentField = (Enum)field;
    //                if (_QueryFields == "")
    //                    _QueryFields += " " + field.ToString() + " ";
    //                else
    //                    _QueryFields += " , " + field.ToString() + " ";
    //            }
    //            catch (Exception)
    //            {
    //                if (_QueryValues == "")
    //                {
    //                    if (field.GetType() == typeof(String))
    //                    {
    //                        if (field == null)
    //                        {
    //                            _QueryValues += " NULL ";
    //                        }
    //                        else
    //                        {
    //                            _QueryValues += "@" + _CurrentField;
    //                            _SqlParameters.Add(new MySqlParameter("@" + _CurrentField, field) { DbType = DbType.String });
    //                            //_QueryValues += " '" + field + "' ";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        _QueryValues += " " + field + " ";
    //                    }
    //                }
    //                else
    //                {
    //                    if (field.GetType() == typeof(String))
    //                    {
    //                        if (field == null)
    //                        {
    //                            _QueryValues += " , NULL ";
    //                        }
    //                        else
    //                        {
    //                            _QueryValues += ", @" + _CurrentField;
    //                            _SqlParameters.Add(new MySqlParameter("@" + _CurrentField, field) { DbType = DbType.String });
    //                            //_QueryValues += " , '" + field + "'";
    //                        }
    //                    }
    //                    else
    //                    {
    //                        _QueryValues += " , " + field + " ";
    //                    }
    //                }
    //            }
    //            _IndexOfValues++;
    //        }
    //        return ExecuteSqlStatmentQuery(@"INSERT INTO " + TableName.ToString() + " ( " + _QueryFields + " )VALUES ( " + _QueryValues + " )", ResultReturnedDataType.NumberOfRowsAffected); ;
    //    }
    //}
}
