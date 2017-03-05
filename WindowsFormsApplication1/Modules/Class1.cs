using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Modules;

namespace WindowsFormsApplication1
{
    class Writer
    {
        Model1 db;
        Convertor convertor = new Convertor();

        public Writer (Model1 db)
        {
            this.db = db;
        }

        public void AddEntry(string tname, string filePath)
        {
            books bk = new books();
            bk.bname = System.IO.Path.GetFileNameWithoutExtension(filePath);
            // bk.tid = th.tid;
            bk.document = convertor.FileToBinary(filePath);

            bk.tid = ThemeWrite(tname);
            db.books.Add(bk);
            db.SaveChanges();

        }

        int ThemeWrite(string theme)
        {
            List<themes> Themes = db.themes.ToList();

            for (int i = 0; i <= db.themes.Count(); i++)
            {
                if (theme == Themes[i].tname)
                {
                    return Themes[i].tid;
                }
                else
                    continue;
            }

            return 0;
        }
    }
}
