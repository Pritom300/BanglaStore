using BanglaStore.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanglaStore
{
    public partial class frmUserDashboard : Form
    {
        //Set a public static method to specify whether the form is purchase or sales
        public static string transactionType;

        public frmUserDashboard()
        {
            InitializeComponent();
        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = frmLogin.loggedIn;
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionType = "Purchase";
            frmPurchaseAndSales purchase = new frmPurchaseAndSales();
            purchase.Show();
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust deaCust = new frmDeaCust();
            deaCust.Show();
        }

        private void salesFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set the value to transacionType method to sales
            transactionType = "Sales";
            frmPurchaseAndSales sales = new frmPurchaseAndSales();
            sales.Show();
        }
    }
}
