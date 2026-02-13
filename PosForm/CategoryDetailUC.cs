using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PosLibrary.model;

namespace PosForm
{
    public partial class CategoryDetailUC : UserControl
    {
        public CategoryDetailUC(ProductCategory category)
        {
            InitializeComponent();
            LoadingCategoryUC(category);
        }

        public void LoadingCategoryUC(ProductCategory category)
        {
            categoryId.Text =category.Id.ToString() +" "+ category.Name;

        }

        public event EventHandler editBtnClicked;
        private void editBtn_Click(object sender, EventArgs e)
        {
            editBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler deleteBtnClicked;
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteBtnClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
