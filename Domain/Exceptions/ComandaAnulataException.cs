using System;

namespace Domain.Exceptions
{
    public class ComandaAnulataException : Exception
    {
        public ComandaAnulataException()
        {
        }

        public ComandaAnulataException(string comandaId) 
            : base($"Comanda cu ID-ul {comandaId} a fost anulata.")
        {
        }

        public ComandaAnulataException(string comandaId, Exception innerException) 
            : base($"Comanda cu ID-ul {comandaId} a fost anulata.", innerException)
        {
        }
    }
}