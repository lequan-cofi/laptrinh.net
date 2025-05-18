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
            this.Resize += home_Resiz;
            formOriginalSize = this.Size;
            recPnl1 = new Rectangle(panel1.Location, button1.Size);
            
        }
        private void hideSubmenu()
        {
            if (submenubaocao.Visible == true)
                submenubaocao.Visible = false;
        }
        private void home_Resiz(object sender, EventArgs e)
        {
            resize_Control(panel1, recPnl1);
        }
        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

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
            showMenu(submenubaocao);
        }

        
    }
      
    }
