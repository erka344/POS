// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=mydatabase.db;Version=3;";
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();

            string sql = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT)";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "INSERT INTO users (name) VALUES ('Эрдэнэ-Очир')";
            command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            sql = "SELECT * FROM users";
            command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Нэр: {reader["name"]}");
            }

            conn.Close();
        }
    }
}

