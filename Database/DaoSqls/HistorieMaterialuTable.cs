using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class HistorieMaterialuTable
    {
        private static string TABLE_NAME = "HistorieMaterialu";
        
        // not needed, we only want to insert into this table through the update trigger on VyukovyMaterial
        // public static string SQL_INSERT = "INSERT INTO HistorieMaterialu VALUES (@IdHistorie, @DatumZmeny, @Typ...)";
        
        // no need to update this table
        
        private static string SQL_DELETE_ID = "DELETE FROM HistorieMaterialu WHERE IdHistorie=@IdHistorie";
        
        private static string SQL_SELECT_ID = "SELECT h.IdHistorie, h.DatumZmeny, h.TypZmeny, h.VyukovyMaterial_Id, h.Nazev, " +
                                             "h.Text, h.Vlozen FROM historiematerialu h WHERE IdHistorie=@IdHistorie ";
        
        private static string SQL_SELECT_LIST_ID = 
            "SELECT IdHistorie, DatumZmeny, TypZmeny, VyukovyMaterial_Id, h.Nazev, h.Text, h.Vlozen, v.Nazev, v.Text, " +
            "v.Kurz_IdKurz, v.Vyucujici_IdVyucujici FROM historiematerialu h JOIN VyukovyMaterial v ON " +
            "v.IdVyukovyMaterial = h.VyukovyMaterial_Id WHERE h.vyukovymaterial_id = @IdVyukovyMaterial";
        
        public static int Delete(int idHistorie)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdHistorie", idHistorie);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static HistorieMaterialu GetParticularMaterial(int idHistorie)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdHistorie", idHistorie);

                    SqlDataReader reader = db.Select(command);

                    Collection<HistorieMaterialu> materials = Read(reader, false);
                    
                    return materials.Count == 1 ? materials[0] : null;
                }
            }
        }
        
        public static Collection<HistorieMaterialu> GetMaterialsByIdVyukovyMaterial(int idVyukovyMaterial)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_LIST_ID))
                {
                    command.Parameters.AddWithValue("@IdVyukovyMaterial", idVyukovyMaterial);

                    SqlDataReader reader = db.Select(command);

                    Collection<HistorieMaterialu> materials = Read(reader, true);

                    return materials;
                }
            }
        }

        private static void PrepareCommand(SqlCommand command, HistorieMaterialu hm)
        {
            command.Parameters.AddWithValue("@IdHistorie", hm.IdHistorie);
            command.Parameters.AddWithValue("@DatumZmeny", hm.DatumZmeny);
            command.Parameters.AddWithValue("@TypZmeny", hm.TypZmeny);
            command.Parameters.AddWithValue("@IdVyukovyMaterial", hm.IdVyukovyMaterial);
            command.Parameters.AddWithValue("@Nazev", hm.Nazev);
            command.Parameters.AddWithValue("@Text", hm.Text);
            command.Parameters.AddWithValue("@Vlozen", hm.Vlozen);
        }
        
        private static Collection<HistorieMaterialu> Read(SqlDataReader reader, bool complete)
        {
            Collection<HistorieMaterialu> historieMaterialuCollection = new Collection<HistorieMaterialu>();

            while (reader.Read())
            {
                HistorieMaterialu hm = new HistorieMaterialu();
                int i = -1;
                
                hm.IdHistorie = reader.GetInt32(++i);
                hm.DatumZmeny = DateTime.Parse(reader.GetString(++i));
                hm.TypZmeny = reader.GetString(++i);
                hm.IdVyukovyMaterial= reader.GetInt32(++i);
                hm.Nazev = reader.GetString(++i);
                hm.Text = reader.GetString(++i);
                hm.Vlozen = DateTime.Parse(reader.GetString(++i));
                if (complete)
                {
                    hm.Material = new VyukovyMaterial();
                    hm.Material.IdVyukovyMaterial = hm.IdVyukovyMaterial;
                    hm.Material.Nazev = reader.GetString(++i);
                    hm.Material.Text = reader.GetString(++i);
                    hm.Material.IdKurz = reader.GetInt32(++i);
                    hm.Material.IdVyucujici = reader.GetInt32(++i);
                }
                
                historieMaterialuCollection.Add(hm);
            }

            return historieMaterialuCollection;
        }
    }
}