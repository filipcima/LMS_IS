using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LMS_IS_WF
{
    public partial class Form2 : Form
    {
        private int idTeacher;
        public Form2(int idTeacher)
        {
            this.idTeacher = idTeacher;
            InitializeComponent();
            InitView(idTeacher);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitView(idTeacher);
        }

        private void InitView(int teacherID)
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
            // bad solution
            // TODO: find out a better one
            new Form1().Show();
        }

        private void CREATE_BUTTON_Click(object sender, EventArgs e)
        {
            Kurz k = new Kurz();
            k.IdVyucujici = this.idTeacher;
            k.IdObor = OborTable.SelectOneByName(SPECIALIZATION_CB.Text).IdObor;
            k.Kapacita = Convert.ToInt32(CAPACITY_VALUE.Text);
            k.Vytvoren = DateTime.Parse(START_DATE_DP.Text);
            k.Nazev = NAME_VALUE.Text;
            k.Popis = DETAIL_VALUE.Text;

            KurzTable.Insert(k);
            InitCourses();
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                int idCourse = Convert.ToInt32(MY_COURSES_LISTVIEW.SelectedItems[0].Text);
                InitWaitingQueue(idCourse);
            }
        }
    }
}
