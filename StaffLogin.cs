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
    public partial class StaffLogin : Form
    {
        public StaffLogin()
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

        private void StaffLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.AcceptButton = btnLogin;
            PasswordText();

        }
        private void PasswordText()
        {

            // The password character is an asterisk.
            txtPass.PasswordChar = '●';
            //ᴥ•●

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            StaffReports Form2 = new StaffReports();
            Form2.Show();
            this.Hide();
        }
    }
}
