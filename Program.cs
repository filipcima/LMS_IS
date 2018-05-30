using System;
using System.Windows.Forms;
using LMS_IS_WF;
using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;

namespace LMSIS
{
    public class Program
    {
        public static int studentID = 3;
        public static int teacherID = 5;


        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}