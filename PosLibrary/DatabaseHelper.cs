using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;


namespace PosLibrary
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private static string dbPath = "\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\pos1.db\"";
        private static string dbPath2 = "\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\pos2.db\"";
        private static string connectionString = $"Data Source={dbPath};";

        public void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Create Categories table
                    using (var command = new SqliteCommand(@"
                        CREATE TABLE IF NOT EXISTS Categories (
                            CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL
                        )", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create Products table
                    using (var command = new SqliteCommand(@"
                        CREATE TABLE IF NOT EXISTS Products (
                            ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                            CategoryId INTEGER,
                            Name TEXT NOT NULL,
                            Price DECIMAL(10,2) NOT NULL,
                            ImagePath TEXT,
                            FOREIGN KEY(CategoryId) REFERENCES Categories(CategoryId)
                        )", connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create Cart table
                    using (var command = new SqliteCommand(@"
                        CREATE TABLE IF NOT EXISTS Cart (
                            CartId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ProductId INTEGER,
                            Quantity INTEGER NOT NULL,
                            UnitPrice DECIMAL(10,2) NOT NULL,
                            Discount DECIMAL(5,2) DEFAULT 0,
                            FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
                        )", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InsertCategory(string name)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand("INSERT INTO Categories (Name) VALUES (@Name)", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertProduct(int categoryId, string name, decimal price, string imagePath = null)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(
                    "INSERT INTO Products (CategoryId, Name, Price, ImagePath) VALUES (@CategoryId, @Name, @Price, @ImagePath)",
                    connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@ImagePath", imagePath ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<(int id, string name)> GetCategories()
        {
            var categories = new List<(int id, string name)>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand("SELECT CategoryId, Name FROM Categories", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add((reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }
            return categories;
        }

        public List<(int id, string name, decimal price, string imagePath)> GetProductsByCategory(int categoryId)
        {
            var products = new List<(int id, string name, decimal price, string imagePath)>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(
                    "SELECT ProductId, Name, Price, ImagePath FROM Products WHERE CategoryId = @CategoryId",
                    connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add((
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetDecimal(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3)
                            ));
                        }
                    }
                }
            }
            return products;
        }

        public void AddToCart(int productId, int quantity, decimal unitPrice, decimal discount = 0)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"
                    INSERT INTO Cart (ProductId, Quantity, UnitPrice, Discount)
                    VALUES (@ProductId, @Quantity, @UnitPrice, @Discount)",
                    connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    command.Parameters.AddWithValue("@Discount", discount);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<(int productId, string productName, int quantity, decimal unitPrice, decimal discount)> GetCartItems()
        {
            var items = new List<(int productId, string productName, int quantity, decimal unitPrice, decimal discount)>();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(@"
                    SELECT c.ProductId, p.Name, c.Quantity, c.UnitPrice, c.Discount
                    FROM Cart c
                    JOIN Products p ON c.ProductId = p.ProductId",
                    connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add((
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetDecimal(3),
                                reader.GetDecimal(4)
                            ));
                        }
                    }
                }
            }
            return items;
        }

        public void ClearCart()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand("DELETE FROM Cart", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}