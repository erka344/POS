using System;
using System.Collections.Generic;
using System.Linq;
using Pos.Data;
using Pos.Models;
using Pos.Repositories;

namespace Pos.UI
{
    public class ConsoleUI
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository _userRepository;
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SaleRepository _saleRepository;
        
        private User? _currentUser;
        private Cart _cart;
        
        public ConsoleUI()
        {
            _context = new ApplicationDbContext();
            _userRepository = new UserRepository(_context);
            _productRepository = new ProductRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _saleRepository = new SaleRepository(_context);
            _cart = new Cart();
        }
        
        public void Run()
        {
            Console.WriteLine("Welcome to POS System");
            Console.WriteLine("=====================");
            
            while (true)
            {
                if (_currentUser == null)
                {
                    Login();
                }
                else
                {
                    ShowMainMenu();
                }
            }
        }
        
        private void Login()
        {
            Console.Clear();
            Console.WriteLine("Login");
            Console.WriteLine("=====");
            
            Console.Write("Username: ");
            var username = Console.ReadLine();
            
            Console.Write("Password: ");
            var password = Console.ReadLine();
            
            _currentUser = _userRepository.Authenticate(username ?? string.Empty, password ?? string.Empty);
            
            if (_currentUser == null)
            {
                Console.WriteLine("Invalid username or password. Press any key to try again.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Welcome, {_currentUser.Name}!");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }
        
        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"POS System - {_currentUser?.Name} ({_currentUser?.Role})");
            Console.WriteLine("===============================================");
            Console.WriteLine("1. Products");
            
            if (_currentUser?.IsManager == true)
            {
                Console.WriteLine("2. Categories");
            }
            
            Console.WriteLine("3. Help");
            Console.WriteLine("4. Logout");
            Console.WriteLine("5. Enter Product Code");
            
            if (_cart.Items.Count > 0)
            {
                Console.WriteLine("6. View Cart");
                Console.WriteLine("7. Pay");
            }
            
            Console.Write("\nSelect an option: ");
            var option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    ShowProductsMenu();
                    break;
                case "2":
                    if (_currentUser?.IsManager == true)
                    {
                        ShowCategoriesMenu();
                    }
                    break;
                case "3":
                    ShowHelp();
                    break;
                case "4":
                    Logout();
                    break;
                case "5":
                    EnterProductCode();
                    break;
                case "6":
                    if (_cart.Items.Count > 0)
                    {
                        ViewCart();
                    }
                    break;
                case "7":
                    if (_cart.Items.Count > 0)
                    {
                        ProcessPayment();
                    }
                    break;
            }
        }
        
        private void ShowProductsMenu()
        {
            Console.Clear();
            Console.WriteLine("Products");
            Console.WriteLine("========");
            
            var products = _productRepository.GetAllProducts();
            
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                Console.WriteLine("ID | Code | Name | Price | Category | Stock");
                Console.WriteLine("--------------------------------------------");
                
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id} | {product.Code} | {product.Name} | {product.Price:C} | {product.Category?.Name} | {product.StockQuantity}");
                }
            }
            
            if (_currentUser?.IsManager == true)
            {
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Edit Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Back to Main Menu");
                
                Console.Write("\nSelect an option: ");
                var option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        EditProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPress any key to go back to the main menu.");
                Console.ReadKey();
            }
        }
        
        private void ShowCategoriesMenu()
        {
            Console.Clear();
            Console.WriteLine("Categories");
            Console.WriteLine("==========");
            
            var categories = _categoryRepository.GetAllCategories();
            
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories found.");
            }
            else
            {
                Console.WriteLine("ID | Name | Description");
                Console.WriteLine("------------------------");
                
                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} | {category.Name} | {category.Description}");
                }
            }
            
            Console.WriteLine("\n1. Add Category");
            Console.WriteLine("2. Edit Category");
            Console.WriteLine("3. Delete Category");
            Console.WriteLine("4. Back to Main Menu");
            
            Console.Write("\nSelect an option: ");
            var option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    AddCategory();
                    break;
                case "2":
                    EditCategory();
                    break;
                case "3":
                    DeleteCategory();
                    break;
            }
        }
        
        private void ShowHelp()
        {
            Console.Clear();
            Console.WriteLine("Help");
            Console.WriteLine("====");
            
            Console.WriteLine("This is a Point of Sale (POS) system with the following features:");
            Console.WriteLine("- User authentication with different roles (Manager, Cashier)");
            Console.WriteLine("- Product management (add, edit, delete)");
            Console.WriteLine("- Category management (add, edit, delete)");
            Console.WriteLine("- Sales processing with cart functionality");
            Console.WriteLine("- Receipt printing");
            
            Console.WriteLine("\nPress any key to go back to the main menu.");
            Console.ReadKey();
        }
        
        private void Logout()
        {
            _currentUser = null;
            _cart.Clear();
        }
        
        private void EnterProductCode()
        {
            Console.Clear();
            Console.WriteLine("Enter Product Code");
            Console.WriteLine("=================");
            
            Console.Write("Product Code: ");
            var code = Console.ReadLine();
            
            if (string.IsNullOrEmpty(code))
            {
                Console.WriteLine("Product code cannot be empty. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var product = _productRepository.GetProductByCode(code);
            
            if (product == null)
            {
                Console.WriteLine($"Product with code '{code}' not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (product.StockQuantity <= 0)
            {
                Console.WriteLine($"Product '{product.Name}' is out of stock. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            Console.Write($"Quantity (default: 1): ");
            var quantityInput = Console.ReadLine();
            
            int quantity = 1;
            if (!string.IsNullOrEmpty(quantityInput) && int.TryParse(quantityInput, out int parsedQuantity))
            {
                quantity = parsedQuantity;
            }
            
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (quantity > product.StockQuantity)
            {
                Console.WriteLine($"Only {product.StockQuantity} items available in stock. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            _cart.AddItem(product, quantity);
            Console.WriteLine($"Added {quantity} x {product.Name} to cart. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void ViewCart()
        {
            Console.Clear();
            Console.WriteLine("Shopping Cart");
            Console.WriteLine("=============");
            
            if (_cart.Items.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                Console.WriteLine("Product | Quantity | Unit Price | Total");
                Console.WriteLine("----------------------------------------");
                
                foreach (var item in _cart.Items)
                {
                    Console.WriteLine($"{item.Product?.Name} | {item.Quantity} | {item.UnitPrice:C} | {item.TotalPrice:C}");
                }
                
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Total Amount: {_cart.TotalAmount:C}");
            }
            
            Console.WriteLine("\n1. Update Quantity");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Clear Cart");
            Console.WriteLine("4. Back to Main Menu");
            
            Console.Write("\nSelect an option: ");
            var option = Console.ReadLine();
            
            switch (option)
            {
                case "1":
                    UpdateCartItemQuantity();
                    break;
                case "2":
                    RemoveCartItem();
                    break;
                case "3":
                    _cart.Clear();
                    break;
            }
        }
        
        private void UpdateCartItemQuantity()
        {
            if (_cart.Items.Count == 0)
            {
                Console.WriteLine("Cart is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Enter product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            
            if (item == null)
            {
                Console.WriteLine("Product not found in cart. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.Write($"Enter new quantity (current: {item.Quantity}): ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var product = _productRepository.GetProductByCode(item.Product?.Code ?? string.Empty);
            
            if (product == null)
            {
                Console.WriteLine("Product not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (quantity > product.StockQuantity)
            {
                Console.WriteLine($"Only {product.StockQuantity} items available in stock. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            _cart.UpdateQuantity(productId, quantity);
            Console.WriteLine($"Updated quantity to {quantity}. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void RemoveCartItem()
        {
            if (_cart.Items.Count == 0)
            {
                Console.WriteLine("Cart is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Enter product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            
            if (item == null)
            {
                Console.WriteLine("Product not found in cart. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            _cart.RemoveItem(productId);
            Console.WriteLine($"Removed {item.Product?.Name} from cart. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void ProcessPayment()
        {
            Console.Clear();
            Console.WriteLine("Payment");
            Console.WriteLine("=======");
            
            Console.WriteLine($"Total Amount: {_cart.TotalAmount:C}");
            
            Console.Write("Amount Paid: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amountPaid))
            {
                Console.WriteLine("Invalid amount. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (amountPaid < _cart.TotalAmount)
            {
                Console.WriteLine($"Insufficient payment. Please pay at least {_cart.TotalAmount:C}. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var sale = new Sale
            {
                SaleDate = DateTime.Now,
                UserId = _currentUser?.Id ?? 0,
                TotalAmount = _cart.TotalAmount,
                AmountPaid = amountPaid
            };
            
            foreach (var item in _cart.Items)
            {
                sale.Items.Add(new SaleItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            }
            
            var saleId = _saleRepository.CreateSale(sale);
            
            Console.WriteLine($"Payment successful. Sale ID: {saleId}");
            Console.WriteLine($"Change: {(amountPaid - _cart.TotalAmount):C}");
            
            PrintReceipt(saleId);
            
            _cart.Clear();
            
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        
        private void PrintReceipt(int saleId)
        {
            var sale = _saleRepository.GetSaleById(saleId);
            
            if (sale == null)
            {
                Console.WriteLine("Error retrieving sale information for receipt.");
                return;
            }
            
            Console.WriteLine("\nReceipt");
            Console.WriteLine("=======");
            Console.WriteLine($"Sale ID: {sale.Id}");
            Console.WriteLine($"Date: {sale.SaleDate}");
            Console.WriteLine($"Cashier: {sale.User?.Name}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Product | Quantity | Unit Price | Total");
            Console.WriteLine("----------------------------------------");
            
            foreach (var item in sale.Items)
            {
                Console.WriteLine($"{item.Product?.Name} | {item.Quantity} | {item.UnitPrice:C} | {item.TotalPrice:C}");
            }
            
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Total Amount: {sale.TotalAmount:C}");
            Console.WriteLine($"Amount Paid: {sale.AmountPaid:C}");
            Console.WriteLine($"Change: {sale.ChangeAmount:C}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Thank you for your purchase!");
        }
        
        private void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("Add Product");
            Console.WriteLine("===========");
            
            Console.Write("Code: ");
            var code = Console.ReadLine();
            
            if (string.IsNullOrEmpty(code))
            {
                Console.WriteLine("Code cannot be empty. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var existingProduct = _productRepository.GetProductByCode(code);
            
            if (existingProduct != null)
            {
                Console.WriteLine($"Product with code '{code}' already exists. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var categories = _categoryRepository.GetAllCategories();
            
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories found. Please add a category first. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("\nCategories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }
            
            Console.Write("\nCategory ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var category = categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (category == null)
            {
                Console.WriteLine("Category not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Stock Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stockQuantity))
            {
                Console.WriteLine("Invalid stock quantity. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            if (stockQuantity < 0)
            {
                Console.WriteLine("Stock quantity cannot be negative. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var product = new Product
            {
                Code = code,
                Name = name,
                Price = price,
                CategoryId = categoryId,
                StockQuantity = stockQuantity
            };
            
            _productRepository.AddProduct(product);
            
            Console.WriteLine($"Product '{name}' added successfully. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void EditProduct()
        {
            Console.Clear();
            Console.WriteLine("Edit Product");
            Console.WriteLine("============");
            
            Console.Write("Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var products = _productRepository.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == productId);
            
            if (product == null)
            {
                Console.WriteLine("Product not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Editing product: {product.Name} (ID: {product.Id})");
            Console.WriteLine("Leave blank to keep the current value.");
            
            Console.Write($"Code [{product.Code}]: ");
            var code = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(code) && code != product.Code)
            {
                var existingProduct = _productRepository.GetProductByCode(code);
                
                if (existingProduct != null && existingProduct.Id != productId)
                {
                    Console.WriteLine($"Product with code '{code}' already exists. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
                
                product.Code = code;
            }
            
            Console.Write($"Name [{product.Name}]: ");
            var name = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(name))
            {
                product.Name = name;
            }
            
            Console.Write($"Price [{product.Price}]: ");
            var priceInput = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(priceInput) && decimal.TryParse(priceInput, out decimal price))
            {
                if (price <= 0)
                {
                    Console.WriteLine("Price must be greater than 0. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
                
                product.Price = price;
            }
            
            var categories = _categoryRepository.GetAllCategories();
            
            Console.WriteLine("\nCategories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }
            
            Console.Write($"\nCategory ID [{product.CategoryId}]: ");
            var categoryIdInput = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(categoryIdInput) && int.TryParse(categoryIdInput, out int categoryId))
            {
                var category = categories.FirstOrDefault(c => c.Id == categoryId);
                
                if (category == null)
                {
                    Console.WriteLine("Category not found. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
                
                product.CategoryId = categoryId;
            }
            
            Console.Write($"Stock Quantity [{product.StockQuantity}]: ");
            var stockQuantityInput = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(stockQuantityInput) && int.TryParse(stockQuantityInput, out int stockQuantity))
            {
                if (stockQuantity < 0)
                {
                    Console.WriteLine("Stock quantity cannot be negative. Press any key to try again.");
                    Console.ReadKey();
                    return;
                }
                
                product.StockQuantity = stockQuantity;
            }
            
            _productRepository.UpdateProduct(product);
            
            Console.WriteLine($"Product '{product.Name}' updated successfully. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("Delete Product");
            Console.WriteLine("==============");
            
            Console.Write("Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var products = _productRepository.GetAllProducts();
            var product = products.FirstOrDefault(p => p.Id == productId);
            
            if (product == null)
            {
                Console.WriteLine("Product not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Are you sure you want to delete product '{product.Name}' (ID: {product.Id})? (Y/N)");
            var confirmation = Console.ReadLine()?.ToUpper();
            
            if (confirmation == "Y")
            {
                _productRepository.DeleteProduct(productId);
                Console.WriteLine($"Product '{product.Name}' deleted successfully. Press any key to continue.");
                Console.ReadKey();
            }
        }
        
        private void AddCategory()
        {
            Console.Clear();
            Console.WriteLine("Add Category");
            Console.WriteLine("===========");
            
            Console.Write("Name: ");
            var name = Console.ReadLine();
            
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name cannot be empty. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Description: ");
            var description = Console.ReadLine();
            
            var category = new Category
            {
                Name = name,
                Description = description ?? string.Empty
            };
            
            _categoryRepository.AddCategory(category);
            
            Console.WriteLine($"Category '{name}' added successfully. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void EditCategory()
        {
            Console.Clear();
            Console.WriteLine("Edit Category");
            Console.WriteLine("============");
            
            Console.Write("Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var categories = _categoryRepository.GetAllCategories();
            var category = categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (category == null)
            {
                Console.WriteLine("Category not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Editing category: {category.Name} (ID: {category.Id})");
            Console.WriteLine("Leave blank to keep the current value.");
            
            Console.Write($"Name [{category.Name}]: ");
            var name = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(name))
            {
                category.Name = name;
            }
            
            Console.Write($"Description [{category.Description}]: ");
            var description = Console.ReadLine();
            
            if (description != null)
            {
                category.Description = description;
            }
            
            _categoryRepository.UpdateCategory(category);
            
            Console.WriteLine($"Category '{category.Name}' updated successfully. Press any key to continue.");
            Console.ReadKey();
        }
        
        private void DeleteCategory()
        {
            Console.Clear();
            Console.WriteLine("Delete Category");
            Console.WriteLine("==============");
            
            Console.Write("Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var categories = _categoryRepository.GetAllCategories();
            var category = categories.FirstOrDefault(c => c.Id == categoryId);
            
            if (category == null)
            {
                Console.WriteLine("Category not found. Press any key to try again.");
                Console.ReadKey();
                return;
            }
            
            var products = _productRepository.GetAllProducts();
            var productsInCategory = products.Count(p => p.CategoryId == categoryId);
            
            if (productsInCategory > 0)
            {
                Console.WriteLine($"Cannot delete category '{category.Name}' because it contains {productsInCategory} products.");
                Console.WriteLine("Please delete or reassign the products first. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine($"Are you sure you want to delete category '{category.Name}' (ID: {category.Id})? (Y/N)");
            var confirmation = Console.ReadLine()?.ToUpper();
            
            if (confirmation == "Y")
            {
                _categoryRepository.DeleteCategory(categoryId);
                Console.WriteLine($"Category '{category.Name}' deleted successfully. Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
} 