using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using LMSIS.Database.Models;

namespace LMSIS.Database.DaoSqls
{
    public class StudentTable
    {
        private static string TABLE_NAME = "Student";

        private static string SQL_INSERT = "INSERT INTO Student VALUES (@DatumRegistrace, @PosledniPrihlaseni, " +
                                          "@Jmeno, @Prijmeni, @Login, @Heslo, @TypStudia_IdTypStudia)";

        private static string SQL_UPDATE = "UPDATE Student SET Jmeno=@Jmeno, Prijmeni=@Prijmeni," +
                                          "DatumRegistrace=@DatumRegistrace, PosledniPrihlaseni=@PosledniPrihlaseni," +
                                          "Login=@Login, Heslo=@Heslo, TypStudia_IdTypStudia=@TypStudia_IdTypStudia WHERE " +
                                          "IdStudent=@IdStudent";

        private static string SQL_DELETE_ID = "DELETE FROM Student WHERE IdStudent=@IdStudent";

        private static string SQL_SELECT_ID = "SELECT IdStudent, Jmeno, Prijmeni, DatumRegistrace, PosledniPrihlaseni, " +
                                             "\"Login\", Heslo, TypStudia_IdTypStudia FROM Student WHERE IdStudent=@IdStudent";

        private static string SQL_SELECT_UNSUCESSFUL = "SELECT IdStudent, Jmeno, Prijmeni, DatumRegistrace, " +
                                                       "PosledniPrihlaseni, \"Login\", Heslo, TypStudia_IdTypStudia " +
                                                       "FROM Student s JOIN zapsanykurz z ON s.idstudent = z.student_idstudent " +
                                                       "WHERE splneno = 0 AND year(datumukonceni) = year(GETDATE()) " +
                                                       "GROUP BY IdStudent, Jmeno, Prijmeni, DatumRegistrace, " +
                                                       "PosledniPrihlaseni, \"Login\", Heslo, TypStudia_IdTypStudia " +
                                                       "HAVING count(splneno) >= 2";

        private static string SQL_SELECT_BY_ID_COURSE = 
            "SELECT IdStudent, Jmeno, Prijmeni, DatumRegistrace, PosledniPrihlaseni, " +
            "\"Login\", Heslo, TypStudia_IdTypStudia FROM zapsanykurz JOIN student s ON " +
            "zapsanykurz.student_idstudent = s.idstudent WHERE zapsanykurz.kurz_idkurz = @IdKurz";
        
        
        public static int Insert(Student student, Database pDb = null)
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
            PrepareCommand(command, student);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }
        
        public static int Update(Student student)
        {
            using (var db = new Database())
            {
                db.Connect();

                SqlCommand command = db.CreateCommand(SQL_UPDATE);
                PrepareCommand(command, student);
                int ret = db.ExecuteNonQuery(command);
                
                return ret;
            }
        }

        public static int Delete(int idStudent)
        {
            using (var db = new Database())
            {
                db.Connect();
                SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

                command.Parameters.AddWithValue("@IdStudent", idStudent);
                int ret = db.ExecuteNonQuery(command);

                return ret;
            }
        }

        public static Student SelectOne(int idStudent)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_ID))
                {
                    command.Parameters.AddWithValue("@IdStudent", idStudent);

                    SqlDataReader reader = db.Select(command);

                    Collection<Student> students = Read(reader, true);

                    if (students.Count == 1)
                    {
                        return students[0];
                    }
                }
            }
            return null;
        }
        
        public static Collection<Student> SelectUnsucessfulOnes()
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_UNSUCESSFUL))
                {
                    SqlDataReader reader = db.Select(command);
                    Collection<Student> students = Read(reader, true);
                    return students;
                }
            }
        }
        
        public static Collection<Student> SelectByCourse(int idKurz)
        {
            using (Database db = new Database())
            {
                db.Connect();

                using (SqlCommand command = db.CreateCommand(SQL_SELECT_BY_ID_COURSE))
                {
                    command.Parameters.AddWithValue("@IdKurz", idKurz);
                    SqlDataReader reader = db.Select(command);
                    Collection<Student> students = Read(reader, true);
                    return students;
                }
            }
        }
        
        private static void PrepareCommand(SqlCommand command, Student student)
        {
            command.Parameters.AddWithValue("@IdStudent", student.IdStudent);
            command.Parameters.AddWithValue("@Jmeno", student.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", student.Prijmeni);
            command.Parameters.AddWithValue("@DatumRegistrace", student.DatumRegistrace);
            command.Parameters.AddWithValue("@PosledniPrihlaseni", student.PosledniPrihlaseni == null ? DBNull.Value : 
                (object)student.PosledniPrihlaseni);
            command.Parameters.AddWithValue("@Login", student.Login);
            command.Parameters.AddWithValue("@Heslo", student.Heslo);
            command.Parameters.AddWithValue("@TypStudia_IdTypStudia", student.IdTypStudia);
        }
                
        private static Collection<Student> Read(SqlDataReader reader, bool complete)
        {
            Collection<Student> students = new Collection<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                int i = -1;
                student.IdStudent = reader.GetInt32(++i);
                student.Jmeno = reader.GetString(++i);
                student.Prijmeni = reader.GetString(++i);
                student.DatumRegistrace = DateTime.Parse(reader.GetString(++i));
                if (!reader.IsDBNull(++i))
                {
                    student.PosledniPrihlaseni = DateTime.Parse(reader.GetString(i));
                }

                student.Login = reader.GetString(++i);
                student.Heslo = reader.GetString(++i);
                student.IdTypStudia = reader.GetInt32(++i);
                student.TypStudia = TypStudiaTable.SelectOne(student.IdTypStudia);

                students.Add(student);
            }
            
            return students;
        }   
    }
}