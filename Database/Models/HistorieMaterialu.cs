using System;

namespace LMSIS.Database.Models
{
    public class HistorieMaterialu
    {
        public int IdHistorie { get; set; }
        public DateTime DatumZmeny { get; set; }
        public string Nazev { get; set; }
        public string Text { get; set; }
        public DateTime Vlozen { get; set; }
        public int IdVyukovyMaterial { get; set; }
        public VyukovyMaterial Material { get; set; }
        public string TypZmeny { get; set; }
    }
}