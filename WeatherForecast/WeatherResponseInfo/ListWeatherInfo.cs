using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.WeatherResponseInfo
{
    public class ListWeatherInfo
    {
        public MainWeatherInfo Main { get; set; }
        public List<WeatherInfo> Weather { get; set; }
        public string dt_txt { get; set; }
    }
}
