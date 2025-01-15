using Domain.Infrastructure.Database;

using Domain.Models;
using Domain.Operations;
using Domain.Events;

namespace Domain.Workflows
{
    public class WorkflowFacturare
    {
        private readonly FacturaOperation _facturaService;
        private readonly IEventPublisher _eventPublisher;
        public WorkflowFacturare(FacturaOperation facturaService, IEventPublisher eventPublisher)
        {
            _facturaService = facturaService;
            _eventPublisher = eventPublisher;
        }

        public void ProceseazaFacturare(AppDBContext dbContext, Comanda comanda)
        {
            Factura factura = null;
            
            try
            {
                factura = _facturaService.GenereazaFactura(comanda);
                _facturaService.TrimiteFactura(factura);
                _facturaService.ArhiveazaFactura(dbContext,factura);
                
                // Publică evenimentul de succes
                _eventPublisher.Publish(new FacturareRealizataCuSucces(factura.Id, factura.DataFacturarii));
                
                Console.WriteLine("Facturare realizata cu succes!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Eroare la facturare: {e.Message}");
                
                // Publică evenimentul de anulare
                _eventPublisher.Publish(new FacturareAnulata(factura.Id, e.Message));
            }
        }
    }
}
