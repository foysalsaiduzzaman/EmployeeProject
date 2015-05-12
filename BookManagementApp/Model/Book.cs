using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementApp.Model
{
    public class Book
    {
        private int id;
        private string name;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string isbn ;
        private string author;
        private int categoryId;


        
    }
}
