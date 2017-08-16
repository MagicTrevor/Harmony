namespace Harmony.Core.Models
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T @event);
    }
}