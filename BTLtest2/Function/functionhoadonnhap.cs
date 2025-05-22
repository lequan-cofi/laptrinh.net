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
    internal class functionhoadonnhap
    {
        public static SqlConnection Conn;  // Khai báo đối tượng kết nối
        public static string connString;   // Khai báo biến chứa chuỗi kết nối
        public static void Connect()
        {
            connString = "Data Source=DESKTOP-MF91SU2;Initial Catalog=BOOKSTORE;Integrated Security=True";
            //connString = "Data Source=ADMIN\\MSSQLSERVER03;Initial Catalog=BOOKSTORE;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            Conn = new SqlConnection();         		// Cấp phát đối tượng
            Conn.ConnectionString = connString; 		// Kết nối
            Conn.Open();                                // Mở kết nối
        }
        public static void Disconnect()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();   	// Đóng kết nối
                Conn.Dispose();     // Giải phóng tài nguyên
                Conn = null;
            }
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd;		                // Khai báo đối tượng SqlCommand
            cmd = new SqlCommand();	         // Khởi tạo đối tượng
            cmd.Connection = functionhoadonnhap.Conn;	  // Gán kết nối
            cmd.CommandText = sql;			  // Gán câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();		  // Thực hiện câu lệnh SQL
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }

        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = functionhoadonnhap.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }



        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, functionhoadonnhap.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;

            cbo.ValueMember = ma;    // Field for value
            cbo.DisplayMember = ma;  // Field to display
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, functionhoadonnhap.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }

        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, functionhoadonnhap.Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }

        // Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string formattedDateTime = DateTime.Now.ToString("ddMMyyHHmmss");
            key = key + formattedDateTime;
            return key;
        }



        public static bool IsDate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) &&
                (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) &&
                (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }

        public static string ConvertDateTime(string d)
        {
            string[] parts = d.Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }

        public static string ChuyenSoSangChu(string sNumber)
        {
            // Tách phần nguyên từ chuỗi đầu vào
            string[] parts = sNumber.Split('.');
            string integerPart = parts[0];

            int mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            integerPart = integerPart.Replace(",", "");
            mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            int mLen = integerPart.Length; // không cần trừ 1 vì không phải là vòng lặp từ 0
            for (int i = 0; i < mLen; i++)
            {
                mDigit = Convert.ToInt32(integerPart.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i + 1) // Chữ số cuối cùng không cần xét tiếp
                    break;
                switch ((mLen - i - 1) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        break;
                    default:
                        switch ((mLen - i - 1) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }

            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1) + " đồng";
            return mTemp;

        }
        //Đăng nhập
        public static bool ValidateUser(string username, string password, out string employeeId)
        {
            employeeId = string.Empty;
            string query = "SELECT MaNhanVien FROM tbltaikhoan WHERE TenTaiKhoan = @username AND MatKhau = @password";
            using (SqlCommand cmd = new SqlCommand(query, Conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    employeeId = reader["MaNhanVien"].ToString();
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
        }
    }
}
