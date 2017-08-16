namespace Harmony.Core.Models
{
    public static class DomainEvent
    {
        public static IEventDispatcher Dispatcher { get; set; }

        public static void Raise<T>(T @event) where T : IEvent
        {
            Dispatcher.Dispatch(@event);
        }

    }
}