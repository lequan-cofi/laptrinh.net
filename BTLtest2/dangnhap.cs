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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form2
            home home = new home();

            // Khi Form2 đóng, mình sẽ hiện lại Form1
            home.FormClosed += (s, args) => this.Show();

            // Hiện Form2
            home.Show();

            // Ẩn Form1 (nếu không muốn ẩn thì bỏ dòng này)
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
