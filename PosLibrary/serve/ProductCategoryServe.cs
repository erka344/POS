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
    public class ProductCategoryServe
    {
        private IProductCategoryRepo categoryRepo;

        public ProductCategoryServe(string connectionString)
        {
            this.categoryRepo = new ProductCategoryRepo(connectionString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ProductCategory> GetAllProductCategory()
        {
            return categoryRepo.GetAllCategory();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetProductCategoryNameById(int id)
        {
            return categoryRepo.GetCategoryById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<ProductCategory> GetCategoryByName(string name)
        {
            return categoryRepo.GetCategoryByName(name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public void AddProductCategory(ProductCategory category)
        {
            categoryRepo.AddCategory(category);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        public void UpdateProductCategory(ProductCategory category)
        {
            categoryRepo.UpdateCategory(category);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProductCategory(int id)
        {
            categoryRepo.DeleteCategory(id);
        }
    }
}
