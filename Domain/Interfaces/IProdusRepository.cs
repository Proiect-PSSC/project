using Domain.Models;

namespace Domain.Interfaces;
public interface IProdusRepository
{
    Task<Produs> GetByIdAsync(Guid id);
    Task UpdateAsync(Produs produs);
}