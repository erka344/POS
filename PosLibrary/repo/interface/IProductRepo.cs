using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PosLibrary.model;

namespace PosLibrary.repo.@interface
{
    interface IProductRepo
    {
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public List<Product> GetProducts();
        public List<Product> GetProductsByCategory(int CategoryId);
    }
}
