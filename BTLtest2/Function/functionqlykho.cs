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
    internal class functionqlykho
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
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = function.functionqlykho.Conn;
            Mydata.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, function.functionqlykho.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter Mydata = new SqlDataAdapter(sql, function.functionqlykho.Conn);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void RunSql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = function.functionqlykho.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
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
            cmd.Connection = function.functionqlykho.Conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Dữ liệu đang được dùng, không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
    }
}
