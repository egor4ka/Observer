using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class StatisticsDisplay : IObserver
    {
        private WeatherDataBase _weatherData;
        private float _maxTemperature;
        private float _minTemperature;
        private float _temperatureSum;
        private int _numReadings = 0;
        public StatisticsDisplay(WeatherData weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData), "Пустое значение!"); }
            _weatherData = weatherData;
            weatherData.Attach(this);
        }
        public StatisticsDisplay(WeatherDataEvent weatherData)
        {
            if (weatherData == null) { throw new ArgumentNullException(nameof(weatherData)); }
            _weatherData = weatherData;
            weatherData.weatherChanged += Update;
        }
        public void Update()
        {
            float temperature = _weatherData.GetTemperature();
            _temperatureSum += temperature;
            _numReadings++;
            if (temperature > _maxTemperature)
            {
                _maxTemperature = temperature;
            }
            if (temperature < _minTemperature)
            {
                _minTemperature = temperature;
            }
            Display();
        }
        public void Display()
        {
            Console.WriteLine("Значения по статистике: (Средняя/Максимальная/Минимальная температура) = " + (_temperatureSum / _numReadings) + "/" + _maxTemperature + "/" + _minTemperature);
        }
    }
}