namespace Proiect_PSSC.Domain.Entities;

public class Produs
{
    public Guid Id { get; private set; }
    public string Denumire { get; private set; }
    public decimal Pret { get; private set; }
    public int Cantitate { get; set; }

    public Produs(Guid id, string denumire, decimal pret, int cantitate)
    {
        Id = id;
        Denumire = denumire;
        Pret = pret;
        Cantitate = cantitate;
    }
}