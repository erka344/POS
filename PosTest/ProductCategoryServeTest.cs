using PosLibrary.serve;
using PosLibrary.model;

namespace PosTest
{
    [TestClass]
    public class ProductCategoryServeTest
    {
        private ProductCategoryServe categoryServe;
        private const string TestConnectionString = "test_connection";

        [TestInitialize]
        public void Setup()
        {
            categoryServe = new ProductCategoryServe(TestConnectionString);
        }

        [TestMethod]
        public void Constructor_ValidConnectionString_CreatesInstance()
        {
            var serve = new ProductCategoryServe("valid_connection");
            Assert.IsNotNull(serve);
        }

        [TestMethod]
        public void ProductCategoryServe_Constructor_CreatesInstanceSuccessfully()
        {
            var categoryServe = new ProductCategoryServe("test_connection");
            Assert.IsNotNull(categoryServe);
        }

        [TestMethod]
        public void ProductCategoryServe_HasCorrectPublicMethods()
        {
            var categoryServeType = typeof(ProductCategoryServe);
            
            Assert.IsNotNull(categoryServeType.GetMethod("GetAllProductCategory"));
            Assert.IsNotNull(categoryServeType.GetMethod("GetProductCategoryNameById"));
            Assert.IsNotNull(categoryServeType.GetMethod("GetCategoryByName"));
            Assert.IsNotNull(categoryServeType.GetMethod("AddProductCategory"));
            Assert.IsNotNull(categoryServeType.GetMethod("UpdateProductCategory"));
            Assert.IsNotNull(categoryServeType.GetMethod("DeleteProductCategory"));
        }
    }
}