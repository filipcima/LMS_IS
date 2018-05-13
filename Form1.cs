using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;
using System;
using System.Collections.ObjectModel;
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

        public Form1(int idStudent)
        {
            this.idStudent = idStudent;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitView(idStudent);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitView(int studentID)
        {
            MY_COURSES_LISTVIEW.Items.Clear();
            AVAIL_COURSES_CB.Items.Clear();
            Student s = StudentTable.SelectOne(studentID);
            Collection<ZapsanyKurz> signedCourses = ZapsanyKurzTable.SelectCoursesByIdStudent(studentID);
            Collection<Kurz> activeCourses = KurzTable.SelectByStudentAndOngoing(studentID.ToString());

            foreach (var c in activeCourses)
            {
                AVAIL_COURSES_CB.Items.Add(c.Nazev);
            }

            if (signedCourses.Count > 0)
            {
                ZapsanyKurz firstCourse = signedCourses[0];

                foreach (var c in signedCourses)
                {
                    ListViewItem i = new ListViewItem(c.IdRegistrace.ToString());
                    i.SubItems.Add(c.Kurz.Nazev);
                    MY_COURSES_LISTVIEW.Items.Add(i);
                }
                InitCourse(firstCourse);
            }
        }

        private void InitCourse(ZapsanyKurz course)
        {
            Collection<Pisemka> upcomingTests = PisemkaTable.SelectUpcomingTests(course);
            Collection<Pisemka> pastTests = PisemkaTable.SelectPastTests(course);

            COURSE_NAME.Text = course.Kurz.Nazev;
            COURSE_DESC.Text = course.Kurz.Popis;

            UPCOMING_TESTS_LISTVIEW.Items.Clear();
            PAST_TESTS_LISTVIEW.Items.Clear();

            InitTests(upcomingTests, UPCOMING_TESTS_LISTVIEW, false);
            InitTests(pastTests, PAST_TESTS_LISTVIEW, true);
            InitStatus(course);
            InitMaterials(course);
        }

        private void InitTests(Collection<Pisemka> tests, ListView lst, bool includeMark)
        {
            foreach (var t in tests)
            {
                ListViewItem i = new ListViewItem(t.IdPisemka.ToString());
                i.SubItems.Add(t.DatumPisemky.ToShortDateString());
                if (includeMark)
                {
                    i.SubItems.Add(t.Znamka.ToString());
                }

                UPCOMING_TESTS_LISTVIEW.Items.Add(i);
            }
        }

        private void InitStatus(ZapsanyKurz zk)
        {
            double? avg = ZapsanyKurzTable.GetAvgMark(zk.IdRegistrace);
            if (avg != null)
            {
                AVERAGE_MARK.Text = "Average mark: " + avg;
            }
            else
            {
                AVERAGE_MARK.Text = "Average mark: no marks yet";
            }
            string dateOfSign = zk.DatumZapisu.ToShortDateString();
            bool? done = zk.Splneno;

            DATE_OF_SIGN.Text = "Signed: " + dateOfSign;
            bool done2 = done ?? false;
            if (done2)
            {
                COMPLETED.Text = "Done: YES";
            }
            else
            {
                COMPLETED.Text = "DONE: NO";
            }
        }    
        
        private void InitMaterials(ZapsanyKurz course)
        {
            LEARNING_MATERIALS_LISTVIEW.Items.Clear();

            Collection<VyukovyMaterial> materials = VyukovyMaterialTable.SelectByCourse(course.IdKurz);
            if (materials != null)
            {
                foreach (var material in materials)
                {
                    ListViewItem i = new ListViewItem(material.IdVyukovyMaterial.ToString());
                    i.SubItems.Add(material.Nazev);
                    i.SubItems.Add(material.Text);
                    i.SubItems.Add(material.Autor.Prijmeni + ", " + material.Autor.Jmeno);

                    LEARNING_MATERIALS_LISTVIEW.Items.Add(i);
                }
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
            int studentsCount = 0, capacity = 0;
            if (courseName != null)
            {
                Kurz k = KurzTable.SelectByCourseName(courseName);
                zk.IdKurz = k.IdKurz;

                studentsCount = KurzTable.GetStudentsCount(k.IdKurz);
                capacity = k.Kapacita;

                zk.IdStudent = idStudent;
                ZapsanyKurzTable.Insert(zk);
                if (studentsCount < capacity)
                {
                    InitView(idStudent);
                }
                else
                {
                    MessageBox.Show("Jiz neni misto. Budete zapsan do fronty na tento kurz. " +
                        "Jakmile se otevre kurz, budete zapsan do kurzu.");
                }
            }
        }

        private void SIGN_OUT_BUTTON_Click(object sender, EventArgs e)
        {
            if (MY_COURSES_LISTVIEW.SelectedItems.Count == 1)
            {
                string s = MY_COURSES_LISTVIEW.SelectedItems[0].Text;
                COURSE_NAME.Text = s;
                
                ZapsanyKurzTable.Delete(Convert.ToInt32(s));
                InitView(idStudent);
            }
        }

        private void switchToTeacherViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            // bad solution
            // TODO: find out a better one
            new Form2(5).Show();
        }
    }
}
