using Domain.Models;
using Domain.Interfaces;
using Domain.Infrastructure.Database;

namespace Domain.Infrastructure.Repositories;

public class ProdusRepository : IProdusRepository
{
    private readonly AppDBContext _context;

    public ProdusRepository(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Produs> GetByIdAsync(Guid id)
    {
        // va fi inlocuit cu baza de date
        return _context.Produse.FirstOrDefault(p => p.Id == id);
    }

    public async Task UpdateAsync(Produs produs)
    {
        var existingProdus = _context.Produse.FirstOrDefault(p => p.Id == produs.Id);
        if (existingProdus != null)
        {
            //si aici
            existingProdus.Cantitate = produs.Cantitate;
        }
    }
}