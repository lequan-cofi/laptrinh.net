namespace BTLtest2
{
    partial class qlymatsach
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoluongmat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMasach = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnBoqua = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtMalanmat = new System.Windows.Forms.TextBox();
            this.dgvKhosach = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhosach)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(584, 152);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 149;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 148;
            this.label3.Text = "Ngày mất";
            // 
            // txtSoluongmat
            // 
            this.txtSoluongmat.Location = new System.Drawing.Point(584, 97);
            this.txtSoluongmat.Name = "txtSoluongmat";
            this.txtSoluongmat.Size = new System.Drawing.Size(200, 26);
            this.txtSoluongmat.TabIndex = 147;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "Số lượng mất";
            // 
            // txtMasach
            // 
            this.txtMasach.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtMasach.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtMasach.FormattingEnabled = true;
            this.txtMasach.Location = new System.Drawing.Point(136, 155);
            this.txtMasach.Name = "txtMasach";
            this.txtMasach.Size = new System.Drawing.Size(194, 28);
            this.txtMasach.TabIndex = 145;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(82, 486);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 35);
            this.btnThem.TabIndex = 144;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(368, 486);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 35);
            this.btnLuu.TabIndex = 143;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(232, 486);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 35);
            this.btnXoa.TabIndex = 142;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnBoqua
            // 
            this.btnBoqua.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBoqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoqua.Location = new System.Drawing.Point(492, 486);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(88, 35);
            this.btnBoqua.TabIndex = 141;
            this.btnBoqua.Text = "Bỏ qua";
            this.btnBoqua.UseVisualStyleBackColor = false;
            this.btnBoqua.Click += new System.EventHandler(this.btnBoqua_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDong.Location = new System.Drawing.Point(639, 486);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(86, 35);
            this.btnDong.TabIndex = 140;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtMalanmat
            // 
            this.txtMalanmat.Location = new System.Drawing.Point(136, 100);
            this.txtMalanmat.Name = "txtMalanmat";
            this.txtMalanmat.Size = new System.Drawing.Size(194, 26);
            this.txtMalanmat.TabIndex = 139;
            // 
            // dgvKhosach
            // 
            this.dgvKhosach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhosach.Location = new System.Drawing.Point(18, 237);
            this.dgvKhosach.Name = "dgvKhosach";
            this.dgvKhosach.RowHeadersWidth = 51;
            this.dgvKhosach.RowTemplate.Height = 24;
            this.dgvKhosach.Size = new System.Drawing.Size(774, 212);
            this.dgvKhosach.TabIndex = 138;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 137;
            this.label7.Text = "Mã lần mất";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 136;
            this.label6.Text = "Mã sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 37);
            this.label1.TabIndex = 135;
            this.label1.Text = "QUẢN LÝ MẤT SÁCH";
            // 
            // qlymatsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 595);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoluongmat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMasach);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnBoqua);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtMalanmat);
            this.Controls.Add(this.dgvKhosach);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "qlymatsach";
            this.Text = "qlymatsach";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhosach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoluongmat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtMasach;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnBoqua;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.TextBox txtMalanmat;
        private System.Windows.Forms.DataGridView dgvKhosach;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}