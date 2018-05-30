using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class VyukovyMaterialTable
    {
        private static string TABLE_NAME = "VyukovyMaterial";
        
        private static string SQL_INSERT = "INSERT INTO VyukovyMaterial VALUES (@Nazev, @Text, @Vlozen, " +
                                          "@IdVyucujici, @IdKurz)";

        private static string SQL_UPDATE = "UPDATE VyukovyMaterial SET Nazev=@Nazev, Text=@Text, Vlozen=@Vlozen, " +
                                           "Vyucujici_IdVyucujici=@IdVyucujici, Kurz_IdKurz=@IdKurz";

        private static string SQL_DELETE_ID = "DELETE FROM VyukovyMaterial WHERE IdVyukovyMaterial=@IdVyukovyMaterial";

        private static string SQL_SELECT_ID = "SELECT vm.idvyukovymaterial, vm.nazev, vm.text, vm.vlozen, " +
                                              "vm.vyucujici_idvyucujici, vm.kurz_IdKurz, k.Nazev, k.Popis, " +
                                              "k.Vyucujici_IdVyucujici, k.Obor_IdObor, k.Kapacita, v.Titul, v.Jmeno, " +
                                              "v.Prijmeni FROM VyukovyMaterial vm JOIN vyucujici v ON v.IdVyucujici = " +
                                              "vm.Vyucujici_IdVyucujici JOIN Kurz k ON k.IdKurz = vm.Kurz_IdKurz WHERE " +
                                              "IdVyukovyMaterial=@IdVyukovyMaterial";

        private static string SQL_MATERIALS_BY_COURSE = "SELECT vm.idvyukovymaterial, vm.nazev, vm.text, vm.vlozen, " +
                                                        "vm.vyucujici_idvyucujici, vm.kurz_IdKurz, v.Titul, v.Jmeno, " +
                                                        "v.Prijmeni FROM VyukovyMaterial vm JOIN vyucujici v ON v.IdVyucujici = " +
                                                        "vm.Vyucujici_IdVyucujici JOIN Kurz k ON k.IdKurz = vm.Kurz_IdKurz " +
                                                        "WHERE k.IdKurz=@IdKurz";
        
        public static int Insert(VyukovyMaterial vm, Database pDb = null)
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
            PrepareCommand(command, vm);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(VyukovyMaterial vm)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, vm);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int idMaterial)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdVyukovyMaterial", idMaterial);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        
        public static VyukovyMaterial SelectOne(int idMaterial)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdVyukovyMaterial", idMaterial);

                    SqlDataReader reader = db.Select(command);

                    Collection<VyukovyMaterial> materialy = Read(reader, true);

                    if (materialy.Count == 1)
                    {
                        return materialy[0];
                    }
                }
            }
            return null;
        }
        public static Collection<VyukovyMaterial> SelectByCourse(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_MATERIALS_BY_COURSE))
                {
                    command.Parameters.AddWithValue("@IdKurz", idKurz);

                    SqlDataReader reader = db.Select(command);

                    Collection<VyukovyMaterial> materialy = Read(reader, false);
                    
                    return materialy;
                }
            }
            
        }
        
        private static void PrepareCommand(SqlCommand command, VyukovyMaterial vm)
        {
            command.Parameters.AddWithValue("@IdVyukovyMaterial", vm.IdVyukovyMaterial);
            command.Parameters.AddWithValue("@Nazev", vm.Nazev);
            command.Parameters.AddWithValue("@Text", vm.Text);
            command.Parameters.AddWithValue("@Vlozen", vm.Vlozen);
            command.Parameters.AddWithValue("@IdVyucujici", vm.IdVyucujici);
            command.Parameters.AddWithValue("@IdKurz", vm.IdKurz);
        }
        
        private static Collection<VyukovyMaterial> Read(SqlDataReader reader, bool complete)
        {
            Collection<VyukovyMaterial> materialy = new Collection<VyukovyMaterial>();

            while (reader.Read())
            {
                VyukovyMaterial vm = new VyukovyMaterial();
                int i = -1;
                vm.IdVyukovyMaterial = reader.GetInt32(++i);
                vm.Nazev = reader.GetString(++i);
                vm.Text = reader.GetString(++i);
                vm.Vlozen = reader.GetDateTime(++i);
                vm.IdVyucujici = reader.GetInt32(++i);
                vm.IdKurz = reader.GetInt32(++i);
                if (complete)
                {
                    vm.Kurz = new Kurz();
                    vm.Kurz.IdKurz = vm.IdKurz;
                    vm.Kurz.Nazev = reader.GetString(++i);
                    vm.Kurz.Popis = reader.GetString(++i);
                    vm.Kurz.IdVyucujici = reader.GetInt32(++i);
                    vm.Kurz.IdObor = reader.GetInt32(++i);
                    vm.Kurz.Kapacita = reader.GetByte(++i);
                }
                
                vm.Autor = new Vyucujici();
                vm.Autor.IdVyucujici = vm.IdVyucujici;
                if (!reader.IsDBNull(++i))
                {
                    vm.Autor.Titul = reader.GetString(i);    
                }
                
                vm.Autor.Jmeno = reader.GetString(++i);
                vm.Autor.Prijmeni = reader.GetString(++i);
                
                materialy.Add(vm);
            }
            
            return materialy;
        }

        
    }
}