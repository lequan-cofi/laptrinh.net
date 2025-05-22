namespace BTLtest2
{
    partial class timkiemsach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timkiemsach));
            this.txtMasach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimlai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimkiem = new System.Windows.Forms.Button();
            this.cboNgonngu = new System.Windows.Forms.ComboBox();
            this.cboNxb = new System.Windows.Forms.ComboBox();
            this.cboLoaisach = new System.Windows.Forms.ComboBox();
            this.txtTensach = new System.Windows.Forms.TextBox();
            this.dgvTimkiemsach = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimkiemsach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimkiemsach)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasach
            // 
            this.txtMasach.Location = new System.Drawing.Point(370, 163);
            this.txtMasach.Name = "txtMasach";
            this.txtMasach.Size = new System.Drawing.Size(176, 26);
            this.txtMasach.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "Mã sách";
            // 
            // btnTimlai
            // 
            this.btnTimlai.BackColor = System.Drawing.SystemColors.Window;
            this.btnTimlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimlai.Image = ((System.Drawing.Image)(resources.GetObject("btnTimlai.Image")));
            this.btnTimlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimlai.Location = new System.Drawing.Point(526, 560);
            this.btnTimlai.Name = "btnTimlai";
            this.btnTimlai.Size = new System.Drawing.Size(100, 37);
            this.btnTimlai.TabIndex = 70;
            this.btnTimlai.Text = "Tìm lại";
            this.btnTimlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimlai.UseVisualStyleBackColor = false;
            this.btnTimlai.Click += new System.EventHandler(this.btnTimlai_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(684, 560);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(94, 37);
            this.btnDong.TabIndex = 69;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimkiem.Image")));
            this.btnTimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimkiem.Location = new System.Drawing.Point(386, 560);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(76, 37);
            this.btnTimkiem.TabIndex = 68;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimkiem.UseVisualStyleBackColor = false;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // cboNgonngu
            // 
            this.cboNgonngu.FormattingEnabled = true;
            this.cboNgonngu.Location = new System.Drawing.Point(711, 206);
            this.cboNgonngu.Name = "cboNgonngu";
            this.cboNgonngu.Size = new System.Drawing.Size(164, 28);
            this.cboNgonngu.TabIndex = 67;
            // 
            // cboNxb
            // 
            this.cboNxb.FormattingEnabled = true;
            this.cboNxb.Location = new System.Drawing.Point(711, 160);
            this.cboNxb.Name = "cboNxb";
            this.cboNxb.Size = new System.Drawing.Size(164, 28);
            this.cboNxb.TabIndex = 66;
            // 
            // cboLoaisach
            // 
            this.cboLoaisach.FormattingEnabled = true;
            this.cboLoaisach.Location = new System.Drawing.Point(370, 254);
            this.cboLoaisach.Name = "cboLoaisach";
            this.cboLoaisach.Size = new System.Drawing.Size(176, 28);
            this.cboLoaisach.TabIndex = 65;
            // 
            // txtTensach
            // 
            this.txtTensach.Location = new System.Drawing.Point(370, 206);
            this.txtTensach.Name = "txtTensach";
            this.txtTensach.Size = new System.Drawing.Size(176, 26);
            this.txtTensach.TabIndex = 64;
            // 
            // dgvTimkiemsach
            // 
            this.dgvTimkiemsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimkiemsach.Location = new System.Drawing.Point(268, 314);
            this.dgvTimkiemsach.Name = "dgvTimkiemsach";
            this.dgvTimkiemsach.RowHeadersWidth = 62;
            this.dgvTimkiemsach.Size = new System.Drawing.Size(668, 229);
            this.dgvTimkiemsach.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Ngôn ngữ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(627, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 61;
            this.label4.Text = "NXB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "Loại sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Tên sách";
            // 
            // lblTimkiemsach
            // 
            this.lblTimkiemsach.AutoSize = true;
            this.lblTimkiemsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTimkiemsach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTimkiemsach.Location = new System.Drawing.Point(501, 97);
            this.lblTimkiemsach.Name = "lblTimkiemsach";
            this.lblTimkiemsach.Size = new System.Drawing.Size(267, 37);
            this.lblTimkiemsach.TabIndex = 58;
            this.lblTimkiemsach.Text = "TÌM KIẾM SÁCH";
            // 
            // timkiemsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.txtMasach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimlai);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTimkiem);
            this.Controls.Add(this.cboNgonngu);
            this.Controls.Add(this.cboNxb);
            this.Controls.Add(this.cboLoaisach);
            this.Controls.Add(this.txtTensach);
            this.Controls.Add(this.dgvTimkiemsach);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTimkiemsach);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "timkiemsach";
            this.Text = "timkiemsach";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimkiemsach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMasach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimlai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.ComboBox cboNgonngu;
        private System.Windows.Forms.ComboBox cboNxb;
        private System.Windows.Forms.ComboBox cboLoaisach;
        private System.Windows.Forms.TextBox txtTensach;
        private System.Windows.Forms.DataGridView dgvTimkiemsach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTimkiemsach;
    }
}