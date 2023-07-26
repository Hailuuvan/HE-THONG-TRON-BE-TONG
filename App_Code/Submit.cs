using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        string connectionString = "Server=DESKTOP-DELLCUA\\SQLEXPRESS;Database=SCADA_6;User Id=sa;Password=scadanhom7;";

        // Lấy dữ liệu từ form
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Message: ");
        string message = Console.ReadLine();

        // Kết nối đến cơ sở dữ liệu
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Tạo câu lệnh SQL để chèn dữ liệu vào bảng
            string sql = "INSERT INTO Contact (Name, Email, Message) VALUES (@Name, @Email, @Message)";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                // Thêm các tham số
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Message", message);

                // Thực hiện câu lệnh SQL
                command.ExecuteNonQuery();
            }

            // Đóng kết nối
            connection.Close();
        }

        Console.WriteLine("Dữ liệu đã được lưu vào cơ sở dữ liệu.");
        Console.ReadLine();
    }
}
