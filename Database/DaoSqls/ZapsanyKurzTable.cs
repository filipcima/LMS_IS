﻿using System;
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

        private static string SQL_RUNNING_COURSES = 
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz FROM " +
            "ZapsanyKurz z WHERE getdate() > DatumZapisu AND (getdate() < DatumUkonceni OR DatumUkonceni IS NULL)";

        private static string SQL_STOPPED_COURSES = 
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz FROM " +
            "ZapsanyKurz z WHERE getdate() > DatumZapisu AND (getdate() > DatumUkonceni OR DatumUkonceni IS NOT NULL)";

        private static string SQL_COURSES_BY_STUDENT = 
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz FROM " +
            "ZapsanyKurz z WHERE Student_IdStudent=@IdStudent";

        private static string SQL_COURSES_BY_TEACHER = 
            "SELECT z.IdRegistrace, z.DatumZapisu, z.DatumUkonceni, z.Splneno, z.Student_IdStudent, z.Kurz_IdKurz FROM " +
            "ZapsanyKurz z JOIN Kurz k ON k.IdKurz = z.kurz_IdKurz WHERE k.Vyucujici_IdVyucujici=@IdVyucujici";
        
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
                    Collection<ZapsanyKurz> kurzy = Read(reader, false);
                    
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
                    Collection<ZapsanyKurz> kurzy = Read(reader, false);
                    
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
                    Collection<ZapsanyKurz> kurzy = Read(reader, false);
                    
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
                    Collection<ZapsanyKurz> kurzy = Read(reader, false);
                    
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
                    zapsanyKurz.Student.DatumRegistrace = DateTime.Parse(reader.GetString(++i));
                    zapsanyKurz.Kurz.Nazev = reader.GetString(++i);
                    zapsanyKurz.Kurz.Popis = reader.GetString(++i);
                    zapsanyKurz.Kurz.Vytvoren = DateTime.Parse(reader.GetString(++i));
                    zapsanyKurz.Kurz.IdVyucujici = reader.GetInt32(++i);
                    zapsanyKurz.Kurz.Kapacita = reader.GetByte(++i);
                }

                zapsaneKurzy.Add(zapsanyKurz);
            }
            
            return zapsaneKurzy;
        }   
    }
}