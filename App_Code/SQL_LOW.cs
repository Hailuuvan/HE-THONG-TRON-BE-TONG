using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SQL
/// </summary>
public class SQL_LOW
{
    public string connectionString; // chuỗi kết nối đến CSDL
    public SQL_LOW(string connectionString)
    {
        // TODO: Add constructor logic here
        // Tham chiếu giá trị connectionString
        this.connectionString = connectionString;
    }
    //Lay du lieu trong database
    public DataTable GetSenSor()
    {
        string strSQL = "select * from Data_Low";
        return GetData(strSQL, connectionString);
    }
    /*
    public DataTable GetSenSor(string Name_Sensor, string StartTime, string EndTime)
    {
        string strSQL = "select * from Data_Table where Name = N'" + Name_Sensor + "' " +
                        "and Time > convert(datetime, N'" + StartTime + "', 103) " +
                        "and Time < convert(datetime, N'" + EndTime + "', 103)";
        return GetData(strSQL, connectionString);
    }*/
    public System.Data.DataTable GetData(string selectCommand, string connectionString)
    {
        try
        {
            // Tạo đối tượng SqlDataAdapter với câu lệnh truy vấn và chuỗi kết nối.
            //Create a new data adapter based on the specified query.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            // Create a command builder to generate SQL update insert, and delete
            // delete commands based on selectectCommand. There are used to
            // update the database.
            // Tạo đối tượng SqlCommandBuilder từ SqlDataAdapter
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            // Populate a new data table and bind it to the BindingSource.
            // Tạo đối tượng DataTable để lưu trữ dữ liệu
            System.Data.DataTable table = new System.Data.DataTable();

            // Lấy dữ liệu từ cơ sở dữ liệu và điền vào bảng dữ liệu
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


