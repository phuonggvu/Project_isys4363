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
    public partial class VerifyEmail : Form
    {
        DataTable dtEmail;
        public string customer_id;
        public VerifyEmail()
        {
            InitializeComponent();
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

        private void VerifyEmail_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnVerify;
            this.CenterToScreen();

        }
        private void FindEmail()
        {
            string sql = "SELECT Customer_id, Email FROM PrjCustomers WHERE Email ='" +
                     txtEmail.Text + "';";
            Walton_DB.FillDataTable_ViaSql(ref dtEmail, sql);
            foreach (DataRow dr in dtEmail.Rows)
            {
                customer_id= dr[0].ToString();
                txtEmail.Text = dr[1].ToString();
            }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text != null)
            {
                try
                {
                    FindEmail();
                    if (customer_id == null)
                    {
                        MessageBox.Show("This email does not exist in our system.\nTry again!");
                    }
                    else
                    {
                        SecurityQuestion Form2 = new SecurityQuestion();
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
               
            


        }

       
    }
}
