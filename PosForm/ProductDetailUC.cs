using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosLibrary.model;

namespace PosForm
{
    public partial class ProductDetailUC : UserControl
    {
        public ProductDetailUC(Product product)
        {
            InitializeComponent();
            LoadingProductUC(product);
        }

        private void LoadingProductUC(Product product)
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
            
            ProductName.Text = product.Name;
        }

        public event EventHandler editBtnClicked;
        private void editBtn_Click(object sender, EventArgs e)
        {
            editBtnClicked?.Invoke(this, e);
        }

        public event EventHandler deleteBtnClicked;
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteBtnClicked?.Invoke(this, e);
        }
    }
}
