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
        List<City> cities = new List<City>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            List.Items.Add(Name.Text + "|" + Temperature.Text + "°C" + "|" + Humidity.Text + "%" + "|" + Wind.Text + "km/h");
            Name.Text = string.Empty;
            Temperature.Text = string.Empty;
            Humidity.Text = string.Empty;
            Wind.Text = string.Empty;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = List.SelectedItems;

        }
    }
}