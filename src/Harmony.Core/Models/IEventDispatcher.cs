namespace Harmony.Core.Models
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent eventToDispatch) where TEvent : IEvent;
    }
}