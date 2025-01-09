using Proiect_PSSC.Domain.Entities;
using Proiect_PSSC.Domain.Services;

namespace Proiect_PSSC.Application.Workflows;

public class WorkflowPlasareComanda
{
    private readonly ServiceComanda _comandaService;

    public WorkflowPlasareComanda(ServiceComanda comandaService)
    {
        _comandaService = comandaService;
    }

    public async Task<Comanda> ProceseazaComanda(List<Produs> produse)
    {
        var comanda = new Comanda(produse);
        return await _comandaService.ProceseazaComanda(comanda);
    }
}