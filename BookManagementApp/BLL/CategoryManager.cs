using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementApp.DAL;
using BookManagementApp.Model;

namespace BookManagementApp.BLL
{
    public class CategoryManager
    {
         CategoryGateway categoryGateway = new CategoryGateway();
        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }

        public bool GetCategoryByName(string categoryName)
        {
            Category category = categoryGateway.GetCategoryByName(categoryName);
            if (category != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveCategory(Category aCategory)
        {
            return categoryGateway.InsertCategory(aCategory) > 0;
        }
    }
}
