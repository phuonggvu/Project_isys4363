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
    public partial class ProductDetail : Form
    {
        public ProductDetail()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShopPage Form2 = new ShopPage();
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

        private void ProductDetail_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        private void btnWishlist_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You added the item to your wishlist!\nDo you want to go to wishlist?", "Wishlist", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                WishList Form2 = new WishList();
                Form2.Show();
                this.Hide();
            }
           
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You added the item to your shopping cart!\nDo you want to go to shopping cart?", "Cart", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cart Form2 = new Cart();
                Form2.Show();
                this.Hide();
            }
        }
    }
}
