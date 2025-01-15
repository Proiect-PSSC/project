using Domain.Events;
using Domain.Infrastructure.Database;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Domain.Interfaces;
namespace Domain.EventHandlers
{
    public class FacturareRealizataCuSuccesHandler : IEventHandler<FacturareRealizataCuSucces>
    {
        private readonly AppDBContext _dbContext;
        private readonly ILogger<FacturareRealizataCuSuccesHandler> _logger;

        public FacturareRealizataCuSuccesHandler(AppDBContext dbContext, ILogger<FacturareRealizataCuSuccesHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task Handle(FacturareRealizataCuSucces eventData)
        {
            var factura = await _dbContext.Facturi.FindAsync(eventData.FacturaId);
            if (factura != null)
            {
                // Actualizează statusul facturii
                factura.Status = "Realizata";
                _dbContext.Facturi.Update(factura);
                await _dbContext.SaveChangesAsync();

                // Logare pentru debugging
                _logger.LogInformation($"Facturarea pentru factura {eventData.FacturaId} a fost realizată cu succes.");
            }
            else
            {
                _logger.LogWarning($"Factura cu ID-ul {eventData.FacturaId} nu a fost găsită.");
            }
        }
    }
}