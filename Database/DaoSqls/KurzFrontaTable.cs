using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;
using LMSIS.Extensions;

namespace LMSIS.Database.DaoSqls
{
    public class KurzFrontaTable
    {
        private static string TABLE_NAME = "KurzFronta";
        
        private static string SQL_INSERT = "INSERT INTO KurzFronta VALUES (@IdStudent, @IdKurz, @TStamp)";

        private static string SQL_DELETE_ID = "DELETE FROM KurzFronta WHERE IdKurzFronta=@IdKurzFronta";

        private static string SQL_MATERIALS_BY_COURSE = "SELECT s.* FROM kurzfronta kf JOIN student s ON " +
                                                        "kf.student_idstudent = s.idstudent WHERE kurz_idkurz=@IdKurz";

        public static int Insert(KurzFronta kf, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, kf);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Delete(int idKurzFronta)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdKurzFronta", idKurzFronta);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Collection<Student> SelectStudentsByCourse(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_MATERIALS_BY_COURSE))
                {
                    command.Parameters.AddWithValue("@IdKurz", idKurz);

                    SqlDataReader reader = db.Select(command);

                    Collection<Student> students = ReadStudents(reader, true);

                    return students;
                }
            }

        }

        private static void PrepareCommand(SqlCommand command, KurzFronta kf)
        {
            command.Parameters.AddWithValue("@IdKurzFronta", kf.IdKurzFronta);
            command.Parameters.AddWithValue("@IdStudent", kf.IdStudent);
            command.Parameters.AddWithValue("@IdKurz", kf.IdKurz);
            command.Parameters.AddWithValue("@TStamp", kf.Stamp);
        }
        
        // todo: decide to keep or not this method
        private static Collection<KurzFronta> Read(SqlDataReader reader, bool complete)
        {
            Collection<KurzFronta> kurzFrontas = new Collection<KurzFronta>();

            while (reader.Read())
            {
                KurzFronta kf = new KurzFronta();

                int i = -1;

                kf.IdKurzFronta = reader.GetInt32(++i);
                kf.Stamp = reader.GetDateTime(++i);
                kf.IdStudent = reader.GetInt32(++i);
                kf.Student = StudentTable.SelectOne(kf.IdStudent);
                kf.IdKurz = reader.GetInt32(++i);
                kf.Kurz = KurzTable.SelectOne(kf.IdKurz);
                
                kurzFrontas.Add(kf);
            }

            return kurzFrontas;
        }

        private static Collection<Student> ReadStudents(SqlDataReader reader, bool complete)
        {
            Collection<Student> students = new Collection<Student>();

            while (reader.Read())
            {
                Student student = new Student();

                int i = -1;

                student.IdStudent = reader.GetInt32(++i);
                student.DatumRegistrace = DateTime.Parse(reader.GetString(++i));
                if (!reader.IsDBNull(++i))
                {
                    student.PosledniPrihlaseni = DateTime.Parse(reader.GetString(i));
                }
                student.Jmeno = reader.GetString(++i);
                student.Prijmeni = reader.GetString(++i);
                student.Login = reader.GetString(++i);
                student.Heslo = reader.GetString(++i);
                student.TypStudia = new TypStudia();
                student.TypStudia.IdTypStudia = reader.GetInt32(++i);

                students.Add(student);
            }

            return students;
        }
    }
}