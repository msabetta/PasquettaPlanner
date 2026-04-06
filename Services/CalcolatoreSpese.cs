using PasquettaPlanner.Models;

namespace PasquettaPlanner.Services;

public class CalcolatoreSpese
{
    public void CalcolaQuote(List<Partecipante> partecipanti, decimal totaleGenerale)
    {
        if (partecipanti.Count == 0) return;

        decimal quotaATesta = totaleGenerale / partecipanti.Count;
        Console.WriteLine($"\n--- 📊 ESTRATTO CONTO ---");
        Console.WriteLine($"Totale Spesa: {totaleGenerale:C}");
        Console.WriteLine($"Quota individuale: {quotaATesta:C}\n");

        foreach (var p in partecipanti)
        {
            decimal bilancio = p.SpesaAnticipata - quotaATesta;
            string stato = bilancio >= 0 ? "Deve ricevere" : "Deve dare";
            Console.WriteLine($"{p.Nome}: {stato} {Math.Abs(bilancio):C} (Anticipati: {p.SpesaAnticipata:C})");
        }
    }
}
