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

namespace YMS5570_LibraryProject
{
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoryTransactions categorytransactions = new CategoryTransactions();
            categorytransactions.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserTransactions userTransactions = new UserTransactions();
            userTransactions.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookTransactions booktransactions = new BookTransactions();
            booktransactions.Show();
        }
    }
}
