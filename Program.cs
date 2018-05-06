using System;
using LMSIS.Database.DaoSqls;
using LMSIS.Database.Models;

namespace LMSIS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // KURZFRONTA TABLE   
            Console.WriteLine("KurzFronta");
            // 11.3
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
            // 11.1
            Console.WriteLine(KurzFrontaTable.Insert(kf));
            // 11.2
            Console.WriteLine(KurzFrontaTable.Delete(4));
            
            // OBOR TABLE
            Console.WriteLine("Obor");
            Obor o = new Obor
            {
                Nazev = "Skvely obor",
                Popis = "Nejlepsi obor svete"
            };
            // 7.4
            Console.WriteLine(OborTable.SelectOne(1));
            // 7.5
            Console.WriteLine(OborTable.SelectAll());
            // 7.1
            Console.WriteLine(OborTable.Insert(o));
            // 7.2
            Console.WriteLine(OborTable.Update(o));
            // 7.3            
            //Console.WriteLine(OborTable.Delete(5));


            // PISEMKA TABLE
            Console.WriteLine("Pisemka");
            // 8.4
            Pisemka p = PisemkaTable.SelectOne(1);
            // 8.1
            Console.WriteLine(PisemkaTable.Insert(p));
            // 8.2
            Console.WriteLine(PisemkaTable.Update(p));
            // 8.5
            Console.WriteLine(PisemkaTable.GetAvgMark(2));
            // 8.7
            Console.WriteLine(PisemkaTable.SelectPastTests(1));
            // 8.6
            Console.WriteLine(PisemkaTable.SelectUpcomingTests(1));
            // 8.8
            Console.WriteLine(PisemkaTable.TestCheckDaily());
            // 8.3
            //Console.WriteLine(PisemkaTable.Delete(1));
            
            // TYPSTUDIA TABLE
            Console.WriteLine("TypStudia");
            TypStudia ts = TypStudiaTable.SelectOne(1);
            // 6.1
            Console.WriteLine(TypStudiaTable.Insert(ts));
            // 6.2
            Console.WriteLine(TypStudiaTable.Update(ts));
            // 6.3
            //Console.WriteLine(TypStudiaTable.Delete(4));
            
            // KURZ TABLE
            Console.WriteLine("Kurz");
            // 5.4 
            Kurz k = KurzTable.SelectOne(1);
            // 5.1
            Console.WriteLine(KurzTable.Insert(k));
            // 5.5
            Console.WriteLine(KurzTable.GetStudentsCount(1));
            // 5.2
            Console.WriteLine(KurzTable.Update(k));
            // 5.3
            //Console.WriteLine(KurzTable.Delete(1));
            
            // ZAPSANYKURZ TABLE
            Console.WriteLine("ZapsanyKurz");
            // 3.4
            ZapsanyKurz zk = ZapsanyKurzTable.SelectOne(1);
            // 3.2
            Console.WriteLine(ZapsanyKurzTable.Update(zk));
            // 3.1
            Console.WriteLine(ZapsanyKurzTable.Insert(zk));
            // 3.3
            //ZapsanyKurzTable.Delete(1);
            // 4.3
            Console.WriteLine(ZapsanyKurzTable.SelectCoursesByIdStudent(1));
            // 4.4
            Console.WriteLine(ZapsanyKurzTable.SelectCoursesByIdTeacher(1));
            // 4.1
            Console.WriteLine(ZapsanyKurzTable.SelectRunningCourses());
            // 4.2
            Console.WriteLine(ZapsanyKurzTable.SelectStoppedCourses());
            
            // VYUKOVYMATERIAL TABLE
            Console.WriteLine("VyukovyMaterial");
            // 9.4
            VyukovyMaterial vm = VyukovyMaterialTable.SelectOne(1);
            // 9.1
            Console.WriteLine(VyukovyMaterialTable.Insert(vm));
            // 9.2
            Console.WriteLine(VyukovyMaterialTable.Update(vm));
            // 9.3
            //Console.WriteLine(VyukovyMaterialTable.Delete(1));
            // 9.5
            Console.WriteLine(VyukovyMaterialTable.SelectByCourse(1));
            
            // VYUCUJICI TABLE
            Console.WriteLine("Vyucujici");
            // 2.5
            Vyucujici vyucujici = VyucujiciTable.SelectOne(1);
            // 2.1
            Console.WriteLine(VyucujiciTable.Insert(vyucujici));
            // 2.2
            Console.WriteLine(VyucujiciTable.Update(vyucujici));
            // 2.3
            //Console.WriteLine(VyucujiciTable.Delete(1));
            // 2.4
            Console.WriteLine(VyucujiciTable.SelectByCourseName("Algoritmy II"));
            
            // HISTORIEMATERIALU TABLE
            Console.WriteLine("HistorieMaterialu");
            // 10.1
            //Console.WriteLine(HistorieMaterialuTable.Delete(1));
            // 10.2
            Console.WriteLine(HistorieMaterialuTable.GetParticularMaterial(2));
            // 10.3
            Console.WriteLine(HistorieMaterialuTable.GetMaterialsByIdVyukovyMaterial(2));

            // STUDENT TABLE
            Console.WriteLine("Student");
            // 1.6
            Student s = StudentTable.SelectOne(1);
            // 1.1
            Console.WriteLine(StudentTable.Insert(s));
            // 1.2
            Console.WriteLine(StudentTable.Update(s));
            // 1.3
            //Console.WriteLine(StudentTable.Delete(1));
            // 1.4
            Console.WriteLine(StudentTable.SelectByCourse(1));
            // 1.5
            Console.WriteLine(StudentTable.SelectUnsucessfulOnes());
        }
    }
}