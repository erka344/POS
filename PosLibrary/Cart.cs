using System;
using System.Collections.Generic;
using System.Linq;

namespace PosLibrary
{
    public class Cart
    {
        public int CartId { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public CartStatus Status { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        //public virtual List<CartItem> Items { get; set; } = new List<CartItem>();

        //// Calculated properties
        //public decimal SubTotal => Items.Sum(item => item.SubTotal);
        //public decimal TotalDiscount => Items.Sum(item => item.DiscountAmount);
        //public decimal Total => Items.Sum(item => item.Total);
        //public int TotalItems => Items.Sum(item => item.Quantity);
    }

    public enum CartStatus
    {
        Active,
        CheckedOut,
        Abandoned,
        Completed
    }
}