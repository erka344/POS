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
            SearchTextBox = new TextBox();
            ExitButton = new Button();
            PrintButton = new Button();
            PayButton = new Button();
            TotalPriceLabel = new Label();
            label1 = new Label();
            categoriesPanel = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            productsToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            productsPanel = new FlowLayoutPanel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ProductFlowPanel = new FlowLayoutPanel();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(608, 80);
            SearchTextBox.Multiline = true;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(532, 36);
            SearchTextBox.TabIndex = 18;
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // ExitButton
            // 
            ExitButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.Location = new Point(448, 627);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(129, 60);
            ExitButton.TabIndex = 17;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // PrintButton
            // 
            PrintButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintButton.Location = new Point(235, 627);
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
            // TotalPriceLabel
            // 
            TotalPriceLabel.AutoSize = true;
            TotalPriceLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalPriceLabel.Location = new Point(190, 524);
            TotalPriceLabel.Name = "TotalPriceLabel";
            TotalPriceLabel.Size = new Size(49, 38);
            TotalPriceLabel.TabIndex = 14;
            TotalPriceLabel.Text = "$0";
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { productsToolStripMenuItem, categoriesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1159, 28);
            menuStrip1.TabIndex = 20;
            menuStrip1.Text = "menuStrip1";
            // 
            // productsToolStripMenuItem
            // 
            productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            productsToolStripMenuItem.Size = new Size(80, 24);
            productsToolStripMenuItem.Text = "Products";
            productsToolStripMenuItem.Click += productsToolStripMenuItem_Click;
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(94, 24);
            categoriesToolStripMenuItem.Text = "Categories";
            categoriesToolStripMenuItem.Click += categoriesToolStripMenuItem_Click;
            // 
            // productsPanel
            // 
            productsPanel.Location = new Point(608, 130);
            productsPanel.Name = "productsPanel";
            productsPanel.Size = new Size(532, 238);
            productsPanel.TabIndex = 21;
            // 
            // ProductFlowPanel
            // 
            ProductFlowPanel.AutoScroll = true;
            ProductFlowPanel.FlowDirection = FlowDirection.TopDown;
            ProductFlowPanel.Location = new Point(15, 122);
            ProductFlowPanel.Name = "ProductFlowPanel";
            ProductFlowPanel.Size = new Size(562, 368);
            ProductFlowPanel.TabIndex = 22;
            ProductFlowPanel.WrapContents = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(15, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 49);
            panel1.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(486, 12);
            label6.Name = "label6";
            label6.Size = new Size(49, 23);
            label6.TabIndex = 4;
            label6.Text = "Total";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(419, 13);
            label5.Name = "label5";
            label5.Size = new Size(50, 23);
            label5.TabIndex = 3;
            label5.Text = "Dis%";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(310, 12);
            label4.Name = "label4";
            label4.Size = new Size(69, 23);
            label4.TabIndex = 2;
            label4.Text = "U/Price";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(175, 12);
            label3.Name = "label3";
            label3.Size = new Size(80, 23);
            label3.TabIndex = 1;
            label3.Text = "Quantity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 12);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 0;
            label2.Text = "Item Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(608, 57);
            label7.Name = "label7";
            label7.Size = new Size(86, 20);
            label7.TabIndex = 24;
            label7.Text = "Search here";
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 720);
            Controls.Add(label7);
            Controls.Add(panel1);
            Controls.Add(ProductFlowPanel);
            Controls.Add(productsPanel);
            Controls.Add(SearchTextBox);
            Controls.Add(ExitButton);
            Controls.Add(PrintButton);
            Controls.Add(PayButton);
            Controls.Add(TotalPriceLabel);
            Controls.Add(label1);
            Controls.Add(categoriesPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox SearchTextBox;
        private Button ExitButton;
        private Button PrintButton;
        private Button PayButton;
        private Label TotalPriceLabel;
        private Label label1;
        private FlowLayoutPanel categoriesPanel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem productsToolStripMenuItem;
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private FlowLayoutPanel productsPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FlowLayoutPanel ProductFlowPanel;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
    }
}