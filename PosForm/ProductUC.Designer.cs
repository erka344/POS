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
            ((System.ComponentModel.ISupportInitialize)ProductImage).BeginInit();
            SuspendLayout();
            // 
            // ProductImage
            // 
            ProductImage.Location = new Point(13, 16);
            ProductImage.Name = "ProductImage";
            ProductImage.Size = new Size(150, 115);
            ProductImage.TabIndex = 0;
            ProductImage.TabStop = false;
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.Location = new Point(64, 134);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(50, 20);
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
            AddToCartBtn.Click += this.AddToCartBtn_Click;
            // 
            // ProductUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(AddToCartBtn);
            Controls.Add(ProductName);
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
    }
}
