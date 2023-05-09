using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherForecast.Views
{
    /// <summary>
    /// Interaction logic for AddCityDialog.xaml
    /// </summary>
    public partial class AddCityDialog : Window
    {
        public AddCityDialog()
        {
            InitializeComponent();
        }

        public bool NeedAdd { get; set; } = false;
        public string CityName
        {
            get { return cityName.Text; }
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            NeedAdd = true;
            this.DialogResult = true;
        }
    }
}
