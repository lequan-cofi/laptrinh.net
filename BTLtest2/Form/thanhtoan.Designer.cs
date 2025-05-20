namespace BTLtest2
{
    partial class thanhtoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picChuyenkhoan = new System.Windows.Forms.PictureBox();
            this.rdoChuyenkhoan = new System.Windows.Forms.RadioButton();
            this.rdoTienmat = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongtien = new System.Windows.Forms.TextBox();
            this.cboMahoadon = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picChuyenkhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // picChuyenkhoan
            // 
            this.picChuyenkhoan.Location = new System.Drawing.Point(302, 372);
            this.picChuyenkhoan.Name = "picChuyenkhoan";
            this.picChuyenkhoan.Size = new System.Drawing.Size(170, 170);
            this.picChuyenkhoan.TabIndex = 24;
            this.picChuyenkhoan.TabStop = false;
            // 
            // rdoChuyenkhoan
            // 
            this.rdoChuyenkhoan.AutoSize = true;
            this.rdoChuyenkhoan.Location = new System.Drawing.Point(26, 448);
            this.rdoChuyenkhoan.Name = "rdoChuyenkhoan";
            this.rdoChuyenkhoan.Size = new System.Drawing.Size(94, 17);
            this.rdoChuyenkhoan.TabIndex = 23;
            this.rdoChuyenkhoan.TabStop = true;
            this.rdoChuyenkhoan.Text = "Chuyển khoản";
            this.rdoChuyenkhoan.UseVisualStyleBackColor = true;
            // 
            // rdoTienmat
            // 
            this.rdoTienmat.AutoSize = true;
            this.rdoTienmat.Location = new System.Drawing.Point(26, 407);
            this.rdoTienmat.Name = "rdoTienmat";
            this.rdoTienmat.Size = new System.Drawing.Size(66, 17);
            this.rdoTienmat.TabIndex = 22;
            this.rdoTienmat.TabStop = true;
            this.rdoTienmat.Text = "Tiền mặt";
            this.rdoTienmat.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "VNĐ";
            // 
            // txtTongtien
            // 
            this.txtTongtien.Location = new System.Drawing.Point(478, 50);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.Size = new System.Drawing.Size(184, 20);
            this.txtTongtien.TabIndex = 20;
            // 
            // cboMahoadon
            // 
            this.cboMahoadon.FormattingEnabled = true;
            this.cboMahoadon.Location = new System.Drawing.Point(130, 50);
            this.cboMahoadon.Name = "cboMahoadon";
            this.cboMahoadon.Size = new System.Drawing.Size(184, 21);
            this.cboMahoadon.TabIndex = 19;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 100);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(744, 246);
            this.dataGridView.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(379, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Phương thức thanh toán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã hóa đơn";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "THANH TOÁN";
            // 
            // thanhtoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 583);
            this.Controls.Add(this.picChuyenkhoan);
            this.Controls.Add(this.rdoChuyenkhoan);
            this.Controls.Add(this.rdoTienmat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTongtien);
            this.Controls.Add(this.cboMahoadon);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "thanhtoan";
            this.Text = "thanhtoan";
            ((System.ComponentModel.ISupportInitialize)(this.picChuyenkhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picChuyenkhoan;
        private System.Windows.Forms.RadioButton rdoChuyenkhoan;
        private System.Windows.Forms.RadioButton rdoTienmat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongtien;
        private System.Windows.Forms.ComboBox cboMahoadon;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}