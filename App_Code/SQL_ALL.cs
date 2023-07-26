using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SQL
/// </summary>
public class SQL_ALL
{
    public string connectionString;
    public SQL_ALL(string connectionString)
    {
        //
        // TODO: Add constructor logic here
        //
        this.connectionString = connectionString;
    }
    //Lay du lieu trong database
    /*public DataTable GetSenSor()
    {
        string strSQL = "SELECT Name, Value, Time FROM Data_Table UNION SELECT Name, Value, Time FROM Data_Low;";
        return GetData(strSQL, connectionString);
    }

    public DataTable GetSenSor(string Name_Sensor, string StartTime, string EndTime)
    {
        string strSQL = "SELECT * FROM DATA_TABLE where Name = N'" + Name_Sensor + "' " +
                        "and Time > convert(datetime, N'" + StartTime + "', 103) " +
                        "and Time < convert(datetime, N'" + EndTime + "', 103)";
        // Truy xuất dữ liệu từ bảng data_low
        strSQL += "; SELECT * FROM DATA_LOW WHERE Name = N'" + Name_Sensor + "' " +
                  "AND Time > CONVERT(datetime, N'" + StartTime + "', 103) " +
                  "AND Time < CONVERT(datetime, N'" + EndTime + "', 103)";
        return GetData(strSQL, connectionString);
    }*/
    // Hiển thị
    public DataTable GetSenSor()
    {
        string strSQL = "SELECT Name, Value, Time FROM Data_Table UNION SELECT Name, Value, Time FROM Data_Low";
        return GetData(strSQL, connectionString);
    }
    // Tra cứu
    public DataTable GetSenSor(string Name_Sensor, string StartTime, string EndTime)
    {
        string strSQL = "SELECT Name, Value, Time FROM Data_Table WHERE Name = N'" + Name_Sensor + "' " +
                        "AND Time > CONVERT(datetime, N'" + StartTime + "', 103) " +
                        "AND Time < CONVERT(datetime, N'" + EndTime + "', 103)" +
                        "UNION " +
                        "SELECT Name, Value, Time FROM Data_Low WHERE Name = N'" + Name_Sensor + "' " +
                        "AND Time > CONVERT(datetime, N'" + StartTime + "', 103) " +
                        "AND Time < CONVERT(datetime, N'" + EndTime + "', 103)";
        return GetData(strSQL, connectionString);
    }

    public System.Data.DataTable GetData(string selectCommand, string connectionString)
    {
        try
        {
            //Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            // Create a command builder to generate SQL update insert, and delete
            // delete commands based on selectectCommand. There are used to
            // update the database.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            System.Data.DataTable table = new System.Data.DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;

            dataAdapter.Fill(table);

            return table;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}


