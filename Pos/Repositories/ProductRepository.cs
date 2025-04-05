using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pos.Data;
using Pos.Models;

namespace Pos.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;
        
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT p.Id, p.Code, p.Name, p.Price, p.CategoryId, p.StockQuantity, c.Name as CategoryName
                FROM Products p
                JOIN Categories c ON p.CategoryId = c.Id";
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    CategoryId = reader.GetInt32(4),
                    StockQuantity = reader.GetInt32(5),
                    Category = new Category
                    {
                        Id = reader.GetInt32(4),
                        Name = reader.GetString(6)
                    }
                });
            }
            
            return products;
        }
        
        public Product? GetProductByCode(string code)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT p.Id, p.Code, p.Name, p.Price, p.CategoryId, p.StockQuantity, c.Name as CategoryName
                FROM Products p
                JOIN Categories c ON p.CategoryId = c.Id
                WHERE p.Code = @Code";
            command.Parameters.AddWithValue("@Code", code);
            
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    Id = reader.GetInt32(0),
                    Code = reader.GetString(1),
                    Name = reader.GetString(2),
                    Price = reader.GetDecimal(3),
                    CategoryId = reader.GetInt32(4),
                    StockQuantity = reader.GetInt32(5),
                    Category = new Category
                    {
                        Id = reader.GetInt32(4),
                        Name = reader.GetString(6)
                    }
                };
            }
            
            return null;
        }
        
        public void AddProduct(Product product)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Products (Code, Name, Price, CategoryId, StockQuantity)
                VALUES (@Code, @Name, @Price, @CategoryId, @StockQuantity)";
            
            command.Parameters.AddWithValue("@Code", product.Code);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            
            command.ExecuteNonQuery();
        }
        
        public void UpdateProduct(Product product)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Products
                SET Code = @Code, Name = @Name, Price = @Price, CategoryId = @CategoryId, StockQuantity = @StockQuantity
                WHERE Id = @Id";
            
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@Code", product.Code);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            command.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
            
            command.ExecuteNonQuery();
        }
        
        public void DeleteProduct(int id)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Products WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            
            command.ExecuteNonQuery();
        }
        
        public void UpdateStock(int productId, int quantity)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = "UPDATE Products SET StockQuantity = StockQuantity + @Quantity WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", productId);
            command.Parameters.AddWithValue("@Quantity", quantity);
            
            command.ExecuteNonQuery();
        }
    }
} 