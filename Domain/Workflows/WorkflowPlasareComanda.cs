using Domain.Models;
using Domain.Operations;
using Domain.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Workflows
{
    public class WorkflowPlasareComanda
    {
        private readonly ComandaOperation _service;

        public WorkflowPlasareComanda(ComandaOperation service)
        {
            _service = service;
        }

        public async Task<Comanda> ProceseazaComanda(List<Produs> produse)
        {
            var comanda = new Comanda(produse);
            
            comanda = await _service.ProceseazaComanda(comanda);
            
            if (comanda.Status == "Acceptata")
            {
                throw new ComandaAcceptataException(comanda.Id.ToString());
            }
            else if (comanda.Status == "Anulata")
            {
                throw new ComandaAnulataException(comanda.Id.ToString());
            }

            return comanda;
        }
    }
}