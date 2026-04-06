using PasquettaPlanner.Models;

namespace PasquettaPlanner.Services;

public class VisualizzatoreGantt
{
    public void Disegna(List<AttivitaGantt> attivita)
    {
        if (!attivita.Any()) return;

        var dataMin = attivita.Min(a => a.Inizio);
        var dataMax = attivita.Max(a => a.Inizio.AddDays(a.DurataGiorni));
        int totaleGiorni = (dataMax - dataMin).Days;

        Console.WriteLine("\n--- 📅 TIMELINE PASQUETTA ---");

        // 1. RIGA DEI MESI
        Console.Write("                     | ");
        string ultimoMese = "";

        for (int i = 0; i <= totaleGiorni; i++)
        {
            DateTime dataGiorno = dataMin.AddDays(i);
            string nomeMese = dataGiorno.ToString("MMM").ToUpper(); // Usa "MMM" per avere già 3 lettere (es. APR)

            if (nomeMese != ultimoMese)
            {
                // Stampa il mese (es. "APR") e un trattino per riempire lo spazio del primo giorno
                Console.Write($"{nomeMese} "); 
                ultimoMese = nomeMese;
            }
            else
            {
                // Stampa 3 spazi vuoti per ogni giorno successivo dello stesso mese
                // (2 cifre del giorno + 1 spazio di separazione = 3 caratteri)
                Console.Write("   "); 
            }
        }
        Console.Write("\n");

        // 2. RIGA DEI GIORNI (es. 30 31 01 02...)
        Console.Write("Attività             | ");
        for (int i = 0; i <= totaleGiorni; i++)
        {
            Console.Write($"{dataMin.AddDays(i).Day:D2} ");
        }
        Console.WriteLine("\n" + new string('-', 23 + (totaleGiorni * 3)));

        // 3. DISEGNO DELLE BARRE
        foreach (var task in attivita.OrderBy(t => t.Inizio))
        {
            Console.Write(task.Nome.PadRight(20) + " | ");
            int offset = (task.Inizio - dataMin).Days;
            
            Console.Write(new string(' ', offset * 3));
            
            // Colore: Rosso per la grigliata, Ciano per il resto
            Console.ForegroundColor = task.Nome.ToLower().Contains("grigliata") 
                ? ConsoleColor.Red 
                : ConsoleColor.Cyan;
                
            Console.Write(new string('█', task.DurataGiorni * 3 - 1));
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

