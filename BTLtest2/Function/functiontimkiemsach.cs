using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLtest2.function
{
    internal class functiontimkiemsach
    {
        public static SqlConnection Conn;     //Khai báo đối tượng kết nối
        public static string connString;      //Khai báo biến chứa chuỗi kết nối
        public static void Connect()
        {
            connString = "Data Source=LAPTOP-87GE02HR;Initial Catalog=laptrinh.net;Integrated Security=True;Trust Server Certificate=True";
            Conn = new SqlConnection();                 //Cấp phát đối tượng
            Conn.ConnectionString = connString;         //Kết nối
            Conn.Open();                                 //Mở kết nối
        }
        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();    //Đóng kết nối
                Conn.Dispose();      //Giải phóng tài nguyên
                Conn = null;
            }
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;      // Truong gia tri
            cbo.DisplayMember = ten;    // Truong hien thi
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table.Rows.Count > 0;
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            try
            {
                cmd.ExecuteNonQuery();      // Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
            }
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                cmd.Dispose();
            }
        }
    }
}
