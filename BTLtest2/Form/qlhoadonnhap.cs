using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace BTLtest2
{
    public partial class qlhoadonnhap : Form
    {
        public qlhoadonnhap()
        {
            InitializeComponent();
        }
        DataTable tblCTHDN;
        private void qlhoadonnhap_Load(object sender, EventArgs e)
        {
            function.functionhoadonnhap.Connect();
            LoadComboBoxes();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            txtMahang.ReadOnly = true;
            txtMahoadon.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTennhacungcap.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            mskDienthoai.ReadOnly = true;
            txtTenhang.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtTongtien.Text = "0";
            txtNgaynhap.ReadOnly = true;
            //cboManhanvien.Enabled = false;
            //cboNhacungcap.Enabled=false;

            btnThemsanpham.Enabled = false;


            //CLASS.functionNAM.FillCombo("SELECT MaNhanVien, TenNhanVien FROM tblNhanVien", cboManhanvien, "MaNhanVien", "TenNhanVien");
            //cboManhanvien.SelectedIndex = -1;

            //CLASS.functionNAM.FillCombo("SELECT MaNCC, TenNCC FROM tblNhaCungCap", cboNhacungcap, "MaNCC", "TenNCC");
            //cboNhacungcap.SelectedIndex = -1;


            function.functionhoadonnhap.FillCombo("SELECT SoHDN FROM tblCTHDNhap", cboTimmahoadon, "SoHDN", "SoHDN");
            cboTimmahoadon.SelectedIndex = -1;

            InitializeLocalMaSachCounter();
            // Add event handlers
            cboManhanvien.SelectedIndexChanged += new EventHandler(cboManhanvien_SelectedIndexChanged);
            txtDongia.TextChanged += new EventHandler(txtDongia_TextChanged);
            txtSoluong.TextChanged += new EventHandler(txtSoluong_TextChanged);
        }

        private void LoadComboBoxes()
        {
            // Load data for cboManhanvien
            string str = "SELECT MaNhanVien, TenNhanVien FROM tblNhanVien";
            DataTable dtNhanVien = function.functionhoadonnhap.GetDataToTable(str);
            cboManhanvien.DataSource = dtNhanVien;
            cboManhanvien.DisplayMember = "TenNhanVien";
            cboManhanvien.ValueMember = "MaNhanVien";
            cboManhanvien.SelectedIndex = -1;

            // Load data for cboNhacungcap
            str = "SELECT MaNCC, TenNCC FROM tblNhaCungCap";
            DataTable dtNhaCungCap = function.functionhoadonnhap.GetDataToTable(str);
            cboNhacungcap.DataSource = dtNhaCungCap;
            cboNhacungcap.DisplayMember = "TenNCC";
            cboNhacungcap.ValueMember = "MaNCC";
            cboNhacungcap.SelectedIndex = -1;
        }

        private void Load_DataGridViewChitiet()
        {
            string sql = "SELECT a.MaSach, b.TenSach, a.SoLuongNhap, a.DonGiaNhap, a.ThanhTien, b.MaCode " +
             "FROM tblCTHDNhap AS a " +
             "JOIN tblSach AS b ON a.MaSach = b.MaSach " +
             "WHERE a.SoHDN = N'" + txtMahoadon.Text + "'";


            tblCTHDN = function.functionhoadonnhap.GetDataToTable(sql);
            DataGridViewChitiet.DataSource = tblCTHDN;

            // Cập nhật lại tên cột để phản ánh chính xác dữ liệu
            DataGridViewChitiet.Columns[0].HeaderText = "Mã hàng";
            DataGridViewChitiet.Columns[1].HeaderText = "Tên hàng";
            DataGridViewChitiet.Columns[2].HeaderText = "Số lượng";
            DataGridViewChitiet.Columns[3].HeaderText = "Đơn giá nhập";
            DataGridViewChitiet.Columns[4].HeaderText = "Thành tiền";
            DataGridViewChitiet.Columns[5].HeaderText = "Số code";

            // Cập nhật lại chiều rộng của các cột
            DataGridViewChitiet.Columns[0].Width = 90;
            DataGridViewChitiet.Columns[1].Width = 150;
            DataGridViewChitiet.Columns[2].Width = 90;
            DataGridViewChitiet.Columns[3].Width = 100;
            DataGridViewChitiet.Columns[4].Width = 130;
            DataGridViewChitiet.Columns[5].Width = 130;


            DataGridViewChitiet.AllowUserToAddRows = false;
            DataGridViewChitiet.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_ThongtinHD()
        {
            string str = "SELECT NgayNhap FROM tblHoaDonNhap WHERE SoHDN = N'" + txtMahoadon.Text + "'";
            txtNgaynhap.Text = function.functionhoadonnhap.ConvertDateTime(function.functionhoadonnhap.GetFieldValues(str));

            str = "SELECT h.MaNhanVien, TenNhanVien FROM tblHoaDonNhap h inner join tblNhanVien n on h.MaNhanVien=n.MaNhanVien  WHERE SoHDN = N'" + txtMahoadon.Text + "'";
            DataTable dt1 = function.functionhoadonnhap.GetDataToTable(str);
            if (dt1.Rows.Count > 0)
            {
                DataRow row = dt1.Rows[0];
                cboManhanvien.SelectedValue = row["MaNhanVien"].ToString();
                txtTennhanvien.Text = row["TenNhanVien"].ToString();
            }

            str = "SELECT ncc.MaNCC, ncc.TenNCC, ncc.SoDienThoai, ncc.DiaChi " +
                  "FROM tblHoaDonNhap AS hdn " +
                  "JOIN tblNhaCungCap AS ncc ON hdn.MaNCC = ncc.MaNCC " +
                  "WHERE hdn.SoHDN = N'" + txtMahoadon.Text + "'";

            DataTable dt = function.functionhoadonnhap.GetDataToTable(str);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cboNhacungcap.SelectedValue = row["MaNCC"].ToString();
                txtTennhacungcap.Text = row["TenNCC"].ToString();
                txtDiachi.Text = row["DiaChi"].ToString();
                mskDienthoai.Text = row["SoDienThoai"].ToString();
            }

            str = "SELECT TongTien FROM tblHoaDonNhap WHERE SoHDN = N'" + txtMahoadon.Text + "'";
            txtTongtien.Text = function.functionhoadonnhap.GetFieldValues(str);

            lblTienchu.Text = "Bằng chữ: " + function.functionhoadonnhap.ChuyenSoSangChu(txtTongtien.Text);
        }

        private void cboManhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboManhanvien.SelectedValue != null)
            {
                string selectedMaNhanVien = cboManhanvien.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedMaNhanVien))
                {
                    string query = "SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = N'" + selectedMaNhanVien + "'";
                    string tenNhanVien = function.functionhoadonnhap.GetFieldValues(query);
                    txtTennhanvien.Text = tenNhanVien;
                }
            }
        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {
            UpdateThanhtien();
            UpdateTongtien();
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            UpdateThanhtien();
            UpdateTongtien();
        }

        private void UpdateThanhtien()
        {
            if (decimal.TryParse(txtDongia.Text, out decimal dongia) && int.TryParse(txtSoluong.Text, out int soluong))
            {
                decimal thanhtien = dongia * soluong;
                txtThanhtien.Text = thanhtien.ToString();
            }
            else
            {
                txtThanhtien.Text = "0";
            }
        }

        private void UpdateTongtien()
        {
            decimal tongtien = 0;

            foreach (DataGridViewRow row in DataGridViewChitiet.Rows)
            {
                if (decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString(), out decimal thanhtien))
                {
                    tongtien += thanhtien;
                }
            }

            if (decimal.TryParse(txtThanhtien.Text, out decimal currentThanhtien))
            {
                tongtien += currentThanhtien;
            }

            txtTongtien.Text = tongtien.ToString();
        }


        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalculateTotal();
                e.Handled = true;
            }
        }

        private void CalculateTotal()
        {
            if (int.TryParse(txtSoluong.Text, out int soluong) && decimal.TryParse(txtDongia.Text, out decimal dongia))
            {
                decimal thanhtien = (soluong * dongia);
                txtThanhtien.Text = thanhtien.ToString("0.00");
                CalculateTotalPrice();
            }
            else
            {
                //MessageBox.Show("Vui lòng nhập số lượng và đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculateTotalPrice()
        {
            decimal tongtien = 0;
            foreach (DataRow row in tblCTHDN.Rows)
            {
                tongtien += Convert.ToDecimal(row["Thanhtien"]);
            }
            txtTongtien.Text = tongtien.ToString("0.00");
            lblTienchu.Text = "Bằng chữ: " + function.functionhoadonnhap.ChuyenSoSangChu(txtTongtien.Text);
        }



        private void ResetValues()
        {
            txtMahoadon.Text = "";
            txtNgaynhap.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.SelectedIndex = -1; // Đặt lại comboBox nhân viên
            txtTennhanvien.Clear();
            cboNhacungcap.SelectedIndex = -1;
            txtTennhacungcap.Clear();
            txtDiachi.Clear();
            mskDienthoai.Clear();
            txtMacode.Text = "";
            txtMahang.Text = "";
            txtTongtien.Text = "0";
            lblTienchu.Text = "Bằng chữ: ";
            txtSoluong.Clear();
            txtThanhtien.Clear();
            txtTenhang.Clear();
            txtDongia.Clear();
        }


        //click để xóa 1 sản phẩm
        private void DataGridViewChitiet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                int rowIndex = e.RowIndex;

                string mahang = DataGridViewChitiet.Rows[rowIndex].Cells["MaSach"].Value.ToString();
                double Thanhtien = Convert.ToDouble(DataGridViewChitiet.Rows[rowIndex].Cells["Thanhtien"].Value.ToString());

                DelHangTamThoi(rowIndex);

                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
            }
        }
        private void DelHangTamThoi(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataGridViewChitiet.Rows.Count)
            {
                DataGridViewChitiet.Rows.RemoveAt(rowIndex);
            }
        }

        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            try
            {
                double Tong = Convert.ToDouble(txtTongtien.Text);

                double Tongmoi = Tong - Thanhtien;

                txtTongtien.Text = Tongmoi.ToString();
                lblTienchu.Text = "Bằng chữ: " + function.functionhoadonnhap.ChuyenSoSangChu(Tongmoi.ToString());
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoluong_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }


        private void btnThem_Click_1(object sender, EventArgs e)
        {
            cboManhanvien.Enabled = true;
            cboNhacungcap.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            btnThemsanpham.Enabled = true;
            ResetValues();
            txtMahoadon.Text = function.functionhoadonnhap.CreateKey("HDN");
            Load_DataGridViewChitiet();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cboManhanvien == null || string.IsNullOrEmpty(cboManhanvien.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboManhanvien.Focus();
                    return;
                }

                if (cboNhacungcap.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboNhacungcap.Focus();
                    return;
                }

                // Kiểm tra nếu tblCTHDN không null và có dữ liệu
                if (tblCTHDN == null || tblCTHDN.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm vào đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txtMacode == null || txtMacode.Text == "")
                    {
                        txtMacode.Focus();
                    }
                    else
                        txtSoluong.Focus();
                    return;
                }

                // Thêm thông tin hóa đơn nhập vào bảng tblHoaDonNhap
                string query = $"INSERT INTO tblHoaDonNhap (SoHDN, MaNhanVien, NgayNhap, MaNCC, TongTien) " +
                               $"VALUES (N'{txtMahoadon.Text}', N'{cboManhanvien.SelectedValue}', '{function.functionhoadonnhap.ConvertDateTime(txtNgaynhap.Text)}', " +
                               $"N'{cboNhacungcap.SelectedValue}', {txtTongtien.Text})";
                function.functionhoadonnhap.RunSql(query);

                // Thêm chi tiết hóa đơn nhập vào bảng tblCTHDNhap và cập nhật/insert sản phẩm trong bảng tblSach
                foreach (DataRow row in tblCTHDN.Rows)
                {
                    string maSach = row["MaSach"].ToString();
                    string tenSach = row["TenSach"].ToString();
                    int soLuongNhap = int.Parse(row["SoLuongNhap"].ToString());
                    double donGiaNhap = double.Parse(row["DonGiaNhap"].ToString());
                    double thanhTien = double.Parse(row["ThanhTien"].ToString());
                    double donGiaBan = donGiaNhap * 1.1;
                    string maCode = row["MaCode"].ToString();

                    // Kiểm tra nếu sản phẩm đã tồn tại trong cơ sở dữ liệu
                    string checkQuery = $"SELECT COUNT(*) FROM tblSach WHERE MaSach = N'{maSach}'";
                    int productCount = int.Parse(function.functionhoadonnhap.GetFieldValues(checkQuery));

                    if (productCount > 0)
                    {
                        // Cập nhật số lượng và giá của sản phẩm
                        string updateQuery = $"UPDATE tblSach SET SoLuong = SoLuong + {soLuongNhap}, DonGiaNhap = {donGiaNhap}, DonGiaBan = {donGiaBan} WHERE MaSach = N'{maSach}'";
                        function.functionhoadonnhap.RunSql(updateQuery);
                    }
                    else
                    {
                        // Thêm sản phẩm mới vào bảng tblSach
                        string insertQuery = $"INSERT INTO tblSach (MaSach,TenSach, SoLuong, DonGiaNhap, DonGiaBan,MaCode) " +
                                             $"VALUES (N'{maSach}',N'{tenSach}', {soLuongNhap}, {donGiaNhap}, {donGiaBan},N'{maCode}')";
                        function.functionhoadonnhap.RunSql(insertQuery);
                    }

                    // Thêm chi tiết hóa đơn nhập vào bảng tblCTHDNhap
                    string insertCTHDNhapQuery = $"INSERT INTO tblCTHDNhap (SoHDN, MaSach, SoLuongNhap, DonGiaNhap, ThanhTien) " +
                                                 $"VALUES (N'{txtMahoadon.Text}', N'{maSach}', {soLuongNhap}, {donGiaNhap}, {thanhTien})";
                    function.functionhoadonnhap.RunSql(insertCTHDNhapQuery);
                }

                MessageBox.Show("Đơn hàng đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI and form values
                btnThem.Enabled = true;
                btnThemsanpham.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnIn.Enabled = true;

                ResetValues();
                Load_DataGridViewChitiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboNhacungcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhacungcap.SelectedValue != null)
            {
                string selectedNhacungcap = cboNhacungcap.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(selectedNhacungcap))
                {
                    string query = "SELECT TenNCC, DiaChi, SoDienThoai FROM tblNhaCungCap WHERE MaNCC = N'" + selectedNhacungcap + "'";
                    DataTable dt = function.functionhoadonnhap.GetDataToTable(query);

                    if (dt.Rows.Count > 0)
                    {
                        txtTennhacungcap.Text = dt.Rows[0]["TenNCC"].ToString();
                        txtDiachi.Text = dt.Rows[0]["DiaChi"].ToString();
                        mskDienthoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                    }
                    else
                    {
                        // Nếu không tìm thấy dữ liệu, có thể xóa thông tin hiện tại
                        txtTennhacungcap.Text = string.Empty;
                        txtDiachi.Text = string.Empty;
                        mskDienthoai.Text = string.Empty;
                    }
                }
            }
        }

        private void txtMacode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string maCode = txtMacode.Text.Trim();

                if (!string.IsNullOrEmpty(maCode))
                {
                    try
                    {
                        string query = $"SELECT MaSach, TenSach, MaCode FROM tblSach WHERE MaCode = '{maCode}'";
                        DataTable dt = function.functionhoadonnhap.GetDataToTable(query);

                        if (dt.Rows.Count > 0)
                        {
                            txtMahang.Text = dt.Rows[0]["MaSach"].ToString();
                            txtTenhang.Text = dt.Rows[0]["TenSach"].ToString();
                            txtMacode.Text = dt.Rows[0]["MaCode"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm với mã code này. Vui lòng nhập hàng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtTenhang.ReadOnly = false;
                            txtTenhang.Focus();
                            ResetProductInputs(keepMacode: true);

                            string newMaSach = GenerateNewMaSach();

                            txtMahang.Text = newMaSach;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã code.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private int localMaSachCounter = 0;

        private void InitializeLocalMaSachCounter()
        {
            string query = "SELECT TOP 1 MaSach FROM tblSach ORDER BY CAST(SUBSTRING(MaSach, 2, LEN(MaSach) - 1) AS INT) DESC";
            DataTable dt = function.functionhoadonnhap.GetDataToTable(query);

            if (dt.Rows.Count > 0)
            {
                string currentMaxMaSach = dt.Rows[0]["MaSach"].ToString();
                localMaSachCounter = int.Parse(currentMaxMaSach.Substring(1));
            }
            else
            {
                localMaSachCounter = 0;
            }
        }

        private string GenerateNewMaSach()
        {
            localMaSachCounter++;
            return "S" + localMaSachCounter;
        }

        private void btnThemsanpham_Click(object sender, EventArgs e)
        {
            txtTenhang.ReadOnly = true;


            if (string.IsNullOrEmpty(txtMacode.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMacode.Focus();
                return;
            }


            // Yêu cầu người dùng nhập tên sách
            if (string.IsNullOrEmpty(txtTenhang.Text.Trim()))
            {
                txtTenhang.ReadOnly = false;
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenhang.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSoluong.Text) || !int.TryParse(txtSoluong.Text, out int soluong) || soluong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Focus();
                return;
            }

            // Tính toán thành tiền
            CalculateTotal();

            // Lấy giá trị của mã sản phẩm và mã code
            string maSach = txtMahang.Text.Trim();
            string maCode = txtMacode.Text.Trim();
            int soluongtang = int.Parse(txtSoluong.Text);
            decimal dongia = decimal.Parse(txtDongia.Text);

            // Kiểm tra xem đã có sản phẩm với mã sách hoặc mã code tương tự trong danh sách hay chưa
            bool productExists = false;

            foreach (DataRow row in tblCTHDN.Rows)
            {
                // So sánh với cả MaSach và MaCode
                if (row["MaSach"].ToString() == maSach || row["MaCode"].ToString() == maCode)
                {
                    // Nếu có, cập nhật lại số lượng sản phẩm
                    int existingQuantity = int.Parse(row["SoLuongNhap"].ToString());
                    row["SoLuongNhap"] = existingQuantity + soluongtang;

                    // Tính lại thành tiền
                    row["Thanhtien"] = (existingQuantity + soluongtang) * dongia;
                    productExists = true;
                    break;
                }
            }

            // Nếu không có sản phẩm có mã sách tương tự, thêm sản phẩm mới vào danh sách
            if (!productExists)
            {
                DataRow newRow = tblCTHDN.NewRow();
                newRow["MaSach"] = maSach;
                newRow["TenSach"] = txtTenhang.Text.Trim();
                newRow["SoLuongNhap"] = soluong;
                newRow["DonGiaNhap"] = dongia;
                newRow["Thanhtien"] = soluong * dongia;
                newRow["MaCode"] = maCode; // Assuming MaCode exists in tblCTHDN
                tblCTHDN.Rows.Add(newRow);
            }

            DataGridViewChitiet.DataSource = tblCTHDN;

            CalculateTotalPrice();

            ResetProductInputs();
        }

        private void ResetProductInputs(bool keepMacode = false)
        {
            if (!keepMacode)
            {
                txtMacode.Text = "";
            }
            txtMahang.Text = "";
            txtTenhang.Text = "";
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtThanhtien.Text = "";
        }


        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Đặt lại tất cả các giá trị và trạng thái ban đầu của hóa đơn
                ResetValues();

                // Đặt lại trạng thái của các nút và hộp thoại
                btnThem.Enabled = true;
                btnThemsanpham.Enabled = false;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnIn.Enabled = false;

                // Xóa toàn bộ dữ liệu trong DataGridView
                tblCTHDN.Clear();
                DataGridViewChitiet.DataSource = tblCTHDN;
            }
        }

        private void btnTimhoadon_Click_1(object sender, EventArgs e)
        {
            if (cboTimmahoadon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTimmahoadon.Focus();
                return;
            }
            txtMahoadon.Text = cboTimmahoadon.Text;
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            cboNhacungcap.Enabled = false;
            cboManhanvien.Enabled = false;
            txtMacode.ReadOnly = true;
            txtSoluong.ReadOnly = true;
            txtDongia.ReadOnly = true;
            btnThem.Enabled = true;
            btnThemsanpham.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
            btnIn.Enabled = true;
            cboTimmahoadon.SelectedIndex = -1;
        }

        private void cboTimmahoadon_DropDown(object sender, EventArgs e)
        {
            function.functionhoadonnhap.FillCombo("SELECT SoHDN FROM tblHoaDonNhap", cboTimmahoadon, "SoHDN", "SoHDN");
            cboTimmahoadon.SelectedIndex = -1;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "BOOK STORE";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "12 Chùa Bộc, HVNH";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (03)66764577";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán

            sql = "SELECT a.SoHDN, a.NgayNhap, a.TongTien, b.TenNCC, b.DiaChi, b.SoDienThoai, c.TenNhanVien FROM tblHoaDonNhap AS a, tblNhaCungCap AS b, tblNhanVien AS c WHERE a.SoHDN = N'" + txtMahoadon.Text + "' AND a.MaNCC = b.MaNCC AND a.MaNhanVien =c.MaNhanVien";
            tblThongtinHD = function.functionhoadonnhap.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSach, a.SoLuongNhap, b.DonGiaNhap , a.ThanhTien FROM tblCTHDNhap AS a JOIN tblSach AS b ON a.MaSach = b.MaSach  WHERE   a.SoHDN = N'" + txtMahoadon.Text + "'";
            tblThongtinHang = function.functionhoadonnhap.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng nhập";
            exRange.Range["D11:D11"].Value = "Đơn giá nhập";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + function.functionhoadonnhap.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewChitiet_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                // Lấy chỉ số dòng hiện tại
                int rowIndex = e.RowIndex;

                // Lấy mã sản phẩm và thành tiền của dòng hiện tại
                string mahang = DataGridViewChitiet.Rows[rowIndex].Cells["MaSach"].Value.ToString();
                double Thanhtien = Convert.ToDouble(DataGridViewChitiet.Rows[rowIndex].Cells["Thanhtien"].Value.ToString());

                // Xóa hàng tạm thời khỏi DataGridView
                DelHangTamThoi(rowIndex);

                // Cập nhật lại tổng tiền cho hóa đơn
                DelUpdateTongtien(txtMahoadon.Text, Thanhtien);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMahoadon.Text))
            {
                MessageBox.Show("Bạn phải chọn một hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string soHDN = txtMahoadon.Text;


            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {

                string sql = $"SELECT MaSach, SoLuongNhap FROM tblCTHDNhap WHERE SoHDN = N'{soHDN}'";
                DataTable dt = function.functionhoadonnhap.GetDataToTable(sql);


                foreach (DataRow row in dt.Rows)
                {
                    string maSach = row["MaSach"].ToString();
                    int soLuongNhap = Convert.ToInt32(row["SoLuongNhap"]);
                    sql = $"UPDATE tblSach SET SoLuong = SoLuong - {soLuongNhap} WHERE MaSach = N'{maSach}'";
                    function.functionhoadonnhap.RunSql(sql);
                }

                sql = $"DELETE FROM tblCTHDNhap WHERE SoHDN = N'{soHDN}'";
                function.functionhoadonnhap.RunSqlDel(sql);


                sql = $"DELETE FROM tblHoaDonNhap WHERE SoHDN = N'{soHDN}'";
                function.functionhoadonnhap.RunSqlDel(sql);

                MessageBox.Show("Hóa đơn đã được xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetValues();
                Load_DataGridViewChitiet();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HienThiHoaDon(string maHoaDon)
        {

            LoadComboBoxes();

            int index = cboTimmahoadon.FindStringExact(maHoaDon);

            if (index != -1)
            {
                cboTimmahoadon.SelectedIndex = index;
            }

            txtMahoadon.Text = maHoaDon;
            MessageBox.Show(txtMahoadon.Text);
            Load_ThongtinHD();
            Load_DataGridViewChitiet();
            cboNhacungcap.Enabled = false;
            cboManhanvien.Enabled = false;
            txtMacode.ReadOnly = true;
            txtSoluong.ReadOnly = true;
            txtDongia.ReadOnly = true;
            btnThem.Enabled = true;
            btnThemsanpham.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
<<<<<<< HEAD

        private void btnThemsanpham_Click_1(object sender, EventArgs e)
        {

        }
=======
>>>>>>> 11c05b5075591128da0e21cb778e5a32dd965d84
    }
}
