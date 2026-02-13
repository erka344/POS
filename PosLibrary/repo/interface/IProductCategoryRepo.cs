using PosLibrary.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.repo.@interface
{
    public interface IProductCategoryRepo
    {
        
        public void AddCategory(ProductCategory category);
        public void UpdateCategory(ProductCategory category);
        public void DeleteCategory(int CategoryId);
        public List<ProductCategory> GetAllCategory();
        public string GetCategoryById(int categoryId);
        public List<ProductCategory> GetCategoryByName(string name);
    }
}
