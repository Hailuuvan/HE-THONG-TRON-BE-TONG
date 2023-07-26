using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DataAccount
{
    public String ConnectionString;
    public DataAccount(String ConnectionString)
    {
        this.ConnectionString = ConnectionString;
    }
    public DataTable CheckAccount(String TaiKhoan, String MatKhau)
    {
        string strSQL = "select * from NGUOIDUNG where TAIKHOAN = '" + TaiKhoan + "' AND MATKHAU = '" + MatKhau + "'";
        return GetData(strSQL, ConnectionString);
    }
    public System.Data.DataTable GetData(string selectCommand, string connectionString)
    {
        try
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

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