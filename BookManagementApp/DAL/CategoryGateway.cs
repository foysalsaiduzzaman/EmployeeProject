using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementApp.Model;

namespace BookManagementApp.DAL
{
    public class CategoryGateway
    {
        private string conString = ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString;
        private SqlConnection con;
        private SqlCommand cmd;
        private string query;

        public CategoryGateway()
        {
            con = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public  Category GetCategoryByName(string categoryName)
        {
            query = "Select * from Category where name = '"+categoryName+"'";
            cmd.CommandText = query;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Category category = null;
            while (reader.Read())
            {
                if (category == null)
                {
                    category = new Category();
                }
                category.Name = reader["name"].ToString();
                category.Id = int.Parse(reader["id"].ToString());
            }
            reader.Close();
            con.Close();
            return category;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories =new List<Category>();
            query = "SELECT * from Category";
            cmd.CommandText = query;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = int.Parse(reader["id"].ToString());
                category.Name = reader["name"].ToString();
                categories.Add(category);
            }
            reader.Close();
            con.Close();
            return categories;
        }

        public int InsertCategory(Category aCategory)
        {
            query = "INSERT into Category values('"+aCategory.Name+"')";
            cmd.CommandText = query;
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}
