using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MyWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        SQL _sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
            //_sql = new SQL(connectionString);
            if (!IsPostBack)
            {
                // Kiểm tra xem người dùng đã đăng nhập chưa
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // Nếu đã đăng nhập, chuyển hướng đến trang chính
                    Response.Redirect("~/HomePage.html");
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ người dùng
            string username = txtUsername.Value;
            string password = txtPassword.Value;

            // Kiểm tra thông tin đăng nhập
            if (CheckLogin(username, password))
            {
                // Nếu đúng, tạo phiên đăng nhập và chuyển hướng đến trang chính
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(username), null);
                Response.Redirect("~/HomePage.html");
            }
            else
            {
                // Nếu sai, hiển thị thông báo lỗi
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }

        private bool CheckLogin(string username, string password)
        {
            //Chuỗi kết nối tới cơ sở dữ liệu SQL
            string connectionString = "Data Source=DESKTOP-DELLCUA\\SQLEXPRESS;Initial Catalog=SCADA_6;User ID=sa;Password=scadanhom7";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn SQL
                    string query = "SELECT COUNT(*) FROM NGUOIDUNG WHERE TAIKHOAN = @Username AND MATKHAU = @Password";

                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Thực hiện truy vấn và lấy kết quả
                        int count = (int)command.ExecuteScalar();

                        // Kiểm tra xem có bản ghi nào khớp với thông tin đăng nhập hay không
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                    // Ví dụ: ghi log, hiển thị thông báo lỗi, v.v.
                    Response.Write("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return false;
        }
    }
}