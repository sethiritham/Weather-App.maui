using System.Net.Http.Json;
using System.Diagnostics;

namespace Weather_App.maui
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly GeoLocationService _geoLocationService;
        private const string ApiKey = "02efb388165cfcf82cc2763ca3556dba"; 

        public WeatherService()
        {
            _httpClient = new HttpClient();
            _geoLocationService = new GeoLocationService();
        }

        public async Task<OneCallApiResponse?> GetOneCallApiDataAsync(string city)
        {
            var coordinates = await _geoLocationService.GetCoordinatesForCityAsync(city);
            if (coordinates == null)
            {
                Debug.WriteLine("Could not get coordinates for the city.");
                return null;
            }

            var url = $"https://api.openweathermap.org/data/3.0/onecall?lat={coordinates.Value.Lat}&lon={coordinates.Value.Lon}&appid={ApiKey}&units=metric";

            try
            {
                var weatherData = await _httpClient.GetFromJsonAsync<OneCallApiResponse>(url);
                return weatherData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }
    }
}