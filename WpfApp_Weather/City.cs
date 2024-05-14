using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Weather
{
    internal class City
    {
        public string Name { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float WindStrength { get; set; }

        public City(string name, float temperature, float humidity, float windStrength)
        {
            Name = name;
            Temperature = temperature;
            Humidity = humidity;
            WindStrength = windStrength;
        }

        public static List<City> FromFile(string filePath)
        {
            List<City> cities = new List<City>();

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] p = line.Split(' ');

                if (p.Length == 4 &&
                    float.TryParse(p[1], out float temperature) &&
                    float.TryParse(p[2], out float humidity) &&
                    float.TryParse(p[3], out float wind))
                {
                    string cityName = p[0];
                    City city = new City(cityName, temperature, humidity, wind);
                    cities.Add(city);
                }
            }
            return cities;
        }


        public override string ToString()
        {
            return $"{Name}"; //- {Temperature}°C {Humidity}% {WindStrength}km/h";
        }
    }
    
}
