namespace PasquettaPlanner.Models
{
    public class ElementoSpesa
    {
        public string Nome { get; set; } = string.Empty;          // Es: "Costine di maiale"
        public decimal Prezzo { get; set; }        // Es: 25.50 (usiamo decimal per i soldi!)
        public string Categoria { get; set; } = "Generico"; // Es: Carne, Alcol, Carbonella
        public string AcquistatoDa { get; set; } = string.Empty;  // Il nome dell'amico che ha anticipato i soldi
        public double Quantita { get; set; }       // Es: 2.5 (kg) o 10 (pezzi)
        public bool IsPerVegetariani { get; set; } // Per filtrare chi deve pagare cosa
    }
}