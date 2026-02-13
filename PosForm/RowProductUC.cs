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
            InitCustomButtons();
        }
        public void LoadingRowProductUC()
        {
            ProductName.Text = product.Name;
            Quantity.Text = product.Quantity.ToString();
            PriceLabel.Text = $"${product.price.ToString()}";
            DiscountLabel.Text = product.Discount.ToString();
            TotalLabel.Text = $"${(product.price * (1 - product.Discount/100) * product.Quantity).ToString()}";
        }

        private void InitCustomButtons()
        {
            // Add Button
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.FlatAppearance.BorderSize = 0;
            AddButton.Text = "";
            AddButton.BackColor = Color.Transparent;
            AddButton.Paint += AddButton_Paint;

            // Minus Button
            MinusButton.FlatStyle = FlatStyle.Flat;
            MinusButton.FlatAppearance.BorderSize = 0;
            MinusButton.Text = "";
            MinusButton.BackColor = Color.Transparent;
            MinusButton.Paint += MinusButton_Paint;
        }

        private void AddButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = ((Button)sender).ClientRectangle;
            using (Brush brush = new SolidBrush(Color.LightGreen))
            {
                e.Graphics.FillEllipse(brush, rect);
            }

            using (Pen pen = new Pen(Color.White, 2))
            {
                int cx = rect.Width / 2;
                int cy = rect.Height / 2;
                e.Graphics.DrawLine(pen, cx, cy - 6, cx, cy + 6);
                e.Graphics.DrawLine(pen, cx - 6, cy, cx + 6, cy);
            }
        }

        // Paint Minus Button (–)
        private void MinusButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Rectangle rect = ((Button)sender).ClientRectangle;
            using (Brush brush = new SolidBrush(Color.MediumVioletRed))
            {
                e.Graphics.FillEllipse(brush, rect);
            }

            using (Pen pen = new Pen(Color.White, 2))
            {
                int cx = rect.Width / 2;
                int cy = rect.Height / 2;
                e.Graphics.DrawLine(pen, cx - 6, cy, cx + 6, cy);
            }
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
