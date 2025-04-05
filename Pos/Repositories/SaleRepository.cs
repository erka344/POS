using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Pos.Data;
using Pos.Models;

namespace Pos.Repositories
{
    public class SaleRepository
    {
        private readonly ApplicationDbContext _context;
        
        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public int CreateSale(Sale sale)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var transaction = connection.BeginTransaction();
            
            try
            {
                // Insert sale
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = @"
                        INSERT INTO Sales (SaleDate, UserId, TotalAmount, AmountPaid)
                        VALUES (@SaleDate, @UserId, @TotalAmount, @AmountPaid);
                        SELECT last_insert_rowid();";
                    
                    command.Parameters.AddWithValue("@SaleDate", sale.SaleDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@UserId", sale.UserId);
                    command.Parameters.AddWithValue("@TotalAmount", sale.TotalAmount);
                    command.Parameters.AddWithValue("@AmountPaid", sale.AmountPaid);
                    
                    var saleId = Convert.ToInt32(command.ExecuteScalar());
                    
                    // Insert sale items
                    foreach (var item in sale.Items)
                    {
                        using var itemCommand = connection.CreateCommand();
                        itemCommand.Transaction = transaction;
                        itemCommand.CommandText = @"
                            INSERT INTO SaleItems (SaleId, ProductId, Quantity, UnitPrice)
                            VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice)";
                        
                        itemCommand.Parameters.AddWithValue("@SaleId", saleId);
                        itemCommand.Parameters.AddWithValue("@ProductId", item.ProductId);
                        itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCommand.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        
                        itemCommand.ExecuteNonQuery();
                        
                        // Update stock
                        using var stockCommand = connection.CreateCommand();
                        stockCommand.Transaction = transaction;
                        stockCommand.CommandText = "UPDATE Products SET StockQuantity = StockQuantity - @Quantity WHERE Id = @ProductId";
                        stockCommand.Parameters.AddWithValue("@ProductId", item.ProductId);
                        stockCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                        stockCommand.ExecuteNonQuery();
                    }
                    
                    transaction.Commit();
                    return saleId;
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        
        public Sale? GetSaleById(int id)
        {
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT s.Id, s.SaleDate, s.UserId, s.TotalAmount, s.AmountPaid, u.Name as UserName
                FROM Sales s
                JOIN Users u ON s.UserId = u.Id
                WHERE s.Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var sale = new Sale
                {
                    Id = reader.GetInt32(0),
                    SaleDate = DateTime.Parse(reader.GetString(1)),
                    UserId = reader.GetInt32(2),
                    TotalAmount = reader.GetDecimal(3),
                    AmountPaid = reader.GetDecimal(4),
                    User = new User
                    {
                        Id = reader.GetInt32(2),
                        Name = reader.GetString(5)
                    }
                };
                
                // Get sale items
                using var itemsCommand = connection.CreateCommand();
                itemsCommand.CommandText = @"
                    SELECT si.Id, si.ProductId, si.Quantity, si.UnitPrice, p.Name as ProductName
                    FROM SaleItems si
                    JOIN Products p ON si.ProductId = p.Id
                    WHERE si.SaleId = @SaleId";
                itemsCommand.Parameters.AddWithValue("@SaleId", id);
                
                using var itemsReader = itemsCommand.ExecuteReader();
                while (itemsReader.Read())
                {
                    sale.Items.Add(new SaleItem
                    {
                        Id = itemsReader.GetInt32(0),
                        ProductId = itemsReader.GetInt32(1),
                        Quantity = itemsReader.GetInt32(2),
                        UnitPrice = itemsReader.GetDecimal(3),
                        Product = new Product
                        {
                            Id = itemsReader.GetInt32(1),
                            Name = itemsReader.GetString(4)
                        }
                    });
                }
                
                return sale;
            }
            
            return null;
        }
        
        public List<Sale> GetSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            var sales = new List<Sale>();
            
            using var connection = _context.GetConnection();
            connection.Open();
            
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT s.Id, s.SaleDate, s.UserId, s.TotalAmount, s.AmountPaid, u.Name as UserName
                FROM Sales s
                JOIN Users u ON s.UserId = u.Id
                WHERE s.SaleDate BETWEEN @StartDate AND @EndDate
                ORDER BY s.SaleDate DESC";
            
            command.Parameters.AddWithValue("@StartDate", startDate.ToString("yyyy-MM-dd HH:mm:ss"));
            command.Parameters.AddWithValue("@EndDate", endDate.ToString("yyyy-MM-dd HH:mm:ss"));
            
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var sale = new Sale
                {
                    Id = reader.GetInt32(0),
                    SaleDate = DateTime.Parse(reader.GetString(1)),
                    UserId = reader.GetInt32(2),
                    TotalAmount = reader.GetDecimal(3),
                    AmountPaid = reader.GetDecimal(4),
                    User = new User
                    {
                        Id = reader.GetInt32(2),
                        Name = reader.GetString(5)
                    }
                };
                
                sales.Add(sale);
            }
            
            return sales;
        }
    }
} 