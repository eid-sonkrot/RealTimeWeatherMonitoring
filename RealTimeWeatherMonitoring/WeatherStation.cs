using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeWeatherMonitoring
{
    public class WeatherStation:IObservable
    {
        private List<IObserver> observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObservers(WeatherData weatherData)
        {
            observers.ForEach(observer => observer.Update(weatherData));
        }
        public void UpdateWeatherData(WeatherData weatherData)
        {
            NotifyObservers(weatherData);
        }
    }
}
