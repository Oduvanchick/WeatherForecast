using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeatherForecast.Services;
using WeatherForecast.ViewModels;
using WeatherForecast.Views;

namespace WeatherForecast
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            WeatherService weatherService = new WeatherService();

            MainView mainView = new MainView()
            {
                DataContext = new MainViewModel(weatherService, new DialogService())
            };

            mainView.Show();


            base.OnStartup(e);
        }
    }
}
