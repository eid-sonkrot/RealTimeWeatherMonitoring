using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace RealTimeWeatherMonitoring
{
    class RealTimeWeatherMonitoring
    {
        public static void Main()
        {
            var realProject = new RealTimeWeatherMonitoring();
            var weatherStation = new WeatherStation();

            new BotFactory().CreatBots();
            realProject.SubscribeBot(ref weatherStation);
            realProject.HellowMassge();
            Thread.Sleep(1000);
            while (true)
            {
                var choice=realProject.GetChoice();

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        realProject.UpdateWeatherData(ref realProject,ref weatherStation);
                        break;
                    case 2:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
        public void UpdateWeatherData(ref RealTimeWeatherMonitoring realProject, ref WeatherStation weatherStation)
        {
            var Data = (string)(null);
            var weatherData = new WeatherData();

            Data =realProject.UserInput();
            weatherData = realProject.GetWeatherData(Data);
            if (weatherData == null)
            {
                realProject.WrongDataFormatteMassge();
            }
            weatherStation.UpdateWeatherData(weatherData);
            realProject.PreesAnyKey();
        }
        public string? UserInput()
        {
            Console.Clear();
            Console.WriteLine("Enter weather data : ");
            var Data = Console.ReadLine();

            Console.Clear();
            return Data;
        }
        public void ChoiceOption()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Update Weather Data");
            Console.WriteLine("2. Exit Program");
            Console.Write("Enter option : ");
        }
        public int GetChoice()
        {
            new RealTimeWeatherMonitoring().ChoiceOption();
            var choice = int.Parse(Console.ReadLine());

            return choice;
        }
        public void SubscribeBot(ref WeatherStation weatherStation)
        {
            weatherStation.Subscribe(SunBot.GetSunBot());
            weatherStation.Subscribe(SnowBot.GetSnowBot());
            weatherStation.Subscribe(RainBot.GetRainBot());
        }
        public void HellowMassge()
        {
            Console.WriteLine("welcome to Foothill station");
        }
        public void WrongDataFormatteMassge()
        {
            Console.WriteLine("Wrong Data input");
            Thread.Sleep(1000);
        }
        public void PreesAnyKey()
        {
            Console.Write("Prees Any Key : ");
            Console.ReadKey();
        }
        public WeatherData GetWeatherData(string Data)
        {
            try
            {
                var dataObject = new DataFormateFactory().CreateDataFormate(Data).GetDocument(Data);

                if (dataObject.GetType() == typeof(JsonDocument))
                {
                    var jsonObject = (JsonDocument)dataObject;

                    return jsonObject.Deserialize<WeatherData>();
                }
                if (dataObject.GetType() == typeof(XDocument))
                {
                    var xmlDoc = (XDocument)dataObject;
                    var serializer = new XmlSerializer(typeof(WeatherData));
                    var weatherData = new WeatherData();

                    using (XmlReader reader = xmlDoc.CreateReader())
                    {
                        weatherData = (WeatherData)serializer.Deserialize(reader);
                    }
                    return weatherData;
                }
                return null;
            }
            catch (Exception? ex)
            {
                Console.WriteLine($"Invalid data format {ex.Message}");
                return null;
            }
        }
    }
}