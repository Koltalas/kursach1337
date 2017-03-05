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


        List<themes> Themes;
        List<ListViewGroup> themesList;
        Writer writer;
        public Form1()
        {
            InitializeComponent();
            CurrentUser.TeacherDiscipline = 1;

            try
            {
                db = new Model1();
                writer = new Writer(db);
                themesList = new List<ListViewGroup>();
                Themes = db.themes.ToList();
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
                    listView1.Items.Add(new ListViewItem(Books[i].bname, 0, themeExist(Themes)));
                }

                for (int i = 0; i < themesList.Count(); i++)
                {
                    comboBox1.Items.Add(Themes[i].tname);
                }


                /*   List<themes> theme = db.themes.ToList();

                  List<ListViewGroup> Themes1 = new List<ListViewGroup>();
                  themesList.Add(new ListViewGroup(Themes[0].tname));

                  listView1.Groups.Add(themesList[0]);
                  listView1.Items.Add(new ListViewItem(Books[0].bname, themesList[0]));
                  //Themes[0].Name = theme[0].tname;
                  */


            }
            catch
            { }
        }

        ListViewGroup themeExist(List<themes> Themes)
        {
           
                for (int i = 0; i < listView1.Groups.Count; i++)
                {
                    for (int j = 0; j < db.themes.Count(); j++)
                    {
                        if (listView1.Groups[i].Name == Themes[j].tname)
                            return listView1.Groups[i];
                    }
                }
           
                return null;
            
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                textBox1.Text = file;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writer.AddEntry(comboBox1.Text, file);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            themesman themesManager = new themesman();
            themesManager.ShowDialog();
        }
    }
}

