using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public class VyucujiciTable
    {
        private static string TABLE_NAME = "Vyucujici";

        private static string SQL_INSERT = "INSERT INTO Vyucujici VALUES (@Titul, @Jmeno, @Prijmeni, @Login," +
                                          "@Heslo, @DatumNarozeni)";

        private static string SQL_UPDATE = "UPDATE Vyucujici SET IdVyucujici=@IdVyucujici, Titul=@Titul, Jmeno=@Jmeno, " +
                                          "Prijmeni=@Prijmeni, DatumRegistrace=@DatumRegistrace, Login=@Login, " +
                                          "Heslo=@Heslo, PosledniPrihlaseni=@PosledniPrihlaseni WHERE IdVyucujici=@IdVyucujici";

        private static string SQL_DELETE_ID = "DELETE FROM Vyucujici WHERE Vyucujici=@IdVyucujici";

        private static string SQL_SELECT_ID = "SELECT IdVyucujici, Titul, Jmeno, Prijmeni, \"Login\", " +
                                             "Heslo, DatumNarozeni FROM Student JOIN TypStudia ON TypStudia.IdTypStudia=" +
                                             "Student.TypStudia_IdTypStudia WHERE IdStudent=@IdStudent";

        private static string SQL_SELECT_BY_COURSE_NAME = "SELECT * FROM vyucujici v JOIN kurz k ON v.idvyucujici = " +
                                                         "k.vyucujici_idvyucujici WHERE k.nazev = @Nazev";
        
        
        public static int Insert(Vyucujici vyucujici, Database pDb = null)
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
            PrepareCommand(command, vyucujici);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(Vyucujici vyucujici)
        {
            using (var db = new Database())
            {
                db.Connect();

                SqlCommand command = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(command, vyucujici);
                int ret = db.ExecuteNonQuery(command);
                
                return ret;
            }
        }

        public static int Delete(int idVyucujici)
        {
            using (var db = new Database())
            {
                db.Connect();
                SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

                command.Parameters.AddWithValue("@IdVyucujici", idVyucujici);
                int ret = db.ExecuteNonQuery(command);

                return ret;
            }
        }

        public static Vyucujici SelectOne(int idVyucujici)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdVyucujici", idVyucujici);

                    SqlDataReader reader = db.Select(command);

                    Collection<Vyucujici> teachers = Read(reader, true);

                    if (teachers.Count == 1)
                    {
                        return teachers[0];
                    }
                }
            }
            return null;
        }
        
        public static Collection<Vyucujici> SelectByCourseName(string courseName)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_BY_COURSE_NAME))
                {
                    command.Parameters.AddWithValue("@Nazev", courseName);
                    SqlDataReader reader = db.Select(command);
                    Collection<Vyucujici> teachers = Read(reader, true);
                    
                    return teachers;
                }
            }
        }
        
        private static void PrepareCommand(SqlCommand command, Vyucujici vyucujici)
        {
            command.Parameters.AddWithValue("@IdVyucujici", vyucujici.IdVyucujici);
            command.Parameters.AddWithValue("@Titul", vyucujici.Titul == null ? DBNull.Value : (object)vyucujici.Titul);
            command.Parameters.AddWithValue("@Jmeno", vyucujici.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", vyucujici.Prijmeni);
            command.Parameters.AddWithValue("@Login", vyucujici.Login);
            command.Parameters.AddWithValue("@Heslo", vyucujici.Heslo);
            command.Parameters.AddWithValue("@DatumNarozeni", vyucujici.DatumNarozeni);
        }
                
        private static Collection<Vyucujici> Read(SqlDataReader reader, bool complete)
        {
            Collection<Vyucujici> teachers = new Collection<Vyucujici>();

            while (reader.Read())
            {
                Vyucujici vyucujici = new Vyucujici();
                int i = -1;
                vyucujici.IdVyucujici= reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    vyucujici.Titul = reader.GetString(i);
                }
                vyucujici.Jmeno = reader.GetString(++i);
                vyucujici.Prijmeni = reader.GetString(++i);
                vyucujici.Login = reader.GetString(++i);
                vyucujici.Heslo = reader.GetString(++i);
                vyucujici.DatumNarozeni = DateTime.Parse(reader.GetString(++i));
                
                teachers.Add(vyucujici);
            }
            
            return teachers;
        }   
    
    }
}