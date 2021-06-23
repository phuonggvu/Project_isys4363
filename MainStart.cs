using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_isys4263
{
    public partial class MainStart : Form
    {
        public MainStart()
        {
            InitializeComponent();
   
        }

        private void MainStart_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            Login Form2 = new Login();
            Form2.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactPage Form2 = new ContactPage();
            Form2.Show();
            this.Hide();
        }

        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopPage Form2 = new ShopPage();
            Form2.Show();
            this.Hide();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            Cart Form2 = new Cart();
            Form2.Show();
            this.Hide();
        }
    }
}
