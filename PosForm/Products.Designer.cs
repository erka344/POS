namespace PosForm
{
    partial class Products
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
            label7 = new Label();
            SaveBtn = new Button();
            addBtn = new Button();
            productsFlowPanel = new FlowLayoutPanel();
            label5 = new Label();
            productCategoreName = new TextBox();
            label4 = new Label();
            productDiscountText = new TextBox();
            label3 = new Label();
            productPriceText = new TextBox();
            label2 = new Label();
            ProductIdText = new TextBox();
            label1 = new Label();
            productNameText = new TextBox();
            searchTextBox = new TextBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(615, 112);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 34;
            label7.Text = "Image";
            // 
            // SaveBtn
            // 
            SaveBtn.Enabled = false;
            SaveBtn.Location = new Point(615, 12);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(184, 29);
            SaveBtn.TabIndex = 32;
            SaveBtn.Text = "save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(408, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(184, 29);
            addBtn.TabIndex = 31;
            addBtn.Text = "add product";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // productsFlowPanel
            // 
            productsFlowPanel.AutoScroll = true;
            productsFlowPanel.Location = new Point(12, 45);
            productsFlowPanel.Name = "productsFlowPanel";
            productsFlowPanel.Size = new Size(369, 229);
            productsFlowPanel.TabIndex = 30;
            productsFlowPanel.WrapContents = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(408, 211);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 28;
            label5.Text = "Categore name";
            // 
            // productCategoreName
            // 
            productCategoreName.Location = new Point(408, 234);
            productCategoreName.Name = "productCategoreName";
            productCategoreName.Size = new Size(184, 27);
            productCategoreName.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(615, 50);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 26;
            label4.Text = "Discount";
            // 
            // productDiscountText
            // 
            productDiscountText.Location = new Point(615, 73);
            productDiscountText.Name = "productDiscountText";
            productDiscountText.Size = new Size(184, 27);
            productDiscountText.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 156);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 24;
            label3.Text = "Price";
            // 
            // productPriceText
            // 
            productPriceText.Location = new Point(408, 179);
            productPriceText.Name = "productPriceText";
            productPriceText.Size = new Size(184, 27);
            productPriceText.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(408, 50);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 22;
            label2.Text = "Bar code (id)";
            // 
            // ProductIdText
            // 
            ProductIdText.Location = new Point(408, 73);
            ProductIdText.Name = "ProductIdText";
            ProductIdText.ReadOnly = true;
            ProductIdText.Size = new Size(184, 27);
            ProductIdText.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(408, 103);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 20;
            label1.Text = "Name";
            // 
            // productNameText
            // 
            productNameText.Location = new Point(408, 126);
            productNameText.Name = "productNameText";
            productNameText.Size = new Size(184, 27);
            productNameText.TabIndex = 19;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(12, 12);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(369, 27);
            searchTextBox.TabIndex = 18;
            searchTextBox.TextChanged += SearchProduct_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(615, 135);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(184, 126);
            pictureBox2.TabIndex = 35;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 286);
            Controls.Add(pictureBox2);
            Controls.Add(label7);
            Controls.Add(SaveBtn);
            Controls.Add(addBtn);
            Controls.Add(productsFlowPanel);
            Controls.Add(label5);
            Controls.Add(productCategoreName);
            Controls.Add(label4);
            Controls.Add(productDiscountText);
            Controls.Add(label3);
            Controls.Add(productPriceText);
            Controls.Add(label2);
            Controls.Add(ProductIdText);
            Controls.Add(label1);
            Controls.Add(productNameText);
            Controls.Add(searchTextBox);
            Name = "Products";
            Text = "Products";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label7;
        private Button SaveBtn;
        private Button addBtn;
        private FlowLayoutPanel productsFlowPanel;
        private Label label5;
        private TextBox productCategoreName;
        private Label label4;
        private TextBox productDiscountText;
        private Label label3;
        private TextBox productPriceText;
        private Label label2;
        private TextBox ProductIdText;
        private Label label1;
        private TextBox productNameText;
        private TextBox searchTextBox;
        private PictureBox pictureBox2;
    }
}