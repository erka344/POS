namespace PosForm
{
    partial class ProductUC
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
            ProductImage = new PictureBox();
            ProductName = new Label();
            AddToCartBtn = new Button();
            ProductPriceLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductImage).BeginInit();
            SuspendLayout();
            // 
            // ProductImage
            // 
            ProductImage.Location = new Point(13, 16);
            ProductImage.Name = "ProductImage";
            ProductImage.Size = new Size(150, 123);
            ProductImage.TabIndex = 0;
            ProductImage.TabStop = false;
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.BackColor = Color.Transparent;
            ProductName.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            ProductName.Location = new Point(13, 142);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(53, 23);
            ProductName.TabIndex = 1;
            ProductName.Text = "label1";
            
            // 
            // AddToCartBtn
            // 
            AddToCartBtn.Location = new Point(13, 168);
            AddToCartBtn.Name = "AddToCartBtn";
            AddToCartBtn.Size = new Size(150, 29);
            AddToCartBtn.TabIndex = 2;
            AddToCartBtn.Text = "Add to cart";
            AddToCartBtn.UseVisualStyleBackColor = true;
            AddToCartBtn.Click += AddToCartBtn_Click;
            // 
            // ProductPriceLabel
            // 
            ProductPriceLabel.AutoSize = true;
            ProductPriceLabel.BackColor = Color.Transparent;
            ProductPriceLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductPriceLabel.Location = new Point(120, 144);
            ProductPriceLabel.Name = "ProductPriceLabel";
            ProductPriceLabel.Size = new Size(43, 20);
            ProductPriceLabel.TabIndex = 3;
            ProductPriceLabel.Text = "price";
            
            // 
            // ProductUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ProductPriceLabel);
            Controls.Add(ProductName);
            Controls.Add(AddToCartBtn);
            Controls.Add(ProductImage);
            Name = "ProductUC";
            Size = new Size(180, 210);
            ((System.ComponentModel.ISupportInitialize)ProductImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ProductImage;
        private Label ProductName;
        private Button AddToCartBtn;
        private Label ProductPriceLabel;
    }
}
