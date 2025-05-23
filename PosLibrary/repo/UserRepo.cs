using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using PosLibrary.model;
using PosLibrary.repo.@interface;

namespace PosLibrary.repo
{
    public class UserRepo : IUserRepo
    {
        private readonly string connectionString;
        public UserRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddUser(User user) 
        { 
            using(var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                string Qry = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, @role)";

                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@username", user.UserName);
                    com.Parameters.AddWithValue("@password", user.Password);
                    com.Parameters.AddWithValue("@role", (int)user.Role);
                    com.ExecuteNonQuery();

                    // Get the auto-generated ID
                    com.CommandText = "SELECT last_insert_rowid()";
                    user.Id = Convert.ToInt32(com.ExecuteScalar());
                }
            }
        }
        public void UpdateUser(User user)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "UPDATE Users SET Username = @username, Password = @password, Role = @role WHERE Id = @id";

                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@username", user.UserName);
                    com.Parameters.AddWithValue("@password", user.Password);
                    com.Parameters.AddWithValue("@role", (int)user.Role);
                    com.Parameters.AddWithValue("@id", user.Id);

                    com.ExecuteNonQuery();
                }
            }
        }
        public void DeleteUser(int userId)
        {
            using (var connect = new SqliteConnection(this.connectionString))
            {
                connect.Open();
                string Qry = "DELETE FROM Users WHERE ID = @id";
                using(var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@id", userId);
                    com.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetUsers()
        {
            var users = new List<User>();
            using (var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                string Qry = "SELECT Id, Username, Password, Role FROM Users";

                using (var com = new SqliteCommand(Qry, connect))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserName = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = (UserRole)Convert.ToInt32(reader["Role"])
                            });
                        }
                    }
                }
            }
            return users;

        }
        public User GetUserById(int userId)
        {
            using (var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                string Qry = "SELECT Id, Username, Password, Role FROM Users WHERE Id = @id";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@id", userId);

                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserName = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = (UserRole)Convert.ToInt32(reader["Role"])
                            };
                        }
                    }
                }
            }
            return null;
        }
        public User GetUserByName(string name)
        {
            using (var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                string Qry = "SELECT Id, Username, Password, Role FROM Users WHERE Username = @username";
                using (var com = new SqliteCommand(Qry, connect))
                {
                    com.Parameters.AddWithValue("@username", name);

                    using (var reader = com.ExecuteReader())
                    {
                        if (reader.Read()) 
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserName = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = (UserRole)Convert.ToInt32(reader["Role"])
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
