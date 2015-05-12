using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookManagementApp.BLL;
using BookManagementApp.Model;

namespace BookManagementApp.UI
{
    public partial class CategoryEntryUI : Form
    {
        public CategoryEntryUI()
        {
            InitializeComponent();
        }

        private CategoryManager categoryManager = new CategoryManager();
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryTextBox.Text != "")
            {
                string categoryName = categoryTextBox.Text;
                Category aCategory = new Category();
                aCategory.Name = categoryName;
                bool isCategoryExists = categoryManager.GetCategoryByName(categoryName);
                if (isCategoryExists)
                {
                    MessageBox.Show("Category already exists!");
                }
                else
                {
                    bool isCategorySaved = categoryManager.SaveCategory(aCategory);
                    MessageBox.Show("Category Saved Successfully!");
                    categoryTextBox.Text = "";
                    categoryTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Category!");
            }

        }
    }
}
