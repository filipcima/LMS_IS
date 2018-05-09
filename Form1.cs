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
    public partial class Form1 : Form
    {
        private int idStudent;
        public Form1()
        {
            this.idStudent = 4;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int studentID = 4;
            InitView(studentID);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InitView(int studentID)
        {
            MY_COURSES_LISTVIEW.Items.Clear();
            AVAIL_COURSES_CB.Items.Clear();
            Student s = StudentTable.SelectOne(studentID);
            Collection<ZapsanyKurz> signedCourses = ZapsanyKurzTable.SelectCoursesByIdStudent(studentID);
            ZapsanyKurz firstCourse = signedCourses[0];
            Collection<Kurz> activeCourses = KurzTable.SelectActiveCourses();
            foreach (var c in signedCourses)
            {
                ListViewItem i = new ListViewItem(c.IdRegistrace.ToString());
                i.SubItems.Add(c.Kurz.Nazev);
                MY_COURSES_LISTVIEW.Items.Add(i);
            }

            foreach (var c in activeCourses)
            {
                AVAIL_COURSES_CB.Items.Add(c.Nazev);
            }


            InitCourse(firstCourse);
        }

        private void InitCourse(ZapsanyKurz course)
        {
            Collection<Pisemka> upcomingTests = PisemkaTable.SelectUpcomingTests(course);
            Collection<Pisemka> pastTests = PisemkaTable.SelectPastTests(course);

            COURSE_NAME.Text = course.Kurz.Nazev;
            COURSE_DESC.Text = course.Kurz.Popis;

            UPCOMING_TESTS_LISTVIEW.Items.Clear();
            PAST_TESTS_LISTVIEW.Items.Clear();

            foreach (var t in upcomingTests)
            {
                ListViewItem i = new ListViewItem(t.IdPisemka.ToString());
                i.SubItems.Add(t.ZapsanyKurz.Kurz.Nazev);
                UPCOMING_TESTS_LISTVIEW.Items.Add(i);
            }

            foreach (var t in pastTests)
            {
                ListViewItem i = new ListViewItem(t.ZapsanyKurz.Kurz.Nazev);
                i.SubItems.Add(t.DatumPisemky.ToString());
                i.SubItems.Add(t.Znamka.ToString());
                PAST_TESTS_LISTVIEW.Items.Add(i);
            }
        }

        private void MY_COURSES_LISTVIEW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                string s = MY_COURSES_LISTVIEW.SelectedItems[0].Text;
                COURSE_NAME.Text = s;
                ZapsanyKurz course = ZapsanyKurzTable.SelectOne(Convert.ToInt32(s));
                InitCourse(course);
            }
        }

        private void SIGN_COURSE_BUTTON_Click(object sender, EventArgs e)
        {
            string courseName = AVAIL_COURSES_CB.Text;
            
            ZapsanyKurz zk = new ZapsanyKurz();
            if (courseName != null)
            {
                zk.IdKurz = 3;
            }
            
            zk.IdStudent = idStudent;
            ZapsanyKurzTable.Insert(zk);
            InitView(idStudent);
        }
    }
}
