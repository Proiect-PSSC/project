using Domain.Infrastructure.Database;
using Domain.Models;
using Domain.Operations;

namespace Domain.Workflows;

public class WorkflowCerereTransport
{
    private readonly TransportOperation _transportOperation;

    public WorkflowCerereTransport(TransportOperation transportOperation)
    {
        _transportOperation = transportOperation;
    }

    public void ProceseazaTransport(AppDBContext dbContext, Comanda comanda, string detaliiLivrare, CerereTransport cerereTransport)
    {
        try
        {
            if (comanda.Status != "Acceptata")
                throw new InvalidOperationException("Transportul poate fi inițiat doar pentru comenzi acceptate.");

            _transportOperation.InitiereLivrare(dbContext,comanda,detaliiLivrare);
            _transportOperation.ExpediereComanda(cerereTransport);
            _transportOperation.NotificareClient(cerereTransport);

            Console.WriteLine("Transport realizat cu succes!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Eroare la procesarea transportului: {e.Message}");
        }
    }
}