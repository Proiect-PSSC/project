using System;

namespace Domain.Exceptions
{
    public class ComandaAcceptataException : Exception
    {
        public ComandaAcceptataException()
        {
        }

        public ComandaAcceptataException(string comandaId) 
            : base($"Comanda cu ID-ul {comandaId} a fost acceptata.")
        {
        }

        public ComandaAcceptataException(string comandaId, Exception innerException) 
            : base($"Comanda cu ID-ul {comandaId} a fost acceptata.", innerException)
        {
        }
    }
}