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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bntqlynhanvien_Click(object sender, EventArgs e)
        {

        }
        private Form activeForm = null;

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
            openChildForm(new baocao());
        }
    }
}
