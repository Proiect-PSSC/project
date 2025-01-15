namespace Domain.Events
{
    public interface IEventHandler<in TEvent> where TEvent : class
    {
        Task Handle(TEvent eventData);
    }
}