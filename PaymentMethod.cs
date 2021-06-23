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
    public partial class PaymentMethod : Form
    {
        public PaymentMethod()
        {
            InitializeComponent();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your order is placed!");
            ShopPage Form2 = new ShopPage();
            Form2.Show();
            this.Hide();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UpgradeSubs Form2 = new UpgradeSubs();
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

        private void PaymentMethod_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }
    }
}
