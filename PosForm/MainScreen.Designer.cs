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
            productTable = new TableLayoutPanel();
            SearchTextBox = new TextBox();
            ExitButton = new Button();
            PrintButton = new Button();
            PayButton = new Button();
            TotalPrice = new Label();
            label1 = new Label();
            categoriesPanel = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            profileToolStripMenuItem = new ToolStripMenuItem();
            productsToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            productsPanel = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // productTable
            // 
            productTable.AllowDrop = true;
            productTable.AutoScroll = true;
            productTable.ColumnCount = 5;
            productTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            productTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            productTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            productTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            productTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            productTable.Location = new Point(15, 67);
            productTable.Name = "productTable";
            productTable.RowCount = 1;
            productTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            productTable.Size = new Size(548, 428);
            productTable.TabIndex = 19;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(608, 67);
            SearchTextBox.Multiline = true;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(532, 49);
            SearchTextBox.TabIndex = 18;
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.Location = new Point(434, 627);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(129, 60);
            ExitButton.TabIndex = 17;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            // 
            // PrintButton
            // 
            PrintButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintButton.Location = new Point(221, 627);
            PrintButton.Name = "PrintButton";
            PrintButton.Size = new Size(129, 60);
            PrintButton.TabIndex = 16;
            PrintButton.Text = "Print";
            PrintButton.UseVisualStyleBackColor = true;
            // 
            // PayButton
            // 
            PayButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PayButton.Location = new Point(15, 627);
            PayButton.Name = "PayButton";
            PayButton.Size = new Size(129, 60);
            PayButton.TabIndex = 15;
            PayButton.Text = "Pay";
            PayButton.UseVisualStyleBackColor = true;
            PayButton.Click += PayButton_Click_1;
            // 
            // TotalPrice
            // 
            TotalPrice.AutoSize = true;
            TotalPrice.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalPrice.Location = new Point(190, 524);
            TotalPrice.Name = "TotalPrice";
            TotalPrice.Size = new Size(57, 38);
            TotalPrice.TabIndex = 14;
            TotalPrice.Text = "$...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 524);
            label1.Name = "label1";
            label1.Size = new Size(169, 38);
            label1.TabIndex = 13;
            label1.Text = "Total Price: ";
            // 
            // categoriesPanel
            // 
            categoriesPanel.BackColor = SystemColors.ButtonHighlight;
            categoriesPanel.Location = new Point(608, 384);
            categoriesPanel.Name = "categoriesPanel";
            categoriesPanel.Size = new Size(532, 318);
            categoriesPanel.TabIndex = 12;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { profileToolStripMenuItem, productsToolStripMenuItem, categoriesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1159, 28);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            profileToolStripMenuItem.Size = new Size(66, 24);
            profileToolStripMenuItem.Text = "Profile";
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(80, 24);
            productsToolStripMenuItem.Text = "Products";
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(94, 24);
            categoriesToolStripMenuItem.Text = "Categories";
            // 
            // productsPanel
            // 
            productsPanel.Location = new Point(608, 130);
            productsPanel.Name = "productsPanel";
            productsPanel.Size = new Size(532, 238);
            productsPanel.TabIndex = 21;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 720);
            Controls.Add(productsPanel);
            Controls.Add(productTable);
            Controls.Add(SearchTextBox);
            Controls.Add(ExitButton);
            Controls.Add(PrintButton);
            Controls.Add(PayButton);
            Controls.Add(TotalPrice);
            Controls.Add(label1);
            Controls.Add(categoriesPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel productTable;
        private TextBox SearchTextBox;
        private Button ExitButton;
        private Button PrintButton;
        private Button PayButton;
        private Label TotalPrice;
        private Label label1;
        private FlowLayoutPanel categoriesPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem profileToolStripMenuItem;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private FlowLayoutPanel productsPanel;
    }
}