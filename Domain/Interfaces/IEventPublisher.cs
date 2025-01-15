namespace Domain.Events
{
    public interface IEventPublisher
    {
        void Publish(object eventMessage); // Aceasta va publica orice eveniment
    }
}