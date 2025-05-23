using PosLibrary.model;
using PosLibrary.serve;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosForm
{
    public partial class Categories : Form
    {
        ProductCategoryServe productCategoryServe;
        ProductCategory usedProductCategory;
        User currentUser;
        
        public Categories(User user)
        {
            InitializeComponent();
            currentUser = user;
            string connectionString = $"Data Source=\"C:\\Users\\erka\\source\\repos\\Pos\\PosForm\\PosDatabase.db\";";
            productCategoryServe = new ProductCategoryServe(connectionString);
            LoadingCategories();
            usedProductCategory = new ProductCategory();
            loadingUserRole();
        }

        public void LoadingCategories()
        {
            flowLayoutPanel1.Controls.Clear();
            List<ProductCategory> categories = productCategoryServe.GetAllProductCategory();
            foreach (ProductCategory category in categories)
            {
                CategoryDetailUC categoryDetailUC = new CategoryDetailUC(category);
                categoryDetailUC.editBtnClicked += (s, e) => ProductCategoryDetailUC_editBtnClicked(category);
                categoryDetailUC.deleteBtnClicked += (s, e) => ProductCategoryDetailUC_deleteBtnClicked(category);
                flowLayoutPanel1.Controls.Add(categoryDetailUC);
            }
        }
        private void searchCategoryText_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchCategoryText.Text;
            List<ProductCategory> productCategories = productCategoryServe.GetCategoryByName(searchText);
            flowLayoutPanel1.Controls.Clear();
            foreach (ProductCategory category in productCategories)
            {
                CategoryDetailUC categoryDetailUC = new CategoryDetailUC(category);
                categoryDetailUC.editBtnClicked += (s, e) => ProductCategoryDetailUC_editBtnClicked(category);
                categoryDetailUC.deleteBtnClicked += (s, e) => ProductCategoryDetailUC_deleteBtnClicked(category);
                flowLayoutPanel1.Controls.Add(categoryDetailUC);
            }

        }
        private void loadingUserRole()
        {
            if (currentUser.Role != 0)
            {
                addBtn.Enabled = false;
                SaveBtn.Enabled = false;
            }
        }
        private void ProductCategoryDetailUC_editBtnClicked(ProductCategory category)
        {
            CategoryIdText.Text = category.Id.ToString();
            CategoryNameText.Text = category.Name;

            if (currentUser.Role != 0)
            {
                addBtn.Enabled = false;
                SaveBtn.Enabled = false;
            }
            else
            {
                SaveBtn.Enabled = true;
            }
                
        }
        private void ProductCategoryDetailUC_deleteBtnClicked(ProductCategory category)
        {
            DialogResult result = MessageBox.Show(
                "Та устгахдаа итгэлтэй байна уу?",
                "Баталгаажуулалт",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (currentUser.Role != 0)
            {
                
            } else {
                if (result == DialogResult.Yes)
                {
                    productCategoryServe.DeleteProductCategory(category.Id);
                    MessageBox.Show("Амжилттай устгалаа!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            int maxId = 1;
            var categories = productCategoryServe.GetAllProductCategory();
            int currentId = int.Parse(CategoryIdText.Text);
            usedProductCategory.Id = currentId;
            usedProductCategory.Name = CategoryNameText.Text;

            if (categories.Any())
            {
                maxId = categories.Max(c => c.Id);
            }

            if (maxId < currentId)
            {
                productCategoryServe.AddProductCategory(usedProductCategory);
                MessageBox.Show("Амжилттай burtgelee!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                productCategoryServe.UpdateProductCategory(usedProductCategory);
                MessageBox.Show("Амжилттай shinchillee!", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadingCategories();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var categories = productCategoryServe.GetAllProductCategory();
            int nextId = 1;

            if (categories.Any()) { nextId = categories.Max(c => c.Id)+1; }

            CategoryIdText.Text = nextId.ToString();
            CategoryNameText.Text = "";

            SaveBtn.Enabled = true;
        }
    }
}
