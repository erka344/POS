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
            searchCategoreText = new TextBox();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // searchCategoreText
            // 
            searchCategoreText.Location = new Point(12, 12);
            searchCategoreText.Name = "searchCategoreText";
            searchCategoreText.Size = new Size(148, 27);
            searchCategoreText.TabIndex = 0;
            searchCategoreText.Text = "search categore";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 27);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // Categories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 409);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(searchCategoreText);
            Name = "Categories";
            Text = "Categories";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox searchCategoreText;
        private TextBox textBox1;
        private Label label1;
    }
}