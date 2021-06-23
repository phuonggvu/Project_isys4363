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

    public partial class Profile : Form
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["Login"];
        DataTable dtData;
        string customer_id;
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txtEmail.Text = ((Login)f).txtEmail.Text;
            ShowData();
            PasswordText();
            ShowSub();
        }
        private void ShowSub()
        {
            string sql = "SELECT * FROM PrjSubs WHERE Customer_id ='" +
                      customer_id + "';";
            Walton_DB.FillDataTable_ViaSql(ref dtData, sql);
            foreach (DataRow dr in dtData.Rows)
            {

                txtSubs.Text = dr[2].ToString();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            MainStart Form2 = new MainStart();
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

        private void ShowData()
        {
            string sql = "SELECT * FROM PrjCustomers WHERE Email ='" +
                     txtEmail.Text + "';";
            Walton_DB.FillDataTable_ViaSql(ref dtData, sql);
            foreach (DataRow dr in dtData.Rows)
            {
                customer_id = dr[0].ToString(); 
                txtFirst.Text = dr[1].ToString();
                txtLast.Text = dr[2].ToString();
                txtDob.Text = dr[5].ToString();
                txtSecureQues.Text = dr[6].ToString();
                txtAns.Text = dr[7].ToString();
                txtAddress.Text = dr[8].ToString();
            }
        }
        private void UpdateInfo()
        {
          

            string sql = "UPDATE PrjCustomers SET Fname ='" + txtFirst.Text + "', Lname = '" + txtLast.Text +
                "', DOB = '" + txtDob.Text + "',  Address ='" + txtAddress.Text +
               "' WHERE Email = '" + txtEmail.Text + "';";

            Walton_DB.ExecSqlString(sql);
        }
      
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateInfo();
                MessageBox.Show("You successfully modified your information!!");
                ShowData();
            }
            catch (Exception ex)
            {
                //show error
                MessageBox.Show("You did not fill out the form correctly\n" + ex);
            }
        }

        private void NewPass()
        {
            string sql = "UPDATE PrjCustomers SET Pass ='" + txtNewPass.Text + "' WHERE Email = '" + txtEmail.Text + "' AND Pass ='"
                + txtPass.Text+"';";

            Walton_DB.ExecSqlString(sql);
        }
        private void PasswordText()
        {

            // The password character is an asterisk.
            txtPass.PasswordChar = '●';
            txtRePass.PasswordChar = '●';
            txtNewPass.PasswordChar = '●';
            //ᴥ•●

        }
        private void btnNewPass_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text == "" || txtRePass.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("You must fill in all the fields!!");
            }
            else
            {
                if (txtNewPass.Text == txtRePass.Text)
                {
                    try
                    {

                        NewPass();
                        MessageBox.Show("You successfully modified your Password!!");
                        txtPass.Clear();
                        txtNewPass.Clear();
                        txtRePass.Clear();

                    }
                    catch (Exception ex)
                    {
                        //show error
                        MessageBox.Show("You did not fill out the form correctly\n" + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Your passwords don't match \nPlease try again!");
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MainStart Form2 = new MainStart();
            Form2.Show();
            this.Hide();
        }

        private void btnUpgrade_Click(object sender, EventArgs e)
        {

            UpgradeSubs Form2 = new UpgradeSubs();
            Form2.Show();
            this.Hide();
        }

        private void btnWishlist_Click(object sender, EventArgs e)
        {
            WishList Form2 = new WishList();
            Form2.Show();
            this.Hide();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderPage Form2 = new OrderPage();
            Form2.Show();
            this.Hide();
        }
    }
}
