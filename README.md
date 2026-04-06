# 🍖 PasquettaPlanner 🍷

Un'applicazione console intuitiva scritta in **C# (.NET)** per organizzare la grigliata perfetta senza impazzire con i conti.

## 🚀 Funzionalità
- **Gestione Partecipanti**: Registra chi partecipa e le relative allergie.
- **Lista della Spesa**: Aggiungi prodotti, prezzi e assegna chi ha anticipato i soldi.
- **Calcolatore Quote**: Divisione automatica delle spese con resoconto "chi deve dare quanto a chi".
- **Export Dati**: Salvataggio automatico del riepilogo su file locale.

## 📂 Struttura del Progetto
Il progetto segue una struttura modulare per una facile manutenzione:

```text
📦 PasquettaPlanner
 ┣ 📂 Models        # Classi Partecipante e ElementoSpesa
 ┣ 📂 Services      # Logica di business (Calcoli e Gestione Liste)
 ┣ 📂 Data          # Gestione persistenza (Salvataggio su file)
 ┗ 📜 Program.cs    # Interfaccia utente e ciclo principale
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
## 📝 Utilizzo

   1. All'avvio, inserisci i nomi dei partecipanti separati da una virgola.
   2. Usa il menu numerico per aggiungere le spese (es. "Costine", "25.50", "Marco").
   3. Seleziona Vedi Quote per vedere istantaneamente il bilancio di ogni amico.
   4. Esci per generare il file di riepilogo lista_pasquetta.txt.

## ✍️ Note di Sviluppo
Sviluppato con ❤️ per la sopravvivenza dei grigliatori della domenica.
