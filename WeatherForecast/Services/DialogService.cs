using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeatherForecast.Services.Interfaces;

namespace WeatherForecast.Services
{
    public class DialogService : IDialogService
    {
        public bool ShowConfirmationRequest(string message, string caption = "")
        {
            var result = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            return result.HasFlag(MessageBoxResult.OK);
        }

        public void ShowNotification(string message, string caption = "")
        {
            MessageBox.Show(message, caption);
        }
    }
}
