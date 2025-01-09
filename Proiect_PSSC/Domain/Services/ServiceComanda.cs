using Proiect_PSSC.Domain.Entities;
using Proiect_PSSC.Domain.Interfaces;

namespace Proiect_PSSC.Domain.Services;

public class ServiceComanda
{
    private readonly IProdusRepository _produsRepository;

    public ServiceComanda(IProdusRepository produsRepository)
    {
        _produsRepository = produsRepository;
    }

    public async Task<bool> ValideazaDateComanda(List<Guid> produseIds)
    {
        foreach (var produsId in produseIds)
        {
            var produs = await _produsRepository.GetByIdAsync(produsId);
            if (produs == null)
            {
                return false;
            }
        }
        return true;
    }

    public async Task<bool> VerificaStoc(List<Produs> produse)
    {
        foreach (var produs in produse)
        {
            var produsDb = await _produsRepository.GetByIdAsync(produs.Id);
            if (produsDb == null || produsDb.Cantitate < produs.Cantitate)
            {
                return false;
            }
        }
        return true;
    }

    public void CalculeazaPretTotal(Comanda comanda)
    {
        comanda.CalculeazaPretTotal();
    }

    public async Task<Comanda> ProceseazaComanda(Comanda comanda)
    {
        if (!await ValideazaDateComanda(comanda.Produse.Select(p => p.Id).ToList()))
        {
            comanda.AnuleazaComanda("Produs inexistent.");
            return comanda;
        }

        if (!await VerificaStoc(comanda.Produse))
        {
            comanda.AnuleazaComanda("Stoc insuficient.");
            return comanda;
        }

        CalculeazaPretTotal(comanda);
        comanda.AcceptaComanda();
        return comanda;
    }
}