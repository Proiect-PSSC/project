namespace Proiect_PSSC.Domain.Entities;

public class Comanda
{
    public Guid Id { get; private set; }
    public List<Produs> Produse { get; private set; }
    public decimal PretTotal { get; private set; }
    public string Status { get; private set; }

    public Comanda(List<Produs> produse)
    {
        Id = Guid.NewGuid();
        Produse = produse;
        PretTotal = 0;
        Status = "In Asteptare";
    }

    public void AcceptaComanda()
    {
        Status = "Acceptata";
    }

    public void AnuleazaComanda(string motiv)
    {
        Status = $"Anulata: {motiv}";
    }

    public void CalculeazaPretTotal()
    {
        PretTotal = Produse.Sum(p => p.Pret * p.Cantitate);
    }
}