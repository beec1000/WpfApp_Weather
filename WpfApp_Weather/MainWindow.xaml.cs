using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_Weather
{
    public partial class MainWindow : Window
    {
        private List<City> cities;

        public MainWindow()
        {
            InitializeComponent();
            cities = new List<City>
            {
                new City() { Name = "TesztVaros", Temperature = 69f, Humidity = 420f, WindStrength = 42.069f }
            };

            List.ItemsSource = cities;
            List.SelectionChanged += List_SelectionChanged;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = List.SelectedItem as City;
            if (selected != null)
            {
                DataList.ItemsSource = new List<City> { selected };
            }
            else
            {
                DataList.ItemsSource = null;
            }
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
                MessageBox.Show("Please enter valid values for temperature, humidity, and wind.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<City> selectedCities = new List<City>();
            foreach (var item in List.SelectedItems)
            {
                if (item is City city)
                {
                    selectedCities.Add(city);
                }
            }

            foreach (var city in selectedCities)
            {
                cities.Remove(city);
            }

            List.ItemsSource = null;
            List.ItemsSource = cities;
        }
    }
}
