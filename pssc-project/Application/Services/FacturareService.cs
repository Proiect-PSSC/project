using pssc_project.Domain.Entities;
using pssc_project.Domain.Interfaces;
using pssc_project.Domain.Events;
using System;
using System.Collections.Generic;

namespace pssc_project.Application.Commands.Services
{
    public class FacturareService : IFacturareService
    {
        public bool FacturareComanda(List<Produs> produse)
        {
            try
            {
                // Calcularea prețului total
                decimal pretTotal = CalculeazaPretTotal(produse);

                // Generarea facturii
                var factura = GenereazaFactura(produse, pretTotal);

                // Trimiterea facturii
                TrimiteFactura(factura);

                return true;
            }
            catch (Exception ex)
            {
                // Logica de tratare a erorilor
                Console.WriteLine($"Eroare la facturare: {ex.Message}");
                return false;
            }
        }

        private decimal CalculeazaPretTotal(List<Produs> produse)
        {
            decimal total = 0;
            foreach (var produs in produse)
            {
                total += produs.Pret * produs.Cantitate;
            }
            return total;
        }

        public Factura GenereazaFactura(List<Produs> produse, decimal pretTotal)
        {
            return new Factura
            {
                Produse = produse,
                PretTotal = pretTotal,
                DataEmiterii = DateTime.Now
            };
        }

        private void TrimiteFactura(Factura factura)
        {
            // Logica de trimitere a facturii (ex. prin email, API etc.)
            Console.WriteLine("Factura trimisă către client.");
        }
    }

    public class Factura
    {
        public List<Produs> Produse { get; set; }
        public decimal PretTotal { get; set; }
        public DateTime DataEmiterii { get; set; }
    }
}
