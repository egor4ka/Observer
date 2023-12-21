using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Observer
{
    public class ForengateDisplay : IObserver
    {
        private WeatherDataBase _weatherData;
        private float _lastPressure;
        private float _currentPressure;
        public ForengateDisplay(WeatherData weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData), "Пустое значение!"); }
            _weatherData = weatherData;
            weatherData.Attach(this);
        }
        public ForengateDisplay(WeatherDataEvent weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData)); }
            _weatherData = weatherData;
            weatherData.weatherChanged += Update;
        }
        public void Update()
        {
            if (_weatherData != null)
            {
                _lastPressure = _currentPressure;
                _currentPressure = _weatherData.GetPressure();
                Display();
            }
        }
        public void Display()
        {
            Console.WriteLine("Прогноз погоды: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Погода улучшается!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("Изменений в погоде не обнаружено!");
            }
            else
            {
                Console.WriteLine("Ожидаются заморозки!");
            }
        }
    }
}