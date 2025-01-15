using Domain.Infrastructure.Database;

namespace Domain.Workflows;
using Domain.Models;
using Domain.Operations;

public class WorkflowFacturare
{
    private readonly FacturaOperation _facturaService;

    public WorkflowFacturare(FacturaOperation facturaService)
    {
        _facturaService = facturaService;
    }

    public void ProceseazaFacturare(AppDBContext dbContext, Comanda comanda)
    {
        try
        {
            var factura = _facturaService.GenereazaFactura(comanda);
            _facturaService.TrimiteFactura(factura);
            _facturaService.ArhiveazaFactura(dbContext,factura);
            Console.WriteLine("Facturare realizata cu succes!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Eroare la facturare: {e.Message}");
        }
    }
}