using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;


namespace Weather_App.maui
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadWeatherForCity("Bengaluru");
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                await LoadWeatherForCity(CityEntry.Text);
            }
        }

        private async Task LoadWeatherForCity(string city)
        {
            var weatherData = await _weatherService.GetOneCallApiDataAsync(city);
            if (weatherData == null) 
                return;

            var today = weatherData.Daily.FirstOrDefault();
            var tomorrow = weatherData.Daily.Skip(1).FirstOrDefault();

            // Prepare values
            var maxTemp = $"{(int)(today?.Temp?.Max ?? 0)}°C";
            var currentTemp = $"{(int)(weatherData.Current?.Temp ?? 0)}°C";
            var minTemp = $"{(int)(today?.Temp?.Min ?? 0)}°C";
            var tomorrowMax = $"{(int)(tomorrow?.Temp?.Max ?? 0)}°C";
            var humidity = $"{(int)(weatherData?.Current?.Humidity ?? 0)}%";
            var wind = $"{(int)(weatherData?.Current?.Windspeed ?? 0)} kmph";
            var feelsLike = weatherData?.Current?.FeelsLike is not null
                ? $"{(int)weatherData.Current.FeelsLike}°C"
                : string.Empty;
            var description = today?.Summary;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (MaximumTemperature != null) MaximumTemperature.Text = maxTemp;
                if (TempLabel != null) TempLabel.Text = currentTemp;
                if (CityLabel != null) CityLabel.Text = city;
                if (MinimumTemperature != null) MinimumTemperature.Text = minTemp;
                if (TomorrowForecastTemp != null) TomorrowForecastTemp.Text = tomorrowMax;
                if (HumidityPercentage != null) HumidityPercentage.Text = humidity;
                if (Description != null) Description.Text = description;

                var windLabel = this.FindByName<Label>("WindSpeedKMPH")
                            ?? this.FindByName<Label>("WindSpeedKmph")
                            ?? this.FindByName<Label>("WindSpeed");
                if (windLabel != null) windLabel.Text = wind;

                var feelsLabel = this.FindByName<Label>("FeelsLikeText");
                if (feelsLabel != null && !string.IsNullOrEmpty(feelsLike)) feelsLabel.Text = feelsLike;
            });
        }
    }
}