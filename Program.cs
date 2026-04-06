using PasquettaPlanner.Models;
using PasquettaPlanner.Services;
using PasquettaPlanner.Data;

var gestore = new GestoreLista();
var calcolatore = new CalcolatoreSpese();
var partecipanti = new List<Partecipante>();
var ganttService = new VisualizzatoreGantt();

string pathPiano = "piano_lavoro.txt";

// 1. Assicurati che il file esista
SalvaSuFile.CreaFileEsempioSeManca(pathPiano);

// 2. Ora caricalo in sicurezza
var pianoLavoro = SalvaSuFile.ImportaPiano(pathPiano);

if (pianoLavoro.Count == 0) 
{
    Console.WriteLine("⚠️ Nessun piano trovato. Caricamento dati di default...");
    // ... aggiungi dati di default o chiedi all'utente ...
    pianoLavoro = new List<AttivitaGantt>
    {
        new() { Nome = "Spesa Carne", Inizio = new DateTime(2026, 4, 10), DurataGiorni = 1 },
        new() { Nome = "Marinate", Inizio = new DateTime(2026, 4, 12), DurataGiorni = 1 },
        new() { Nome = "Grigliata", Inizio = new DateTime(2026, 4, 13), DurataGiorni = 1 }
    };
}

Console.WriteLine("🍖 BENVENUTO NEL PIANIFICATORE PASQUETTA 🍷");
Console.Write("Scegli tra le seguenti opzioni");

bool continua = true;
while (continua)
{
    Console.Write("\n 1. Inserisci partecipanti \n 2. Aggiungi Spesa \n 3. Vedi Quote \n 4. Salva su file txt \n 5. Visualizzatore Gantt \n 6. Esci dal programma \n");
    var scelta = Console.ReadLine();
    if (scelta == "1"){
        // Setup rapido partecipanti
        Console.WriteLine("Inserisci i nomi dei partecipanti divisi da virgola:");
        var nomi = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();
        foreach (var n in nomi) partecipanti.Add(new Partecipante { Nome = n.Trim() });        
    }

    if (scelta == "2")
    {
        Console.Write("Cosa hai comprato? "); string cosa = Console.ReadLine()!;
        Console.Write("Prezzo? "); decimal prezzo = decimal.Parse(Console.ReadLine()!);
        Console.Write("Chi ha pagato? "); string chi = Console.ReadLine()!;

        gestore.AggiungiVoce(cosa, prezzo, "Varie", chi);
        
        // Aggiorna quanto ha anticipato la persona
        var p = partecipanti.FirstOrDefault(x => x.Nome.Equals(chi, StringComparison.OrdinalIgnoreCase));
        p?.SpesaAnticipata += prezzo; //if (p != null) p.SpesaAnticipata += prezzo;
    }
    
    else if (scelta == "3")
    {
        calcolatore.CalcolaQuote(partecipanti, gestore.OttieniTotale());
    }
    
    else if (scelta == "4")
    {
        SalvaSuFile.Esporta($"Totale Pasquetta: {gestore.OttieniTotale():C}");
    }
    
    else if (scelta == "5")
    {
        ganttService.Disegna(pianoLavoro);
    }

    else //esci dal programma
    {
        continua = false;
    }
}
