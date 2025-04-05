using System;
using System.Windows.Forms;
using Pos.Data;
using Pos.Models;
using Pos.Repositories;

namespace Pos.UI
{
    public class MainForm : Form
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository _userRepository;
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly SaleRepository _saleRepository;
        
        private User? _currentUser;
        private Cart _cart;
        
        private Panel mainPanel;
        private Panel loginPanel;
        private Panel productsPanel;
        private Panel cartPanel;
        private Panel categoriesPanel;
        
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        
        private DataGridView productsGridView;
        private DataGridView cartGridView;
        private DataGridView categoriesGridView;
        
        public MainForm()
        {
            _context = new ApplicationDbContext();
            _userRepository = new UserRepository(_context);
            _productRepository = new ProductRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _saleRepository = new SaleRepository(_context);
            _cart = new Cart();
            
            InitializeComponents();
            ShowLoginPanel();
        }
        
        private void InitializeComponents()
        {
            this.Text = "POS System";
            this.Size = new Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Main Panel
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(mainPanel);
            
            // Login Panel
            loginPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            
            usernameTextBox = new TextBox
            {
                Location = new Point(400, 300),
                Size = new Size(200, 25)
            };
            
            passwordTextBox = new TextBox
            {
                Location = new Point(400, 340),
                Size = new Size(200, 25),
                PasswordChar = '*'
            };
            
            loginButton = new Button
            {
                Text = "Login",
                Location = new Point(450, 380),
                Size = new Size(100, 30)
            };
            loginButton.Click += LoginButton_Click;
            
            loginPanel.Controls.AddRange(new Control[] { usernameTextBox, passwordTextBox, loginButton });
            mainPanel.Controls.Add(loginPanel);
            
            // Products Panel
            productsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            
            productsGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            
            productsPanel.Controls.Add(productsGridView);
            mainPanel.Controls.Add(productsPanel);
            
            // Cart Panel
            cartPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            
            cartGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            
            cartPanel.Controls.Add(cartGridView);
            mainPanel.Controls.Add(cartPanel);
            
            // Categories Panel
            categoriesPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            
            categoriesGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            
            categoriesPanel.Controls.Add(categoriesGridView);
            mainPanel.Controls.Add(categoriesPanel);
        }
        
        private void ShowLoginPanel()
        {
            HideAllPanels();
            loginPanel.Visible = true;
        }
        
        private void ShowProductsPanel()
        {
            HideAllPanels();
            productsPanel.Visible = true;
            LoadProducts();
        }
        
        private void ShowCartPanel()
        {
            HideAllPanels();
            cartPanel.Visible = true;
            LoadCart();
        }
        
        private void ShowCategoriesPanel()
        {
            HideAllPanels();
            categoriesPanel.Visible = true;
            LoadCategories();
        }
        
        private void HideAllPanels()
        {
            loginPanel.Visible = false;
            productsPanel.Visible = false;
            cartPanel.Visible = false;
            categoriesPanel.Visible = false;
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;
            
            _currentUser = _userRepository.Authenticate(username, password);
            
            if (_currentUser != null)
            {
                ShowProductsPanel();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void LoadProducts()
        {
            var products = _productRepository.GetAllProducts();
            productsGridView.DataSource = products;
        }
        
        private void LoadCart()
        {
            cartGridView.DataSource = _cart.Items;
        }
        
        private void LoadCategories()
        {
            var categories = _categoryRepository.GetAllCategories();
            categoriesGridView.DataSource = categories;
        }
    }
} 