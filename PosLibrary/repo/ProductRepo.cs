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
                command.CommandText = @"INSERT INTO Products (Name, Price, CategoryId) VALUES (@name, @price, @categoryId)";
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
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
                                    SET Name = @name, Price = @price, CategoryId = @categoryId
                                    WHERE Id = @id";
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@id", product.BarCode);
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
                command.Parameters.AddWithValue("@id", product.BarCode);
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
                command.CommandText = "SELECT Id, Name, Price, CategoryId FROM Products";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            BarCode = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            price = (int)reader["Price"],
                            CategoryId = (int)reader["CategoryId"],
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
                command.CommandText = @"SELECT Id, Name, Price, CategoryId
                                    FROM Products
                                    WHERE CategoryId = @categoryId";
                command.Parameters.AddWithValue("@categoryId", categoryId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            BarCode = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            price = (int)reader["Price"],
                            CategoryId = (int)reader["CategoryId"]
                        });
                    }
                }
            }
            return products;
        }
    }
}
