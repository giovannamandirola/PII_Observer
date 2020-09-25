
namespace Observer
{
    public interface IObservable
    {
        Temperature Current { get; set; }
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void NotifyObservers();
    }
}