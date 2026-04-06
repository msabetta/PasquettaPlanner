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


bool continua = true;

while (continua)
{
    MostraMenu();
    var scelta = Console.ReadLine();

    switch (scelta)
    {
        case "1":
            InserisciPartecipanti(partecipanti);
            break;

        case "2":
            AggiungiSpesa(partecipanti, gestore);
            break;

        case "3":
            calcolatore.CalcolaQuote(partecipanti, gestore.OttieniTotale());
            break;

        case "4":

            List<string> strings = new List<string>();
            if (partecipanti.Count == 0)
                strings.Add("Non sono presenti partecipanti. Non può essere valutato l'estratto conto");
            else
            {
                decimal totaleGenerale =  gestore.OttieniTotale();
                decimal quotaATesta = totaleGenerale / partecipanti.Count;
                strings.Add($"--- ESTRATTO CONTO ---");
                strings.Add($"Totale Spesa: {totaleGenerale:C}");
                strings.Add($"Quota individuale: {quotaATesta:C}");

                foreach (var p in partecipanti)
                {
                    decimal bilancio = p.SpesaAnticipata - quotaATesta;
                    string stato = bilancio >= 0 ? "Deve ricevere" : "Deve dare";
                    strings.Add($"{p.Nome}: {stato} {Math.Abs(bilancio):C} (Anticipati: {p.SpesaAnticipata:C})");
                }

                strings.Add("Elenco degli elementi di spesa: ");
                strings.Add("Nome  Prezzo  Categoria  AcquistatoDa  PerVegetariani");
                foreach(var g in gestore.Spese)                
                    strings.Add($"{g.Nome}  {g.Prezzo}  {g.Categoria}  {g.AcquistatoDa}  {g.IsPerVegetariani}");
            }

            SalvaSuFile.Esporta_Righe(strings);
            break;

        case "5":
            ganttService.Disegna(pianoLavoro);
            break;

        case "6":
            continua = false;
            break;

        default:
            ScriviErrore("Scelta non valida!");
            break;
    }

    Pausa();
}



void MostraMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("🍖 BENVENUTO NEL PIANIFICATORE PASQUETTA 🍷\n");
    Console.ResetColor();

    Console.WriteLine("1. Inserisci partecipanti");
    Console.WriteLine("2. Aggiungi Spesa");
    Console.WriteLine("3. Vedi Quote");
    Console.WriteLine("4. Salva su file di testo");
    Console.WriteLine("5. Visualizzatore Gantt");
    Console.WriteLine("6. Esci");

    Console.Write("\nScelta: ");
}

void InserisciPartecipanti(List<Partecipante> partecipanti)
{
    Console.WriteLine("Inserisci i nomi separati da virgola:");
    var nomi = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

    foreach (var n in nomi)
    {
        var nome = n.Trim();
        if (!string.IsNullOrEmpty(nome))
        {
            partecipanti.Add(new Partecipante { Nome = nome });
            Console.WriteLine($"Aggiunto: {nome}");
        }
    }
}


void AggiungiSpesa(List<Partecipante> partecipanti, GestoreLista gestore)
{
    Console.Write("Cosa hai comprato? ");
    string cosa = Console.ReadLine()!;

    decimal prezzo;
    while (true)
    {
        Console.Write("Prezzo: ");
        if (decimal.TryParse(Console.ReadLine(), out prezzo))
            break;

        ScriviErrore("Inserisci un numero valido!");
    }

    Console.Write("Chi ha pagato? ");
    string chi = Console.ReadLine()!;

    var p = partecipanti.FirstOrDefault(x =>
        x.Nome.Equals(chi, StringComparison.OrdinalIgnoreCase));

    if (p == null)
    {
        ScriviErrore("Partecipante non trovato!");
        return;
    }

    gestore.AggiungiVoce(cosa, prezzo, "Varie", chi);
    p.SpesaAnticipata += prezzo;

    ScriviSuccesso("Spesa aggiunta!");
}

void ScriviErrore(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(msg);
    Console.ResetColor();
}

void ScriviSuccesso(string msg)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(msg);
    Console.ResetColor();
}

void Pausa()
{
    Console.WriteLine("\nPremi Invio per continuare...");
    Console.ReadLine();
}