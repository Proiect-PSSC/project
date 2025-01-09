using Proiect_PSSC.Domain.Entities;

namespace Proiect_PSSC.Domain.Interfaces;

public interface IProdusRepository
{
    Task<Produs> GetByIdAsync(Guid id);
    Task UpdateAsync(Produs produs);
}