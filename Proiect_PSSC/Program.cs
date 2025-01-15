using Domain.Workflows;
using Domain.Models;
using Domain.Interfaces;
using Domain.Operations;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Database;



namespace Proiect_PSSC;

class Program
{
    static async Task Main(string[] args)
    {
        var dbContext = new AppDBContext();
        var produsRepository = new ProdusRepository(dbContext);
        var comandaService = new ComandaOperation(produsRepository);
        var workflow = new WorkflowPlasareComanda(comandaService);
        
        var produse = new List<Produs>
        {
            dbContext.Produse[0],
            dbContext.Produse[1]
        };
        
        var comanda = await workflow.ProceseazaComanda(produse);
        
        Console.WriteLine($"Status comanda: {comanda.Status}\nProduse: {string.Join(", ", comanda.Produse.Select(p => $"{p.Cantitate}x {p.Denumire} (Pret: {p.Pret})"))}\nPret total: {comanda.PretTotal}\n");

        var facturaService = new FacturaOperation();
        var workflowFacturare = new WorkflowFacturare(facturaService);
        
        workflowFacturare.ProceseazaFacturare(dbContext, comanda);
    }
}