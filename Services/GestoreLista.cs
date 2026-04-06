using PasquettaPlanner.Models;

namespace PasquettaPlanner.Services;

public class GestoreLista
{
    public List<ElementoSpesa> Spese { get; } = new();

    public void AggiungiVoce(string nome, decimal prezzo, string categoria, string chiPaga)
    {
        Spese.Add(new ElementoSpesa { Nome = nome, Prezzo = prezzo, Categoria = categoria, AcquistatoDa = chiPaga });
    }

    public decimal OttieniTotale() => Spese.Sum(s => s.Prezzo);
}
