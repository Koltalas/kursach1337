using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Model1 db;
        public string file;
        public string filename;

        public Form1()
        {
            InitializeComponent();
            db = new Model1();

            List<ListViewGroup> themesList = new List<ListViewGroup>();
            List<themes> Themes = db.themes.ToList();
            List<books> Books = db.books.ToList();

            for (int i = 0; i < db.themes.Count(); i++)
            {
                themesList.Add(new ListViewGroup(Themes[i].tname));
            }

            for (int i = 0; i < themesList.Count(); i++)
            {
                listView1.Groups.Add(themesList[i]);
            }

            for (int i = 0; i < db.books.Count(); i++)
            {
                listView1.Items.Add(new ListViewItem(Books[i].bname, themesList[Books[i].tid]));
            }


            /*   List<themes> theme = db.themes.ToList();

              List<ListViewGroup> Themes1 = new List<ListViewGroup>();
              themesList.Add(new ListViewGroup(Themes[0].tname));

              listView1.Groups.Add(themesList[0]);
              listView1.Items.Add(new ListViewItem(Books[0].bname, themesList[0]));
              //Themes[0].Name = theme[0].tname;
              */


            
        }

        public void upload()
        {
            string filePath = file;
            string filename = Path.GetFileName(filePath);

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            br.Close();
            fs.Close();

            themes th = new themes();
            th.tname = textBox1.Text;
            books bk = new books();
            bk.bname = Path.GetFileName(filePath);
           // bk.tid = th.tid;
            bk.document = bytes;

            db.themes.Add(th);
            db.books.Add(bk);
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            upload();
        }
    }
}

