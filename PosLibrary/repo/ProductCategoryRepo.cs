using Microsoft.Data.Sqlite;
using PosLibrary.model;
using PosLibrary.repo.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.repo
{
    public class ProductCategoryRepo : IProductCategoryRepo
    {
        private readonly string  connectionString;
        public ProductCategoryRepo(string connectString)
        {
            this.connectionString = connectString;
        }
        public void AddCategory(ProductCategory category)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "INSERT INTO ProductCategories (Name) VALUES(@name)";
                using (var com = new SqliteCommand(Qry,connect))
                { 
                    com.Parameters.AddWithValue("@name", category.Name);
                    com.ExecuteNonQuery();

                    // Get the auto-generated ID
                    com.CommandText = "SELECT last_insert_rowid()";
                    category.Id = Convert.ToInt32(com.ExecuteScalar());
                }
            }  

        }
        public void UpdateCategory(ProductCategory category)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "UPDATE ProductCategories SET Id = @id, Name = @name WHERE Id = @id ";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@id", category.Id);
                    com.Parameters.AddWithValue("@name", category.Name);
                    com.ExecuteNonQuery();

                }
            }
        }
        public void DeleteCategory(int CategoryId)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "DELETE FROM ProductCategories WHERE Id = @id";
                using(var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@id", CategoryId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public List<ProductCategory> GetAllCategory()
        {
            var list = new List<ProductCategory>();
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "SELECT Id, Name FROM ProductCategories";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductCategory
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"]?.ToString()
                            });
                        }
                    }

                }
            }
            return list;
        }
        public List<ProductCategory> GetCategoryByName(string name)
        {
            var list = new List<ProductCategory>();
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "SELECT Id, Name FROM ProductCategories WHERE Name LIKE @name";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@name", $"%{name}%");
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductCategory
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"]?.ToString()
                            });
                        }
                    }

                }
            }
            return list;
        }

        public string GetCategoryById(int id)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "SELECT Name FROM ProductCategories WHERE Id = @id";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@id", id);
                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read()) { string name = reader["name"].ToString(); return name; }
                    }
                }
                return string.Empty;
            }
        }
    }
}
