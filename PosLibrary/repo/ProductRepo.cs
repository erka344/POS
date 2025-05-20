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
    class ProductRepo :IProductRepo
    {
        private readonly string connectionString;
        public ProductRepo(string connectString)
        {
            this.connectionString = connectString;
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Products (Name, Price, CategoryId, ImageName) VALUES (@name, @price, @categoryId, @imageName)";
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@imageName", product.ImagePath);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Products
                                    SET Name = @name, Price = @price, CategoryId = @categoryId, ImageName = @imageName
                                    WHERE Id = @id";
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@imageName", product.ImagePath);
                command.Parameters.AddWithValue("@id", product.Id);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(Product product)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Products WHERE Id = @id";
                command.Parameters.AddWithValue("@id", product.Id);
                command.ExecuteNonQuery();
            }
        }
        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name, Price, CategoryId, ImageName FROM Products";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            price = (int)Convert.ToDecimal(reader["Price"]),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            ImagePath = reader["ImageName"].ToString()
                        });
                    }
                }
            }
            return products;
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            var products = new List<Product>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT Id, Name, Price, CategoryId, ImageName
                                    FROM Products
                                    WHERE CategoryId = @categoryId";
                command.Parameters.AddWithValue("@categoryId", categoryId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"]?.ToString(),
                            price = Convert.ToInt32(reader["Price"]),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            ImagePath = reader["ImageName"]?.ToString()
                        });
                    }
                }
            }
            return products;
        }

        public List<Product> GetProductByName(string name)
        { 
            var products = new List<Product>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string Qry = "SELECT Id, Name, Price, CategoryId, ImageName FROM Products WHERE Name LIKE @name";

                using(var com  = new SqliteCommand(Qry, connection))
                {
                    com.Parameters.AddWithValue("@name", $"%{name}%");
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"]?.ToString(),
                                price = Convert.ToInt32(reader["Price"]),
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                ImagePath = reader["ImageName"]?.ToString()
                            });
                        }
                    }
                }
            }
            return products;
        }

    }
}
