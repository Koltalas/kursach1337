using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Writer
    {
        Model1 db;

        public Writer (Model1 db)
        {
            this.db = db;
        }

        public byte[] FileToBinary(string filePath)
        {
            string filename = System.IO.Path.GetFileName(filePath);

            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();

            return bytes;
        }

        void AddEntry(string tname, string filePath)
        {
            books bk = new books();
            bk.bname = System.IO.Path.GetFileNameWithoutExtension(filePath);
            // bk.tid = th.tid;
            bk.document = FileToBinary(filePath);

            db.themes.Add(th);
            db.books.Add(bk);
            db.SaveChanges();

        }

        int ThemeWrite(string theme)
        {
            List<themes> Themes = db.themes.ToList();

            for (int x = 0; x < db.themes.Count(); x++)
            {
                if (theme != Themes[x].tname)
                {
                    themes Theme = new themes();
                    Theme.tname = theme;
                    db.themes.Add(Theme);
                    db.SaveChanges();

                    break;
                }
                else
                    return Themes[x].tid;
            }


        }



    }
}
