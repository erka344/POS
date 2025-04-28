using PosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary
{
    class CartItem
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public DateTime AddedDate { get; set; }

        // Navigation properties
        public virtual Cart Cart { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;

        // Calculated properties
        public decimal SubTotal => Quantity * UnitPrice;
        public decimal DiscountAmount => SubTotal * (Discount / 100);
        public decimal Total => SubTotal - DiscountAmount;
    }
}
