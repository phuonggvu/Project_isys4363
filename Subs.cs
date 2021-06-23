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
    public partial class Subs : Form
    {
        System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["SignUp"];

        DataTable dtGetIdSU;

        string emailFromSignUp;
        string Customer_idSU;

        public Subs()
        {
            InitializeComponent();
        }

        private void Subs_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            emailFromSignUp = ((SignUp)f).txtEmail.Text;
            GetIdFromSignUp();
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
        private void GetIdFromSignUp()
        {
            string sql = "SELECT * FROM PrjCustomers WHERE Email ='" +
                    emailFromSignUp + "';";
            Walton_DB.FillDataTable_ViaSql(ref dtGetIdSU, sql);
            foreach (DataRow dr in dtGetIdSU.Rows)
            {
                Customer_idSU = dr[0].ToString();
            }
        }
       
        private void Subscribe()
        {
            
                string sql;
                if (radMonthly.Checked == true)
                {
                    sql = "insert into PrjSubs(Customer_id,Subscription) values ('" + Customer_idSU + "','Monthly')";
                    Walton_DB.ExecSqlString(sql);
                }
                else if (radYearly.Checked == true)
                {
                    sql = "insert into PrjSubs(Customer_id,Subscription) values ('" + Customer_idSU + "','Yearly')";
                    Walton_DB.ExecSqlString(sql);
                }
           

        }

        private void btnSubs_Click(object sender, EventArgs e)
        {
            try
            {
                Subscribe();
                MessageBox.Show("Please proceed to checkout for the subscription!");
                PaymentMethod Form2 = new PaymentMethod();
                Form2.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                //show error
                MessageBox.Show("You did not fill out the form correctly\n" + ex);
            }
        }
    }
}
