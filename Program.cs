using System;
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
            KurzFronta kf = new KurzFronta();
            kf.Kurz = new Kurz();
            kf.Student = new Student();
            kf.Kurz.IdKurz = 3;
            kf.Student.IdStudent = 2;
            kf.Stamp = DateTime.Parse("2018-12-12");
            
            Console.WriteLine(kf.Stamp.ToDateTime2());
            Console.WriteLine(KurzFrontaTable.SelectStudentsByCourse(7));
            foreach (var student in KurzFrontaTable.SelectStudentsByCourse(7))
            {
                Console.WriteLine(student.Login);
            }
            Console.WriteLine(KurzFrontaTable.Insert(kf));
            Console.WriteLine(KurzFrontaTable.Delete(4));
            
            
            // OBOR TABLE
            Obor o = new Obor();
            o.Nazev = "Skvely obor";
            o.Popis = "Nejlepsi obor svete";
            //OborTable.Insert(o);
            OborTable.Delete(5);


            // PISEMKA TABLE
            Pisemka p = new Pisemka
            {
                DatumPisemky = DateTime.Now,
                ZapsanyKurz = new ZapsanyKurz
                {
                     Kurz = new Kurz
                     {
                         IdKurz = 1
                     }
                }
            };
            Console.WriteLine(PisemkaTable.Insert(p));
            Console.WriteLine(PisemkaTable.Delete(17));
            Console.WriteLine(PisemkaTable.GetAvgMark(2));
            Console.WriteLine(PisemkaTable.SelectOne(1));
            Console.WriteLine(PisemkaTable.SelectPastTests(1));
            Console.WriteLine(PisemkaTable.SelectUpcomingTests(1));
            Console.WriteLine(PisemkaTable.TestCheckDaily());
            Console.WriteLine(PisemkaTable.Update(p));
            
            // TYPSTUDIA TABLE
            TypStudia ts = new TypStudia
            {
                Nazev = "Superkombinovane"
            };
            TypStudiaTable.Insert(ts);
            TypStudiaTable.SelectOne(4);
            ts.Nazev = "Supermegakombinovane";
            TypStudiaTable.Update(ts);
            TypStudiaTable.Delete(4);
            
            // KURZ TABLE
            Kurz k = KurzTable.SelectOne(1);
            k.IdKurz = 11;
            Console.WriteLine(k.Nazev + k.Popis);
            KurzTable.Insert(k);
            Console.WriteLine(KurzTable.GetStudentsCount(1));
            KurzTable.Update(k);
            
            //
            
        }
    }
}