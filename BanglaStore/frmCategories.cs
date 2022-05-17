using BanglaStore.BLL;
using BanglaStore.DAL;
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
    public partial class frmCategories : Form
    {
        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        userDAL udal = new userDAL();

        public frmCategories()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
           
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            //Getting ID in Added by field
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            
            c.added_by = usr.id;

            
            bool success = dal.Insert(c);

           
            if (success == true)
            {
                
                MessageBox.Show("New Category Inserted Successfully.");
                Clear();
                
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                
                MessageBox.Show("Failed to Insert New CAtegory.");
            }
        }

        public void Clear()
        {
            txtCategoryID.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Finding the Row Index of the Row Clicked on Data Grid View
            int RowIndex = e.RowIndex;
            txtCategoryID.Text = dgvCategories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCategories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCategories.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            
            DataTable dt = dal.Select();
            dgvCategories.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            c.id = int.Parse(txtCategoryID.Text);
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;
            
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = udal.GetIDFromUsername(loggedUser);
            
            c.added_by = usr.id;

            
            bool success = dal.Update(c);
            
            if (success == true)
            {
                
                MessageBox.Show("Category Updated Successfully");
                Clear();
                
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                
                MessageBox.Show("Failed to Update Category");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get te ID of the Category Which we want to Delete
            c.id = int.Parse(txtCategoryID.Text);

            //Creating Boolean Variable to Delete The CAtegory
            bool success = dal.Delete(c);

            //If the CAtegory id Deleted Successfully then the vaue of success will be true else it will be false
            if (success == true)
            {
                //Category Deleted Successfully
                MessageBox.Show("Category Deleted Successfully");
                Clear();
                //REfreshing DAta Grid View
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
            else
            {
                //FAiled to Delete CAtegory 
                MessageBox.Show("Failed to Delete CAtegory");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the Keywords
            string keywords = txtSearch.Text;

            //Filte the categories based on keywords
            if (keywords != null)
            {
                //Use Searh Method To Display Categoreis
                DataTable dt = dal.Search(keywords);
                dgvCategories.DataSource = dt;
            }
            else
            {
                //Use Select Method to Display All Categories
                DataTable dt = dal.Select();
                dgvCategories.DataSource = dt;
            }
        }
    }
}
