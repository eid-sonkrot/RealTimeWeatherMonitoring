using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeWeatherMonitoring
{
    public class WeatherStation:IObservable
    {
        private readonly List<IObserver> observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            if (observers is null)
            {
                throw new NullReferenceException();
            }
            observers.Add(observer);
        }
        public void Unsubscribe(IObserver observer)
        {
            if (observers is null)
            {
                throw new NullReferenceException();
            }
            observers.Remove(observer);
        }
        public void NotifyObservers(WeatherData weatherData)
        {
            if (weatherData is null)
            {
                throw new NullReferenceException();
            }
            observers.ForEach(observer => observer.Update(weatherData));
        }
        public void UpdateWeatherData(WeatherData weatherData)
        {
            if (weatherData is null)
            {
                throw new NullReferenceException();
            }
            NotifyObservers(weatherData);
        }
    }
}