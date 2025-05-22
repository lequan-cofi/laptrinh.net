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
    internal class functionqlymatsach
    {
        public static SqlConnection Conn;
        public static string connString;

        public static void Connect()
        {
            connString = "Data Source=LAPTOP-87GE02HR;Initial Catalog=laptrinh.net;Integrated Security=True;Trust Server Certificate=True";
            Conn = new SqlConnection();
            Conn.ConnectionString = connString;
            Conn.Open();
        }

        public static void Disconnect()
        {
            if (Conn != null && Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        public static string GetFieldValues(string sql)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetValue(0).ToString();
            }
            reader.Close();
            return result;
        }

        public static bool CheckKey(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, Conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count > 0;
        }

        public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
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
                MessageBox.Show("Dữ liệu đang được sử dụng, không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
        }
    }
}
