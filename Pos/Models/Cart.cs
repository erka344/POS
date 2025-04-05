using System;
using System.Collections.Generic;
using System.Linq;

namespace Pos.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        
        public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
        
        public void AddItem(Product product, int quantity = 1)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
            
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    Product = product,
                    Quantity = quantity,
                    UnitPrice = product.Price
                });
            }
        }
        
        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
        
        public void UpdateQuantity(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                {
                    Items.Remove(item);
                }
                else
                {
                    item.Quantity = quantity;
                }
            }
        }
        
        public void Clear()
        {
            Items.Clear();
        }
    }
} 