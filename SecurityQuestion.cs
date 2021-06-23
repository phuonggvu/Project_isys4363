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
    public partial class SecurityQuestion : Form
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["VerifyEmail"];
        string customer_id;
        string correction;

        DataTable dtQues;
        DataTable dtAns;
        public SecurityQuestion()
        {
            InitializeComponent();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            VerifyEmail Form2 = new VerifyEmail();
            Form2.Show();
            this.Hide();
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainStart Form2 = new MainStart();
            Form2.Show();
            this.Hide();
        }
        private void SecurityQuestion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            customer_id = ((VerifyEmail)f).customer_id;
            CatchQuestion();
            this.AcceptButton = btnContinue;

            this.ActiveControl = txtAns; 
        }

        private void CatchQuestion()
        {
            string sql = "SELECT SecureQ FROM PrjCustomers WHERE customer_id ='" +
                   customer_id + "';";
            Walton_DB.FillDataTable_ViaSql(ref dtQues, sql);
            foreach (DataRow dr in dtQues.Rows)
            {
                txtQues.Text = dr[0].ToString();
            }
        }
        private void LookupAns()
        {
            string sql = "Select COUNT(Customer_id) From PrjCustomers where Customer_id ='" + customer_id 
                + "' AND AnsQ ='" + txtAns.Text + "' Group by Customer_id ";
            Walton_DB.FillDataTable_ViaSql(ref dtAns, sql);
            foreach (DataRow dr in dtAns.Rows)
            {
                correction = dr[0].ToString();
            }
        }

        private void btnContinue_Click_1(object sender, EventArgs e)
        {
            if (txtAns.Text != null)
            {
                try
                {
                    LookupAns();
                    if (correction != "1")
                    {
                        MessageBox.Show("Your answer is incorrect.\nTry again!");
                    }
                    else
                    {
                        MessageBox.Show("Your answer is correct!");

                        NewPass Form2 = new NewPass();
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
