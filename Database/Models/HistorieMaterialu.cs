using System;

namespace LMSIS.Database.Models
{
    public class HistorieMaterialu
    {
        public int IdHistorie { get; set; }
        public string Nazev { get; set; }
        public string Text { get; set; }
        public DateTime Vlozen { get; set; }
        public Vyucujici Autor { get; set; }
        public Kurz Kurz { get; set; }
        public string TypZmeny { get; set; }
    }
}