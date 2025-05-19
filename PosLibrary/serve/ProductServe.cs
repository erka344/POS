using PosLibrary.model;
using PosLibrary.repo;
using PosLibrary.repo.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.serve
{
    class ProductServe
    {
        private IProductRepo productRepo;

        public ProductServe(string connectionString)
        {
            productRepo = new ProductRepo(connectionString);
        }

        public void AddProduct(Product product)
        {
            productRepo.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepo.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepo.DeleteProduct(product);
        }

        public List<Product> GetProducts()
        {
            return productRepo.GetProducts();
        }

        public List<Product> GetProductByCategory(int categoryId)
        {
            return productRepo.GetProductsByCategory(categoryId);
        }
    }
}
