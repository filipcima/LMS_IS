using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public class ZapsanyKurzTable
    {
        private static string TABLE_NAME = "ZapsanyKurz";
        
        private static string SQL_INSERT = "spZapisKurz";
        
        private static string SQL_UPDATE = "UPDATE ZapsanyKurz SET DatumZapisu=@DatumZapisu, DatumUkonceni=" +
                                           "@DatumUkonceni, Splneno=@Splneno, Student_IdStudent=@IdStudent, " +
                                           "Kurz_IdKurz=@IdKurz WHERE IdRegistrace=@IdRegistrace";
        
        private static string SQL_DELETE_ID = "DELETE FROM ZapsanyKurz WHERE IdRegistrace=@IdRegistrace";
        
        private static string SQL_SELECT_ID = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, Student_IdStudent, " +
                                              "Kurz_IdKurz FROM ZapsanyKurz WHERE IdRegistrace=@IdRegistrace";

        private static string SQL_RUNNING_COURSES = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, Student_IdStudent, Kurz_IdKurz FROM ZapsanyKurz WHERE getdate() > DatumZapisu AND (getdate() < DatumUkonceni OR DatumUkonceni IS NULL)";

        private static string SQL_STOPPED_COURSES = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, Student_IdStudent, Kurz_IdKurz FROM ZapsanyKurz WHERE getdate() > DatumZapisu AND (getdate() > DatumUkonceni OR DatumUkonceni IS NOT NULL)";

        private static string SQL_COURSES_BY_STUDENT = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, Student_IdStudent, Kurz_IdKurz FROM ZapsanyKurz WHERE Student_IdStudent=@IdStudent";

        private static string SQL_COURSES_BY_TEACHER = "SELECT IdRegistrace, DatumZapisu, DatumUkonceni, Splneno, Student_IdStudent, Kurz_IdKurz FROM ZapsanyKurz JOIN Kurz ON kurz.IdKurz = zapsanykurz.kurz_IdKurz WHERE kurz.Vyucujici_IdVyucujici=@IdVyucujici";
        
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
        
        public static Collection<ZapsanyKurz> SelectRunningCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_RUNNING_COURSES))
                {
                    SqlDataReader reader = db.Select(command);
                    Collection<ZapsanyKurz> kurzy = Read(reader, true);
                    
                    return kurzy;
                }
            }
        }
        
        public static Collection<ZapsanyKurz> SelectStoppedCourses()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_STOPPED_COURSES))
                {
                    SqlDataReader reader = db.Select(command);
                    Collection<ZapsanyKurz> kurzy = Read(reader, true);
                    
                    return kurzy;
                }
            }
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
                zapsanyKurz.DatumZapisu = DateTime.Parse(reader.GetString(++i));
                
                if (!reader.IsDBNull(++i))
                {
                    zapsanyKurz.DatumUkonceni = DateTime.Parse(reader.GetString(i));
                }
                
                if (!reader.IsDBNull(++i))
                {
                    zapsanyKurz.Splneno = reader.GetBoolean(i);
                }

                zapsanyKurz.IdStudent = reader.GetInt32(++i);
                zapsanyKurz.Student = StudentTable.SelectOne(zapsanyKurz.IdStudent);
                zapsanyKurz.IdKurz = reader.GetInt32(++i);
                zapsanyKurz.Kurz = KurzTable.SelectOne(zapsanyKurz.IdKurz);
                
                zapsaneKurzy.Add(zapsanyKurz);
            }
            
            return zapsaneKurzy;
        }   
    }
}