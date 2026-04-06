# 🍖 PasquettaPlanner 🍷

Un'applicazione console intuitiva scritta in **C# (.NET)** per organizzare la grigliata perfetta, gestire le spese tra amici e monitorare i tempi di preparazione senza impazzire con i conti.

## 🚀 Funzionalità
- **Gestione Partecipanti**: Registra nomi e allergie.
- **Calcolatore Spese**: Algoritmo per il bilancio dei debiti/crediti (chi deve dare quanto a chi).
- **Timeline Gantt**: Visualizzazione grafica in console dei preparativi con distinzione per mesi e giorni.
- **Importazione Dati**: Caricamento automatico del piano di lavoro da file esterno.
- **Esportazione Dati**: Salvataggio del riepilogo finale su file `.txt`.

## 📂 Struttura del Progetto
Il progetto segue una struttura modulare per una facile manutenzione:

```text
📦 PasquettaPlanner
 ┣ 📂 Models        # Strutture dati: Partecipante, ElementoSpesa, AttivitaGantt
 ┣ 📂 Services      # Logica: CalcolatoreSpese, GestoreLista, VisualizzatoreGantt
 ┣ 📂 Data          # Persistenza: Import/Export su file (SalvaSuFile)
 ┣ 📜 Program.cs    # Interfaccia utente (Menu e Input)
 ┗ 📜 piano_lavoro.txt # File di input per la timeline
```

## 🛠️ Requisiti

* .NET 6.0 SDK o superiore.
* Un editor di codice (Visual Studio, VS Code o JetBrains Rider).

## 📋 Prerequisiti di Installazione

Per compilare ed eseguire **PasquettaPlanner**, assicurati di avere installato i seguenti strumenti:

### 1. .NET SDK (Fondamentale)
L'applicazione richiede l'ambiente di runtime e compilazione .NET.
*   **Versione consigliata:** .NET 6.0, 7.0 o 8.0 (LTS).
*   **Download:** [Scarica .NET SDK](https://microsoft.com)
*   **Verifica:** Apri il terminale e digita `dotnet --version`.

### 2. IDE / Editor di Testo (Opzionale per sviluppo)
Per modificare il codice, ti consigliamo uno dei seguenti:
*   **Visual Studio 2022:** (Consigliato per Windows) Installa il carico di lavoro ".NET Desktop Development".
*   **VS Code:** Installa l'estensione "C# Dev Kit".
*   **JetBrains Rider:** Ottima alternativa cross-platform.

### 3. Git (Per versionamento)
Se desideri clonare il repository o gestire le modifiche:
[Scarica Git](https://git-scm.com)

## 💻 Come Iniziare

   1. Clona il progetto o copia i file nella tua cartella locale.ù
   ```
   git clone https://github.com/msabetta/PasquettaPlanner
   ```
   2. Ripristina le dipendenze:
   ```
   dotnet restore
   ```
   3. Avvia l'applicazione:
   ```
   dotnet run
   ```
   4. Segui le istruzioni a video per inserire i partecipanti e le spese.

## 📝 Utilizzo

   1. All'avvio, inserisci i nomi dei partecipanti separati da una virgola.
   2. Usa il menu numerico per aggiungere le spese (es. "Costine", "25.50", "Marco").
   3. Seleziona Vedi Quote per vedere istantaneamente il bilancio di ogni amico.
   4. Generare il file di riepilogo lista_pasquetta.txt.

## 📅 Visualizzazione Timeline (Gantt)
L'app genera automaticamente un diagramma temporale leggendo il file piano_lavoro.txt. La visualizzazione include l'intestazione dei mesi (stampati una sola volta) e i blocchi grafici per le attività.
Esempio di output in Console:


                     | MAR          APR
Attività             | 30 31 01 02 03 04 
---------------------------------------
Spesa Carne          | ███
Marinate             |       ███
Grigliata            |          ██████

## 🛠️ Configurazione File Input (piano_lavoro.txt)
Il file deve trovarsi nella cartella principale del progetto con il seguente formato (Nome|Data|Durata):

Spesa Carne|2026-04-10|1
Marinate|2026-04-12|1
Grigliata|2026-04-13|1

## ✍️ Note di Sviluppo
- Sviluppato con ❤️ per la sopravvivenza dei grigliatori della domenica
- Applicativo interattivo sviluppato per organizzare la Pasquetta come un vero Project Manager