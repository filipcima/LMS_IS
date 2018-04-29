using System;
using System.Collections.ObjectModel;
using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;
using LMSIS.Extensions;

namespace LMSIS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // KURZFRONTA TABLE   
            Console.WriteLine("KurzFronta");
            Console.WriteLine(KurzFrontaTable.SelectStudentsByCourse(7));
            
            foreach (var student in KurzFrontaTable.SelectStudentsByCourse(7))
            {
                Console.WriteLine(student.Login);
            }
            
            KurzFronta kf = new KurzFronta
            {
                IdKurz = 2,
                IdStudent = 2,
                Stamp = DateTime.Now
            };
            Console.WriteLine(KurzFrontaTable.Insert(kf));
            Console.WriteLine(KurzFrontaTable.Delete(4));
            
            // OBOR TABLE
            Console.WriteLine("Obor");
            Obor o = new Obor
            {
                Nazev = "Skvely obor",
                Popis = "Nejlepsi obor svete"
            };
            Console.WriteLine(OborTable.Insert(o));
            Console.WriteLine(OborTable.Delete(5));


            // PISEMKA TABLE
            Console.WriteLine("Pisemka");
            Pisemka p = PisemkaTable.SelectOne(1);
            Console.WriteLine(PisemkaTable.Insert(p));
            Console.WriteLine(PisemkaTable.Update(p));
            Console.WriteLine(PisemkaTable.GetAvgMark(2));
            Console.WriteLine(PisemkaTable.SelectPastTests(1));
            Console.WriteLine(PisemkaTable.SelectUpcomingTests(1));
            Console.WriteLine(PisemkaTable.TestCheckDaily());
            Console.WriteLine(PisemkaTable.Delete(1));
            
            // TYPSTUDIA TABLE
            Console.WriteLine("TypStudia");
            TypStudia ts = TypStudiaTable.SelectOne(1);
            Console.WriteLine(TypStudiaTable.Insert(ts));
            Console.WriteLine(TypStudiaTable.Update(ts));
            Console.WriteLine(TypStudiaTable.Delete(4));
            
            // KURZ TABLE
            Console.WriteLine("Kurz");
            Kurz k = KurzTable.SelectOne(1);
            Console.WriteLine(KurzTable.Insert(k));
            Console.WriteLine(KurzTable.GetStudentsCount(1));
            Console.WriteLine(KurzTable.Update(k));
            
            // ZAPSANYKURZ TABLE
            Console.WriteLine("ZapsanyKurz");
            ZapsanyKurz zk = ZapsanyKurzTable.SelectOne(1);
            Console.WriteLine(ZapsanyKurzTable.Insert(zk));
            //ZapsanyKurzTable.Delete(1);
            Console.WriteLine(ZapsanyKurzTable.SelectCoursesByIdStudent(1));
            Console.WriteLine(ZapsanyKurzTable.SelectCoursesByIdTeacher(1));
            Console.WriteLine(ZapsanyKurzTable.SelectRunningCourses());
            Console.WriteLine(ZapsanyKurzTable.SelectStoppedCourses());
            
            // VYUKOVYMATERIAL TABLE
            Console.WriteLine("VyukovyMaterial");
            VyukovyMaterial vm = VyukovyMaterialTable.SelectOne(1);
            Console.WriteLine(VyukovyMaterialTable.Insert(vm));
            Console.WriteLine(VyukovyMaterialTable.Update(vm));
            //Console.WriteLine(VyukovyMaterialTable.Delete(1));
            Console.WriteLine(VyukovyMaterialTable.SelectByCourse(1));
            
            // VYUCUJICI TABLE
            Console.WriteLine("Vyucujici");
            Vyucujici vyucujici = VyucujiciTable.SelectOne(1);
            Console.WriteLine(VyucujiciTable.Insert(vyucujici));
            Console.WriteLine(VyucujiciTable.Update(vyucujici));
            //Console.WriteLine(VyucujiciTable.Delete(1));
            Console.WriteLine(VyucujiciTable.SelectByCourseName("Algoritmy II"));
            
            // HISTORIEMATERIALU TABLE
            Console.WriteLine("HistorieMaterialu");
            Console.WriteLine(HistorieMaterialuTable.Delete(1));
            Console.WriteLine(HistorieMaterialuTable.GetMaterialsByIdVyukovyMaterial(2));

            // STUDENT TABLE
            Console.WriteLine("Student");
            Student s = StudentTable.SelectOne(1);
            Console.WriteLine(StudentTable.Update(s));
            Console.WriteLine(StudentTable.Insert(s));
            Console.WriteLine(StudentTable.SelectByCourse(1));
            Console.WriteLine(StudentTable.SelectUnsucessfulOnes());
        }
    }
}