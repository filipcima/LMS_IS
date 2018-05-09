using System;
using System.Windows.Forms;
using LMS_IS_WF;
using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;

namespace LMSIS
{
    internal class Program
    {
        public static int StudentID = 1;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}