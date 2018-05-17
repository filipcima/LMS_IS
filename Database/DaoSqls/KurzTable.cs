using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class KurzTable
    {
        private static string TABLE_NAME = "Kurz";

        private static string SQL_INSERT = "spVytvorKurz";

        private static string SQL_UPDATE = "UPDATE Kurz SET Nazev=@Nazev, Popis=@Popis, Vytvoren=@Vytvoren," +
                                          "Ukoncen=@Ukoncen, Vyucujici_IdVyucujici=@IdVyucujici, Obor_IdObor=@IdObor," +
                                          "Kapacita=@Kapacita WHERE IdKurz=@IdKurz";

        private static string SQL_DELETE_ID = "DELETE FROM Kurz WHERE IdKurz=@IdKurz";

        private static string SQL_SELECT_ID = "SELECT k.IdKurz, k.Nazev, k.Popis, k.Vytvoren, k.Ukoncen, k.Kapacita, " +
                                              "k.Vyucujici_IdVyucujici, k.Obor_IdObor, v.titul, v.jmeno, v.prijmeni, " +
                                              "o.nazev FROM kurz k JOIN Vyucujici v ON v.IdVyucujici = k.Vyucujici_Id" +
                                              "Vyucujici JOIN Obor o ON o.IdObor = k.Obor_IdOBor WHERE IdKurz=@IdKurz";

        private static string SQL_STUDENTS_COUNT_BY_COURSE = "SELECT COUNT(*) FROM ZapsanyKurz WHERE Kurz_IdKurz=@IdKurz";

        private static string SQL_COURSES_NOT_FULL = "SELECT k.IdKurz, k.Nazev, k.Popis, k.Kapacita, k.Vyucujici_IdVyucujici, " +
                                                     "k.Obor_IdObor FROM kurz k WHERE (SELECT COUNT(*) FROM zapsanykurz " +
                                                     "WHERE kurz_idkurz = k.idkurz) < k.kapacita";

        private static string SQL_ACTIVE_COURSES = "SELECT k.IdKurz, k.Nazev, k.Obor_IdObor, o.Nazev FROM kurz k JOIN obor o " +
            "ON o.idobor = k.obor_idobor WHERE k.ukoncen IS NULL OR getdate() < k.ukoncen";

        private static string SQL_SELECT_BY_NAME = "SELECT k.IdKurz, k.Nazev, k.Kapacita, k.Obor_IdObor, o.Nazev FROM kurz k " +
            "JOIN obor o ON o.idobor = k.obor_idobor WHERE k.nazev = @Nazev";

        private static string SQL_SELECT_LAST_COURSE_BY_NAME = "SELECT TOP 1 k.IdKurz, k.Nazev, k.Kapacita, k.Obor_IdObor, " +
            "o.Nazev FROM kurz k JOIN obor o ON o.idobor = k.obor_idobor WHERE k.nazev = @Nazev ORDER BY vytvoren DESC";

        private static string SQL_SELECT_BY_TEACHER = "SELECT k.IdKurz, k.Nazev, k.Obor_IdObor, o.Nazev FROM kurz k JOIN " +
            "obor o ON o.idobor = k.obor_idobor WHERE k.vyucujici_idvyucujici = @IdVyucujici";

        private static string SQL_COURSES_BY_STUDENT_ONGOING = "SELECT DISTINCT k.Nazev FROM Kurz k WHERE k.IdKurz " +
            "NOT IN(SELECT k.IdKurz FROM Kurz k JOIN ZapsanyKurz zk ON zk.Kurz_IdKurz = k.IdKurz " +
            "WHERE zk.student_IdStudent = @IdStudent OR k.ukoncen IS NOT NULL)";

        private static string SQL_RUNNING_COURSES =
            "SELECT k.IdKurz, k.Nazev, k.Popis, k.Kapacita, k.Vyucujici_IdVyucujici, k.Obor_IdObor FROM Kurz k JOIN ZapsanKurz " +
            "k ON k.IdKurz = z.Kurz_IdKurz JOIN Student s JOIN ZapsanyKurz z ON s.IdStudent = z.Student_IdStudent " +
            "WHERE getdate() > z.DatumZapisu AND (getdate() < z.DatumUkonceni OR z.DatumUkonceni IS NULL)";

        private static string SQL_STOPPED_COURSES =
            "SELECT k.IdKurz, k.Nazev, k.Popis, k.Kapacita, k.Vyucujici_IdVyucujici, k.Obor_IdObor FROM ZapsanyKurz z " +
            "WHERE getdate() > DatumZapisu AND (getdate() > DatumUkonceni OR DatumUkonceni IS NOT NULL)";
        

        public static int Insert(Kurz kurz, Database pDb = null)
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

            SqlCommand command = db.CreateCommand("spVytvorKurz");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@p_nazev", kurz.Nazev);
            command.Parameters.AddWithValue("@p_popis", kurz.Popis);
            command.Parameters.AddWithValue("@p_vyucujici_id", kurz.IdVyucujici);
            command.Parameters.AddWithValue("@p_obor_id", kurz.IdObor);
            command.Parameters.AddWithValue("@p_kapacita", kurz.Kapacita);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Kurz kurz)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, kurz);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int idKurz)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdKurz", idKurz);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Kurz SelectOne(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdKurz", idKurz);

                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read(reader, true);

                    if (kurzy.Count == 1)
                    {
                        return kurzy[0];
                    }
                }
            }
            return null;
        }

        public static Kurz SelectByCourseName(string name)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_BY_NAME))
                {
                    command.Parameters.AddWithValue("@Nazev", name);

                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read2(reader, true);

                    if (kurzy.Count == 1)
                    {
                        return kurzy[0];
                    }
                }
            }
            return null;
        }

        public static Kurz SelectLastCourseByName(string name)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_LAST_COURSE_BY_NAME))
                {
                    command.Parameters.AddWithValue("@Nazev", name);

                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read2(reader, true);

                    if (kurzy.Count == 1)
                    {
                        return kurzy[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Kurz> SelectByTeacherId(int idVyucujici)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_BY_TEACHER))
                {
                    command.Parameters.AddWithValue("@IdVyucujici", idVyucujici);

                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read2(reader, false);

                    return kurzy;
                }
            }
        }

        public static Collection<Kurz> SelectNonFullCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_COURSES_NOT_FULL))
                {
                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read(reader, false);

                    return kurzy;
                }
            }
        }
        public static Collection<Kurz> SelectActiveCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_ACTIVE_COURSES))
                {
                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = Read2(reader, true);

                    return kurzy;
                }
            }
        }


        public static int GetStudentsCount(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_STUDENTS_COUNT_BY_COURSE))
                {
                    command.Parameters.AddWithValue("@IdKurz", idKurz);

                    SqlDataReader reader = db.Select(command);
                    while (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return 0;
        }

        public static Collection<Kurz> SelectByStudentAndOngoing(string idStudent)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_COURSES_BY_STUDENT_ONGOING))
                {
                    command.Parameters.AddWithValue("@IdStudent", idStudent);

                    SqlDataReader reader = db.Select(command);

                    Collection<Kurz> kurzy = new Collection<Kurz>();

                    while (reader.Read())
                    {
                        Kurz k = new Kurz();

                        int i = -1;

                        k.Nazev = reader.GetString(++i);

                        kurzy.Add(k);
                    }
                    return kurzy;
                }
            }
        }

        public static Collection<Kurz> SelectRunningCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_RUNNING_COURSES))
                {
                    SqlDataReader reader = db.Select(command);
                    Collection<Kurz> kurzy = Read(reader, false);

                    return kurzy;
                }
            }
        }

        public static Collection<Kurz> SelectStoppedCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_STOPPED_COURSES))
                {
                    SqlDataReader reader = db.Select(command);
                    Collection<Kurz> kurzy = Read(reader, false);

                    return kurzy;
                }
            }
        }

        private static void PrepareCommand(SqlCommand command, Kurz kurz)
        {
            command.Parameters.AddWithValue("@IdKurz", kurz.IdKurz);
            command.Parameters.AddWithValue("@Nazev", kurz.Nazev);
            command.Parameters.AddWithValue("@Popis", kurz.Popis);
            command.Parameters.AddWithValue("@Vytvoren", kurz.Vytvoren);
            command.Parameters.AddWithValue("@Ukoncen", kurz.Ukoncen == null ? DBNull.Value : (object)kurz.Ukoncen);
            command.Parameters.AddWithValue("@Kapacita", kurz.Kapacita);
            command.Parameters.AddWithValue("@IdObor", kurz.IdObor);
            command.Parameters.AddWithValue("@IdVyucujici", kurz.IdVyucujici);
        }

        private static Collection<Kurz> Read(SqlDataReader reader, bool complete)
        {
            Collection<Kurz> kurzy = new Collection<Kurz>();

            while (reader.Read())
            {
                Kurz kurz = new Kurz();
                int i = -1;
                kurz.IdKurz = reader.GetInt32(++i);
                kurz.Nazev = reader.GetString(++i);
                kurz.Popis = reader.GetString(++i);
                if (complete)
                {
                    kurz.Vytvoren = reader.GetDateTime(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        kurz.Ukoncen = reader.GetDateTime(i);
                    }
                }

                kurz.Kapacita = reader.GetByte(++i);
                kurz.IdVyucujici = reader.GetInt32(++i);
                kurz.IdObor = reader.GetInt32(++i);
                if (complete)
                {
                    kurz.Vyucujici = new Vyucujici();
                    kurz.Vyucujici.IdVyucujici = kurz.IdVyucujici;
                    if (!reader.IsDBNull(++i))
                    {
                        kurz.Vyucujici.Titul = reader.GetString(i);
                    }

                    kurz.Vyucujici.Jmeno = reader.GetString(++i);
                    kurz.Vyucujici.Prijmeni = reader.GetString(++i);
                    kurz.Obor = new Obor();
                    kurz.Obor.IdObor = kurz.IdObor;
                    kurz.Obor.Nazev = reader.GetString(++i);
                }

                kurzy.Add(kurz);
            }

            return kurzy;
        }

        private static Collection<Kurz> Read2(SqlDataReader reader, bool complete)
        {
            Collection<Kurz> kurzy = new Collection<Kurz>();

            while (reader.Read())
            {
                Kurz kurz = new Kurz();
                int i = -1;
                kurz.IdKurz = reader.GetInt32(++i);
                kurz.Nazev = reader.GetString(++i);
                if (complete)
                {
                    kurz.Kapacita = reader.GetByte(++i);
                }
                kurz.IdObor = reader.GetInt32(++i);
                kurz.Obor = new Obor();
                kurz.Obor.Nazev = reader.GetString(++i);
                
                kurzy.Add(kurz);
            }

            return kurzy;
        }

    }
}