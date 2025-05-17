using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PosForm
{
    class Datas
    {
        string connections = DataBaseConnection.connectionString;
        public void InitialData()
        {
            CreateTables();
            InsertInitialData();
        }

        private void CreateTables()
        {
            using (var connection = new SqliteConnection(connections))
            {
                connection.Open();

                var createProductTable = @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Barcode INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Discount INTEGER DEFAULT 0,
                        CategoryID INTEGER,
                        ImagePath TEXT,
                        FOREIGN KEY (CategoryID) REFERENCES Categories(Id)
                    );
                ";

                var createCategoryTable = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL
                    );
                ";

                var createUsersTable = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );
                ";
                //var createCartTable = @"
                //    CREATE TABLE IF NOT EXISTS Cart (
                //            CartId INTEGER PRIMARY KEY AUTOINCREMENT,
                //            ProductId INTEGER,
                //            Quantity INTEGER NOT NULL,
                //            UnitPrice DECIMAL(10,2) NOT NULL,
                //            Discount DECIMAL(5,2) DEFAULT 0,
                //            FOREIGN KEY(ProductId) REFERENCES Products(ProductId)
                //    );
                //";

                var command = connection.CreateCommand();

                // Create all tables
                command.CommandText = createCategoryTable;
                command.ExecuteNonQuery();

                command.CommandText = createUsersTable;
                command.ExecuteNonQuery();

                command.CommandText = createProductTable;
                command.ExecuteNonQuery();

                //command.CommandText = createCartTable;
                //command.ExecuteNonQuery();
            }
        }
        private void InsertInitialData()
        {
            using (var connection = new SqliteConnection(connections))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    // Insert Users (2 rows)
                    command.CommandText = @"
                        INSERT INTO Users (Username, Password, Role) VALUES
                            ('admin', 'admin123', 'Admin'),
                            ('cashier1', 'cashier123', 'Cashier'),
                            ('cashier2', 'cashier1234', 'Cashier');
                    ";
                    command.ExecuteNonQuery();

                    // Insert Categories
                    command.CommandText = @"
                        INSERT INTO Categories (Name) VALUES
                            ('Beverages'), ('Snacks'), ('Fruits'), ('Vegetables'), ('Dairy'),
                            ('Bakery'), ('Meat'), ('Seafood'), ('Frozen'), ('Canned Goods'),
                            ('Household'), ('Personal Care'), ('Electronics'), ('Clothing'), ('Stationery');
                    ";
                    command.ExecuteNonQuery();

                    // Insert Products
                    command.CommandText = @"
                        INSERT INTO Products (Barcode, Name, Price, Discount, CategoryID, ImagePath) VALUES
                            (1001, 'Coca Cola', 2.00, 0, 1, ''),
                            (1002, 'Pepsi', 1.95, 0, 1, ''),
                            (1003, 'Lays Chips', 1.50, 5, 2, ''),
                            (1004, 'Banana', 0.75, 0, 3, ''),
                            (1005, 'Apple', 0.85, 0, 3, ''),
                            (1006, 'Tomato', 0.90, 0, 4, ''),
                            (1007, 'Milk 1L', 1.20, 0, 5, ''),
                            (1008, 'Bread Loaf', 1.10, 0, 6, ''),
                            (1009, 'Chicken Breast', 3.50, 10, 7, ''),
                            (1010, 'Shrimp 500g', 5.00, 15, 8, ''),
                            (1011, 'Frozen Pizza', 3.00, 5, 9, ''),
                            (1012, 'Canned Beans', 1.00, 0, 10, ''),
                            (1013, 'Laundry Detergent', 4.25, 10, 11, ''),
                            (1014, 'Shampoo', 2.75, 5, 12, ''),
                            (1015, 'Headphones', 10.00, 0, 13, ''),
                            (1016, 'T-shirt', 6.00, 20, 14, ''),
                            (1017, 'Notebook', 0.80, 0, 15, ''),
                            (1018, 'Orange Juice', 2.50, 0, 1, ''),
                            (1019, 'Chocolate Bar', 1.25, 5, 2, ''),
                            (1020, 'Cheese 200g', 2.10, 0, 5, ''),
                            (1021, 'Yogurt Cup', 0.95, 0, 5, ''),
                            (1022, 'Eggs (12 pack)', 2.80, 0, 5, ''),
                            (1023, 'Toothpaste', 1.60, 10, 12, ''),
                            (1024, 'Rice 1kg', 1.90, 5, 10, ''),
                            (1025, 'Pasta 500g', 1.10, 0, 10, ''),
                            (1026, 'Orange', 0.70, 0, 3, ''),
                            (1027, 'Cucumber', 0.60, 0, 4, ''),
                            (1028, 'Floor Cleaner', 3.20, 10, 11, ''),
                            (1029, 'Notebook A5', 1.00, 0, 15, ''),
                            (1030, 'USB Cable', 3.50, 0, 13);
                    ";
                    command.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();
                }
            }
        }

        
        public void InsertCategory(string name)
        {
            using (var connection = new SqliteConnection(connections))
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
            using (var connection = new SqliteConnection(connections))
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
            using (var connection = new SqliteConnection(connections))
            {
                connection.Open();
                using (var command = new SqliteCommand("SELECT Id, Name FROM Categories", connection))
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
            using (var connection = new SqliteConnection(connections))
            {
                connection.Open();
                using (var command = new SqliteCommand(
                    "SELECT Barcode, Name, Price, ImagePath FROM Products WHERE CategoryID = @CategoryId",
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
            using (var connection = new SqliteConnection(connections))
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
            using (var connection = new SqliteConnection(connections))
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
            using (var connection = new SqliteConnection(connections))
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
