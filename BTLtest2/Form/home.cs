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
       
        private void home_Load(object sender, EventArgs e)
        {
            hideSubmenu();
        }
        public home()
        {
            InitializeComponent();
           
            
        }
        private void hideSubmenu()
        {
            if (submenubaocao.Visible == true)
                submenubaocao.Visible = false;
            if (submenuhoadon.Visible == true)
                submenuhoadon.Visible = false;
        }
       
       

        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void panelchillform_Paint(object sender, PaintEventArgs e)
        {

        }
       
       
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelchillform.Controls.Add(ChildForm);
            panelchillform.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }


        private void bntbaocao_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            showMenu(submenubaocao);
        }

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
        }

        private void bnthdban_Click(object sender, EventArgs e)
        {
            openChildForm(new quanlyhoadonban());
        }

        private void bnthdmua_Click(object sender, EventArgs e)
        {
            openChildForm(new qlhoadonnhap());
        }

        private void bntthanhtoan_Click(object sender, EventArgs e)
        {
            openChildForm(new thanhtoan());
        }
    }
      
    }
