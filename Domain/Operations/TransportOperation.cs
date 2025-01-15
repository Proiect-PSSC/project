using Domain.Infrastructure.Database;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Operations;

public class TransportOperation
{
   

    public async Task InitiereLivrare(AppDBContext dbContext, Comanda comanda, string detaliiLivrare)
    {
        var cerereTransport = new CerereTransport(comanda, detaliiLivrare);
        Console.WriteLine($"Livrarea pentru comanda {comanda.Id} a fost initiata.");
        comanda.Status = "In Livrare";
    }

    public void ExpediereComanda(CerereTransport cerereTransport)
    {
        cerereTransport.Status = "Expediata";
        cerereTransport.DataExpediere = DateTime.Now;
        Console.WriteLine($"Comanda {cerereTransport.ComandaId} a fost expediata.");
    }

    public void NotificareClient(CerereTransport cerereTransport)
    {
        cerereTransport.Status = "Livrata";
        cerereTransport.DataLivrare = DateTime.Now;
        Console.WriteLine($"Clientul a fost notificat pentru comanda {cerereTransport.ComandaId}.");
    }
}