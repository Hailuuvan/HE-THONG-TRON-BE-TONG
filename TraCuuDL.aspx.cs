using System;
using System.Configuration;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SQL_ALL _sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
        _sql = new SQL_ALL(connectionString);
        //khoi tao truoc moi hien thi
      
    }

    void Hien_thi_giatri_cambien(string Name_Sensor, string StartTime, string EndTime)
    {
        string html1 =
    "<table>" +
        "<tr>" +
            "<th> Tên Cảm Biến </th>" +
            "<th> Giá trị cảm biến </th>" +
            "<th> Thời gian cập nhật </th>" +
        "</tr>";
        string html2 = "";
        DataTable SenSor = _sql.GetSenSor(Name_Sensor, StartTime, EndTime);
        for (int i = 0; i < SenSor.Rows.Count; i++)
        {
            string tencambien = SenSor.Rows[i]["Name"].ToString();
            double giatri = Convert.ToDouble(SenSor.Rows[i]["Value"]);
            DateTime thoigian = Convert.ToDateTime(SenSor.Rows[i]["Time"]);
            html2 +=
            "<tr>" +
            "<td>" + tencambien + "</td>" +
            "<td>" + giatri.ToString() + "</td>" +
            "<td>" + thoigian.ToString() + "</td>" +
            "</tr>";

        }
        string html3 = "</table>";
        Literal_HienThiGiaTriCB.Text = html1 + html2 + html3;
    }
    /* void Hien_thi_giatri_cambien()
     {
         string html1 =
     "<table>" +
         "<tr>" +
             "<th> Tên Cảm Biến </th>" +
             "<th> Giá trị cảm biến </th>" +
             "<th> Thời gian cập nhật </th>" +
         "</tr>";
         string html2 = "";
         DataTable SenSor = _sql.GetSenSor();
         for (int i = 0; i < SenSor.Rows.Count; i++)
         {
             string tencambien = SenSor.Rows[i]["Name"].ToString();
             double giatri = Convert.ToDouble(SenSor.Rows[i]["Value"]);
             DateTime thoigian = Convert.ToDateTime(SenSor.Rows[i]["Time"]);
             html2 +=
             "<tr>" +
             "<td>" + tencambien + "</td>" +
             "<td>" + giatri.ToString() + "</td>" +
             "<td>" + thoigian.ToString() + "</td>" +
             "</tr>";

         }
         string html3 = "</table>";
         Literal_TatCaGiaTriCB.Text = html1 + html2 + html3;
     }*/
    protected void btn_Click(object sender, EventArgs e)
    {
        string NameID = txbName.Text;
        string StartTime = txbStartTime.Text;
        string EndTime = txbEndTime.Text;
        Hien_thi_giatri_cambien(NameID, StartTime, EndTime);

    }
}
