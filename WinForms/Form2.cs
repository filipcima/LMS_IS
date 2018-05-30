using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;
using System;
using LMSIS;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LMS_IS_WF
{
    public partial class Form2 : Form
    {
        private int idTeacher;

        public Form2()
        {
            this.idTeacher = Program.teacherID;
            InitializeComponent();
            InitView();
        }

        public Form2(int idTeacher)
        {
            this.idTeacher = idTeacher;
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            InitCourses();
            InitSpecialization();
        }

        private void InitCourses()
        {
            MY_COURSES_LISTVIEW.Items.Clear();
            Collection<Kurz> courses = KurzTable.SelectByTeacherId(idTeacher);
            foreach (var c in courses)
            {
                ListViewItem i = new ListViewItem(c.IdKurz.ToString());
                i.SubItems.Add(c.Nazev);
                
                MY_COURSES_LISTVIEW.Items.Add(i);
            }
        }

        private void InitSpecialization()
        {
            Collection<Obor> specs = OborTable.SelectAll();
            foreach (var s in specs)
            {
                SPECIALIZATION_CB.Items.Add(s.Nazev);
            }
        }

        private void InitWaitingQueue(int idCourse)
        {
            WAITING_QUEUE_LW.Items.Clear();
            Collection<Student> students = KurzFrontaTable.SelectStudentsByCourse(idCourse);
            foreach (var s in students)
            {
                ListViewItem i = new ListViewItem(s.Login);
                i.SubItems.Add(s.Jmeno + " " + s.Prijmeni);
                WAITING_QUEUE_LW.Items.Add(i);
            }
        }

        private void switchToStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            Kurz k = new Kurz();
            k.IdVyucujici = this.idTeacher;

            if (int.TryParse(CAPACITY_VALUE.Text, out int n) && 
                NAME_VALUE.Text.Length > 1 && 
                DETAIL_VALUE.Text.Length > 0 && 
                SPECIALIZATION_CB.Text != "")
            {
                k.Kapacita = Convert.ToInt32(CAPACITY_VALUE.Text);
                k.IdObor = OborTable.SelectOneByName(SPECIALIZATION_CB.Text).IdObor;
                k.Nazev = NAME_VALUE.Text;
                k.Popis = DETAIL_VALUE.Text;
                k.Vytvoren = DateTime.Parse(START_DATE_DP.Text);

                KurzTable.Insert(k);

                SPECIALIZATION_CB.Text = "";
                NAME_VALUE.Text = "";
                CAPACITY_VALUE.Text = "";
                DETAIL_VALUE.Text = "";

                InitCourses();
            }
            else
            {
                MessageBox.Show("Vypln vsechny udaje spravne!");
            }
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                int idCourse = Convert.ToInt32(MY_COURSES_LISTVIEW.SelectedItems[0].Text);
                InitWaitingQueue(idCourse);
            }
        }

        private void CANCEL_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }
    }
}
