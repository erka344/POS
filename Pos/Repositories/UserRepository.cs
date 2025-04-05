using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pos.Data;
using Pos.Models;

namespace Pos.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public User? Authenticate(string username, string password)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Username, Password, Role, Name FROM Users WHERE Username = @Username AND Password = @Password";
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Role = (UserRole)reader.GetInt32(3),
                    Name = reader.GetString(4)
                };
            }
            
            return null;
        }
        
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Username, Password, Role, Name FROM Users";
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Role = (UserRole)reader.GetInt32(3),
                    Name = reader.GetString(4)
                });
            }
            
            return users;
        }
    }
} 