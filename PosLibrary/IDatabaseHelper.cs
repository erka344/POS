using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary
{
    public interface IDatabaseHelper
    {
        void InitializeDatabase();
        void InsertCategory(string name);
        void InsertProduct(int categoryId, string name, decimal price, string imagePath = null);
        List<(int id, string name)> GetCategories();
        List<(int id, string name, decimal price, string imagePath)> GetProductsByCategory(int categoryId);
        void AddToCart(int productId, int quantity, decimal unitPrice, decimal discount = 0);
        List<(int productId, string productName, int quantity, decimal unitPrice, decimal discount)> GetCartItems();
        void ClearCart();
    }
}
