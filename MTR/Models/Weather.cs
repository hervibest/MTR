//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net;
//using System.Web;
//using System.IO;
//using System.Windows.Input;


//namespace MTR.Models
//{
//    class Weather
//    {
//        private const string APP_ID = "PLACE-YOUR-APP-ID-HERE";

//        public class OpenWeatherMapService : IWeatherService
//        {
//            private const string APP_ID = "PLACE-YOUR-APP-ID-HERE";
//            private const int MAX_FORECAST_DAYS = 5;
//            private HttpClient client;

//            public OpenWeatherMapService()
//            {
//                client = new HttpClient();
//                client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
//            }

//            public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(string location, int days)
//            {
//                if (location == null) throw new ArgumentNullException("Location can't be null.");
//                if (location == string.Empty) throw new ArgumentException("Location can't be an empty string.");
//                if (days <= 0) throw new ArgumentOutOfRangeException("Days should be greater than zero.");
//                if (days > MAX_FORECAST_DAYS) throw new ArgumentOutOfRangeException($"Days can't be greater than {MAX_FORECAST_DAYS}");

//                var query = $"forecast/daily?q={location}&type=accurate&mode=xml&units=metric&cnt={days}&appid={APP_ID}";
//                var response = await client.GetAsync(query);

//                switch (response.StatusCode)
//                {
//                    case HttpStatusCode.Unauthorized:
//                        throw new UnauthorizedAccessException("Invalid API key.");
//                    case HttpStatusCode.NotFound:
//                        throw new DirectoryNotFoundException("Location not found.");
//                    case HttpStatusCode.OK:
//                        var s = await response.Content.ReadAsStringAsync();
//                        var x = XElement.Load(new StringReader(s));

//                        var data = x.Descendants("time").Select(w => new WeatherForecast
//                        {
//                            Description = w.Element("symbol").Attribute("name").Value,
//                            ID = int.Parse(w.Element("symbol").Attribute("number").Value),
//                            IconID = w.Element("symbol").Attribute("var").Value,
//                            Date = DateTime.Parse(w.Attribute("day").Value),
//                            WindType = w.Element("windSpeed").Attribute("name").Value,
//                            WindSpeed = double.Parse(w.Element("windSpeed").Attribute("mps").Value),
//                            WindDirection = w.Element("windDirection").Attribute("code").Value,
//                            DayTemperature = double.Parse(w.Element("temperature").Attribute("day").Value),
//                            NightTemperature = double.Parse(w.Element("temperature").Attribute("night").Value),
//                            MaxTemperature = double.Parse(w.Element("temperature").Attribute("max").Value),
//                            MinTemperature = double.Parse(w.Element("temperature").Attribute("min").Value),
//                            Pressure = double.Parse(w.Element("pressure").Attribute("value").Value),
//                            Humidity = double.Parse(w.Element("humidity").Attribute("value").Value)
//                        });

//                        return data;
//                    default:
//                        throw new NotImplementedException(response.StatusCode.ToString());
//                }
//            }
//            private ICommand _getWeatherCommand;
            
//            public ICommand GetWeatherCommand
//            {
//                get
//                {

//                    if (_getWeatherCommand == null) _getWeatherCommand =
//                            new RelayCommandAsync(() => GetWeather(), (o) => CanGetWeather());
//                    return _getWeatherCommand;
//                }
//            }

//            public async Task GetWeather()
//            {
//                try
//                {
//                    var weather = await weatherService.GetForecastAsync(Location, 3);
//                    CurrentWeather = weather.First();
//                    Forecast = weather.Skip(1).Take(2).ToList();
//                }
//                catch (HttpRequestException ex)
//                {
//                    dialogService.ShowNotification("Ensure you're connected to the internet!", "Open Weather");
//                }
//                catch (DirectoryNotFoundException ex)
//                {
//                    dialogService.ShowNotification("Location not found!", "Open Weather");
//                }

//            }
//            public class WeatherIconConverter : IMultiValueConverter
//            {
//                public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
//                {
//                    var id = (int)values[0];
//                    var iconID = (string)values[1];

//                    if (iconID == null) return Binding.DoNothing;

//                    var timePeriod = iconID.ToCharArray()[2]; // This is either d or n (day or night)
//                    var pack = "pack://application:,,,/OpenWeather;component/WeatherIcons/";
//                    var img = string.Empty;

//                    if (id >= 200 && id < 300) img = "thunderstorm.png";
//                    else if (id >= 300 && id < 500) img = "drizzle.png";
//                    else if (id >= 500 && id < 600) img = "rain.png";
//                    else if (id >= 600 && id < 700) img = "snow.png";
//                    else if (id >= 700 && id < 800) img = "atmosphere.png";
//                    else if (id == 800) img = (timePeriod == 'd') ? "clear_day.png" : "clear_night.png";
//                    else if (id == 801) img = (timePeriod == 'd') ? "few_clouds_day.png" : "few_clouds_night.png";
//                    else if (id == 802 || id == 803) img = (timePeriod == 'd') ? "broken_clouds_day.png" : "broken_clouds_night.png";
//                    else if (id == 804) img = "overcast_clouds.png";
//                    else if (id >= 900 && id < 903) img = "extreme.png";
//                    else if (id == 903) img = "cold.png";
//                    else if (id == 904) img = "hot.png";
//                    else if (id == 905 || id >= 951) img = "windy.png";
//                    else if (id == 906) img = "hail.png";

//                    Uri source = new Uri(pack + img);

//                    BitmapImage bmp = new BitmapImage();
//                    bmp.BeginInit();
//                    bmp.UriSource = source;
//                    bmp.EndInit();

//                    return bmp;
//                }

//                public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
//                {
//                    return (object[])Binding.DoNothing;
//                }
//            }
//        }
//}
