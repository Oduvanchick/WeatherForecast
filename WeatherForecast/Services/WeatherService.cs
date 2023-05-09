using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using WeatherForecast.WeatherResponseInfo;
using WeatherForecast.Utils;
using System.Linq;

namespace WeatherForecast.Services
{
    public class WeatherService : IWeatherService
    {
        
        private const string APP_ID = "c3ec843b4f84c41fff299214086323c0"; // add your api key
        private HttpClient _client;

        // -- /
        public WeatherService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
        }

        // get forecast from openweathermap
        public async Task<IEnumerable<Weather>> GetForecastAsync(string city)
        {
            var query = $"forecast?q={city}&units=metric&appid={APP_ID}";
            var response = await _client.GetAsync(query);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new Exception("Invalid API key.");
                case HttpStatusCode.NotFound:
                    throw new LocationNotFoundException("Location not found.");
                case HttpStatusCode.OK:
                    try
                    {
                        var responseString = await response.Content.ReadAsStringAsync();

                        var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);
                        var weatherList = weatherResponse.list.Select(w => new Weather
                        {
                            Description = w.Weather.FirstOrDefault().Description,
                            MainDescription = w.Weather.FirstOrDefault().Main,
                            ID = w.Weather.FirstOrDefault().Id,
                            IconPath = $"/Icons/Weather/{w.Weather.FirstOrDefault().Icon}.png",
                            Date = Convert.ToDateTime(w.dt_txt),
                            Temperature = Math.Round(w.Main.Temp),
                            Pressure = w.Main.Pressure,
                            Humidity = w.Main.Humidity
                        }).ToList();

                        return weatherList;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                default:
                    throw new NotImplementedException(response.StatusCode.ToString());
            }
            throw new NotImplementedException();
        }
    }
}
