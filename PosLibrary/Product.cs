using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Foreign key for Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        // Additional properties
        public decimal CostPrice { get; set; }
        public decimal ProfitMargin { get; set; }
        public string Unit { get; set; } = string.Empty; // e.g., kg, piece, liter
        public int MinimumStockLevel { get; set; }
        public bool IsDiscountable { get; set; } = true;
    }
}
