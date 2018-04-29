using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public class VyukovyMaterialTable
    {
        private static string TABLE_NAME = "VyukovyMaterial";
        
        private static string SQL_INSERT = "INSERT INTO VyukovyMaterial VALUES (@Nazev, @Text, @Vlozen, " +
                                          "@IdVyucujici, @IdKurz)";

        private static string SQL_UPDATE = "UPDATE VyukovyMaterial SET IdVyukovyMaterial=@IdVyukovyMaterial, " +
                                          "Nazev=@Nazev, Text=@Text, Vlozen=@Vlozen, Vyucujici_IdVyucujici=" +
                                          "@IdVyucujici, Kurz_IdKurz=@IdKurz";

        private static string SQL_DELETE_ID = "DELETE FROM VyukovyMaterial WHERE IdVyukovyMaterial=@IdVyukovyMaterial";

        private static string SQL_SELECT_ID = "SELECT vm.idvyukovymaterial, vm.nazev, vm.text, vm.vlozen, v.idvyucujici, " +
                                             "v.titul, v.jmeno, v.prijmeni, v.login, v.heslo, v.datumnarozeni, k.idkurz, " +
                                             "k.nazev, k.popis, k.vytvoren, k.ukoncen, k.vyucujici_idvyucujici, " +
                                             "k.obor_idobor, k.kapacita FROM VyukovyMaterial vm JOIN Kurz k ON " +
                                             "vm.kurz_idkurz = k.idkurz JOIN vyucujici v ON vm.vyucujici_idvyucujici " +
                                             "= v.idvyucujici WHERE IdVyukovyMAterial=@IdVyukovyMaterial";

        private static string SQL_MATERIALS_BY_COURSE = "SELECT vm.idvyukovymaterial, vm.nazev, vm.text, vm.vlozen " +
                                                       "FROM vyukovymaterial vm JOIN kurz k ON vm.kurz_idkurz = " +
                                                       "k.idkurz WHERE k.idkurz = @IdKurz";
        
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

                    Collection<VyukovyMaterial> materialy = Read(reader, true);
                    
                    return materialy;
                }
            }
            
        }
        
        private static void PrepareCommand(SqlCommand command, VyukovyMaterial vm)
        {
            command.Parameters.AddWithValue("@IdMaterial", vm.IdVyukovyMaterial);
            command.Parameters.AddWithValue("@Nazev", vm.Nazev);
            command.Parameters.AddWithValue("@Popis", vm.Text);
            command.Parameters.AddWithValue("@Vytvoren", vm.Vlozen);
            command.Parameters.AddWithValue("@IdVyucujici", vm.Autor.IdVyucujici);
            command.Parameters.AddWithValue("@IdKurz", vm.Kurz.IdKurz);
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
                vm.Vlozen = DateTime.Parse(reader.GetString(++i));
                vm.Autor = new Vyucujici();
                vm.Autor.IdVyucujici = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    vm.Autor.Titul = reader.GetString(i);
                }
                vm.Autor.Jmeno = reader.GetString(++i);
                vm.Autor.Prijmeni = reader.GetString(++i);
                vm.Autor.Login = reader.GetString(++i);
                vm.Autor.Heslo = reader.GetString(++i);
                vm.Autor.DatumNarozeni = DateTime.Parse(reader.GetString(++i));
                
                vm.Kurz = new Kurz();
                vm.Kurz.IdKurz = reader.GetInt32(++i);
                vm.Kurz.Nazev = reader.GetString(++i);
                if (!reader.IsDBNull(++i))
                {
                    vm.Kurz.Popis = reader.GetString(i);
                }
                vm.Kurz.Vytvoren = DateTime.Parse(reader.GetString(++i));
                if (!reader.IsDBNull(++i))
                {
                    vm.Kurz.Ukoncen = DateTime.Parse(reader.GetString(i));
                }
                vm.Kurz.Obor = new Obor();
                vm.Kurz.Obor.IdObor = reader.GetInt32(++i);
                
                vm.Kurz.Kapacita = reader.GetInt32(++i);
                materialy.Add(vm);
            }
            
            return materialy;
        }

        
    }
}