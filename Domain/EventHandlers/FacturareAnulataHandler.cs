using Domain.Events;
using Domain.Models;
using System;

namespace Domain.EventHandlers
{
    public class FacturareAnulataHandler : IEventHandler<FacturareAnulata>
    {
        public void Handle(FacturareAnulata eventMessage)
        {
            // Logăm că facturarea a fost anulată
            Console.WriteLine($"Facturarea a fost anulată pentru factura ID: {eventMessage.Factura.Id}");

            // Aici poți adăuga logică suplimentară de gestionare a anulării
            // de exemplu, trimiterea unui email sau un rollback al unor procese.
            // De exemplu:
            // - Revocarea unui proces
            // - Trimiterea unui mesaj de eroare
            // - Reinițializarea unor date

            // Exemplu simplu de acțiune de rollback sau logare
            Console.WriteLine($"Se efectuează rollback pentru factura ID: {eventMessage.Factura.Id}");
        }
    }
}