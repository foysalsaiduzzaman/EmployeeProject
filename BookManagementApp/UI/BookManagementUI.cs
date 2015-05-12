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

namespace BookManagementApp
{
    public partial class BookManagementUI : Form
    {
        private BookManager manager = new BookManager();
        private CategoryManager categoryManager = new CategoryManager();
        public BookManagementUI()
        {
            InitializeComponent();
        }

        private int bookId = 0;
        private void saveButton_Click(object sender, EventArgs e)
        {
           
            if (nameTextBox.Text != "" && isbnTextBox.Text != "" && authorTextBox.Text != "" &&
                (int) categoryComboBox.SelectedValue > 0)
            {
                int categoryId = int.Parse(categoryComboBox.SelectedValue.ToString());
                string name = nameTextBox.Text;
                string isbn = isbnTextBox.Text;
                string author = authorTextBox.Text;
                Book book = new Book();
                book.CategoryId = categoryId;
                book.Name = name;
                book.ISBN = isbn;
                book.Author = author;
                book.Id = bookId;
                bool isISBNExists = manager.GetBookByISBN(isbn);
                if (isISBNExists)
                {
                    MessageBox.Show("ISBN already exists!");
                }
                else
                {
                    bool isSaved = manager.SaveBook(book);
                    if (isSaved)
                    {
                        MessageBox.Show("Book Saved Successfully!");
                        LoadAllBookCategory();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Oops! Could not save!");
                    }

                }
            }
            else
            {
                MessageBox.Show("All fields are to be filled!!");
            }


        }

        private void ClearTextBoxes()
        {
            nameTextBox.Text = "";
            isbnTextBox.Text = "";
            authorTextBox.Text = "";
            categoryComboBox.SelectedValue = "";
            categoryComboBox.Text = "";
            categoryComboBox.Focus();
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && isbnTextBox.Text != "" && authorTextBox.Text != "")
            {
                string name = nameTextBox.Text;
                string isbn = isbnTextBox.Text;
                string author = authorTextBox.Text;
                Book book = new Book();
                book.Id = this.bookId;
                book.Name = name;
                book.ISBN = isbn;
                book.Author = author;
                bool isUpdated = manager.UpdateBook(book);
                if (isUpdated)
                {
                    MessageBox.Show("Book Updated Successfully!");
                    LoadAllBookCategory();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("Update Failed!!");
                }
            }
            else
            {
                MessageBox.Show("Select Book to Update!!");
            }
        } 
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && isbnTextBox.Text != "" && authorTextBox.Text != "")
            {
                DialogResult dr = MessageBox.Show("Do you want to delete book?", "Confirm",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    string name = nameTextBox.Text;
                    string isbn = isbnTextBox.Text;
                    string author = authorTextBox.Text;
                    Book book = new Book();
                    book.Id = this.bookId;
                    book.Name = name;
                    book.ISBN = isbn;
                    book.Author = author;
                    bool isDeleted = manager.DeleteBook(book);
                    if (isDeleted)
                    {
                        MessageBox.Show("Book Deleted Successfully!");
                        ClearTextBoxes();
                        LoadAllBookCategory();
                    }
                    else
                    {
                        MessageBox.Show("Could not delete!!");
                    }
                }
               

            }
            else
            {
                MessageBox.Show("Select Book to Delete!");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string name = nameSearchTextBox.Text;
            string isbn = isbnSearchTextBox.Text;
            List<BookCategoryView> bookCategoryViews = manager.GetBookBySearchCriteria(name, isbn);
            LoadListViewByBookCategory(bookCategoryViews);
        }

        private void booksListView_DoubleClick(object sender, EventArgs e)
        {
            categoryComboBox.SelectedValue = "";
            if (booksListView.SelectedItems.Count > 0)
            {
                categoryComboBox.SelectedValue = "";
                //categoryComboBox.SelectedText = "";
                categoryComboBox.Text = "";
                ListViewItem firstSelectedItem = booksListView.SelectedItems[0];
                BookCategoryView taggedbook= (BookCategoryView)firstSelectedItem.Tag;
                int bookId = taggedbook.Id;
                BookCategoryView abook = manager.GetBookById(bookId);
                nameTextBox.Text = abook.Name;
                isbnTextBox.Text = abook.ISBN;
                authorTextBox.Text = abook.Author;
                categoryComboBox.SelectedText = abook.CategoryName;
                this.bookId = bookId;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            categoryComboBox.SelectedValue = null;
            LoadCategoryComboBox();
            LoadAllBookCategory();
        }

        private void LoadCategoryComboBox()
        {
            List<Category> categories = categoryManager.GetAllCategories();
            categoryComboBox.DisplayMember = "name";
            categoryComboBox.ValueMember = "id";
            categoryComboBox.DataSource = null;
            categoryComboBox.DataSource = categories;
        }

        private void LoadAllBookCategory()
        {
            List<BookCategoryView> bookCategoryViews = manager.LoadAllBookCategories();
            LoadListViewByBookCategory(bookCategoryViews);
        }

        private void LoadListViewByBook(List<Book> books)
        {
            booksListView.Items.Clear();
            foreach (var book in books)
            {
                ListViewItem item = new ListViewItem(book.Id.ToString());
                item.SubItems.Add(book.Name);
                item.SubItems.Add(book.ISBN);
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.CategoryId.ToString());
                item.Tag = book;
                booksListView.Items.Add(item);
            }
        }
        private void LoadListViewByBookCategory(List<BookCategoryView> bookCategoryViews)
        {
            booksListView.Items.Clear();
            foreach (var bookCategoryView in bookCategoryViews)
            {
                ListViewItem item = new ListViewItem(bookCategoryView.Id.ToString());
                item.SubItems.Add(bookCategoryView.Name);
                item.SubItems.Add(bookCategoryView.ISBN);
                item.SubItems.Add(bookCategoryView.Author);
                item.SubItems.Add(bookCategoryView.CategoryName);
                item.Tag = bookCategoryView;
                booksListView.Items.Add(item);
            }
        }

    }
}
