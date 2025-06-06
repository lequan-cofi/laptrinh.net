﻿using System;
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
    public partial class quanlynhacungcap : Form
    {
        public quanlynhacungcap()
        {
            InitializeComponent();
        }

        private void quanlynhacungcap_Load(object sender, EventArgs e)
        {
            function.functionnhacungcap.Connect();
            txtMancc.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
        }
        DataTable tblNCC;
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNCC, TenNCC, Diachi, Sodienthoai FROM tblNhacungcap";
            tblNCC = functionnhacungcap.GetDataToTable(sql);
            DataGridView.DataSource = tblNCC;
            DataGridView.Columns[0].HeaderText = "Mã NCC";
            DataGridView.Columns[1].HeaderText = "Tên NCC";
            DataGridView.Columns[2].HeaderText = "Địa chỉ";
            DataGridView.Columns[3].HeaderText = "Điện thoại";
            DataGridView.Columns[0].Width = 110;
            DataGridView.Columns[1].Width = 200;
            DataGridView.Columns[2].Width = 150;
            DataGridView.Columns[3].Width = 150;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMancc.Enabled = true;
            txtMancc.Focus();
        }
        private void ResetValues()
        {
            txtMancc.Text = "";
            txtTenncc.Text = "";
            txtDiachi.Text = "";
            txtSdt.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMancc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                return;
            }
            if (txtTenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenncc.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }

            if (txtSdt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }

            string cleanedPhoneNumber = StripNonNumeric(txtSdt.Text); //Loại bỏ tất cả các ký tự không phải là chữ số

            if (cleanedPhoneNumber.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại phải đủ 10 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }
            string StripNonNumeric(string input)
            {
                return new string(input.Where(c => char.IsDigit(c)).ToArray()); //lọc ra các ký tự trong chuỗi input mà là chữ số
            }

            sql = "SELECT MaNCC FROM tblNhacungcap WHERE MaNCC=N'" + txtMancc.Text.Trim() + "'";
            if (functionnhacungcap.CheckKey(sql))
            {
                MessageBox.Show("Mã NCC này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMancc.Focus();
                txtMancc.Text = "";
                return;
            }
            sql = "INSERT INTO tblNhacungcap(MaNCC,TenNCC,Diachi,Sodienthoai) VALUES (N'" + txtMancc.Text.Trim() + "',N'" + txtTenncc.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + cleanedPhoneNumber + "')";
            functionnhacungcap.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMancc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NCC", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenncc.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtSdt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }

            string cleanedPhoneNumber = StripNonNumeric(txtSdt.Text);
            if (cleanedPhoneNumber.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Số điện thoại phải đủ 10 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }
            string StripNonNumeric(string input)
            {
                return new string(input.Where(c => char.IsDigit(c)).ToArray());
            }
            sql = "UPDATE tblNhacungcap SET  TenNCC=N'" + txtTenncc.Text.Trim().ToString()
                  + "',Diachi=N'" + txtDiachi.Text.Trim().ToString() + "',Sodienthoai='" +
                cleanedPhoneNumber + "' WHERE MaNCC=N'" + txtMancc.Text + "'";
            functionnhacungcap.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMancc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhacungcap WHERE MaNCC=N'" + txtMancc.Text + "'";
                functionnhacungcap.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMancc.Enabled = false;

        }

        private void DataGridView_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMancc.Focus();
                return;
            }
            if (tblNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMancc.Text = DataGridView.CurrentRow.Cells["mancc"].Value.ToString();
            txtTenncc.Text = DataGridView.CurrentRow.Cells["tenncc"].Value.ToString();
            txtSdt.Text = DataGridView.CurrentRow.Cells["sodienthoai"].Value.ToString();
            txtDiachi.Text = DataGridView.CurrentRow.Cells["diachi"].Value.ToString();
            btnDong.Enabled = true;


        }
    
    }
}
