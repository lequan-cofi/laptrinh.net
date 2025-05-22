using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTLtest2.function;

namespace BTLtest2
{
    public partial class qlykho : Form
    {
        public qlykho()
        {
            InitializeComponent();
        }
        DataTable tblSach;

        private void qlykho_Load(object sender, EventArgs e)
        {
            function.functionqlykho.Connect();
            txtMasach.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.ReadOnly = true;

            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            string sql = "SELECT Masach, Tensach, Soluong, Dongianhap, Dongiaban, Maloaisach, MaTacgia, MaNXB, MaLinhvuc, MaNgonngu, Anh, Sotrang FROM tblSach";

            // Fill ComboBoxes
            function.functionqlykho.FillCombo("SELECT Maloaisach, Tenloaisach FROM tblLoaisach", cboMaloaisach, "Maloaisach", "Tenloaisach");
            cboMaloaisach.SelectedIndex = -1;

            function.functionqlykho.FillCombo("SELECT MaNXB, TenNXB FROM tblNhaxuatban", cboMaNXB, "MaNXB", "TenNXB");
            cboMaNXB.SelectedIndex = -1;

            function.functionqlykho.FillCombo("SELECT Matacgia, Tentacgia FROM tblTacgia", cboMatacgia, "Matacgia", "Tentacgia");
            cboMatacgia.SelectedIndex = -1;

            function.functionqlykho.FillCombo("SELECT Malinhvuc, Tenlinhvuc FROM tblLinhvuc", cboMalinhvuc, "Malinhvuc", "Tenlinhvuc");
            cboMalinhvuc.SelectedIndex = -1;

            function.functionqlykho.FillCombo("SELECT Mangonngu, Tenngonngu FROM tblNgonngu", cboMangonngu, "Mangonngu", "Tenngonngu");
            cboMangonngu.SelectedIndex = -1;

            // Load data to DataGridView
            tblSach = function.functionqlykho.GetDataToTable(sql);
            dgvKhosach.DataSource = tblSach;

            // Đặt tiêu đề cột
            dgvKhosach.Columns["Masach"].HeaderText = "Mã sách";
            dgvKhosach.Columns["Tensach"].HeaderText = "Tên sách";
            dgvKhosach.Columns["Soluong"].HeaderText = "Số lượng";
            dgvKhosach.Columns["Dongianhap"].HeaderText = "Đơn giá nhập";
            dgvKhosach.Columns["Dongiaban"].HeaderText = "Đơn giá bán";
            dgvKhosach.Columns["Maloaisach"].HeaderText = "Mã loại sách";
            dgvKhosach.Columns["MaTacgia"].HeaderText = "Mã tác giả";
            dgvKhosach.Columns["MaNXB"].HeaderText = "Mã NXB";
            dgvKhosach.Columns["MaLinhvuc"].HeaderText = "Mã lĩnh vực";
            dgvKhosach.Columns["MaNgonngu"].HeaderText = "Mã ngôn ngữ";
            dgvKhosach.Columns["Anh"].HeaderText = "Ảnh";
            dgvKhosach.Columns["Sotrang"].HeaderText = "Số trang";

            // Đặt độ rộng cột
            dgvKhosach.Columns["Masach"].Width = 50;
            dgvKhosach.Columns["Tensach"].Width = 200;
            dgvKhosach.Columns["Soluong"].Width = 50;
            dgvKhosach.Columns["Dongianhap"].Width = 100;
            dgvKhosach.Columns["Dongiaban"].Width = 100;
            dgvKhosach.Columns["Maloaisach"].Width = 80;
            dgvKhosach.Columns["MaTacgia"].Width = 80;
            dgvKhosach.Columns["MaNXB"].Width = 80;
            dgvKhosach.Columns["MaLinhvuc"].Width = 80;
            dgvKhosach.Columns["MaNgonngu"].Width = 80;
            dgvKhosach.Columns["Anh"].Width = 150;
            dgvKhosach.Columns["Sotrang"].Width = 70;

            dgvKhosach.AllowUserToAddRows = false;
            dgvKhosach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMasach.Text = "";
            txtTensach.Text = "";
            cboMaloaisach.SelectedIndex = -1;
            cboMatacgia.SelectedIndex = -1;
            cboMaNXB.SelectedIndex = -1;
            cboMalinhvuc.SelectedIndex = -1;
            cboMangonngu.SelectedIndex = -1;
            txtSoluong.Text = "0";
            txtDongianhap.Text = "0";
            txtDongiaban.Text = "0";
            txtAnh.Text = "";
            txtSotrang.Text = "";
            picAnh.Image = null;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMasach.Text = GetNextBookID(); // Set the next book ID
            txtMasach.Enabled = false; // Ensure it's not editable
            txtTensach.Focus();
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.ReadOnly = false;
        }

            private string GetNextBookID()
        {
            string sql = "SELECT TOP 1 Masach FROM tblSach ORDER BY CAST(SUBSTRING(Masach, 2, LEN(Masach)-1) AS INT) DESC";
            DataTable dt = function.functionqlykho.GetDataToTable(sql);
            if (dt.Rows.Count > 0)
            {
                string currentMaxID = dt.Rows[0]["Masach"].ToString();
                int nextIDNumber = int.Parse(currentMaxID.Substring(1)) + 1;
                return "S" + nextIDNumber;
            }
            else
            {
                return "S1";
            }
        }
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            ResetValues();
            txtMasach.Enabled = false;
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.ReadOnly = true;
        }



        private void btnTim_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasach.Text != "")
                sql = "SELECT Masach, Tensach, Soluong, Dongianhap, Dongiaban, Maloaisach, MaNXB FROM tblSach WHERE Masach =N'" + txtMasach.Text + "'";
            else
                sql = "SELECT Masach, Tensach, Soluong, Dongianhap, Dongiaban, Maloaisach, MaNXB FROM tblSach WHERE Tensach LIKE N'%" + txtTensach.Text + "%'";
            tblSach = function.functionqlykho.GetDataToTable(sql);
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có sách này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvKhosach.DataSource = tblSach;
            ResetValues();
        }




        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("CSDL chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTensach.Text == "")
            {
                MessageBox.Show("Phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }
            if (cboMaloaisach.Text == "")
            {
                MessageBox.Show("Phải chọn loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloaisach.Focus();
                return;
            }
            if (cboMaNXB.Text == "")
            {
                MessageBox.Show("Phải chọn nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaNXB.Focus();
                return;
            }
            if (txtDongiaban.Text == "")
            {
                MessageBox.Show("Phải nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongiaban.Focus();
                return;
            }
            if (txtSoluong.Text == "")
            {
                MessageBox.Show("Phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtDongianhap.Text == "")
            {
                MessageBox.Show("Phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
                return;
            }
            if (txtAnh.Text == "")
            {
                MessageBox.Show("Phải chọn ảnh minh họa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            string sql;
            sql = "UPDATE tblSach SET Tensach=N'" + txtTensach.Text.Trim() + "',Maloaisach=N'" + cboMaloaisach.SelectedValue.ToString() + "', MaTacgia=N'" + cboMatacgia.SelectedValue.ToString() + "', MaNXB=N'" + cboMaNXB.SelectedValue.ToString() + "', MaLinhvuc=N'" + cboMalinhvuc.SelectedValue.ToString() + "', MaNgonngu=N'" + cboMangonngu.SelectedValue.ToString() + "', Soluong=N'" + txtSoluong.Text.Trim() + "',Dongianhap=N'" + txtDongianhap.Text.Trim() + "',Dongiaban=N'" + txtDongiaban.Text.Trim() + "',Anh=N'" + txtAnh.Text.Trim() + "', Sotrang=N'" + txtSotrang.Text.Trim() + "' where Masach=N'" + txtMasach.Text.Trim() + "'"; function.functionqlykho.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTensach.Focus();
                return;
            }
            if (cboMaloaisach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn loại sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaloaisach.Focus();
                return;
            }
            if (txtSoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }
            if (txtDongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongianhap.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Phải chọn ảnh minh họa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAnh.Focus();
                return;
            }
            double Dongianhap = Convert.ToDouble(txtDongianhap.Text);
            double Dongiaban = Dongianhap * 1.1;
            txtDongiaban.Text = Dongiaban.ToString();
            sql = "SELECT Masach FROM tblSach where Masach =N'" + txtMasach.Text.Trim() + "'";
            if (function.functionqlykho.CheckKey(sql))
            {
                MessageBox.Show("Mã sách này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMasach.Text = GetNextBookID(); // Get the next book ID if the current one is already in use
                txtMasach.Focus();
                return;
            }
            sql = "INSERT INTO tblSach(Masach,Tensach,Soluong,Dongianhap,Dongiaban,Maloaisach,Manxb,Anh,Matacgia,Malinhvuc,Mangonngu,Sotrang) values(N'" + txtMasach.Text.Trim() + "',N'" + txtTensach.Text.Trim() + "',N'" + txtSoluong.Text.Trim() + "',N'" + txtDongianhap.Text.Trim() + "',N'" + txtDongiaban.Text.Trim() + "',N'" + cboMaloaisach.SelectedValue.ToString() + "',N'" + cboMaNXB.SelectedValue.ToString() + "',N'" + txtAnh.Text.Trim() + "', N'" + cboMatacgia.SelectedValue.ToString() + "', N'" + cboMalinhvuc.SelectedValue.ToString() + "', N'" + cboMangonngu.SelectedValue.ToString() + "', N'" + txtSotrang.Text.Trim() + "')"; function.functionqlykho.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMasach.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("CSDL chưa có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblSach WHERE Masach=N'" + txtMasach.Text.Trim() + "'";
                function.functionqlykho.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
                btnBoqua.Enabled = false;
            }
        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "PNG(*.png)|*.png|JPEG(*.jpeg)|*.jpeg|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dlgOpen.FilterIndex = 1;
            dlgOpen.Title = "Chọn ảnh để hiển thị";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picAnh.Image = Image.FromFile(dlgOpen.FileName);
                    txtAnh.Text = dlgOpen.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDongianhap_TextChanged(object sender, EventArgs e)
        {
            double Dongianhap;
            if (txtDongianhap.Text != "")
            {
                Dongianhap = Convert.ToDouble(txtDongianhap.Text);
            }
            else
            {
                Dongianhap = 0;
            }
            double Dongiaban = Dongianhap * 1.1;
            txtDongiaban.Text = Dongiaban.ToString();
        }

        private void txtDongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvKhosach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMasach.Focus();
                return;
            }
            if (tblSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Loaisach, NXB;
            txtMasach.Text = dgvKhosach.CurrentRow.Cells["Masach"].Value.ToString();
            txtTensach.Text = dgvKhosach.CurrentRow.Cells["Tensach"].Value.ToString();
            Loaisach = dgvKhosach.CurrentRow.Cells["Maloaisach"].Value.ToString();
            cboMaloaisach.Text = function.functionqlykho.GetFieldValues("SELECT Tenloaisach FROM tblLoaisach WHERE Maloaisach =N'" + Loaisach + "'");
            NXB = dgvKhosach.CurrentRow.Cells["MaNXB"].Value.ToString();
            cboMaNXB.Text = function.functionqlykho.GetFieldValues("SELECT TenNXB FROM tblNhaXuatBan where MaNXB =N'" + NXB + "'");
            txtSoluong.Text = dgvKhosach.CurrentRow.Cells["Soluong"].Value.ToString();
            txtDongiaban.Text = dgvKhosach.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            txtDongianhap.Text = dgvKhosach.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtAnh.Text = function.functionqlykho.GetFieldValues("SELECT Anh FROM tblSach where Masach =N'" + txtMasach.Text.Trim() + "'");

            string imagePath = txtAnh.Text;

            try
            {
                if (File.Exists(imagePath))
                {
                    picAnh.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại. Vui lòng kiểm tra lại đường dẫn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnBoqua.Enabled = true;
        }

        private void btnBoqua_Click_1(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMasach.Enabled = false;
        }
    }
}
