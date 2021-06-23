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
    public partial class StaffReports : Form
    {
        public StaffReports()
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
            StaffLogin Form2 = new StaffLogin();
            Form2.Show();
            this.Hide();
        }

        private void StaffReports_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

        }

        private void btnSelectCus_Click(object sender, EventArgs e)
        {
            btnDeleteCus.Enabled = true;
            btnUpdateCus.Enabled = true;

        }

        private void btnUpdateCus_Click(object sender, EventArgs e)
        {
            pnlCustomers.Visible = true;
            pnlSelect.Visible = false;
        }

        private void btnBackfromCus_Click(object sender, EventArgs e)
        {
            pnlCustomers.Visible = false;
            pnlSelect.Visible = true;
        }

        private void btnBackfromNew_Click(object sender, EventArgs e)
        {
            pnlNewInv.Visible = false;
            pnlSelect.Visible = true;
        }

        private void btnAddInv_Click(object sender, EventArgs e)
        {
            pnlNewInv.Visible = true;
            pnlSelect.Visible = false;
        }

        private void btnSelectInv_Click(object sender, EventArgs e)
        {
            btnUpdInv.Enabled = true;
            btnDelInv.Enabled = true;
        }

        private void btnBackfromUpdInv_Click(object sender, EventArgs e)
        {
            pnlUpdateInv.Visible = false;
            pnlSelect.Visible = true;
        }

        private void btnUpdInv_Click(object sender, EventArgs e)
        {
            pnlUpdateInv.Visible = true;
            pnlSelect.Visible = false;
        }
    }
}
