using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class OborTable
    {
        private static string TABLE_NAME = "Obor";
        private static string SQL_INSERT = "INSERT INTO Obor VALUES (@Nazev, @Popis)";
        private static string SQL_UPDATE = "UPDATE Obor SET Nazev=@Nazev, Popis=@Popis WHERE IdObor=@IdObor";
        private static string SQL_DELETE_ID = "DELETE FROM Obor WHERE IdObor=@IdObor";
        private static string SQL_SELECT_ID = "SELECT IdObor, Nazev, Popis FROM Obor WHERE IdObor=@IdObor";
        private static string SQL_SELECT_ALL = "SELECT IdObor, Nazev, Popis FROM Obor";
        private static string SQL_SELECT_BY_NAME = "SELECT IdObor FROM Obor WHERE Nazev=@Nazev";
        
        public static int Insert(Obor obor, Database pDb = null)
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
            PrepareCommand(command, obor);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(Obor obor)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, obor);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int idObor)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdObor", idObor);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        
        public static Obor SelectOne(int idObor)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdObor", idObor);

                    SqlDataReader reader = db.Select(command);

                    Collection<Obor> obory = Read(reader, true);

                    if (obory.Count == 1)
                    {
                        return obory[0];
                    }
                }
            }
            return null;
        }

        public static Obor SelectOneByName(string name)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_BY_NAME))
                {
                    command.Parameters.AddWithValue("@Nazev", name);

                    SqlDataReader reader = db.Select(command);

                    Collection<Obor> obory = Read(reader, false);

                    if (obory.Count == 1)
                    {
                        return obory[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Obor> SelectAll()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ALL))
                {
                    SqlDataReader reader = db.Select(command);

                    Collection<Obor> obory = Read(reader, true);

                    return obory;
                }
            }
        }
        
        private static void PrepareCommand(SqlCommand command, Obor obor)
        {
            command.Parameters.AddWithValue("@IdObor", obor.IdObor);
            command.Parameters.AddWithValue("@Nazev", obor.Nazev);
            command.Parameters.AddWithValue("@Popis", obor.Popis);
        }
        
        private static Collection<Obor> Read(SqlDataReader reader, bool complete)
        {
            Collection<Obor> obory = new Collection<Obor>();

            while (reader.Read())
            {
                Obor obor = new Obor();
                int i = -1;
                obor.IdObor = reader.GetInt32(++i);
                
                if (complete)
                {
                    obor.Nazev = reader.GetString(++i);
                    obor.Popis = reader.GetString(++i);
                }

                obory.Add(obor);
            }
            
            return obory;
        }

    }
}