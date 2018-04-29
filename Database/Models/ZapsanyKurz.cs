using System;

namespace LMSIS.Database.Models
{
    public class ZapsanyKurz
    {
        public int IdRegistrace { get; set; }
        public DateTime DatumZapisu { get; set; }
        public DateTime? DatumUkonceni { get; set; }
        public bool? Splneno { get; set; }
        public int IdStudent { get; set; }
        public Student Student { get; set; }
        public int IdKurz { get; set; }
        public Kurz Kurz { get; set; }
    }
}