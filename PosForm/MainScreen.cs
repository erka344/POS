using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//using Microsoft.EntityFrameworkCore.Storage;
using PosLibrary.serve;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace PosForm
{
    public partial class MainScreen : Form
    {

        DataBase Testdb;

        public MainScreen()
        {
            
            //InitializeComponent();
            //initialProductPanel();
            //testProductPanel();

            //Testdb = new DataBase();       
            


            //data.InitialData();
        }
        private void initialProductPanel()
        {
            // Row 0 дээр column-ийн нэрсийг Label-ээр тавина
            Label col1 = new Label();
            col1.Text = "Item name";
            col1.TextAlign = ContentAlignment.MiddleCenter;
            //col1.Dock = DockStyle.Fill;
            col1.Font = new Font("Arial", 10, FontStyle.Bold);

            Label col2 = new Label();
            col2.Text = "Quantity";
            col2.TextAlign = ContentAlignment.MiddleCenter;
            //col2.Dock = DockStyle.Fill;
            col2.Font = new Font("Arial", 10, FontStyle.Bold);

            Label col3 = new Label();
            col3.Text = "U/price";
            col3.TextAlign = ContentAlignment.MiddleCenter;
            //col3.Dock = DockStyle.Fill;
            col3.Font = new Font("Arial", 10, FontStyle.Bold);

            Label col4 = new Label();
            col4.Text = "Dis%";
            col4.TextAlign = ContentAlignment.MiddleCenter;
            //col4.Dock = DockStyle.Fill;
            col4.Font = new Font("Arial", 10, FontStyle.Bold);

            Label col5 = new Label();
            col5.Text = "Total";
            col5.TextAlign = ContentAlignment.MiddleCenter;
            //col5.Dock = DockStyle.Fill;
            col5.Font = new Font("Arial", 10, FontStyle.Bold);

            // Хамгийн эхний мөрөнд (row 0) column header тавина
            productTable.Controls.Add(col1, 0, 0); // Column 0
            productTable.Controls.Add(col2, 1, 0); // Column 1
            productTable.Controls.Add(col3, 2, 0); // Column 2
            productTable.Controls.Add(col4, 3, 0);
            productTable.Controls.Add(col5, 4, 0);

        }
        private void LoadProductInProductPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(180, 210),
            };

            // Calculate the location based on the number of existing panels
            int panelsCount = productsPanel.Controls.Count;
            int spacing = 10;
            panel.Location = new Point((180 + spacing) * panelsCount, 3);

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(160, 125),
                Location = new Point(12, 12),
                BorderStyle = BorderStyle.FixedSingle,
            };

            Label ProductNameLabel = new Label
            {
                Text = "Product name",
                AutoSize = true, // AutoSize the label
                Location = new Point(44, 142),
            };

            Button AddBtn = new Button
            {
                Text = "Add",
                Size = new Size(150, 30),
                Location = new Point(13, 175),
            };
            AddBtn.Click += (s, e) =>
            {
                addProductToProductTable("Croissant", 2.99m);
            };

            //Button EditBtn = new Button
            //{
            //    Text = "Edit",
            //    Size = new Size(72, 30),
            //    Location = new Point(100, 175),
            //};

            panel.Controls.Add(pictureBox);
            panel.Controls.Add(ProductNameLabel);
            panel.Controls.Add(AddBtn);
            //panel.Controls.Add(EditBtn);
            productsPanel.Controls.Add(panel);

            productsPanel.FlowDirection = FlowDirection.LeftToRight;
            productsPanel.WrapContents = false;
            productsPanel.AutoScroll = true;
        }

        private void testProductPanel()
        {
            for (int i = 0; i < 20; i++)
            {
                LoadProductInProductPanel();
                LoadCategoriesInCategoriesPanel();
            }
        }
        private void LoadCategoriesInCategoriesPanel()
        {
            Button categoreBtn = new Button
            {
                Text = "categore name",
                Size = new Size(120, 90),
                ForeColor = Color.Blue,
            };

            categoriesPanel.Controls.Add(categoreBtn);

            categoriesPanel.FlowDirection = FlowDirection.TopDown;
            categoriesPanel.WrapContents = true;
            categoriesPanel.AutoScroll = true;

        }
        private void addProductToProductTable(string itemName, decimal price)
        {
            int rowIndex = productTable.RowCount++;

            // Шинэ мөр нэмэх
            productTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            // Item Name
            Label nameLabel = new Label
            {
                Text = itemName,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            // Quantity
            Panel quantityPanel = new Panel
            {
                Dock = DockStyle.Fill
            };
            TextBox quantityTextBox = new TextBox
            {
                Text = "1",
                Width = 30,
                Location = new Point(40, 5)
            };
            Button plusButton = new Button
            {
                Text = "+",
                Width = 30,
                Location = new Point(5, 5)
            };
            Button minusButton = new Button
            {
                Text = "-",
                Width = 30,
                Location = new Point(75, 5)
            };

            quantityPanel.Controls.Add(quantityTextBox);
            quantityPanel.Controls.Add(plusButton);
            quantityPanel.Controls.Add(minusButton);

            // Unit Price
            Label priceLabel = new Label
            {
                Text = $"${price:F2}",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            // Discount
            Label discountLabel = new Label
            {
                Text = "0%",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            // Total
            Label totalLabel = new Label
            {
                Text = $"${price:F2}",
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            // "+" товч дарахад
            plusButton.Click += (s, e) =>
            {
                int qty = int.Parse(quantityTextBox.Text);
                qty++;
                quantityTextBox.Text = qty.ToString();
                totalLabel.Text = $"${(qty * price):F2}";
                minusButton.Enabled = true;
            };

            // "-" товч дарахад
            minusButton.Click += (s, e) =>
            {
                int qty = int.Parse(quantityTextBox.Text);
                if (qty > 1)
                {
                    qty--;
                    quantityTextBox.Text = qty.ToString();
                    totalLabel.Text = $"${(qty * price):F2}";
                }
                else
                {
                    minusButton.Enabled = false;
                }
            };

            // TableLayoutPanel дээр нэмэх
            productTable.Controls.Add(nameLabel, 0, productTable.RowCount - 1);
            productTable.Controls.Add(quantityPanel, 1, productTable.RowCount - 1);
            productTable.Controls.Add(priceLabel, 2, productTable.RowCount - 1);
            productTable.Controls.Add(discountLabel, 3, productTable.RowCount - 1);
            productTable.Controls.Add(totalLabel, 4, productTable.RowCount - 1);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void categoriesPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void PayButton_Click_1(object sender, EventArgs e)
        {
            Form payment = new Payment();
            payment.ShowDialog();
        }
    }
}
