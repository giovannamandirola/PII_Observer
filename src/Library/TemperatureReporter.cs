using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        public bool First { get; set; }
        public Temperature Last { get; set; }
        private IObservable provider;

        public void StartReporting(IObservable observable)
        {
            provider = observable;
            this.First = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature temperature)
        {
            Console.WriteLine($"The temperature is {this.provider.Current.Degrees}°C at {this.provider.Current.Date:g}");
            if (First)
            {
                Last = this.provider.Current;
                First = false;
            }
            else
            {
                Console.WriteLine($"   Change: {this.provider.Current.Degrees - Last.Degrees}° in " +
                    $"{this.provider.Current.Date.ToUniversalTime() - Last.Date.ToUniversalTime():g}");
            }
        }
    }
}