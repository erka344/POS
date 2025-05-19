using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PosLibrary.model;
using PosLibrary.serve;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PosForm
{
    public partial class MainScreen : Form
    {
        private string ConnectionString;
        private ProductServe productServe;
        private CartServe cartServe;
        private ProductCategoryServe productCategoryServe;

        public string DbPath = "\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\PosDatabase.db\"";


        DataBase Testdb;
        

        public MainScreen()
        {

            InitializeComponent();
            ConnectionString = $"Data Source={DbPath};";
            productServe = new ProductServe(ConnectionString);
            cartServe = new CartServe(ConnectionString);
            productCategoryServe = new ProductCategoryServe(ConnectionString);

            // Test data ачааллах
            LoadProductsToUI();
            LoadCategoriesInCategoriesPanel();

        }
        private void LoadProductsToUI()
        {
            List<Product> products = productServe.GetProducts();

            foreach (var product in products)
            {
                ProductUC productUC = new ProductUC(product);
                productUC.AddToCartBtnClicked += (s, e) => AddProductToProductFlowPanel(product);
                productsPanel.Controls.Add(productUC);
            }

            productsPanel.FlowDirection = FlowDirection.LeftToRight;
            productsPanel.WrapContents = false;
            productsPanel.AutoScroll = true;
        }

        public void AddProductToProductFlowPanel(Product product)
        {
            cartServe.AddProductToCart(product);
            ReloadCartPanel();
        }

        private void ReloadCartPanel()
        {
            ProductFlowPanel.Controls.Clear(); 

            foreach (var product in cartServe.Products)
            {
                RowProductUC row = new RowProductUC(product);

                row.AddButtonClicked += (s, e) =>
                {
                    cartServe.AddQuantity(product.Name);
                    ReloadCartPanel();
                };

                row.MinusButtonClicked += (s, e) =>
                {
                    cartServe.MinusQuantity(product.Name);
                    ReloadCartPanel();
                };

                row.LoadingRowProductUC();
                ProductFlowPanel.Controls.Add(row);
            }
            TotalPriceLabel.Text = $"${cartServe.CalculateTotal()}";
        }
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            
            string keyword = SearchTextBox.Text;
            var filteredProducts = productServe.SearchProductByName(keyword);

            productsPanel.Controls.Clear();
            foreach (var product in filteredProducts)
            {
                var productUC = new ProductUC(product);
                productUC.AddToCartBtnClicked += (s, e2) => AddProductToProductFlowPanel(product);
                productsPanel.Controls.Add(productUC);
            }
        }

        private void LoadCategoriesInCategoriesPanel()
        {
            foreach (var category in productCategoryServe.GetAllProductCategory())
            {
                Button categoryBtn = new Button
                {
                    Text = category.Name,
                    Size = new Size(120, 90),
                    ForeColor = Color.Blue,
                };
                categoriesPanel.Controls.Add(categoryBtn);
                categoryBtn.Click += (s, e) => LoadingProductsInCategoriesPanel(category.Id) ;
            }
            
            categoriesPanel.FlowDirection = FlowDirection.TopDown;
            categoriesPanel.WrapContents = true;
            categoriesPanel.AutoScroll = true;

        }
        private void LoadingProductsInCategoriesPanel(int categoryId)
        {
            List<Product> products = productServe.GetProductByCategory(categoryId);
            productsPanel.Controls.Clear();
            foreach (var product in products)
            {
                ProductUC productUC = new ProductUC(product);
                productUC.AddToCartBtnClicked += (s, e) => AddProductToProductFlowPanel(product);
                productsPanel.Controls.Add(productUC);
            }

            productsPanel.FlowDirection = FlowDirection.LeftToRight;
            productsPanel.WrapContents = false;
            productsPanel.AutoScroll = true;
        }
        private void addProductToProductTable(string itemName, decimal price)
        {

        }


        private void categoriesPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void MainScreen_Load(object sender, EventArgs e)
        {
            //testProductPanel();

        }

        private void PayButton_Click_1(object sender, EventArgs e)
        {
            int totalPrice = cartServe.CalculateTotal();
            Form payment = new Payment(totalPrice);
            payment.ShowDialog();
        }

      

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
