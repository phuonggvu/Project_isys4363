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
    public partial class SignUp : Form
    {
        DataTable dtQues = null;

        
        public SignUp()
        {
            InitializeComponent();
        }
        private void SignUp_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            SecurityQues();
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
            Login Form2 = new Login();
            Form2.Show();
            this.Hide();
        }
        private void SecurityQues()
        {
            string sql = "SELECT * FROM PrjSecureQues";
            Walton_DB.FillDataTable_ViaSql(ref dtQues, sql);
            foreach (DataRow dr in dtQues.Rows)
            {

                cmbQues.Items.Add(dr[1].ToString());

            }
        }
        private void PasswordText()
        {

            // The password character is an asterisk.
            txtPass.PasswordChar = '●';
            txtRePass.PasswordChar = '●';

            //ᴥ•●

        }
        private void NewCustomer()
        {
            string sql = "insert into PrjCustomers(Fname,Lname,Email,Pass,DOB,SecureQ,AnsQ) VALUES ('" +
                txtFirst.Text + "','" + txtLast.Text + "','" + txtEmail.Text + "','" +
                txtPass.Text + "','" + txtDob.Text + "','" + cmbQues.Text + "','" + txtAns.Text + "')";
            Walton_DB.ExecSqlString(sql);
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirst.Text)&& !string.IsNullOrWhiteSpace(txtLast.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text) 
                && !string.IsNullOrWhiteSpace(txtPass.Text) && !string.IsNullOrWhiteSpace(txtRePass.Text) && !string.IsNullOrWhiteSpace(cmbQues.Text)
                && !string.IsNullOrWhiteSpace(txtAns.Text))
            {
                try
                {

                    if (txtPass.Text == txtRePass.Text)
                    {
                        NewCustomer();
                        MessageBox.Show("Welcome to Southern Drip!");
                        DialogResult dialogResult = MessageBox.Show("Subscribe for limited edition merchs and mystery boxes?", "Subscription", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Subs Form2 = new Subs();
                            Form2.Show();
                            this.Hide();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Login Form2 = new Login();
                            Form2.Show();
                            this.Hide();
                        }
                    }


                    else
                    {
                        MessageBox.Show("Your passwords don't match each other.\nPlease try again!");
                    }
                }
                catch (Exception ex)
                {
                    //show error
                    MessageBox.Show("Please try again!\n" + ex);
                }
            }
            
            else
            {
                MessageBox.Show("You must fill all required fields.\nPlease try again!");
                
            }

        }
    }
}
