using System;

namespace LMSIS.Database.Models
{
    public class Kurz
    {
        public int IdKurz { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public int Kapacita { get; set; }
        public DateTime Vytvoren { get; set; }
        public DateTime? Ukoncen{ get; set; }
        public Vyucujici Vyucujici { get; set; }
        public Obor Obor { get; set; }
    }
}