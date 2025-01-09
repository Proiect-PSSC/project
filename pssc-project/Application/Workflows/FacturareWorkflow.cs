using pssc_project.Application.Commands;
using pssc_project.Domain.Entities;
using pssc_project.Domain.Interfaces;
using pssc_project.Domain.Events;
using System;

namespace pssc_project.Application.Workflows
{
    public class FacturareWorkflow
    {
        private readonly IFacturareService _facturareService;

        public FacturareWorkflow(IFacturareService facturareService)
        {
            _facturareService = facturareService;
        }

        public void ExecutaFacturare(FacturareComandaCommand command)
        {
            try
            {
                bool succes = _facturareService.FacturareComanda(command.Produse);

                if (succes)
                {
                    // Emiterea evenimentului de succes
                    FacturareRealizataCuSucces?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    // Emiterea evenimentului de anulare
                    FacturareAnulata?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
                // Emiterea evenimentului de anulare în caz de eroare
                FacturareAnulata?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler FacturareRealizataCuSucces;
        public event EventHandler FacturareAnulata;
    }
}

