using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class GeneralDisplay : IObserver
    {
        private WeatherDataBase _weatherData;

        public GeneralDisplay(WeatherData weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData), "Пустое значение!"); }
            _weatherData = weatherData;
            weatherData.Attach(this);
        }
        public GeneralDisplay(WeatherDataEvent weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData), "Пустое значение!"); }
            _weatherData = weatherData;
            weatherData.weatherChanged += Update;
        }
        public void Update()
        {
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Общие значения: " + _weatherData.GetTemperature() + " градусов по Фаренгейту и " + _weatherData.GetHumidity() + "% влажности!");
        }
    }
}