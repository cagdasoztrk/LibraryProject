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
    public partial class UserTransactions : Form
    {
        public UserTransactions()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        public void TextBoxEraser()
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox||item is ComboBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox3.Controls)
            {
                if (item is TextBox || item is ComboBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox4.Controls)
            {
                if (item is TextBox || item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
        public void TakeRoles()
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                cmbAddRole.Items.Add(item);
                cmbUpdateRole.Items.Add(item);
            }
        }
        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            AppUser Adduser = new AppUser();
            Adduser.AddDate = DateTime.Now;
            Adduser.FirstName = txtFirstname.Text;
            Adduser.LastName = txtLastname.Text;
            Adduser.Password = txtAddPassword.Text;
            Adduser.Role = (Role)cmbAddRole.SelectedItem;
            Adduser.UserName = txtAddUserName.Text;

            db.AppUsers.Add(Adduser);
            db.SaveChanges();
            UserTakeList();
            TextBoxEraser();

        }

        private void UserTakeList()
        {
            dgwUser.DataSource = db.AppUsers.Where(x => x.Status == Status.Active || x.Status == Status.Updated).ToList();
        }

        private void UserTransactions_Load(object sender, EventArgs e)
        {
            UserTakeList();
            TakeRoles();
        }
        int id;
        private void DgwUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdatePassword.Text = dgwUser.CurrentRow.Cells["Password"].Value.ToString();
            cmbUpdateRole.Text=dgwUser.CurrentRow.Cells["Role"].Value.ToString();
            id = int.Parse(dgwUser.CurrentRow.Cells["ID"].Value.ToString());
            txtDeleteUser.Text = dgwUser.CurrentRow.Cells["ID"].Value.ToString();
            
        }

        private void BtnUpdateUser_Click(object sender, EventArgs e)
        {
            AppUser UpdateUser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            UpdateUser.Password = txtUpdatePassword.Text;
            UpdateUser.Role = (Role)cmbUpdateRole.SelectedItem;
            UpdateUser.Status = Status.Updated;
            UpdateUser.UpdateDate = DateTime.Now;
            db.SaveChanges();
            UserTakeList();
            TextBoxEraser();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AppUser DeleteUser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            db.AppUsers.Remove(DeleteUser);
            db.SaveChanges();
            UserTakeList();
            TextBoxEraser();
        }
    }
}
