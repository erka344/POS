namespace PosForm
{
    partial class CategoryDetailUC
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
            categoryId = new Label();
            editBtn = new Button();
            deleteBtn = new Button();
            SuspendLayout();
            // 
            // categoryId
            // 
            categoryId.AutoSize = true;
            categoryId.Location = new Point(12, 9);
            categoryId.Name = "categoryId";
            categoryId.Size = new Size(50, 20);
            categoryId.TabIndex = 0;
            categoryId.Text = "label1";
            // 
            // editBtn
            // 
            editBtn.Location = new Point(12, 32);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(78, 29);
            editBtn.TabIndex = 1;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(97, 32);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(78, 29);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // CategoryDetailUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(categoryId);
            Name = "CategoryDetailUC";
            Size = new Size(185, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label categoryId;
        private Button editBtn;
        private Button deleteBtn;
    }
}
