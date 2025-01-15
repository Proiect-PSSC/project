namespace Domain.Events
{
    public class FacturareRealizataCuSucces
    {
        public Guid FacturaId { get; }
        public DateTime DataFacturarii { get; }

        public FacturareRealizataCuSucces(Guid facturaId, DateTime dataFacturarii)
        {
            FacturaId = facturaId;
            DataFacturarii = dataFacturarii;
        }
    }
}