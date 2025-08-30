using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Threading.Tasks.Sources;
using System.Net.Http.Json;

namespace Weather_App.maui
{
    public class GetLocation
    {
        private readonly HttpClient httpClient;
        private string APIkey = "02efb388165cfcf82cc2763ca3556dba";

        private class GeoResult
        {
            public string Name { get; set; }
        }

        public GetLocation()
        {
            httpClient = new HttpClient();
        }
        public async Task<Location> GetCurrentLocationAsync()
        {
            try
            {
                var location = await Geolocation.Default.GetLocationAsync();
                return location;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to get location!");
                return null;
            }
        }

        public async Task<string> GetCityFromLocationAsync(Location location)
        {
            if (location == null)
            {
                return "Unknown?!";
            }
            var url = $"http://api.openweathermap.org/geo/1.0/reverse?lat={location.Latitude}&lon={location.Longitude}&limit=1&appid={APIkey}";
            try
            {
                var results = await httpClient.GetFromJsonAsync<List<GeoResult>>(url);
                return results?.FirstOrDefault()?.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to reverse geocode{e.Message}");
                return "Unknown";
            }
            
        }
    }
}
