namespace PasquettaPlanner.Models
{
    public class Partecipante
    {
        public string Nome { get; set; } = string.Empty;
        public double BudgetVersato { get; set; }
        public bool IsVegetariano { get; set; }

        public string Allergie { get; set; } = "Nessuna";
        public decimal SpesaAnticipata { get; set; } // Quanto ha già pagato al supermercato
    }
}
