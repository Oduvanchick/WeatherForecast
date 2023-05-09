using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecast.Commands;
using WeatherForecast.Models;
using WeatherForecast.Services;
using WeatherForecast.Services.Interfaces;
using WeatherForecast.Utils;
using WeatherForecast.Views;

namespace WeatherForecast.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly WeatherService _weatherService;
        private readonly DialogService _dialogService;

        private ICommand _getWeatherCommand;
        private ICommand _addCityCommand;
        private ICommand _removeCityCommand;

        private Weather _currentWeather;
        private City _currentCity;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Weather> _forecast;

        // -- //
        public MainViewModel(WeatherService weatherService, DialogService dialogService)
        {
            _weatherService = weatherService;
            _dialogService = dialogService;
            CurrentWeather = new Weather();
            Cities = new ObservableCollection<City>()
            {
                new City {FullName="Kyiv, Ukraine"},
                new City {FullName="London, England"},
                new City {FullName="Rome, Italy"},
            };
        }

        // get weather command async
        public ICommand GetWeatherCommand => _getWeatherCommand ?? (_getWeatherCommand = new RelayCommandAsync(() => GetWeather(CurrentCity.FullName), (o) => true));

        // remove city command
        public ICommand RemoveCityCommand => _removeCityCommand ?? (_removeCityCommand = new RelayCommand(() => RemoveCity(), () => CurrentCity != null));

        // add city command
        public ICommand AddCityCommand => _addCityCommand ?? (_removeCityCommand = new RelayCommand(() => AddCity(), () => true));


        // get and set list of cities with weather forecast
        public ObservableCollection<City> Cities
        {
            get { return _cities; }
            set
            {
                _cities = value;
                OnPropertyChanged(nameof(Cities));
            }
        }

        // get and set weather for selected city
        public Weather CurrentWeather
        {
            get { return _currentWeather; }
            set
            {
                _currentWeather = value;
                OnPropertyChanged(nameof(CurrentWeather));
            }
        }

        public bool IsCurrentWeatherEmpty { get; set; } = true;
        public bool IsCurrentWeatherNotEmpty => !IsCurrentWeatherEmpty;

        // get and set 3 hour forecast data
        public ObservableCollection<Weather> Forecast
        {
            get { return _forecast; }
            set
            {
                _forecast = value;
                OnPropertyChanged(nameof(Forecast));
            }
        }

        // get and set selected city
        public City CurrentCity
        {
            get { return _currentCity; }
            set
            {
                _currentCity = value;
                OnPropertyChanged(nameof(CurrentCity));
                if (CurrentCity != null)
                    GetWeatherCommand.Execute(this);
            }
        }

        // load weather for selected city
        public async Task GetWeather(string city)
        {
            if (CurrentCity == null)
                return;
            try
            {
                var weather = await _weatherService.GetForecastAsync(city);
                if (weather == null)
                {
                    CleanWeather();
                    return;
                }
                IsCurrentWeatherEmpty = false;
                OnPropertyChanged(nameof(IsCurrentWeatherEmpty));
                OnPropertyChanged(nameof(IsCurrentWeatherNotEmpty));
                CurrentWeather = weather.First();
                Forecast = new ObservableCollection<Weather>(weather.Skip(1).Take(3).ToList());


            }
            catch (HttpRequestException ex)
            {
                _dialogService.ShowNotification("Ensure you're connected to the internet!", "Open Weather");
                CleanWeather();
                return;
            }
            catch (LocationNotFoundException ex)
            {
                _dialogService.ShowNotification("Location not found!", "Open Weather");
                CleanWeather();
                return;
            }

        }

        // execute dialog window for creating new city
        private void AddCity()
        {
            AddCityDialog addCityDialog = new AddCityDialog();
            addCityDialog.ShowDialog();
            if (addCityDialog.NeedAdd)
            {
                var newCity = new City() { FullName = addCityDialog.CityName };
                Cities.Add(newCity);
            }
        }
        
        // delete city from list
        private void RemoveCity()
        {
            Cities.Remove(CurrentCity);
            CurrentCity = null;
            CleanWeather();
        }

        // clean data of weather
        private void CleanWeather()
        {
            CurrentWeather = null;
            Forecast = null;
            IsCurrentWeatherEmpty = true;
            OnPropertyChanged(nameof(IsCurrentWeatherEmpty));
            OnPropertyChanged(nameof(IsCurrentWeatherNotEmpty));

        }
    }
}
