using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.serve
{
    public class DataBase
    {
        public string ConnectionString { get; set; }
        public string DbPath = "\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\PosDatabase.db\"";

        public DataBase()
        {
            ConnectionString = $"Data Source={DbPath}";
            InitializeDatabase();
        }

        public void InitializeDatabase()
        {
            bool isNewDatabase = !File.Exists(DbPath);

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            if (isNewDatabase)
            {
                CreateTables(connection);
                InsertData(connection);
            }
        }

        private void CreateTables(SqliteConnection connection)
        { 
            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL UNIQUE,
                    Password TEXT NOT NULL,
                    Role INTEGER NOT NULL
                );
            ");

            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS ProductCategories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
            ");

            ExecuteNonQuery(connection, @"
                CREATE TABLE IF NOT EXISTS Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Price INTEGER NOT NULL,
                    CategoryId INTEGER,
                    ImageName TEXT,
                    FOREIGN KEY (CategoryId) REFERENCES ProductCategories (Id)
                );
            ");
            
        }

        private void InsertData(SqliteConnection connection)
        {

            ExecuteNonQuery(connection, @"
                INSERT OR IGNORE INTO Users (Username, Password, Role) VALUES 
                ('manager', 'password', 0),
                ('cashier1', 'password', 1),
                ('cashier2', 'password', 1)
            ");

            ExecuteNonQuery(connection, @"
                INSERT OR IGNORE INTO ProductCategories (Name) VALUES 
                ('Beverages'),
                ('Snacks'),
                ('Groceries')
            ");

            ExecuteNonQuery(connection, @"
                INSERT OR IGNORE INTO Products (Name, Price, CategoryId, ImageName) VALUES 
                ('Coca Cola', 150, 1, 'cocacola.jpg'),
                ('Pepsi', 145, 1, 'pepsi.jpg'),
                ('Chips', 200, 2, 'chips.jpg'),
                ('Chocolate Bar', 250, 2, 'chocolate.jpg'),
                ('Bread', 30, 3, 'bread.jpg'),
                ('Milk', 350, 3, 'milk.jpg')
            ");
            
        }
        private void ExecuteNonQuery(SqliteConnection connection, string commandText)
        {
            using var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }
    }
}
