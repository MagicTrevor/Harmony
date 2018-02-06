namespace Harmony.Core.Models
{
    public interface Handles<in T> where T : IEvent
    {
        void Handle(T args);
    }
}