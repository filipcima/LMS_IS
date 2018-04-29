using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public class HistorieMaterialuTable
    {
        private static string TABLE_NAME = "HistorieMaterialu";
        
        // not needed, we only want to insert into this table through the update trigger on VyukovyMaterial
        // public static string SQL_INSERT = "INSERT INTO HistorieMaterialu VALUES (@IdHistorie, @DatumZmeny, @Typ...)";
        
        // no need to update this table
        
        private static string SQL_DELETE_ID = "DELETE FROM HistorieMaterialu WHERE IdHistorie=@IdHistorie";
        private static string SQL_SELECT_ID = "SELECT IdHistorie, DatumZmeny, TypZmeny, VyukovyMaterial_Id, h.Nazev, " +
                                             "h.Text, h.Vlozen, v.nazev, v.vlozen, v.vyucujici_idvyucujici, v.kurz_idkurz " +
                                             "FROM historiematerialu h JOIN vyukovymaterial v ON h.vyukovymaterial_id = " +
                                             "v.idvyukovymaterial WHERE IdHistorie=@IdHistorie ";
        private static string SQL_SELECT_LIST_ID = "SELECT IdHistorie, DatumZmeny, TypZmeny, VyukovyMaterial_Id, h.Nazev, " +
                                                  "h.Text, h.Vlozen, v.nazev, v.text, v.vlozen, v.vyucujici_idvyucujici, " +
                                                  "v.kurz_idkurz FROM historiematerialu h JOIN vyukovymaterial v " +
                                                  "ON h.vyukovymaterial_id = v.idvyukovymaterial " +
                                                  "WHERE h.vyukovymaterial_id = @IdVyukovyMaterial";
        
        
        public static int Delete(int idHistorie)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdKurzFronta", idHistorie);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
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
            command.Parameters.AddWithValue("@IdVyukovyMaterial", hm.Material.IdVyukovyMaterial);
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
                hm.Material.IdVyukovyMaterial = reader.GetInt32(++i);
                hm.Nazev = reader.GetString(++i);
                hm.Text = reader.GetString(++i);
                hm.Vlozen = reader.GetDateTime(++i);
                hm.Material.Nazev = reader.GetString(++i);
                hm.Material.Text = reader.GetString(++i);
                hm.Material.Autor.IdVyucujici = reader.GetInt32(++i);
                
                
                /*
                IdHistorie, DatumZmeny, TypZmeny, VyukovyMaterial_Id, h.Nazev, " +
                "h.Text, h.Vlozen, v.nazev, v.text, v.vlozen, v.vyucujici_idvyucujici, " +
                    "v.kurz_idkurz*/ 
                historieMaterialuCollection.Add(hm);
            }

            return historieMaterialuCollection;
        }

        private static Collection<Student> ReadStudents(SqlDataReader reader, bool complete)
        {
            Collection<Student> students = new Collection<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                int i = -1;

                
                
                students.Add(student);
            }

            return students;
        }
        
        
        
        
    }
}