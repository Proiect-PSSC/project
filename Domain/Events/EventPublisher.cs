namespace Domain.Events
{
    public class EventPublisher : IEventPublisher
    {
        public void Publish(object eventMessage)
        {
            //  doar logăm evenimentul
            Console.WriteLine($"Eveniment publicat: {eventMessage.GetType().Name}");
        }
    }
}