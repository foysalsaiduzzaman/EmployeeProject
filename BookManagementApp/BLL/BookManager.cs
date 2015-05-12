using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementApp.DAL;
using BookManagementApp.Model;

namespace BookManagementApp.BLL
{
    public class BookManager
    {
        private BookGateway gateway = new BookGateway();
        public bool GetBookByISBN(string isbn)
        {
            Book book = gateway.GetBookByISBN(isbn);
            if (book!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveBook(Book book)
        {
            return   gateway.InsertBook(book) >0;
        }


        public List<BookCategoryView> LoadAllBookCategories()
        {
            return gateway.GetAllBookCategories();
        }

        public List<BookCategoryView> GetBookBySearchCriteria(string name, string isbn)
        {
            return gateway.GetBookBySearchCriteria(name, isbn);
        }

        public BookCategoryView GetBookById(int bookId)
        {
            return gateway.GetBookById(bookId);
        }

        public bool UpdateBook(Book book)
        {
            return gateway.UpdateBook(book)>0;
        }

        public bool DeleteBook(Book book)
        {
            return gateway.DeleteBook(book)>0;
        }
    }
}
