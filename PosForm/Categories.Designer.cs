namespace PosForm
{
    partial class Categories
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
            searchCategoryText = new TextBox();
            SaveBtn = new Button();
            addBtn = new Button();
            CategoryNameText = new TextBox();
            label5 = new Label();
            label2 = new Label();
            CategoryIdText = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            SuspendLayout();
            // 
            // searchCategoryText
            // 
            searchCategoryText.Location = new Point(12, 48);
            searchCategoryText.Name = "searchCategoryText";
            searchCategoryText.Size = new Size(190, 27);
            searchCategoryText.TabIndex = 0;
            searchCategoryText.TextChanged += searchCategoryText_TextChanged;
            // 
            // SaveBtn
            // 
            SaveBtn.Enabled = false;
            SaveBtn.Location = new Point(229, 218);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(184, 29);
            SaveBtn.TabIndex = 47;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(227, 48);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(184, 29);
            addBtn.TabIndex = 46;
            addBtn.Text = "Add category";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // CategoryNameText
            // 
            CategoryNameText.Location = new Point(229, 170);
            CategoryNameText.Name = "CategoryNameText";
            CategoryNameText.Size = new Size(184, 27);
            CategoryNameText.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(229, 147);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 45;
            label5.Text = "Categore name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 85);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 52;
            label2.Text = "Category Id";
            // 
            // CategoryIdText
            // 
            CategoryIdText.Location = new Point(229, 108);
            CategoryIdText.Name = "CategoryIdText";
            CategoryIdText.ReadOnly = true;
            CategoryIdText.Size = new Size(184, 27);
            CategoryIdText.TabIndex = 51;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(11, 85);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(212, 303);
            flowLayoutPanel1.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 55;
            label1.Text = "search category";
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 400);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(CategoryIdText);
            Controls.Add(SaveBtn);
            Controls.Add(addBtn);
            Controls.Add(label5);
            Controls.Add(CategoryNameText);
            Controls.Add(searchCategoryText);
            Name = "Categories";
            Text = "Categories";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchCategoryText;
        private Button SaveBtn;
        private Button addBtn;
        private TextBox CategoryNameText;
        private Label label5;
        private Label label2;
        private TextBox CategoryIdText;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}