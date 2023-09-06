using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection.Metadata.Ecma335;

namespace RealTimeWeatherMonitoring
{
    class RealTimeWeatherMonitoring
    {
        private static RealTimeWeatherMonitoring realProject= new RealTimeWeatherMonitoring();
        private static DataFormateFactory dataFormateFactory=new DataFormateFactory();
        public static void Main()
        {
            var weatherStation = new WeatherStation();

            new BotFactory().CreatBots();
            realProject.SubscribeBot(ref weatherStation);
            realProject.HellowMassge();
            realProject.PreesAnyKey();
            while (true)
            {
                var choice=realProject.GetChoice();

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        var Data = (string)(null);
                        var weatherData = realProject.GetWeatherData(Data);

                        Data = realProject.UserInput();
                        realProject.UpdateWeatherData(weatherData,Data,ref weatherStation);
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
        public void UpdateWeatherData(WeatherData weatherData,string Data,ref WeatherStation weatherStation)
        {
            if (CheackWeatherData(weatherData))
            {
                realProject.WrongDataFormatteMassge();
                return;
            }
            weatherStation.UpdateWeatherData(weatherData);
            realProject.PreesAnyKey();
        }
        public bool CheackWeatherData(WeatherData weatherData)
        {
            if (weatherData is null)
            {
                return false;
            }
            return true;
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
            PreesAnyKey();
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
                var dataObject = dataFormateFactory.CreateDataFormate(Data).GetDocument(Data);

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
            catch (FormatException? ex)
            {
                Console.WriteLine($"Invalid data format {ex.Message}");
                return null;
            }
        }
    }
}