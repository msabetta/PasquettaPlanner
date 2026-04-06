using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasquettaPlanner.Models
{
    public class AttivitaGantt
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime Inizio { get; set; }
        public int DurataGiorni { get; set; }
    }
}