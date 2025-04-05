using System;
using System.Collections.Generic;
using System.Linq;

namespace Pos.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount => AmountPaid - TotalAmount;
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        
        public void CalculateTotal()
        {
            TotalAmount = Items.Sum(item => item.TotalPrice);
        }
    }
} 