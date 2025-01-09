using pssc_project.Domain.Entities;

namespace pssc_project.Domain.Interfaces
{
    public interface IFacturareService
    {
        bool FacturareComanda(List<Produs> produse);
    }
}

