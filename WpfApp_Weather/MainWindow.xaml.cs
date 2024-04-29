using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_Weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<City> cities;

        public MainWindow()
        {
            InitializeComponent();
            cities = [new City() { Name = "TesztVaros", Temperature = 69f, Humidity = 420f, WindStrength = 42.069f }];

            List.ItemsSource = cities;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(Temperature.Text, out float temperature) &&
                float.TryParse(Humidity.Text, out float humidity) &&
                float.TryParse(Wind.Text, out float wind))
            {
                cities.Add(new City()
                {
                    Name = Name.Text,
                    Temperature = temperature,
                    Humidity = humidity,
                    WindStrength = wind
                });

                List.ItemsSource = null;
                List.ItemsSource = cities;

                Name.Text = string.Empty;
                Temperature.Text = string.Empty;
                Humidity.Text = string.Empty;
                Wind.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for temperature, humidity, and wind.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<City> selectedC = new List<City>();
            foreach (var i in List.SelectedItems)
            {
                if (i is City city)
                {
                    selectedC.Add(city);
                }
            }

            foreach (var c in selectedC)
            {
                cities.Remove(c);
            }

            List.ItemsSource = null;
            List.ItemsSource = cities;
        }
    }
}