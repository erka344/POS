using System;
using System.IO;
using Microsoft.Data.Sqlite;
using Pos.Models;

namespace Pos.Data
{
    public class ApplicationDbContext
    {
        private readonly string _connectionString;
        
        public ApplicationDbContext()
        {
            var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pos.db");
            _connectionString = $"Data Source={dbPath}";
            InitializeDatabase();
        }
        
        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            
            // Create Users table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role INTEGER NOT NULL,
                        Name TEXT NOT NULL
                    )";
                command.ExecuteNonQuery();
            }
            
            // Create Categories table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Description TEXT
                    )";
                command.ExecuteNonQuery();
            }
            
            // Create Products table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Code TEXT NOT NULL UNIQUE,
                        Name TEXT NOT NULL,
                        Price REAL NOT NULL,
                        CategoryId INTEGER NOT NULL,
                        StockQuantity INTEGER NOT NULL,
                        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                    )";
                command.ExecuteNonQuery();
            }
            
            // Create Sales table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Sales (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SaleDate TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        TotalAmount REAL NOT NULL,
                        AmountPaid REAL NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(Id)
                    )";
                command.ExecuteNonQuery();
            }
            
            // Create SaleItems table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS SaleItems (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SaleId INTEGER NOT NULL,
                        ProductId INTEGER NOT NULL,
                        Quantity INTEGER NOT NULL,
                        UnitPrice REAL NOT NULL,
                        FOREIGN KEY (SaleId) REFERENCES Sales(Id),
                        FOREIGN KEY (ProductId) REFERENCES Products(Id)
                    )";
                command.ExecuteNonQuery();
            }
            
            // Insert default users if they don't exist
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT OR IGNORE INTO Users (Username, Password, Role, Name)
                    VALUES 
                        ('manager', 'manager123', 0, 'Manager'),
                        ('cashier1', 'cashier123', 1, 'Cashier 1'),
                        ('cashier2', 'cashier123', 1, 'Cashier 2')";
                command.ExecuteNonQuery();
            }
        }
        
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
} 