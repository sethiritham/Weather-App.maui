using System.Text.Json.Serialization;

namespace Weather_App.maui
{
    public class OneCallApiResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather? Current { get; set; }

        [JsonPropertyName("daily")]
        public List<DailyForecast> Daily { get; set; } = new();
    }

    public class CurrentWeather
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherDetail> Weather { get; set; } = new();

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("wind_speed")]
        public float Windspeed { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }


    }

    public class DailyForecast
    {
        [JsonPropertyName("temp")]
        public DailyTemp? Temp { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }
    }

    public class DailyTemp
    {
        [JsonPropertyName("min")]
        public double Min { get; set; }

        [JsonPropertyName("max")]
        public double Max { get; set; }
    }

    public class WeatherDetail
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("id")]

        public int? ID { get; set; }
    }
}