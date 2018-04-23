using System;

namespace LMSIS.Database.Models
{
    public class Vyucujici
    {
        public int IdVyucujici { get; set; }
        public string Titul { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string Login { get; set; }
        public string Heslo { get; set; }
        public DateTime DatumNarozeni { get; set; }
    }
}