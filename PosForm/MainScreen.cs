using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PosLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PosForm
{
    public partial class MainScreen : Form
    {
        private FlowLayoutPanel categoryPanel;
        private FlowLayoutPanel productsPanel;
        private Panel cartPanel;
        private DataGridView cartGridView;
        private Label totalPriceLabel;
        private Button profileButton;
        private TextBox searchBox;
        private Dictionary<string, int> categoryIds = new Dictionary<string, int>();
        private Cart currentCart;
        private readonly IDatabaseHelper databaseHelper;
        private data datas;
        

        public MainScreen()
        {
            InitializeComponent();
            databaseHelper = new DatabaseHelper();
            datas = new data();
            databaseHelper.InitializeDatabase();
            InitializeUI();
            InitializeDatabase();
            LoadCategories();
            InitializeCart();
        }

        private void InitializeDatabase()
        {
            datas.InitializeDatabase(databaseHelper);
        }

        private void InitializeUI()
        {
            // Main layout
            this.Size = new Size(1200, 800);
            this.Text = "POS System";

            // Search box
            searchBox = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(200, 30),
                PlaceholderText = "Search products..."
            };
            searchBox.TextChanged += SearchBox_TextChanged;
            this.Controls.Add(searchBox);

            // Categories panel
            categoryPanel = new FlowLayoutPanel
            {
                Location = new Point(10, 50),
                Size = new Size(800, 200),
                AutoScroll = true
            };
            this.Controls.Add(categoryPanel);

            // Products panel
            productsPanel = new FlowLayoutPanel
            {
                Location = new Point(10, 260),
                Size = new Size(800, 500),
                AutoScroll = true
            };
            this.Controls.Add(productsPanel);

            // Profile button
            profileButton = new Button
            {
                Location = new Point(1100, 10),
                Size = new Size(40, 40),
                Text = "👤"
            };
            this.Controls.Add(profileButton);
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                productsPanel.Controls.Clear();
                return;
            }

            // Search in all categories
            productsPanel.Controls.Clear();
            foreach (var category in databaseHelper.GetCategories())
            {
                var products = databaseHelper.GetProductsByCategory(category.id)
                    .Where(p => p.name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase));

                foreach (var product in products)
                {
                    AddProductToPanel(product.id, product.name, product.price);
                }
            }
        }

        private void LoadCategories()
        {
            categoryPanel.Controls.Clear();
            foreach (var category in databaseHelper.GetCategories())
            {
                categoryIds[category.name] = category.id;
                Button categoryBtn = new Button
                {
                    Text = category.name,
                    Size = new Size(120, 80),
                    BackColor = Color.RoyalBlue,
                    ForeColor = Color.White,
                    Margin = new Padding(5),
                    FlatStyle = FlatStyle.Flat
                };
                categoryBtn.Click += (s, e) => LoadProducts(category.id);
                categoryPanel.Controls.Add(categoryBtn);
            }
        }

        private void LoadProducts(int categoryId)
        {
            productsPanel.Controls.Clear();
            var products = databaseHelper.GetProductsByCategory(categoryId);
            foreach (var product in products)
            {
                AddProductToPanel(product.id, product.name, product.price);
            }
        }

        private void AddProductToPanel(int productId, string name, decimal price)
        {
            Panel productPanel = new Panel
            {
                Size = new Size(150, 200),
                Margin = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label nameLabel = new Label
            {
                Text = name,
                Location = new Point(5, 120),
                Size = new Size(140, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label priceLabel = new Label
            {
                Text = $"${price:F2}",
                Location = new Point(5, 140),
                Size = new Size(140, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button addToCartBtn = new Button
            {
                Text = "Add to Cart",
                Location = new Point(5, 160),
                Size = new Size(140, 30)
            };
            addToCartBtn.Click += (s, e) => AddToCart(productId, name, price);

            productPanel.Controls.AddRange(new Control[] { nameLabel, priceLabel, addToCartBtn });
            productsPanel.Controls.Add(productPanel);
        }

        private void InitializeCart()
        {
            // Create a new cart
            currentCart = new Cart
            {
                CreatedDate = DateTime.Now,
                Status = CartStatus.Active
            };

            // Cart panel
            cartPanel = new Panel
            {
                Location = new Point(820, 50),
                Size = new Size(360, 710),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Cart grid
            cartGridView = new DataGridView
            {
                Location = new Point(5, 5),
                Size = new Size(350, 600),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };
            cartGridView.Columns.Add("ItemName", "Item Name");
            cartGridView.Columns.Add("Quantity", "Quantity");
            cartGridView.Columns.Add("UPrice", "U/Price");
            cartGridView.Columns.Add("Dis%", "Dis%");
            cartGridView.Columns.Add("Total", "Total");

            // Total price label
            totalPriceLabel = new Label
            {
                Location = new Point(5, 650),
                Size = new Size(350, 30),
                Text = "Total Price: $0.00",
                Font = new Font(Font.FontFamily, 12, FontStyle.Bold)
            };

            cartPanel.Controls.Add(cartGridView);
            cartPanel.Controls.Add(totalPriceLabel);
            this.Controls.Add(cartPanel);
        }

        private void LoadCartItems()
        {
            cartGridView.Rows.Clear();
            var items = databaseHelper.GetCartItems();
            foreach (var item in items)
            {
                decimal total = item.quantity * item.unitPrice * (1 - item.discount / 100);
                cartGridView.Rows.Add(
                    item.productName,
                    item.quantity,
                    item.unitPrice.ToString("C2"),
                    item.discount,
                    total.ToString("C2")
                );
            }
            UpdateTotalPrice();
        }

        private void AddToCart(int productId, string itemName, decimal price)
        {
            databaseHelper.AddToCart(productId, 1, price);
            LoadCartItems();
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in cartGridView.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    string totalStr = row.Cells["Total"].Value.ToString().Replace("$", "");
                    if (decimal.TryParse(totalStr, out decimal rowTotal))
                    {
                        total += rowTotal;
                    }
                }
            }
            totalPriceLabel.Text = $"Total Price: {total:C2}";
        }
    }
}
