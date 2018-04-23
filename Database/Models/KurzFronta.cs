using System;

namespace LMSIS.Database.Models
{
    public class KurzFronta
    {
        public int IdKurzFronta { get; set; }
        public Student Student { get; set; }
        public Kurz Kurz { get; set; }
        public DateTime Stamp { get; set; }
    }
}