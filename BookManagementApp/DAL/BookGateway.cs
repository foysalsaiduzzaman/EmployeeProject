using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementApp.Model;

namespace BookManagementApp.DAL
{
    public class BookGateway
    {
        private string conString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
        private SqlConnection con;
        private SqlCommand cmd;
        private string query;

        public BookGateway()
        {
            con = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public int InsertBook(Book book)
        {
            query = "INSERT into Book values('"+book.Name+"','"+book.ISBN+"','"+book.Author+"','"+book.CategoryId+"')";
            cmd.CommandText = query;
            int rowsAffected = 0;
            if (con.State!=ConnectionState.Open)
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rowsAffected;
        }

        public Book GetBookByISBN(string isbn)
        {
            query = "Select * from Book where isbn = '" + isbn + "'";
            cmd.CommandText = query;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Book book = null;
            while (reader.Read())
            {
                if (book == null)
                {
                    book = new Book();
                }
                book.Id = int.Parse(reader["id"].ToString());
                book.Name = reader["name"].ToString();
                book.ISBN = reader["isbn"].ToString();
                book.Author = reader["author"].ToString();
                book.CategoryId = int.Parse(reader["categoryid"].ToString());
            }
            reader.Close();
            con.Close();
            return book;
        }

        public List<BookCategoryView> GetAllBookCategories()
        {
            List<BookCategoryView> bookCategoryViews = new List<BookCategoryView>();
            query = "SELECT * from BookCategory";
            cmd.CommandText = query;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookCategoryView bookCategoryView = new BookCategoryView();
                bookCategoryView.Id = int.Parse(reader["id"].ToString());
                bookCategoryView.Name = reader["name"].ToString();
                bookCategoryView.ISBN = reader["isbn"].ToString();
                bookCategoryView.Author = reader["author"].ToString();
                bookCategoryView.CategoryId = int.Parse(reader["categoryid"].ToString());
                bookCategoryView.CategoryName = reader["CategoryName"].ToString();
                bookCategoryViews.Add(bookCategoryView);
            }
            reader.Close();
            con.Close();
            return bookCategoryViews;
        }

        public List<BookCategoryView> GetBookBySearchCriteria(string name, string isbn)
        {
            query = "SELECT * from BookCategory";
            if (name != "" && isbn != "")
            {
                query = "SELECT * from BookCategory where name = '" + name + "' and isbn = '" + isbn + "'";
            }
            else if (name != "")
            {
                query = "SELECT * from BookCategory where name = '" + name + "'";
            }
            else if(isbn != "")
            {
                query = "SELECT * from BookCategory where isbn = '" + isbn + "'";
            }
            cmd.CommandText = query;
            con.Open();
            List<BookCategoryView> bookCategoryViews = new List<BookCategoryView>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookCategoryView bookCategoryView = new BookCategoryView();
                bookCategoryView.Id = int.Parse(reader["id"].ToString());
                bookCategoryView.Name = reader["name"].ToString();
                bookCategoryView.ISBN = reader["isbn"].ToString();
                bookCategoryView.Author = reader["author"].ToString();
                bookCategoryView.CategoryId =reader["categoryid"].ToString()=="" ? (int?)null : int.Parse(reader["categoryid"].ToString());
                bookCategoryView.CategoryName = reader["CategoryName"].ToString();
                bookCategoryViews.Add(bookCategoryView);
            }
            reader.Close();
            con.Close();

            return bookCategoryViews;
        }

        public BookCategoryView GetBookById(int bookId)
        {
            query = "SELECT * from BookCategory where id = '" + bookId + "'";
            cmd.CommandText = query;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            BookCategoryView book = null;
            while (reader.Read())
            {
                if (book == null)
                {
                    book = new BookCategoryView();
                }
                book.Id = int.Parse(reader["id"].ToString());
                book.Name = reader["name"].ToString();
                book.ISBN = reader["isbn"].ToString();
                book.Author = reader["author"].ToString();
                book.CategoryId = int.Parse(reader["categoryid"].ToString());
                book.CategoryName = reader["CategoryName"].ToString();
            }
            reader.Close();
            con.Close();
            return book;
        }



        public int UpdateBook(Book book)
        {
            query = "UPDATE Book SET name = '" + book.Name + "', isbn = '" + book.ISBN + "', author = '" + book.Author +
                    "' where id = '"+book.Id+"'";
            cmd.CommandText = query;
            con .Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            
            con.Close();
            return rowsAffected;
        }

        public int DeleteBook(Book book)
        {
            query = "DELETE from Book where id = '" + book.Id + "'";
            cmd.CommandText = query;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
