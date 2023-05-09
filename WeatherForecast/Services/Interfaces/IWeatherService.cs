using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<IEnumerable<Weather>> GetForecastAsync(string city);
    }
}
