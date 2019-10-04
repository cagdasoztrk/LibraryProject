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
    public partial class ChangePassword : Form
    {
        ProjectContext db = new ProjectContext();
        AppUser appuser = new AppUser();
        public ChangePassword(string username)
        {
            InitializeComponent();
            appuser =db.AppUsers.FirstOrDefault(x=> x.UserName==username);
        }
        

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtcomfirmpassword.Text == txtnewpassword.Text)
            {
                appuser.Password = txtnewpassword.Text.ToString();
                appuser.UpdateDate = DateTime.Now;
                appuser.Status = DAL.ORM.Abstarct.Status.Updated;
            }
            db.SaveChanges();
            TextBoxEraser();
        }

        private void TextBoxEraser()
        {
            txtnewpassword.Text = string.Empty;
            txtcomfirmpassword.Text = string.Empty;
        }
    }
}
