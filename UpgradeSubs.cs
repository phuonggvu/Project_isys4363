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
    public partial class UpgradeSubs : Form
    {
        public UpgradeSubs()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void btnSubs_Click(object sender, EventArgs e)
        {
            PaymentMethod Form2 = new PaymentMethod();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Profile Form2 = new Profile();
            Form2.Show();
            this.Hide();
        }
    }
}
