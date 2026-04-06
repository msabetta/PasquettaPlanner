using PasquettaPlanner.Models; 
using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq; // Necessario per usare .Count()

namespace PasquettaPlanner.Data;

public static class SalvaSuFile
{
    private const string Path = "lista_pasquetta.txt";

    public static void Esporta(string contenuto)
    {
        File.WriteAllText(Path, contenuto);
        Console.WriteLine($"\n💾 Lista salvata in: {Path}");
    }

    public static void Esporta_Righe(List<string> righe)
    {
        try 
        {
            // Scrive tutte le righe. Se il file esiste, lo sovrascrive.
            // Se non esiste, lo crea automaticamente.
            File.WriteAllLines(Path, righe);

            Console.WriteLine($"\n✅ Salvataggio completato!");
            Console.WriteLine($"💾 File: {Path}");
            Console.WriteLine($"📝 Righe scritte: {righe.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n❌ Errore durante il salvataggio: {ex.Message}");
        }
    }

    public static List<AttivitaGantt> ImportaPiano(string percorso)
    {
        var lista = new List<AttivitaGantt>();
        
        if (!File.Exists(percorso)) return lista;

        foreach (var riga in File.ReadAllLines(percorso))
        {
            var parti = riga.Split('|');
            if (parti.Length == 3)
            {
                lista.Add(new AttivitaGantt {
                    Nome = parti[0],
                    Inizio = DateTime.ParseExact(parti[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    DurataGiorni = int.Parse(parti[2])
                });
            }
        }
        return lista;
    }

    public static void CreaFileEsempioSeManca(string percorso)
    {
        if (!File.Exists(percorso))
        {
            // Contenuto di default: Nome|Data|Durata
            string[] contenuto = {
                "Lista Invitati|2026-04-01|1",
                "Spesa Bevande|2026-04-10|1",
                "Marinate Carne|2026-04-12|1",
                "GRIGLIATA|2026-04-13|1"
            };

            File.WriteAllLines(percorso, contenuto);
            Console.WriteLine($"ℹ️ File '{percorso}' non trovato. Creato un piano di esempio.");
        }
    }

}
