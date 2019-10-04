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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        ProjectContext db = new ProjectContext();
        AppUser loginuser = new AppUser();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                MessageBox.Show("lütfen Kullanıcı adı giriniz");
                return;
            }
            else
            {
                if (db.AppUsers.Where(x => x.UserName == txtUsername.Text).ToList().Count>0)
                {
                    loginuser = db.AppUsers.FirstOrDefault(x => x.UserName == txtUsername.Text);
                    if (loginuser.Password == txtPassword.Text)
                    {
                        if (loginuser.Role == Role.Admin)
                        {
                            this.Hide();
                            AdminPage adminpage = new AdminPage();
                            adminpage.Show();
                        }
                        else
                        {
                            //userforms
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                        return;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Yanlış Kullancı Adı.");
                    return;
                }
            }
        }
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtUsername.Text==string.Empty)
            {
                MessageBox.Show("lütfen Kullanıcı adı giriniz");
                return;
            }
            else
            {
                if (db.AppUsers.Where(x => x.UserName == txtUsername.Text).ToList().Count>0)
                {
                    loginuser = db.AppUsers.FirstOrDefault(x => x.UserName == txtUsername.Text);
                    this.Hide();
                    ChangePassword changepassword = new ChangePassword(txtUsername.Text);
                    changepassword.Show();
                    
                }
                else
                {
                    MessageBox.Show("Yanlış Kullancı Adı.");
                    return;
                }               
            }
        }
    }
}
