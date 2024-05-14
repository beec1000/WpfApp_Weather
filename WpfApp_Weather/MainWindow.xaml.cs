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
            cities = City.FromFile(@"..\..\..\src\cities.txt");

            List.ItemsSource = cities;
            List.SelectionChanged += List_SelectionChanged;

            List.SelectedItem = cities[0];
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
                if (!string.IsNullOrWhiteSpace(Name.Text))
                {
                    City newCity = new City(Name.Text, temperature, humidity, wind);
                    cities.Add(newCity);

                    List.ItemsSource = null;
                    List.ItemsSource = cities;

                    Name.Text = string.Empty;
                    Temperature.Text = string.Empty;
                    Humidity.Text = string.Empty;
                    Wind.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please enter a valid city name.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

            MessageBox.Show("The selected city has been deleted.", "INFORMATION", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            List.ItemsSource = null;
            List.ItemsSource = cities;
        }
    }
}
