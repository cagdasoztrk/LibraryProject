using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMS5570_LibraryProject.DAL.ORM.Abstarct;
using YMS5570_LibraryProject.DAL.ORM.Concrate;
using YMS5570_LibraryProject.DAL.ORM.Context;

namespace YMS5570_LibraryProject
{
    public partial class BookTransactions : Form
    {
        public BookTransactions()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            Book Addbook = new Book();
            Addbook.Title = txtAddTitle.Text;
            Addbook.Content = txtAddContent.Text;
            Addbook.AppUser= (AppUser)cmbAddUser.SelectedItem;
            Addbook.Category = (Category)cmbAddCategory.SelectedItem;
            db.Books.Add(Addbook);
            db.SaveChanges();
            TakeBooks();
        }

        private void TakeBooks()
        {
            dataGridView1.DataSource = db.Books.Where(x => x.Status == DAL.ORM.Abstarct.Status.Active || x.Status == DAL.ORM.Abstarct.Status.Updated).ToList();
        }

        private void BookTransactions_Load(object sender, EventArgs e)
        {
            TakeBooks();
            GetUsers();
            GetCategories();
        }

        private void GetCategories()
        {
            foreach (var item in db.Categories.Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList())
            {
                cmbAddCategory.Items.Add(item);
                cmbUpdateCategory.Items.Add(item);
            }
        }

        private void GetUsers()
        {
            foreach (var item in db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList())
            {
                cmbAddUser.Items.Add(item);
                cmbUpdateUser.Items.Add(item);
            }
        }
        int id;
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Book Updaterezerv = db.Books.FirstOrDefault(x => x.ID == id);
            Updaterezerv.Status = Status.Updated;
            Updaterezerv.Title = txtUpdateBook.Text;
            Updaterezerv.Content = txtUpdateContent.Text;
            Updaterezerv.UpdateDate = DateTime.Now;
            Updaterezerv.AppUser =(AppUser)cmbUpdateUser.SelectedItem;
            Updaterezerv.Category = (Category)cmbUpdateCategory.SelectedItem;
            db.SaveChanges();
            TakeBooks();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            txtUpdateBook.Text = dataGridView1.CurrentRow.Cells["Title"].Value.ToString();
            txtUpdateContent.Text = dataGridView1.CurrentRow.Cells["Content"].Value.ToString();
            txtDelete.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            Book Deleterezerv = db.Books.FirstOrDefault(x => x.ID == id);
            db.Books.Remove(Deleterezerv);
            db.SaveChanges();
            TakeBooks();
        }
    }
}

