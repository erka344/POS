using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pos.Data;
using Pos.Models;

namespace Pos.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<Category> GetAllCategories()
        {
            var categories = new List<Category>();
            
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Description FROM Categories";
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                });
            }
            
            return categories;
        }
        
        public Category? GetCategoryById(int id)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Description FROM Categories WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
                };
            }
            
            return null;
        }
        
        public void AddCategory(Category category)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
            
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);
            
            command.ExecuteNonQuery();
        }
        
        public void UpdateCategory(Category category)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
            
            command.Parameters.AddWithValue("@Id", category.Id);
            command.Parameters.AddWithValue("@Name", category.Name);
            command.Parameters.AddWithValue("@Description", category.Description ?? (object)DBNull.Value);
            
            command.ExecuteNonQuery();
        }
        
        public void DeleteCategory(int id)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Categories WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            
            command.ExecuteNonQuery();
        }
    }
} 