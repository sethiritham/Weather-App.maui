using System.Net.Http.Json;
using System.Diagnostics;

namespace Weather_App.maui
{
    public class GeoLocationService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "02efb388165cfcf82cc2763ca3556dba"; 

        private class GeoResult
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        public GeoLocationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(double Lat, double Lon)?> GetCoordinatesForCityAsync(string city)
        {
            var url = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={ApiKey}";
            try
            {
                var results = await _httpClient.GetFromJsonAsync<List<GeoResult>>(url);
                var firstResult = results?.FirstOrDefault();
                if (firstResult != null)
                {
                    return (firstResult.Lat, firstResult.Lon);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting coordinates: {ex.Message}");
            }
            return null;
        }
    }
}