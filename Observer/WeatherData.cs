using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class WeatherData : WeatherDataBase, ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            if (observer == null) { throw new ArgumentNullException(nameof(observer), "Пустое значение!"); }
            _observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            if (observer == null) { throw new ArgumentNullException(nameof(observer), "Пустое значение!"); }
            _observers.Remove(observer);
        }
        protected override void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
