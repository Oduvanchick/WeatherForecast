using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Models
{
    public class Weather
    {
        // weather id
        public int ID { get; set; }

        // defines type of weather
        public string MainDescription { get; set; }

        // defines extension type of weather
        public string Description { get; set; }

        // defines path to icon for weather
        public string IconPath { get; set; }

        // defines date of forecast
        public DateTime Date { get; set; }
        // defines average temperature in units
        public double Temperature { get; set; }

        // defines level of pressure
        public double Pressure { get; set; }

        // defines percent of humidity
        public double Humidity { get; set; }
    }
}
