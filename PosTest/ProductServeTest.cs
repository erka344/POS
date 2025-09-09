using PosLibrary.serve;
using PosLibrary.model;

namespace PosTest
{
    [TestClass]
    public class ProductServeTest
    {
        private ProductServe productServe;
        private const string TestConnectionString = "test_connection";

        [TestInitialize]
        public void Setup()
        {
            productServe = new ProductServe(TestConnectionString);
        }

        [TestMethod]
        public void Constructor_ValidConnectionString_CreatesInstance()
        {
            var serve = new ProductServe("valid_connection");
            Assert.IsNotNull(serve);
        }

        [TestMethod]
        public void ProductServe_Constructor_CreatesInstanceSuccessfully()
        {
            var productServe = new ProductServe("test_connection");
            Assert.IsNotNull(productServe);
        }

        [TestMethod]
        public void ProductServe_HasCorrectPublicMethods()
        {
            var productServeType = typeof(ProductServe);
            
            Assert.IsNotNull(productServeType.GetMethod("AddProduct"));
            Assert.IsNotNull(productServeType.GetMethod("UpdateProduct"));
            Assert.IsNotNull(productServeType.GetMethod("DeleteProduct"));
            Assert.IsNotNull(productServeType.GetMethod("GetProducts"));
            Assert.IsNotNull(productServeType.GetMethod("GetProductByCategory"));
            Assert.IsNotNull(productServeType.GetMethod("SearchProductByName"));
        }
    }
}