using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;
using System;
using LMSIS;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace LMS_IS_WF
{
    public partial class Form3 : Form
    {
        private int idTeacher, idSelectedCourse;
        public Form3()
        {
            this.idTeacher = Program.teacherID;
            InitializeComponent();
            InitView();
        }

        public Form3(int idTeacher)
        {
            this.idTeacher = idTeacher;
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            MY_COURSES_LISTVIEW.Items.Clear();
            Collection<Kurz> myCourses = KurzTable.SelectByTeacherId(idTeacher);

            if (myCourses.Count > 0)
            {
                Kurz firstCourse = myCourses[0];

                foreach (var c in myCourses)
                {
                    ListViewItem i = new ListViewItem(c.IdKurz.ToString());
                    i.SubItems.Add(c.Nazev);
                    MY_COURSES_LISTVIEW.Items.Add(i);
                }
                InitCourse(firstCourse);
            }

        }

        private void InitCourse(Kurz course)
        {
            COURSE_NAME.Text = course.Nazev;
            COURSE_DESC.Text = "Description: " + course.Popis;
            COURSE_CAPACITY.Text = "Capacity: " + course.Kapacita.ToString();
            COURSE_SPECIALIZATION.Text = "Specialization: " + OborTable.SelectOne(course.IdObor).Nazev;
            AVG_MARK.Text = "Average mark: " + PisemkaTable.GetAvgMark(course.IdKurz).ToString();
            ENDED.Text = "Ended: " + course.Ukoncen.ToString();

            Collection<Pisemka> upcomingTests = PisemkaTable.SelectUpcomingTestsByCourse(course.IdKurz);
            Collection<Pisemka> pastTests = PisemkaTable.SelectPastTestsByCourse(course.IdKurz);

            UPCOMING_TESTS_LISTVIEW.Items.Clear();
            PAST_TESTS_LISTVIEW.Items.Clear();

            foreach (var t in pastTests)
            {
                ListViewItem i = new ListViewItem(t.IdPisemka.ToString());
                i.SubItems.Add(t.DatumPisemky.ToShortDateString());
                i.SubItems.Add(t.Znamka.ToString());

                PAST_TESTS_LISTVIEW.Items.Add(i);
            }

            foreach (var t in upcomingTests)
            {
                ListViewItem i = new ListViewItem(t.IdPisemka.ToString());
                i.SubItems.Add(t.DatumPisemky.ToShortDateString());

                UPCOMING_TESTS_LISTVIEW.Items.Add(i);
            }


        }

        private void MY_COURSES_LISTVIEW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                this.idSelectedCourse = Convert.ToInt32(MY_COURSES_LISTVIEW.SelectedItems[0].Text);
                Kurz course = KurzTable.SelectOne(idSelectedCourse);
                InitCourse(course);
                PrefillUpdateData(course);
            }
        }

        private void PrefillUpdateData(Kurz course)
        {
            InitSpecialization();
            NAME_VALUE.Text = course.Nazev;
            CAPACITY_VALUE.Text = course.Kapacita.ToString();
            DETAIL_VALUE.Text = course.Popis;
            START_DATE_DP.Value = course.Vytvoren;
        }

        private void InitSpecialization()
        {
            SPECIALIZATION_CB.Items.Clear();
            Collection<Obor> specs = OborTable.SelectAll();
            foreach (var s in specs)
            {
                SPECIALIZATION_CB.Items.Add(s.Nazev);
            }
        }

        private void END_COURSE_BUTTON_Click(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                this.idSelectedCourse = Convert.ToInt32(MY_COURSES_LISTVIEW.SelectedItems[0].Text);
                Kurz course = KurzTable.SelectOne(idSelectedCourse);
                course.Ukoncen = DateTime.Now;
                KurzTable.Update(course);
                InitCourse(course);
            }
        }

        private void UPDATE_BUTTON_Click(object sender, EventArgs e)
        {
            Kurz course = new Kurz();
            course.IdKurz = this.idSelectedCourse;
            course.Nazev = NAME_VALUE.Text;
            course.Kapacita = Convert.ToInt32(CAPACITY_VALUE.Text);
            course.Popis = DETAIL_VALUE.Text;
            course.Vytvoren = START_DATE_DP.Value;
            course.IdVyucujici = this.idTeacher;
            if (SPECIALIZATION_CB.Text != null && SPECIALIZATION_CB.Text != "")
            {
                course.IdObor = OborTable.SelectOneByName(SPECIALIZATION_CB.Text).IdObor;
            } else
            {
                MessageBox.Show("Vyber obor!");
                return;
            }

            if (course.Nazev != "" && course.Kapacita > 0 && course.Popis != "")
            {
                KurzTable.Update(course);
            }

            InitView();
            InitCourse(course);
        }

        private void CREATE_COURSE_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void CREATE_TEST_Click(object sender, EventArgs e)
        {
            Pisemka p = new Pisemka();
            p.ZapsanyKurz = new ZapsanyKurz();
            p.ZapsanyKurz.IdKurz = this.idSelectedCourse;
            p.DatumPisemky = TEST_DP.Value;
            if (p.DatumPisemky > DateTime.Now)
            {
                PisemkaTable.Insert(p);
            }
        }

        private void switchToStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }
    }
}
