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
    class CartServe
    {
        private IProductRepo productRepo;
        private List<Product> products;
        public List<Product> Products { get { return products; } }


        public CartServe(string connectionString)
        {
            productRepo = new ProductRepo(connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void AddProductToCart(Product product)
        {
            Product existedItem = products.FirstOrDefault(p => p.BarCode == product.BarCode);

            if (existedItem != null)
            {
                existedItem.Quantity++;
            }
            else
            {
                product.Quantity = 1;
                products.Add(product);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public void DeleteProductFromCart(Product product)
        {
            products.Remove(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductName"></param>
        public void AddQuantity(string ProductName)
        {
            var product = products.FirstOrDefault(p => p.Name == ProductName);

            if (product != null)
            {
                product.Quantity++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductName"></param>
        public void MinusQuantity(string ProductName)
        {
            var product = products.FirstOrDefault(p => p.Name == ProductName);
            if (product != null)
            {
                if (product.Quantity > 1)
                {
                    product.Quantity--;
                }
                else
                {
                    products.Remove(product);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CalculateTotal()
        {
            int total = 0;
            foreach (var product in products)
            {
                total += product.price * product.Quantity;
            }
            return total;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearCart()
        {
            products.Clear();
        }
    }
}
