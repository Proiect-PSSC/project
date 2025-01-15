using Domain.Infrastructure.Database;

namespace Domain.Operations;
using Domain.Models;

public class FacturaOperation
{
    public Factura GenereazaFactura(Comanda comanda)
    {
        if (comanda.Status != "Acceptata")
            throw new InvalidOperationException("Factura poate fi generata doar pentru comenzi acceptate.");

        return new Factura(comanda.Produse, comanda.PretTotal);
    }

    public void TrimiteFactura(Factura factura)
    {
        //  simulare trimitere
        Console.WriteLine("Factura a fost trimisa catre client.");
    }

    public async Task ArhiveazaFactura(AppDBContext dbContext, Factura factura)
    {
        dbContext.Facturi.Add(factura);
        await dbContext.SaveChangesAsync();  // Salvează modificările în baza de date
        Console.WriteLine("Factura a fost arhivata.");
    }
}