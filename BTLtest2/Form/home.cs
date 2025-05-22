using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BTLtest2
{
    public partial class home : Form
    {
        private Form activeForm = null;
        private Size formOriginalSize;
        private Rectangle recPnl1;

        public home()
        {
            InitializeComponent();
<<<<<<< HEAD
           
            
=======
            this.Load += Home_Load;
            this.Resize += Home_Resize;

            formOriginalSize = this.Size;
            recPnl1 = new Rectangle(panel1.Location, panel1.Size); // Sửa từ button1.Size
>>>>>>> 64a212e03026b8bd7607b2b034398236d6bc3be2
        }

        private void Home_Load(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void hideSubmenu()
        {
            if (submenubaocao.Visible)
                submenubaocao.Visible = false;
<<<<<<< HEAD
            if (submenuhoadon.Visible == true)
                submenuhoadon.Visible = false;
        }
       
       
=======
            if (submenuhoadon.Visible)
                submenuhoadon.Visible = false;
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            resize_Control(panel1, recPnl1);
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)this.Width / formOriginalSize.Width;
            float yRatio = (float)this.Height / formOriginalSize.Height;

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
>>>>>>> 64a212e03026b8bd7607b2b034398236d6bc3be2

        private void showMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelchillform.Controls.Add(childForm);
            panelchillform.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void bntbaocao_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
<<<<<<< HEAD
            showMenu(submenubaocao);
        }

=======

            showMenu(submenubaocao);
        }

        private void bnthoadon_Click(object sender, EventArgs e)
        {
            showMenu(submenuhoadon);
        }

>>>>>>> 64a212e03026b8bd7607b2b034398236d6bc3be2
        private void bntqlynhanvien_Click(object sender, EventArgs e)
        {
            openChildForm(new quanlynhanvien());
        }

        private void bntqlysach_Click(object sender, EventArgs e)
        {
            openChildForm(new qlykho());
        }

        private void bnt_quanlykhachhang_Click(object sender, EventArgs e)
        {
            openChildForm(new quanlykhachhang());
        }

<<<<<<< HEAD
        private void bntdtcpln_Click(object sender, EventArgs e)
        {
            openChildForm(new doanhthu());
        }

        private void bnt_loinhuan_Click(object sender, EventArgs e)
        {
            openChildForm(new loinhuan());
        }

        private void bntchiphi_Click(object sender, EventArgs e)
        {
            openChildForm(new chiphi());
        }

        private void bntkhachhang_Click(object sender, EventArgs e)
        {
            openChildForm(new khachhang());
        }

        private void bnthanghoa_Click(object sender, EventArgs e)
        {
            openChildForm(new hanghoa());
        }

        private void bnthangtonkho_Click(object sender, EventArgs e)
        {
            openChildForm(new hangtonkho());
        }

        private void bnthoadon_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            showMenu(submenuhoadon);
=======
        private void bnthdnhap_Click(object sender, EventArgs e)
        {
            openChildForm(new qlhoadonnhap());
>>>>>>> 64a212e03026b8bd7607b2b034398236d6bc3be2
        }

        private void bnthdban_Click(object sender, EventArgs e)
        {
            openChildForm(new quanlyhoadonban());
        }

<<<<<<< HEAD
        private void bnthdmua_Click(object sender, EventArgs e)
        {
            openChildForm(new qlhoadonnhap());
        }

        private void bntthanhtoan_Click(object sender, EventArgs e)
        {
            openChildForm(new thanhtoan());
        }
=======
>>>>>>> 64a212e03026b8bd7607b2b034398236d6bc3be2
    }
      
    }
