using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public static class PisemkaTable
    {
        private static string TABLE_NAME = "Pisemka";

        private static string SQL_INSERT = "spVytvorPisemku";

        private static string SQL_UPDATE = "UPDATE Pisemka SET DatumTestu=@DatumTestu, " +
                                           "Znamka=@Znamka, ZapsanyKurz_IdRegistrace=@IdZapsanyKurz " +
                                           "WHERE IdPisemka=@IdPisemka";

        private static string SQL_DELETE_ID = "DELETE FROM Pisemka WHERE IdPisemka=@IdPisemka";

        private static string SQL_SELECT_ID = "SELECT p.IdPisemka, p.DatumTestu, p.Znamka, p.ZapsanyKurz_IdRegistrace, " +
                                              "zk.DatumZapisu, zk.Student_IdStudent, zk.Kurz_IdKurz FROM Pisemka p " +
                                              "JOIN ZapsanyKurz zk ON zk.IdRegistrace = p.ZapsanyKurz_IdRegistrace " +
                                              "WHERE IdPisemka=@IdPisemka";

        private static string SQL_AVG_MARK = "SELECT avg(p.znamka) FROM pisemka p JOIN zapsanykurz z ON " +
                                             "p.zapsanykurz_idregistrace = z.idregistrace WHERE z.kurz_idkurz=@IdKurz";

        private static string SQL_UPCOMING_TESTS =
            "SELECT p.IdPisemka, p.DatumTestu, k.Nazev FROM pisemka p JOIN ZapsanyKurz zk ON p.ZapsanyKurz_IdRegistrace " +
            "= zk.IdRegistrace JOIN kurz k ON k.IdKurz = zk.kurz_idkurz WHERE zk.student_idstudent=@IdStudent AND " +
            "getdate() < p.datumtestu AND zk.kurz_IdKurz = @IdKurz";

        private static string SQL_PAST_TESTS =
            "SELECT p.IdPisemka, p.DatumTestu, k.Nazev, p.Znamka FROM pisemka p JOIN ZapsanyKurz zk ON p.ZapsanyKurz_IdRegistrace " +
            "= zk.IdRegistrace JOIN kurz k ON k.IdKurz = zk.kurz_idkurz WHERE zk.student_idstudent=@IdStudent AND " +
            "getdate() > p.datumtestu AND zk.kurz_IdKurz = @IdKurz";

        private static string SQL_TEST_CHECK = "spZkontrolujPisemky";

        public static int Insert(Pisemka pisemka, Database pDb = null)
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
            command.Parameters.AddWithValue("@IdZapsanyKurz", pisemka.ZapsanyKurz.IdKurz);
            command.Parameters.AddWithValue("@DatumTestu", pisemka.DatumPisemky);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Pisemka pisemka)
        {
            var db = new Database();
            db.Connect();

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, pisemka);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int idPisemka)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@IdPisemka", idPisemka);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Pisemka SelectOne(int idPisemka)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdPisemka", idPisemka);

                    SqlDataReader reader = db.Select(command);

                    Collection<Pisemka> pisemky = Read(reader, true);

                    if (pisemky.Count == 1)
                    {
                        return pisemky[0];
                    }
                }
            }
            return null;
        }

        public static Collection<Pisemka> SelectUpcomingTests(ZapsanyKurz course)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_UPCOMING_TESTS))
                {
                    command.Parameters.AddWithValue("@IdStudent", course.IdStudent);
                    command.Parameters.AddWithValue("@IdKurz", course.IdKurz);

                    SqlDataReader reader = db.Select(command);

                    Collection<Pisemka> pisemky = Read2(reader, false);

                    return pisemky;
                }
            }
        }

        public static Collection<Pisemka> SelectPastTests(ZapsanyKurz course)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_PAST_TESTS))
                {
                    command.Parameters.AddWithValue("@IdStudent", course.IdStudent);
                    command.Parameters.AddWithValue("@IdKurz", course.IdKurz);

                    SqlDataReader reader = db.Select(command);

                    Collection<Pisemka> pisemky = Read2(reader, true);

                    return pisemky;
                }
            }
        }

        public static double? GetAvgMark(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_AVG_MARK))
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

        public static int TestCheckDaily(Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_TEST_CHECK);
            command.CommandType = CommandType.StoredProcedure;

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Pisemka pisemka)
        {
            command.Parameters.AddWithValue("@IdPisemka", pisemka.IdPisemka);
            command.Parameters.AddWithValue("@DatumTestu", pisemka.DatumPisemky);
            command.Parameters.AddWithValue("@Znamka", pisemka.Znamka);
            command.Parameters.AddWithValue("@IdZapsanyKurz", pisemka.IdZapsanyKurz);
        }

        private static Collection<Pisemka> Read(SqlDataReader reader, bool complete)
        {
            Collection<Pisemka> pisemky = new Collection<Pisemka>();

            while (reader.Read())
            {
                Pisemka pisemka = new Pisemka();
                int i = -1;
                pisemka.IdPisemka = reader.GetInt32(++i);
                if (!reader.IsDBNull(++i))
                {
                    pisemka.DatumPisemky = reader.GetDateTime(i);
                }

                if (complete)
                {
                    if (!reader.IsDBNull(++i))
                    {
                        pisemka.Znamka = reader.GetByte(i);
                    }
                }

                pisemka.IdZapsanyKurz = reader.GetInt32(++i);
                pisemka.ZapsanyKurz = new ZapsanyKurz();
                pisemka.ZapsanyKurz.IdRegistrace = pisemka.IdZapsanyKurz;
                pisemka.ZapsanyKurz.DatumZapisu = reader.GetDateTime(++i);
                pisemka.ZapsanyKurz.IdStudent = reader.GetInt32(++i);
                pisemka.ZapsanyKurz.IdKurz = reader.GetInt32(++i);

                pisemky.Add(pisemka);
            }

            return pisemky;
        }
        private static Collection<Pisemka> Read2(SqlDataReader reader, bool complete)
        {
            Collection<Pisemka> pisemky = new Collection<Pisemka>();

            while (reader.Read())
            {
                Pisemka pisemka = new Pisemka();
                int i = -1;
                pisemka.IdPisemka = reader.GetInt32(++i);
                pisemka.DatumPisemky = reader.GetDateTime(++i);
                pisemka.ZapsanyKurz = new ZapsanyKurz();
                pisemka.ZapsanyKurz.Kurz = new Kurz();
                pisemka.ZapsanyKurz.Kurz.Nazev = reader.GetString(++i);
                if (complete && !reader.IsDBNull(++i))
                {
                    pisemka.Znamka = reader.GetByte(i);
                }

                pisemky.Add(pisemka);
            }


            return pisemky;
        }
    }
}