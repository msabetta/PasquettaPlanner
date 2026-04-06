namespace PasquettaPlanner.Data;

public static class SalvaSuFile
{
    private const string Path = "lista_pasquetta.txt";

    public static void Esporta(string contenuto)
    {
        File.WriteAllText(Path, contenuto);
        Console.WriteLine($"\n💾 Lista salvata in: {Path}");
    }
}
