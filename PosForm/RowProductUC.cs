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
using PosLibrary.serve;

namespace PosForm
{
    public partial class RowProductUC : UserControl
    {
        Product product;
        public RowProductUC(Product product)
        {
            this.product = product;
            InitializeComponent();
            LoadingRowProductUC();
        }
        public void LoadingRowProductUC()
        {
            ProductName.Text = product.Name;
            Quantity.Text = product.Quantity.ToString();
            PriceLabel.Text = $"${product.price.ToString()}";
            DiscountLabel.Text = product.Discount.ToString();
            TotalLabel.Text = $"${(product.price * (1 - product.Discount/100) * product.Quantity).ToString()}";
        }
        public event EventHandler AddButtonClicked;
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, e);
            LoadingRowProductUC();
        }
        public event EventHandler MinusButtonClicked;
        private void MinusButton_Click(object sender, EventArgs e)
        {
            MinusButtonClicked?.Invoke(this, e);
            LoadingRowProductUC();
        }
    }
}
