namespace Domain.Events
{
    public class FacturareAnulata
    {
        public Guid FacturaId { get; }
        public string MotivAnulare { get; }

        public FacturareAnulata(Guid facturaId, string motivAnulare)
        {
            FacturaId = facturaId;
            MotivAnulare = motivAnulare;
        }
    }
}