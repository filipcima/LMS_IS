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
            command.Parameters.AddWithValue("@p_vyucujici_id", kurz.Vyucujici.IdVyucujici);
            command.Parameters.AddWithValue("@p_obor_id", kurz.Obor.IdObor);
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
        
        public static int? GetStudentsCount(int idKurz)
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

            return null;
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
                    kurz.Vytvoren = DateTime.Parse(reader.GetString(++i));
                    if (!reader.IsDBNull(++i))
                    {
                        kurz.Ukoncen = DateTime.Parse(reader.GetString(i));
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
    }
}