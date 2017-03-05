using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class themesman : Form
    {
        public themesman()
        {
            InitializeComponent();
        }

        Model1 db = new Model1();
        List<themes> ThemesList;
        private void themesman_Load(object sender, EventArgs e)
        {
            ReloadThemesList();    
        }

        void ReloadThemesList()
        {
            listBox1.Items.Clear();
            ThemesList = db.themes.ToList();

            for (int i = 0; i < db.themes.Count(); i++)
            {
                if (ThemesList[i].did == CurrentUser.TeacherDiscipline)
                    listBox1.Items.Add(ThemesList[i].tname);
            }
        }

        bool themeExist(string theme)
        {
            ThemesList = db.themes.ToList();

            for (int i = 0; i < db.themes.Count(); i++)
            {
                if (ThemesList[i].did == CurrentUser.TeacherDiscipline & ThemesList[i].tname == theme)
                    return true;
            }
            return false;
        }

        themes themeExistDel(string theme)
        {
            ThemesList = db.themes.ToList();

            for (int i = 0; i < db.themes.Count(); i++)
            {
                if (ThemesList[i].did == CurrentUser.TeacherDiscipline & ThemesList[i].tname == theme)
                    return ThemesList[i];
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (themeExist(textBox1.Text) == false)
            {
                themes theme = new themes();
                theme.tname = textBox1.Text;

                theme.did = CurrentUser.TeacherDiscipline;
                db.themes.Add(theme);
                db.SaveChanges();
            }           
            else
                MessageBox.Show("Такая тема уже существует", "Невозможно добавить тему");
            ReloadThemesList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (themeExist(listBox1.SelectedItem.ToString()))
            {
                themes theme = new themes();
                theme.tname = textBox1.Text;

                theme.did = CurrentUser.TeacherDiscipline;
                db.themes.Remove(themeExistDel(listBox1.SelectedItem.ToString()));
                db.SaveChanges();
            }
            else
                MessageBox.Show("Такая тема уже существует", "Невозможно добавить тему");
            ReloadThemesList();
        }
    }


}
