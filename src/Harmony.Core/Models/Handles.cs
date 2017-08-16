namespace Harmony.Core.Models
{
    public interface Handles<T> where T : IEvent
    {
        void Handle(T args);
    }
}