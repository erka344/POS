namespace PosForm
{
    partial class ProductDetailUC
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
            deleteBtn = new Button();
            editBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)ProductImage).BeginInit();
            SuspendLayout();
            // 
            // ProductImage
            // 
            ProductImage.BorderStyle = BorderStyle.FixedSingle;
            ProductImage.Location = new Point(3, 3);
            ProductImage.Name = "ProductImage";
            ProductImage.Size = new Size(134, 117);
            ProductImage.TabIndex = 16;
            ProductImage.TabStop = false;
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.Location = new Point(44, 128);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(50, 20);
            ProductName.TabIndex = 17;
            ProductName.Text = "label1";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(71, 151);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(66, 24);
            deleteBtn.TabIndex = 19;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(5, 151);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(66, 24);
            editBtn.TabIndex = 18;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // ProductDetailUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(ProductName);
            Controls.Add(ProductImage);
            Name = "ProductDetailUC";
            Size = new Size(140, 190);
            ((System.ComponentModel.ISupportInitialize)ProductImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox ProductImage;
        private Label ProductName;
        private Button deleteBtn;
        private Button editBtn;
    }
}
