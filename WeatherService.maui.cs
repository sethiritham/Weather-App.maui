using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Weather_App.maui;
public class WeatherService
{
    private readonly HttpClient httpClient;
    private const string weather_API = "02efb388165cfcf82cc2763ca3556dba";
    public WeatherService()
    {
        httpClient = new HttpClient();
    }

    public async Task<WeatherInfo> GetWeatherInfoAsync(string city)
    {
        try
        {
            string APIurl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={weather_API}&units=metric";
            var weatherData = await httpClient.GetFromJsonAsync<WeatherInfo>(APIurl);
            return weatherData;
        }
        catch (Exception ex)
        {
            Console.WriteLine("OOPS! Could'nt fetch data from the NET");
            return null;
        }
    }

}