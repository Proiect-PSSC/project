namespace Domain.Models;

public class Factura
{
    public Guid Id { get; private set; } //id unic
    public List<Produs> Produse { get; private set; }
    public decimal PretTotal { get; private set; }
    public DateTime DataFacturarii { get; private set; }
    public string Status { get; private set; }

    public Factura(List<Produs> produse, decimal pretTotal)
    {
        Id = Guid.NewGuid();
        Produse = produse;
        PretTotal = pretTotal;
        DataFacturarii = DateTime.Now;
        Status = "Generata";
    }

    public void MarcheazaAnulata(string motiv)
    {
        Status = $"Anulata: {motiv}";
    }

}