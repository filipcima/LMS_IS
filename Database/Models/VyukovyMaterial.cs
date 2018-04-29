using System;

namespace LMSIS.Database.Models
{
    public class VyukovyMaterial
    {
        public int IdVyukovyMaterial { get; set; }
        public string Nazev { get; set; }
        public string Text { get; set; }
        public DateTime Vlozen { get; set; }
        public int IdVyucujici { get; set; }
        public Vyucujici Autor { get; set; }
        public int IdKurz { get; set; }
        public Kurz Kurz { get; set; }
    }
}