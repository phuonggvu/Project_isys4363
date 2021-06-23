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
    public partial class NewPass : Form
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["VerifyEmail"];
        string customer_id;
        
        public NewPass()
        {
            InitializeComponent();
        }
        private void NewPass_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            customer_id = ((VerifyEmail)f).customer_id;
        }
       

        private void btnBack_Click(object sender, EventArgs e)
        {
            SecurityQuestion Form2 = new SecurityQuestion();
            Form2.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainStart Form2 = new MainStart();
            Form2.Show();
            this.Hide();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == txtRePass.Text)
            {
                try
                {
                    CreateNewPass();
                    MessageBox.Show("You successfully changed your password!!");
                    Login Form2 = new Login();
                    Form2.Show();
                    this.Hide();
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

        private void CreateNewPass()
        {
            string sql = "UPDATE PrjCustomers SET Pass ='" + txtPass.Text +
                "' WHERE Customer_id = '" + customer_id + "';";

            Walton_DB.ExecSqlString(sql);
        }
    }
}
