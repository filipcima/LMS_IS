using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class TypStudiaTable
    {
        private static string TABLE_NAME = "TypStudia";
        private static string SQL_SELECT_ID = "SELECT IdTypStudia, Nazev FROM TypStudia WHERE IdTypStudia=@IdTypStudia";
        private static string SQL_INSERT = "INSERT INTO TypStudia VALUES (@Nazev)";
        private static string SQL_UPDATE = "UPDATE TypStudia SET Nazev=@Nazev WHERE IdTypStudia=@IdTypStudia";
        private static string SQL_DELETE_ID = "DELETE FROM TypStudia WHERE IdTypStudia=@IdTypStudia";
    
        public static int Insert(TypStudia typStudia, Database pDb = null)
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
            PrepareCommand(command, typStudia);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(TypStudia typStudia)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, typStudia);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int idTypStudia)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdTypStudia", idTypStudia);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static TypStudia SelectOne(int idTypStudia)
        {
            Database db = new Database();
            db.Connect();

            using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
            {
                command.Parameters.AddWithValue("@IdTypStudia", idTypStudia);

                SqlDataReader reader = db.Select(command);

                Collection<TypStudia> typStudiaCollection = Read(reader, true);

                if (typStudiaCollection.Count == 1)
                {
                    return typStudiaCollection[0];
                }
            }
            
            db.Close();

            return null;
        }
        
        private static void PrepareCommand(SqlCommand command, TypStudia typStudia)
        {
            command.Parameters.AddWithValue("@IdTypStudia", typStudia.IdTypStudia);
            command.Parameters.AddWithValue("@Nazev", typStudia.Nazev);
        }
                
        private static Collection<TypStudia> Read(SqlDataReader reader, bool complete)
        {
            Collection<TypStudia> typStudiaCollection = new Collection<TypStudia>();

            while (reader.Read())
            {
                TypStudia typStudia = new TypStudia();
                int i = -1;
                typStudia.IdTypStudia = reader.GetInt32(++i);
                typStudia.Nazev = reader.GetString(++i);
                
                typStudiaCollection.Add(typStudia);
            }
            
            return typStudiaCollection;
        }
        
    }
}