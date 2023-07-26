using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SQL
/// </summary>
public class SQL
{
    public string connectionString;
    public SQL(string connectionString)
    {
        this.connectionString = connectionString;   
    }
    //Lay du lieu trong database
    public DataTable GetSenSor()
    {
        string strSQL = "select * from Data_Table";
        return GetData(strSQL, connectionString);
    }
    /*
    public DataTable GetSenSor(string Name_Sensor,string StartTime ,string EndTime)
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
            //Create a new data adapter based on the specified query.
            // Tạo một SqlDataAdapter mới dựa trên truy vấn được chỉ định.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            // Create a command builder to generate SQL update insert, and delete
            // delete commands based on selectectCommand. There are used to
            // update the database.
            // Tạo SqlCommandBuilder để tạo các câu lệnh insert, update và delete dựa trên SqlDataAdapter.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            // Tạo một DataTable mới để lưu trữ dữ liệu.
            System.Data.DataTable table = new System.Data.DataTable();

            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Đổ dữ liệu vào DataTable từ SqlDataAdapter.
            dataAdapter.Fill(table);

            return table;
        }
        catch (Exception ex)
        {
            // Xử lý ngoại lệ nếu có lỗi xảy ra.
            throw ex;
        }
    }
}


