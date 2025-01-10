using Domain.Models;
using Domain.Operations;

namespace Domain.Workflows;

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
        return await _service.ProceseazaComanda(comanda);
    }
}