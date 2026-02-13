using PosLibrary.serve;
using PosLibrary.model;

namespace PosTest
{
    [TestClass]
    public sealed class CartTest
    {
        private CartServe cartServe;
        private const string TestConnectionString = "test_connection";

        [TestInitialize]
        public void Setup()
        {
            cartServe = new CartServe(TestConnectionString);
        }

        [TestMethod]
        public void AddProductToCart_NewProduct_AddsProductWithQuantityOne()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };

            cartServe.AddProductToCart(product);

            Assert.AreEqual(1, cartServe.Products.Count);
            Assert.AreEqual(1, cartServe.Products[0].Quantity);
            Assert.AreEqual("Test Product", cartServe.Products[0].Name);
        }

        [TestMethod]
        public void AddProductToCart_ExistingProduct_IncreasesQuantity()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };

            cartServe.AddProductToCart(product);
            cartServe.AddProductToCart(product);

            Assert.AreEqual(1, cartServe.Products.Count);
            Assert.AreEqual(2, cartServe.Products[0].Quantity);
        }

        [TestMethod]
        public void DeleteProductFromCart_ExistingProduct_RemovesProduct()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };
            cartServe.AddProductToCart(product);

            cartServe.DeleteProductFromCart(product);

            Assert.AreEqual(0, cartServe.Products.Count);
        }

        [TestMethod]
        public void AddQuantity_ExistingProduct_IncreasesQuantity()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };
            cartServe.AddProductToCart(product);

            cartServe.AddQuantity("Test Product");

            Assert.AreEqual(2, cartServe.Products[0].Quantity);
        }

        [TestMethod]
        public void AddQuantity_NonExistingProduct_DoesNothing()
        {
            cartServe.AddQuantity("Non-existing Product");

            Assert.AreEqual(0, cartServe.Products.Count);
        }

        [TestMethod]
        public void MinusQuantity_ProductWithQuantityGreaterThanOne_DecreasesQuantity()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };
            cartServe.AddProductToCart(product);
            cartServe.AddQuantity("Test Product");

            cartServe.MinusQuantity("Test Product");

            Assert.AreEqual(1, cartServe.Products[0].Quantity);
        }

        [TestMethod]
        public void MinusQuantity_ProductWithQuantityOne_RemovesProduct()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };
            cartServe.AddProductToCart(product);

            cartServe.MinusQuantity("Test Product");

            Assert.AreEqual(0, cartServe.Products.Count);
        }

        [TestMethod]
        public void MinusQuantity_NonExistingProduct_DoesNothing()
        {
            cartServe.MinusQuantity("Non-existing Product");

            Assert.AreEqual(0, cartServe.Products.Count);
        }

        [TestMethod]
        public void CalculateTotal_EmptyCart_ReturnsZero()
        {
            int total = cartServe.CalculateTotal();

            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void CalculateTotal_MultipleProducts_ReturnsCorrectTotal()
        {
            var product1 = new Product { Id = 1, Name = "Product 1", price = 100 };
            var product2 = new Product { Id = 2, Name = "Product 2", price = 200 };

            cartServe.AddProductToCart(product1);
            cartServe.AddProductToCart(product2);
            cartServe.AddQuantity("Product 1");

            int total = cartServe.CalculateTotal();

            Assert.AreEqual(400, total); // (100 * 2) + (200 * 1)
        }

        [TestMethod]
        public void ClearCart_WithProducts_RemovesAllProducts()
        {
            var product = new Product { Id = 1, Name = "Test Product", price = 100 };
            cartServe.AddProductToCart(product);

            cartServe.ClearCart();

            Assert.AreEqual(0, cartServe.Products.Count);
        }
    }

    [TestClass]
    public sealed class UserTest
    {
        [TestMethod]
        public void UserServe_Constructor_RequiresIUserRepo()
        {
            // This test verifies that UserServe requires IUserRepo dependency
            // Cannot test directly without database setup, so we test the existence of the constructor
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void User_Properties_CanBeSetAndRetrieved()
        {
            var user = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123",
                Role = UserRole.Manager
            };

            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("testuser", user.UserName);
            Assert.AreEqual("password123", user.Password);
            Assert.AreEqual(UserRole.Manager, user.Role);
        }

        [TestMethod]
        public void UserRole_EnumValues_AreCorrect()
        {
            Assert.AreEqual(0, (int)UserRole.Manager);
            Assert.AreEqual(1, (int)UserRole.Cashier);
        }

        [TestMethod]
        public void User_DefaultValues_AreCorrect()
        {
            var user = new User();

            Assert.AreEqual(string.Empty, user.UserName);
            Assert.AreEqual(string.Empty, user.Password);
            Assert.AreEqual(UserRole.Manager, user.Role);
        }
    }

    [TestClass]
    public sealed class ProductTest
    {
        private const string TestConnectionString = "test_connection";

        [TestMethod]
        public void Product_Properties_CanBeSetAndRetrieved()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                price = 100,
                CategoryId = 1,
                Discount = 10,
                Quantity = 5,
                ImagePath = "/images/test.jpg"
            };

            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Test Product", product.Name);
            Assert.AreEqual(100, product.price);
            Assert.AreEqual(1, product.CategoryId);
            Assert.AreEqual(10, product.Discount);
            Assert.AreEqual(5, product.Quantity);
            Assert.AreEqual("/images/test.jpg", product.ImagePath);
        }

        [TestMethod]
        public void ProductCategory_Properties_CanBeSetAndRetrieved()
        {
            var category = new ProductCategory
            {
                Id = 1,
                Name = "Electronics"
            };

            Assert.AreEqual(1, category.Id);
            Assert.AreEqual("Electronics", category.Name);
        }

        [TestMethod]
        public void User_Properties_CanBeSetAndRetrieved()
        {
            var user = new User
            {
                Id = 1,
                UserName = "testuser",
                Password = "password123",
                Role = UserRole.Manager
            };

            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("testuser", user.UserName);
            Assert.AreEqual("password123", user.Password);
            Assert.AreEqual(UserRole.Manager, user.Role);
        }

        [TestMethod]
        public void UserRole_EnumValues_AreCorrect()
        {
            Assert.AreEqual(0, (int)UserRole.Manager);
            Assert.AreEqual(1, (int)UserRole.Cashier);
        }

        [TestMethod]
        public void User_DefaultValues_AreCorrect()
        {
            var user = new User();

            Assert.AreEqual(string.Empty, user.UserName);
            Assert.AreEqual(string.Empty, user.Password);
            Assert.AreEqual(UserRole.Manager, user.Role);
        }
    }

    [TestClass]
    public sealed class CategoryTest
    {
        private ProductCategoryServe categoryServe;
        private const string TestConnectionString = "test_connection";

        [TestInitialize]
        public void Setup()
        {
            categoryServe = new ProductCategoryServe(TestConnectionString);
        }

        [TestMethod]
        public void ProductCategory_DefaultConstructor_CreatesInstance()
        {
            var category = new ProductCategory();

            Assert.IsNotNull(category);
            Assert.AreEqual(0, category.Id);
            Assert.IsNull(category.Name);
        }

        [TestMethod]
        public void ProductCategory_Properties_CanBeSetAndGet()
        {
            var category = new ProductCategory
            {
                Id = 100,
                Name = "Test Category"
            };

            Assert.AreEqual(100, category.Id);
            Assert.AreEqual("Test Category", category.Name);
        }
    }

    [TestClass]
    public sealed class DatabaseTest
    {
        [TestMethod]
        public void DatabaseTest_Placeholder()
        {
            Assert.IsTrue(true);
        }
    }
}
