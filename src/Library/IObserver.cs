
namespace Observer
{
    public interface IObserver
    {
        bool First{ get; }
        Temperature Last { get; set; }
        void Update(Temperature temperature);
    }
}