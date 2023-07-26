using System;
using System.Configuration;
using System.Data.SqlClient;
namespace MyWebApp
{
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string name = Request.Form["Name"];
                string email = Request.Form["Email"];
                string message = Request.Form["Message"];
            
                SaveDataToDatabase(name, email, message);
                

                Response.Redirect("HomePage.html");
            }
        }

        private void SaveDataToDatabase(string name, string email, string message)
        {
            string connectionString = "Data Source=DESKTOP-DELLCUA\\SQLEXPRESS;Initial Catalog=SCADA_6;User ID=sa;Password=scadanhom7";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "INSERT INTO Contact (Name, Email, Message, Time) VALUES (@Name, @Email, @Message, @Time)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Message", message);
                        command.Parameters.AddWithValue("@Time", DateTime.Now);


                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                    // Ví dụ: ghi log, hiển thị thông báo lỗi, v.v.
                    Response.Write("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

    }
}
