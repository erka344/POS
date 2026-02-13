namespace PosForm
{
    partial class RowProductUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductName = new Label();
            MinusButton = new Button();
            AddButton = new Button();
            Quantity = new Label();
            PriceLabel = new Label();
            DiscountLabel = new Label();
            TotalLabel = new Label();
            SuspendLayout();
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.Location = new Point(3, 12);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(101, 20);
            ProductName.TabIndex = 0;
            ProductName.Text = "Product name";
            // 
            // MinusButton
            // 
            MinusButton.Location = new Point(156, 8);
            MinusButton.Name = "MinusButton";
            MinusButton.Size = new Size(28, 29);
            MinusButton.TabIndex = 1;
            MinusButton.Text = "-";
            MinusButton.UseVisualStyleBackColor = true;
            MinusButton.Click += MinusButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(246, 8);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(28, 29);
            AddButton.TabIndex = 2;
            AddButton.Text = "+";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += this.AddButton_Click;
            // 
            // Quantity
            // 
            Quantity.AutoSize = true;
            Quantity.Location = new Point(206, 12);
            Quantity.Name = "Quantity";
            Quantity.Size = new Size(20, 20);
            Quantity.TabIndex = 3;
            Quantity.Text = "N";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(312, 12);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(50, 20);
            PriceLabel.TabIndex = 4;
            PriceLabel.Text = "$price";
            // 
            // DiscountLabel
            // 
            DiscountLabel.AutoSize = true;
            DiscountLabel.Location = new Point(398, 12);
            DiscountLabel.Name = "DiscountLabel";
            DiscountLabel.Size = new Size(67, 20);
            DiscountLabel.TabIndex = 5;
            DiscountLabel.Text = "Discount";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Location = new Point(488, 12);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(42, 20);
            TotalLabel.TabIndex = 6;
            TotalLabel.Text = "Total";
            // 
            // RowProductUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TotalLabel);
            Controls.Add(DiscountLabel);
            Controls.Add(PriceLabel);
            Controls.Add(Quantity);
            Controls.Add(AddButton);
            Controls.Add(MinusButton);
            Controls.Add(ProductName);
            Name = "RowProductUC";
            Size = new Size(531, 49);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductName;
        private Button MinusButton;
        private Button AddButton;
        private Label Quantity;
        private Label PriceLabel;
        private Label DiscountLabel;
        private Label TotalLabel;
    }
}
