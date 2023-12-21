using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class WeatherDataEvent : WeatherDataBase
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public event Action weatherChanged;

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            OnWeatherChanged();
        }
        protected virtual void OnWeatherChanged()
        {
            weatherChanged.Invoke();
        }
        public float GetTemperatureEvent()
        {
            return _temperature;
        }
        public float GetHumidityEvent()
        {
            return _humidity;
        }
        public float GetPressureEvent()
        {
            return _pressure;
        }
        protected override void Notify()
        { }
    }
}