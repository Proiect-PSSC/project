using System;
using System.Collections.Generic;

namespace Domain.Models;

public class CerereTransport
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ComandaId { get; set; }
    public Comanda Comanda { get; set; }
    public string Status { get; set; } = "Initiata"; 
    public DateTime DataInregistrare { get; set; } = DateTime.Now;
    public DateTime? DataExpediere { get; set; }
    public DateTime? DataLivrare { get; set; }
    public string DetaliiLivrare { get; set; }

    public CerereTransport() { }

    public CerereTransport(Comanda comanda, string detaliiLivrare)
    {
        ComandaId = comanda.Id;
        Comanda = comanda;
        DetaliiLivrare = detaliiLivrare;
    }
}