using System;

namespace LMSIS.Database.Models
{
    public class ZapsanyKurz
    {
        public int IdRegistrace { get; set; }
        public DateTime DatumZapisu { get; set; }
        public DateTime? DatumUkonceni { get; set; }
        public bool? Splneno { get; set; }
        public Student Student_IdStudent { get; set; }
        public Kurz Kurz_IdKurz { get; set; }
    }
}