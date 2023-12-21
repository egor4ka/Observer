using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            GeneralDisplay generalDisplay = new GeneralDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForengateDisplay forengateDisplay = new ForengateDisplay(weatherData);
            weatherData.SetMeasurements(12, 26, 13);
            weatherData.SetMeasurements(85, 41, 56);
            weatherData.SetMeasurements(35, 25, 77);
            Console.ReadLine();
        }
    }
}
