using System;

namespace LMSIS.Database.Models
{
    public class Pisemka
    {
        public int IdPisemka { get; set; }
        public DateTime DatumPisemky { get; set; }
        public int? Znamka { get; set; }
        public int IdZapsanyKurz { get; set; }
        public ZapsanyKurz ZapsanyKurz { get; set; }
    }
}