using System;

namespace LMSIS.Database.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public DateTime DatumRegistrace { get; set; }
        public DateTime? PosledniPrihlaseni { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Login { get; set; }
        public string Heslo { get; set; }
        public TypStudia TypStudia { get; set; }
    }
}