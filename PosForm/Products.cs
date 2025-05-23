using PosLibrary.model;
using PosLibrary.serve;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosForm
{
    public partial class Products : Form
    {
        ProductServe productServe;
        Product UsedProduct;
        User currentUser;
        public Products(User user)
        {
            InitializeComponent();
            currentUser = user;
            string connectionString = $"Data Source=\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\PosDatabase.db\";";
            productServe = new ProductServe(connectionString);
            LoadingProducts();
            UsedProduct = new Product();
            LoadingUserRole();
        }

        private void LoadingProducts()
        {
            productsFlowPanel.Controls.Clear();
            List<Product> Products = productServe.GetProducts();
            foreach (Product Product in Products)
            {
                ProductDetailUC productDetailUC = new ProductDetailUC(Product);
                productDetailUC.editBtnClicked += (s, e) => ProductDetailUC_editBtnClicked(Product);
                productDetailUC.deleteBtnClicked += (s, e) => ProductDetailUC_deleteBtnClicked(Product);
                productsFlowPanel.Controls.Add(productDetailUC);
            }
        }

        private void LoadingUserRole()
        {
            if (currentUser.Role != 0)
            {
                addBtn.Enabled = false;
                SaveBtn.Enabled = false;
            }
        }
        private void SearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;
            List<Product> Products = productServe.SearchProductByName(searchText);
            productsFlowPanel.Controls.Clear();
            foreach (Product Product in Products)
            {
                ProductDetailUC productDetailUC = new ProductDetailUC(Product);
                productDetailUC.editBtnClicked += (s, e) => ProductDetailUC_editBtnClicked(Product);
                productDetailUC.deleteBtnClicked += (s, e) => ProductDetailUC_deleteBtnClicked(Product);
                productsFlowPanel.Controls.Add(productDetailUC);
            }
        }
        private void ProductDetailUC_editBtnClicked(Product product)
        {
            ProductIdText.Text = product.Id.ToString();
            productNameText.Text = product.Name;
            productPriceText.Text = product.price.ToString();
            productDiscountText.Text = product.Discount.ToString();
            productCategoreName.Text = product.CategoryId.ToString();

            string imageDir = Path.Combine(Application.StartupPath, "Images");
            string imageName = string.IsNullOrEmpty(product.ImagePath) ? "default.jpg" : product.ImagePath;
            string fullPath = Path.Combine(imageDir, imageName);

            if (!File.Exists(fullPath))
            {
                fullPath = Path.Combine(imageDir, "default.jpg");
            }

            if (File.Exists(fullPath))
            {
                pictureBox2.Image = Image.FromFile(fullPath);
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Зураг олдсонгүй: " + fullPath, "Анхаар!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (currentUser.Role != 0)
            {
                addBtn.Enabled = false;
                SaveBtn.Enabled = false;
            }
            else
            {
                SaveBtn.Enabled = true;
            }
        }

        private void ProductDetailUC_deleteBtnClicked(Product product)
        {
            DialogResult result = MessageBox.Show(
                "Та устгахдаа итгэлтэй байна уу?",
                "Баталгаажуулалт",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (currentUser.Role != 0) { }
            else {
                if (result == DialogResult.Yes)
                {
                    productServe.DeleteProduct(product);
                    LoadingProducts();
                }      
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сонгосон зургийг PictureBox-д харуулах
                pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // зургыг хэмжээнд тааруулж сунгана
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var products = productServe.GetProducts();
            int nextId = 1;

            if (products.Any())
            {
                nextId = products.Max(p => p.Id) + 1;
            }

            ProductIdText.Text = nextId.ToString();
            productNameText.Text = "";
            productPriceText.Text = "";
            productDiscountText.Text = "";
            productCategoreName.Text = "";
            

            SaveBtn.Enabled = true;

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var products = productServe.GetProducts();
            int MaxId = 1;
            int currentID = int.Parse(ProductIdText.Text);
            UsedProduct.Id = currentID;
            UsedProduct.price = int.Parse(productPriceText.Text);
            UsedProduct.Name = productNameText.Text;
            UsedProduct.CategoryId = int.Parse(productCategoreName.Text);
            UsedProduct.Discount = int.Parse(productDiscountText.Text);

            if (pictureBox2.Image != null)
            {
                string imageDir = Path.Combine(Application.StartupPath, "Images");
                Directory.CreateDirectory(imageDir); // хавтсыг үүсгэнэ

                string fileName = $"product_{ProductIdText.Text}.jpg";
                string fullPath = Path.Combine(imageDir, fileName);

                pictureBox2.Image.Save(fullPath); // зургаа хадгалах

                UsedProduct.ImagePath = fileName; // зөвхөн нэрийг хадгалах
            } else { UsedProduct.ImagePath = "default.jpg"; }

            if (products.Any())
            {
                MaxId = products.Max(p => p.Id);
            }

            if (MaxId < currentID)
            {
                productServe.AddProduct(UsedProduct);
                MessageBox.Show("Амжилттай burtgelee!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                productServe.UpdateProduct(UsedProduct);
                MessageBox.Show("Амжилттай shinchillee!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            SaveBtn.Enabled = false;

            LoadingProducts();
        }
    }
}
