using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

public class Walton_DB
{
    public static SqlConnection lo_Connection;
    public const int CommandTimeOutSeconds = 1200;

    private static bool OpenConnection()
    {
        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                if (lo_Connection == null)
                {
                    lo_Connection = new SqlConnection();
                    lo_Connection.ConnectionString = "Data Source=essql1.walton.uark.edu;Initial Catalog=PROJECTS2068;User ID=PROJECTS2068;Password=CD92yag$";

                }

                if (lo_Connection.State == ConnectionState.Closed)
                    lo_Connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                lo_Connection.Dispose();
                lo_Connection = null;
                if (Retry >= 1 && (ex.Message.Contains("Data Provider error 6") || ex.Message.Contains("An existing connection was forcibly closed") || ex.Message.Contains("The specified network name is no longer available") || ex.Message.Contains("The semaphore timeout period has expired") || ex.Message.Contains("The timeout period elapsed prior to completion of the operation")))
                {
                    // short pause before retrying
                    System.Threading.Thread.Sleep(1337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("The server was not found or was not accessible")
                                || ex.Message.Contains("Could not open a connection to SQL Server")))
                {
                    // long pause before retrying
                    System.Threading.Thread.Sleep(91337);
                    Retry -= 1;
                }
                else
                    Retry = -1;
            }
        }
        return false;
    }

    public static SqlConnection Connection
    {
        get
        {
            if (OpenConnection())
                return lo_Connection;
            else
                return null;
        }
    }

    public static bool ExecSqlString(string SqlString)
    {
        SqlCommand SqlCmd = new SqlCommand(SqlString);
        return ExecSqlCommand(ref SqlCmd);
    }

    public static bool ExecSqlCommand(ref SqlCommand SqlCmd)
    {
        if (!OpenConnection())
            return false;

        SqlCmd.Connection = lo_Connection;
        SqlCmd.CommandTimeout = CommandTimeOutSeconds;
        
        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                SqlCmd.ExecuteNonQuery();
                lo_Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (Retry >= 1 && ex.Message.Contains("deadlock victim"))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("INSERT EXEC failed ") || ex.Message.Contains("Schema changed ")))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else
                {
                    lo_Connection.Close();
                    Retry = -1;
                }
            }
        }
        return false;
    }

    public static bool FillDataTable_ViaCmd(ref DataTable ReturnTable, ref SqlCommand SqlCmd)
    {
        System.Data.SqlClient.SqlDataAdapter lo_Ada = new System.Data.SqlClient.SqlDataAdapter();
        DataTable Return_DataTable = new DataTable();
        SqlConnection ActiveConn;

        if (!OpenConnection())
            return false;
        else
            ActiveConn = lo_Connection;

        SqlCmd.Connection = ActiveConn;
        SqlCmd.CommandTimeout = CommandTimeOutSeconds;

        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                lo_Ada.SelectCommand = SqlCmd;
                lo_Ada.Fill(Return_DataTable);
                lo_Ada.Dispose();
                lo_Ada = null;
                ActiveConn.Close();
                ReturnTable = Return_DataTable;
                return true;
            }
            catch (Exception ex)
            {
                if (Retry >= 1 && ex.Message.Contains("deadlock victim"))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("INSERT EXEC failed ") || ex.Message.Contains("Schema changed ")))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else
                {
                    ActiveConn.Close();
                    Retry = -1;
                }
            }
        }
        return false;
    }

    public static bool FillDataTable_ViaSql(ref DataTable ReturnTable, string SqlStr)
    {
        SqlCommand SqlCmd = new SqlCommand(SqlStr);
        return FillDataTable_ViaCmd(ref ReturnTable, ref SqlCmd);
    }

    public static DataSet CreateDataSet_ViaCmd(SqlCommand SqlCmd, string str_TableName)
    {
        System.Data.SqlClient.SqlDataAdapter lo_Ada = new System.Data.SqlClient.SqlDataAdapter();
        DataSet Return_DataSet = new DataSet();
        SqlConnection ActiveConn;

        if (!OpenConnection())
            return null;
        else
            ActiveConn = lo_Connection;

        SqlCmd.Connection = ActiveConn;
        SqlCmd.CommandTimeout = CommandTimeOutSeconds;

        int Retry = 2;
        while (Retry >= 0)
        {
            try
            {
                lo_Ada.SelectCommand = SqlCmd;
                lo_Ada.Fill(Return_DataSet, str_TableName);
                lo_Ada.Dispose();
                lo_Ada = null;
                ActiveConn.Close();
                return Return_DataSet;
            }
            catch (Exception ex)
            {
                if (Retry >= 1 && ex.Message.Contains("deadlock victim"))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else if (Retry >= 1 && (ex.Message.Contains("INSERT EXEC failed ") || ex.Message.Contains("Schema changed ")))
                {
                    System.Threading.Thread.Sleep(3337);
                    Retry -= 1;
                }
                else
                {
                    ActiveConn.Close();
                    Retry = -1;
                }
            }
        }
        return null;
    }

    public static DataSet CreateDataSet_ViaSql(string str_Sql, string str_TableName)
    {
        return CreateDataSet_ViaCmd(new SqlCommand(str_Sql), str_TableName);
    }

    public static Hashtable CreateHashTable2_ViaCmd(ref SqlCommand SqlCmd)
    {
        // creates a key-pair hashtable for a multi-row 2-column query
        // item key will be the first column value (must be a string-type)
        // item value will be the second column
        // null keys are not added, null values are converted to empty strings

        System.Data.SqlClient.SqlDataReader lo_DatR;
        Hashtable lo_HT = new Hashtable();

        if (!OpenConnection())
            return null;

        try
        {
            SqlCmd.Connection = lo_Connection;
            SqlCmd.CommandTimeout = CommandTimeOutSeconds;
            lo_DatR = SqlCmd.ExecuteReader();
            if (lo_DatR.HasRows)
            {
                while (lo_DatR.Read())
                {
                    if (!Convert.IsDBNull(lo_DatR[0]))
                    {
                        if (Convert.IsDBNull(lo_DatR[1]))
                            lo_HT.Add(lo_DatR[0], "");
                        else
                            lo_HT.Add(lo_DatR[0], lo_DatR[1]);
                    }
                }
            }
            lo_DatR.Close();

            if (lo_HT.Count <= 0)
                return null;
            else
                return lo_HT;
        }
        catch
        {
            return null;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static Hashtable CreateHashTable_ViaCmd(ref SqlCommand SqlCmd)
    {
        // creates a hashtable for a single-row query
        // item key will be the db column name
        // null values are converted to empty strings
        System.Data.SqlClient.SqlDataReader lo_DatR;
        Hashtable lo_HT;
        int li_i;
        SqlConnection ActiveConn;

        if (!OpenConnection())
            return null;
        else
            ActiveConn = lo_Connection;

        try
        {
            SqlCmd.Connection = ActiveConn;
            SqlCmd.CommandTimeout = CommandTimeOutSeconds;

            lo_DatR = SqlCmd.ExecuteReader(CommandBehavior.SingleRow);
            if (!lo_DatR.HasRows)
                lo_HT = null;
            else if (!lo_DatR.Read())
                lo_HT = null;
            else
            {
                lo_HT = new Hashtable();
                for (li_i = 0; li_i <= lo_DatR.FieldCount - 1; li_i++)
                {
                    if (Convert.IsDBNull(lo_DatR[li_i]))
                        lo_HT.Add(lo_DatR.GetName(li_i), "");
                    else
                        lo_HT.Add(lo_DatR.GetName(li_i), lo_DatR[li_i]);
                }
                if (lo_HT.Count <= 0)
                    lo_HT = null;
            }
            lo_DatR.Close();

            return lo_HT;
        }
        catch
        {
            return null;
        }
        finally
        {
            ActiveConn.Close();
        }
    }

    public static Hashtable CreateHashTable_ViaSql(string str_Sql)
    {
        System.Data.SqlClient.SqlCommand lo_SqlCmd = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlDataReader lo_DatR;
        Hashtable lo_HT;
        int li_i;

        if (!OpenConnection())
            return null;

        try
        {
            lo_SqlCmd.Connection = lo_Connection;
            lo_SqlCmd.CommandTimeout = CommandTimeOutSeconds;
            lo_SqlCmd.CommandText = str_Sql;
            lo_DatR = lo_SqlCmd.ExecuteReader(CommandBehavior.SingleRow);

            if (!lo_DatR.HasRows)
                lo_HT = null;
            else if (!lo_DatR.Read())
                lo_HT = null;
            else
            {
                lo_HT = new Hashtable();
                for (li_i = 0; li_i <= lo_DatR.FieldCount - 1; li_i++)
                {
                    if (Convert.IsDBNull(lo_DatR[li_i]))
                        lo_HT.Add(lo_DatR.GetName(li_i), "");
                    else
                        lo_HT.Add(lo_DatR.GetName(li_i), lo_DatR[li_i]);
                }
                if (lo_HT.Count <= 0)
                    lo_HT = null;
            }
            lo_DatR.Close();

            return lo_HT;
        }
        catch
        {
            return null;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static ArrayList CreateArrayList_ViaSql(string str_Sql)
    {
        System.Data.SqlClient.SqlCommand lo_SqlCmd = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlDataReader lo_DatR;
        ArrayList Return_ArrayList = new ArrayList();

        if (!OpenConnection())
            return null;

        try
        {
            lo_SqlCmd.Connection = lo_Connection;
            lo_SqlCmd.CommandTimeout = CommandTimeOutSeconds;
            lo_SqlCmd.CommandText = str_Sql;
            lo_DatR = lo_SqlCmd.ExecuteReader();

            if (lo_DatR.HasRows)
            {
                while (lo_DatR.Read())
                {
                    if (Convert.IsDBNull(lo_DatR[0]))
                        Return_ArrayList.Add("");
                    else
                        Return_ArrayList.Add(lo_DatR[0]);
                }
            }
            lo_DatR.Close();

            if (Return_ArrayList.Count > 0)
                return Return_ArrayList;
            else
                return null;
        }
        catch
        {
            return null;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static decimal RetrieveScalar(string StrSql)
    {
        System.Data.SqlClient.SqlCommand objCom = new System.Data.SqlClient.SqlCommand();
        decimal ld_Result;

        if (!OpenConnection())
            return 0;

        try
        {
            objCom.Connection = lo_Connection;
            objCom.CommandTimeout = CommandTimeOutSeconds;
            objCom.CommandText = StrSql;
            ld_Result = (decimal)objCom.ExecuteScalar();

            return ld_Result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static object RetrieveSingleValue(string Sql)
    {
        System.Data.SqlClient.SqlCommand objCom = new System.Data.SqlClient.SqlCommand();
        object ld_Result;

        if (!OpenConnection())
            return 0;

        try
        {
            objCom.Connection = lo_Connection;
            objCom.CommandTimeout = CommandTimeOutSeconds;
            objCom.CommandText = Sql;
            ld_Result = objCom.ExecuteScalar();

            return ld_Result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static object RetrieveSingleValue(ref SqlCommand objCom)
    {
        object ld_Result;

        if (!OpenConnection())
            return 0;

        objCom.Connection = lo_Connection;
        objCom.CommandTimeout = CommandTimeOutSeconds;

        try
        {
            ld_Result = objCom.ExecuteScalar();

            return ld_Result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static bool AppendDataTable(ref DataTable dsNewTable, string strSQL)
    {
        if (!OpenConnection())
            return false;

        try
        {
            DataTable oDataSet = new DataTable();
            System.Data.SqlClient.SqlDataAdapter DataAdapter;

            DataAdapter = new System.Data.SqlClient.SqlDataAdapter(strSQL, lo_Connection);

            System.Data.SqlClient.SqlCommandBuilder myDataRowsCommandBuilder = new System.Data.SqlClient.SqlCommandBuilder(DataAdapter);

            DataAdapter.Update(dsNewTable);

            DataAdapter.Dispose();
            myDataRowsCommandBuilder.Dispose();

            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            lo_Connection.Close();
        }
    }

    public static bool CloneDataTable(ref DataTable ReturnTable, string TableName)
    {
        System.Data.SqlClient.SqlDataAdapter lo_Ada = new System.Data.SqlClient.SqlDataAdapter();
        DataTable Return_DataTable = new DataTable();

        if (!OpenConnection())
            return false;

        try
        {
            System.Data.SqlClient.SqlCommand SqlCmd;
            SqlCmd = new System.Data.SqlClient.SqlCommand("Select TOP 1 * from " + TableName, lo_Connection);
            SqlCmd.Connection = lo_Connection;
            lo_Ada.SelectCommand = SqlCmd;
            lo_Ada.FillSchema(Return_DataTable, SchemaType.Source);
            lo_Ada.Dispose();
            lo_Ada = null;

            ReturnTable = Return_DataTable;
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            lo_Connection.Close();
        }
    }
}

