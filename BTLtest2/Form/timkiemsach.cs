using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLtest2
{
    public partial class timkiemsach : Form
    {
        public timkiemsach()
        {
            InitializeComponent();
        }

        private void TimKiemSach_Load(object sender, EventArgs e)
        {
            function.functiontimkiemsach.Connect();
            btnTimlai.Enabled = false;
            function.functiontimkiemsach.FillCombo("select maloaisach, tenloaisach from tblLoaiSach", cboLoaisach, "maloaisach", "tenloaisach");
            cboLoaisach.SelectedIndex = -1;
            function.functiontimkiemsach.FillCombo("select manxb, tennxb from tblNhaXuatBan", cboNxb, "manxb", "tennxb");
            cboNxb.SelectedIndex = -1;
            function.functiontimkiemsach.FillCombo("select mangonngu, tenngonngu from tblNgonNgu", cboNgonngu, "mangonngu", "tenngonngu");
            cboNgonngu.SelectedIndex = -1;
            ResetValues();
        }
        DataTable tblTKS;
        private void ResetValues()
        {
            txtTensach.Text = "";
            cboLoaisach.Text = "";
            cboNxb.Text = "";
            cboNgonngu.Text = "";
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtTensach.Text == "") && (cboNxb.Text == "") && (cboLoaisach.Text == "") && (cboNgonngu.Text == ""))
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select masach, tensach, soluong, dongianhap, dongiaban, maloaisach, manxb, mangonngu from tblSach WHERE 1=1";
            if (txtTensach.Text != "")
                sql = sql + " and tensach Like N'%" + txtTensach.Text + "%'";
            if (cboLoaisach.Text != "")
                sql = sql + " AND maloaisach Like N'%" + cboLoaisach.SelectedValue.ToString() + "%'";
            if (cboNxb.Text != "")
                sql = sql + " AND manxb Like N'%" + cboNxb.SelectedValue.ToString() + "%'";
            if (cboNgonngu.Text != "")
                sql = sql + " AND mangonngu Like N'%" + cboNgonngu.SelectedValue.ToString() + "%'";

            tblTKS = function.functiontimkiemsach.GetDataToTable(sql);
            if (tblTKS.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblTKS.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvTimkiemsach.DataSource = tblTKS;
            ResetValues();
            btnTimkiem.Enabled = false;
            btnTimlai.Enabled = true;
            Load_DataGridView();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimkiemsach.DataSource = null;
            btnTimkiem.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
