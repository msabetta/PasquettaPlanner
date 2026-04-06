using PasquettaPlanner.Models;
using PasquettaPlanner.Services;
using PasquettaPlanner.Data;

var gestore = new GestoreLista();
var calcolatore = new CalcolatoreSpese();
var partecipanti = new List<Partecipante>();

Console.WriteLine("🍖 BENVENUTO NEL PIANIFICATORE PASQUETTA 🍷");

// Setup rapido partecipanti
Console.WriteLine("Inserisci i nomi dei partecipanti divisi da virgola:");
var nomi = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();
foreach (var n in nomi) partecipanti.Add(new Partecipante { Nome = n.Trim() });

bool continua = true;
while (continua)
{
    Console.WriteLine("\n1. Aggiungi Spesa | 2. Vedi Quote | 3. Salva ed Esci");
    var scelta = Console.ReadLine();

    if (scelta == "1")
    {
        Console.Write("Cosa hai comprato? "); string cosa = Console.ReadLine()!;
        Console.Write("Prezzo? "); decimal prezzo = decimal.Parse(Console.ReadLine()!);
        Console.Write("Chi ha pagato? "); string chi = Console.ReadLine()!;

        gestore.AggiungiVoce(cosa, prezzo, "Varie", chi);
        
        // Aggiorna quanto ha anticipato la persona
        var p = partecipanti.FirstOrDefault(x => x.Nome.Equals(chi, StringComparison.OrdinalIgnoreCase));
        if (p != null) p.SpesaAnticipata += prezzo;
    }
    else if (scelta == "2")
    {
        calcolatore.CalcolaQuote(partecipanti, gestore.OttieniTotale());
    }
    else
    {
        SalvaSuFile.Esporta($"Totale Pasquetta: {gestore.OttieniTotale():C}");
        continua = false;
    }
}
