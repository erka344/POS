using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PosLibrary.model;

namespace PosForm
{
    public partial class ProductUC : UserControl
    {
        private Product product;
        public ProductUC(Product product)
        {
            this.product = product;
            InitializeComponent();
            LoadingProductUC();
        }

        private void LoadingProductUC()
        {
            string imageName = string.IsNullOrEmpty(product.ImagePath) ? "default.jpg" : product.ImagePath;
            string fullPath = Path.Combine(Application.StartupPath, "Images", imageName);

            if (File.Exists(fullPath))
            {
                ProductImage.Image = Image.FromFile(fullPath);
                ProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                ProductImage.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", "default.jpg"));
            }
            ProductPriceLabel.Text = $"${product.price}";
            ProductName.Text = product.Name;
        }


        public event EventHandler AddToCartBtnClicked;
        public void AddToCartBtn_Click(object sender, EventArgs e)
        {
            AddToCartBtnClicked?.Invoke(this, EventArgs.Empty);
        }

    }
}
