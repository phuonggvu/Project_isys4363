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
    public partial class OrderPage : Form
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Profile Form2 = new Profile();
            Form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainStart Form2 = new MainStart();
            Form2.Show();
            this.Hide();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OrderPage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnPage Form2 = new ReturnPage();
            Form2.Show();
            this.Hide();
        }

        private void btnTrack_Click(object sender, EventArgs e)
        {
            TrackingPage Form2 = new TrackingPage();
            Form2.Show();
            this.Hide();
        }
    }
}
