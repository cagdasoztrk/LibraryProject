using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMS5570_LibraryProject.DAL.ORM.Concrate;
using YMS5570_LibraryProject.DAL.ORM.Context;

namespace YMS5570_LibraryProject
{
    public partial class CategoryTransactions : Form
    {
        public CategoryTransactions()
        {
            InitializeComponent();
        }

        ProjectContext db = new ProjectContext();

        public void TextBoxEraser()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox4.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        public void CategoryTakeList()
        {
            dataGridView1.DataSource = db.Categories.Where(x => x.Status == DAL.ORM.Abstarct.Status.Active || x.Status == DAL.ORM.Abstarct.Status.Updated).ToList();
        }


        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = txtAddName.Text;
            category.Description = txtAddDescription.Text;

            db.Categories.Add(category);
            db.SaveChanges();

            CategoryTakeList();
            TextBoxEraser();
        }

        private void AddCategoryPage_Load(object sender, EventArgs e)
        {
            CategoryTakeList();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.Name = txtUpdateName.Text;
            category.Description = txtUpdateDescription.Text;
            category.UpdateDate = DateTime.Now;
            category.Status = DAL.ORM.Abstarct.Status.Updated;
            db.SaveChanges();
            CategoryTakeList();
            TextBoxEraser();

        }

        int id;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateName.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txtUpdateDescription.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            txtDelete.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.Status = DAL.ORM.Abstarct.Status.Deleted;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();
            CategoryTakeList();
            TextBoxEraser();
        }
    }
}
