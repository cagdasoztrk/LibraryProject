using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS5570_LibraryProject.DAL.ORM.Abstarct;

namespace YMS5570_LibraryProject.DAL.ORM.Concrate
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}