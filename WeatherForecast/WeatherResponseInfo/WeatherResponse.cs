using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WeatherForecast.WeatherResponseInfo
{
    public class WeatherResponse
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ListWeatherInfo> list { get; set; }
    }
}
