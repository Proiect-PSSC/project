using Domain.Models;

namespace Domain.Infrastructure.Database;

public class AppDBContext
{
    public List<Produs> Produse { get; set; }
    public List<Factura> Facturi { get; set; }

    public AppDBContext()
    {
        Produse = new List<Produs>
        {
            new Produs(Guid.NewGuid(), "Produs1", 100m, 10),
            new Produs(Guid.NewGuid(), "Produs2", 50m, 20),
            new Produs(Guid.NewGuid(), "Produs3", 99m, 5),
        };
        Facturi = new List<Factura>();
    }
}