using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class ZapsanyKurzTable
    {
        private static string TABLE_NAME = "ZapsanyKurz";
        
        private static string SQL_INSERT = "spZapisKurz";
        
        private static string SQL_UPDATE = "UPDATE ZapsanyKurz SET DatumZapisu=@DatumZapisu, DatumUkonceni=" +
                                           "@DatumUkonceni, Splneno=@Splneno, Student_IdStudent=@IdStudent, " +
                                           "Kurz_IdKurz=@IdKurz WHERE IdRegistrace=@IdRegistrace";
        
        private static string SQL_DELETE_ID = "DELETE FROM ZapsanyKurz WHERE IdRegistrace=@IdRegistrace";
        
        private static string SQL_SELECT_ID = 
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz, " +
            "s.Jmeno, s.Prijmeni, s.Login, s.DatumRegistrace, k.Nazev, k.Popis, k.Vytvoren, k.Vyucujici_IdVyucujici, " +
            "k.Kapacita FROM ZapsanyKurz z JOIN Kurz k on k.IdKurz = z.Kurz_IdKurz JOIN Student s ON s.IdStudent = " +
            "z.Student_IdStudent WHERE IdRegistrace=@IdRegistrace";

        private static string SQL_COURSES_BY_STUDENT =
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz, " +
            "s.Jmeno, s.Prijmeni, s.Login, s.DatumRegistrace, k.Nazev, k.Popis, k.Vytvoren, k.Vyucujici_IdVyucujici, " +
            "k.Kapacita FROM ZapsanyKurz z JOIN Kurz k on k.IdKurz = z.Kurz_IdKurz JOIN Student s ON s.IdStudent = " +
            "z.Student_IdStudent WHERE Student_IdStudent=@IdStudent";

        private static string SQL_COURSES_BY_TEACHER =
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz, " +
            "s.Jmeno, s.Prijmeni, s.Login, s.DatumRegistrace, k.Nazev, k.Popis, k.Vytvoren, k.Vyucujici_IdVyucujici, " +
            "k.Kapacita FROM ZapsanyKurz z JOIN Kurz k on k.IdKurz = z.Kurz_IdKurz JOIN Student s ON s.IdStudent = " +
            "z.Student_IdStudent WHERE k.Vyucujici_IdVyucujici=@IdVyucujici";

        private static string SQL_AVG_MARK = "SELECT avg(p.znamka) FROM pisemka p JOIN zapsanykurz z ON " +
                                            "p.zapsanykurz_idregistrace = z.idregistrace WHERE z.IdRegistrace = @IdRegistrace";

        public static int Insert(ZapsanyKurz zk, Database pDb = null)
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
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdKurz", zk.IdKurz);
            command.Parameters.AddWithValue("@IdStudent", zk.IdStudent);
            
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(ZapsanyKurz zapsanyKurz)
        {
            using (var db = new Database())
            {
                db.Connect();

                SqlCommand command = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(command, zapsanyKurz);
                int ret = db.ExecuteNonQuery(command);
                
                return ret;
            }
        }

        public static int Delete(int idRegistrace)
        {
            using (var db = new Database())
            {
                db.Connect();
                db.BeginTransaction();

                SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

                command.Parameters.AddWithValue("@IdRegistrace", idRegistrace);
                int ret = db.ExecuteNonQuery(command);
                db.EndTransaction();
                return ret;
            }
        }

        public static ZapsanyKurz SelectOne(int idRegistrace)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdRegistrace", idRegistrace);

                    SqlDataReader reader = db.Select(command);

                    Collection<ZapsanyKurz> zapsaneKurzy = Read(reader, true);

                    if (zapsaneKurzy.Count == 1)
                    {
                        return zapsaneKurzy[0];
                    }
                }
            }
            return null;
        }

        public static Collection<ZapsanyKurz> SelectCoursesByIdStudent(int idStudent)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_COURSES_BY_STUDENT))
                {
                    command.Parameters.AddWithValue("@IdStudent", idStudent);
                    SqlDataReader reader = db.Select(command);
                    Collection<ZapsanyKurz> kurzy = Read(reader, true);

                    return kurzy;
                }
            }
        }

        public static Collection<ZapsanyKurz> SelectCoursesByIdTeacher(int idTeacher)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_COURSES_BY_TEACHER))
                {
                    command.Parameters.AddWithValue("@IdVyucujici", idTeacher);
                    SqlDataReader reader = db.Select(command);
                    Collection<ZapsanyKurz> kurzy = Read(reader, true);

                    return kurzy;
                }
            }
        }

        public static double? GetAvgMark(int idRegistrace)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_AVG_MARK))
                {
                    command.Parameters.AddWithValue("@IdRegistrace", idRegistrace);

                    SqlDataReader reader = db.Select(command);
                    while (reader.Read())
                    {
                        if(!reader.IsDBNull(0))
                        {
                            return reader.GetInt32(0);
                        } else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        private static void PrepareCommand(SqlCommand command, ZapsanyKurz zapsanyKurz)
        {
            command.Parameters.AddWithValue("@IdRegistrace", zapsanyKurz.IdRegistrace);
            command.Parameters.AddWithValue("@DatumZapisu", zapsanyKurz.DatumZapisu);
            command.Parameters.AddWithValue("@DatumUkonceni", zapsanyKurz.DatumUkonceni == null ? DBNull.Value : 
                (object)zapsanyKurz.DatumUkonceni);
            command.Parameters.AddWithValue("@Splneno", zapsanyKurz.Splneno == null ? DBNull.Value : 
                (object)zapsanyKurz.Splneno);
            command.Parameters.AddWithValue("@IdStudent", zapsanyKurz.IdStudent);
            command.Parameters.AddWithValue("@IdKurz", zapsanyKurz.IdKurz);
        }
                
        private static Collection<ZapsanyKurz> Read(SqlDataReader reader, bool complete)
        {
            Collection<ZapsanyKurz> zapsaneKurzy = new Collection<ZapsanyKurz>();

            while (reader.Read())
            {
                ZapsanyKurz zapsanyKurz = new ZapsanyKurz();
                int i = -1;
                zapsanyKurz.IdRegistrace = reader.GetInt32(++i);
                zapsanyKurz.DatumZapisu = reader.GetDateTime(++i);
                
                if (!reader.IsDBNull(++i))
                {
                    zapsanyKurz.DatumUkonceni = reader.GetDateTime(i);
                }
                
                if (!reader.IsDBNull(++i))
                {
                    zapsanyKurz.Splneno = reader.GetBoolean(i);
                }

                zapsanyKurz.IdStudent = reader.GetInt32(++i);
                zapsanyKurz.IdKurz = reader.GetInt32(++i);
                if (complete)
                {
                    zapsanyKurz.Student = new Student();
                    zapsanyKurz.Kurz = new Kurz();
                    zapsanyKurz.Student.IdStudent = zapsanyKurz.IdStudent;
                    zapsanyKurz.Kurz.IdKurz = zapsanyKurz.IdKurz;
                    zapsanyKurz.Student.Jmeno = reader.GetString(++i);
                    zapsanyKurz.Student.Prijmeni = reader.GetString(++i);
                    zapsanyKurz.Student.Login = reader.GetString(++i);
                    zapsanyKurz.Student.DatumRegistrace = reader.GetDateTime(++i);
                    zapsanyKurz.Kurz.Nazev = reader.GetString(++i);
                    zapsanyKurz.Kurz.Popis = reader.GetString(++i);
                    zapsanyKurz.Kurz.Vytvoren = reader.GetDateTime(++i);
                    zapsanyKurz.Kurz.IdVyucujici = reader.GetInt32(++i);
                    zapsanyKurz.Kurz.Kapacita = reader.GetByte(++i);
                }

                zapsaneKurzy.Add(zapsanyKurz);
            }
            
            return zapsaneKurzy;
        }   
    }
}