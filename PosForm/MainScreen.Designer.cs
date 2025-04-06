namespace PosForm
{
    partial class MainScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            category = new Panel();
            products = new Panel();
            totalPrice = new Panel();
            productList = new Panel();
            scrollPanel = new Panel();
            SuspendLayout();
            // 
            // category
            // 
            category.Location = new Point(548, 367);
            category.Name = "category";
            category.Size = new Size(488, 268);
            category.TabIndex = 0;
            // 
            // products
            // 
            products.Location = new Point(548, 12);
            products.Name = "products";
            products.Size = new Size(488, 349);
            products.TabIndex = 1;
            // 
            // totalPrice
            // 
            totalPrice.Location = new Point(12, 602);
            totalPrice.Name = "totalPrice";
            totalPrice.Size = new Size(530, 100);
            totalPrice.TabIndex = 2;
            // 
            // productList
            // 
            productList.Location = new Point(12, 80);
            productList.Name = "productList";
            productList.Size = new Size(530, 516);
            productList.TabIndex = 3;
            // 
            // scrollPanel
            // 
            scrollPanel.Location = new Point(548, 641);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(488, 61);
            scrollPanel.TabIndex = 1;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 714);
            Controls.Add(scrollPanel);
            Controls.Add(productList);
            Controls.Add(totalPrice);
            Controls.Add(products);
            Controls.Add(category);
            Name = "MainScreen";
            Text = "MainScreen";
            ResumeLayout(false);
        }

        #endregion

        private Panel category;
        private Panel products;
        private Panel totalPrice;
        private Panel productList;
        private Panel scrollPanel;
    }
}