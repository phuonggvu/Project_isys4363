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
    public partial class Login : Form
    {
        DataTable dtLogin = null;
        
        
        string email;
        string pass;
        public Login()
        {
            InitializeComponent();
        }
       

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.AcceptButton = btnLogin;
            PasswordText();

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
            MainStart Form2 = new MainStart();
            Form2.Show();
            this.Hide();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            VerifyEmail Form2 = new VerifyEmail();
            Form2.Show();
            this.Hide();
        }
        private void PasswordText()
        {

            // The password character is an asterisk.
            txtPass.PasswordChar = '●';
            //ᴥ•●

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ( txtEmail != null && txtPass != null)
            {
                try
                {
                    string sql = "SELECT Email,Pass FROM PrjCustomers WHERE Email ='" +
                       txtEmail.Text + "' AND Pass = '" + txtPass.Text + "';";
                    Walton_DB.FillDataTable_ViaSql(ref dtLogin, sql);
                    foreach (DataRow dr in dtLogin.Rows)
                    {

                        email = dr[0].ToString();
                        pass = dr[1].ToString();

                    }
                    //if the username or password is not found, the system will ask user to try again
                    if (email == null || pass == null)
                    {
                        MessageBox.Show("Please input your username and password correctly!");

                    }
                    else
                    {
                        MessageBox.Show("You're in!");
                        Profile Form2 = new Profile();
                        Form2.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    //show error
                    MessageBox.Show("You did not fill out the form correctly\n" + ex);
                }
            }
            else
            {
                MessageBox.Show("Please input your username and password correctly!");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignUp Form2 = new SignUp();
            Form2.Show();
            this.Hide();
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            StaffLogin Form2 = new StaffLogin();
            Form2.Show();
            this.Hide();
        }
    }
}
