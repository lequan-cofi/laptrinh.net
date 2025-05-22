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
    public partial class qlymatsach : Form
    {
        DataTable tblMatSach;
        private bool isAddingNew = false;
        public qlymatsach()
        {
            InitializeComponent();
        }

        private void qlymatsach_Load(object sender, EventArgs e)
        {
            function.functionqlymatsach.Connect();
            LoadDataGridView();
            // Thiết lập trạng thái ban đầu cho các nút và textbox
            txtMalanmat.Enabled = false;
            txtSoluongmat.Enabled = false; // Ban đầu vô hiệu hóa
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            dateTimePicker1.Value = DateTime.Now; // Đặt giá trị mặc định cho DateTimePicker
            FillMaSachComboBox();
        }

        private void FillMaSachComboBox()
        {
            function.functionqlymatsach.FillCombo("SELECT Masach, Tensach FROM tblSach", txtMasach, "Masach", "Tensach");
            txtMasach.SelectedIndex = -1;
        }

        private void LoadDataGridView()
        {
            string sql = "SELECT MaLanMat, MaSach, SoLuongMat, NgayMat FROM tblMatSach";
            tblMatSach = function.functionqlymatsach.GetDataToTable(sql);
            dgvKhosach.DataSource = tblMatSach;

            // Đặt tiêu đề cột
            dgvKhosach.Columns["MaLanMat"].HeaderText = "Mã lần mất";
            dgvKhosach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvKhosach.Columns["SoLuongMat"].HeaderText = "Số lượng mất";
            dgvKhosach.Columns["NgayMat"].HeaderText = "Ngày mất";

            // Điều chỉnh độ rộng cột
            dgvKhosach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKhosach.AllowUserToAddRows = false;
            dgvKhosach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMalanmat.Text = "";
            txtMasach.SelectedIndex = -1;
            txtSoluongmat.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private string GenerateMaLanMat()
        {
            string sql = "SELECT TOP 1 MaLanMat FROM tblMatSach ORDER BY MaLanMat DESC";
            DataTable dt = function.functionqlymatsach.GetDataToTable(sql);
            if (dt.Rows.Count > 0)
            {
                string lastMa = dt.Rows[0]["MaLanMat"].ToString();
                if (int.TryParse(lastMa.Substring(2), out int number))
                {
                    return "ML" + (number + 1).ToString("D3");
                }
            }
            return "ML001";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMalanmat.Text = GenerateMaLanMat();
            txtMalanmat.Enabled = false;
            txtMasach.Enabled = true;
            txtSoluongmat.Enabled = true;
            txtMasach.Focus();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            isAddingNew = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            ResetValues();
            txtMalanmat.Enabled = false;
            txtMasach.Enabled = false;
            txtSoluongmat.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhosach.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvKhosach.CurrentRow == null)
            {
                MessageBox.Show("Bạn phải chọn một bản ghi để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLanMatToDelete = dgvKhosach.CurrentRow.Cells["MaLanMat"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lần mất sách có mã '{maLanMatToDelete}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = $"DELETE FROM tblMatSach WHERE MaLanMat = '{maLanMatToDelete}'";
                function.functionqlymatsach.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMasach.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasach.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSoluongmat.Text) || !int.TryParse(txtSoluongmat.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng mất phải là một số lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluongmat.Focus();
                return;
            }

            string maLanMat = txtMalanmat.Text;
            string maSach = txtMasach.SelectedValue.ToString();
            DateTime ngayMat = dateTimePicker1.Value;

            string sql = $"INSERT INTO tblMatSach (MaLanMat, MaSach, SoLuongMat, NgayMat) VALUES ('{maLanMat}', '{maSach}', {soLuong}, '{ngayMat:yyyy-MM-dd}')";
            function.functionqlymatsach.RunSql(sql);

            LoadDataGridView();
            ResetValues();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMalanmat.Enabled = false;
            txtMasach.Enabled = false;
            txtSoluongmat.Enabled = false;
            isAddingNew = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhosach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhosach.Rows[e.RowIndex];
                txtMalanmat.Text = row.Cells["MaLanMat"].Value.ToString();
                if (row.Cells["MaSach"].Value != null)
                {
                    txtMasach.SelectedValue = row.Cells["MaSach"].Value.ToString();
                }
                txtSoluongmat.Text = row.Cells["SoLuongMat"].Value.ToString();
                dateTimePicker1.Value = (DateTime)row.Cells["NgayMat"].Value;

                btnXoa.Enabled = true; // Cho phép xóa khi có bản ghi được chọn
            }
        }
    }
}
