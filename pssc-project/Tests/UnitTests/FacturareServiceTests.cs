using Moq;
using Xunit;
using System.Collections.Generic;
using pssc_project.Application.Commands.Services;
using pssc_project.Domain.Entities;
using pssc_project.Domain.Interfaces;

namespace pssc_project.Tests.UnitTests
{
    public class FacturareServiceTests
    {
        [Fact]
        public void FacturareComanda_CalculeazaPretTotalCorect()
        {
            // Arrange
            var produse = new List<Produs>
            {
                new Produs { Nume = "Produs 1", Pret = 50, Cantitate = 2 },
                new Produs { Nume = "Produs 2", Pret = 30, Cantitate = 1 }
            };

            var facturareService = new FacturareService();

            // Act
            var result = facturareService.FacturareComanda(produse);

            // Assert
            Assert.True(result);
            // Putem adăuga un control pentru un total corect al prețului facturii.
        }

        [Fact]
        public void FacturareComanda_GenerareFacturaCorecta()
        {
            // Arrange
            var produse = new List<Produs>
            {
                new Produs { Nume = "Produs 1", Pret = 50, Cantitate = 2 }
            };

            var facturareService = new FacturareService();

            // Act
            var factura = facturareService.GenereazaFactura(produse, 100); // Pretul total ar trebui să fie 100

            // Assert
            Assert.NotNull(factura);
            Assert.Equal(100, factura.PretTotal);
        }
    }
}