using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;


namespace Weather_App.maui
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;
        private bool isdefaultactive = true;
        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadWeatherForCity("Mumbai");
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
            int ID = weatherData?.Current?.Weather[0]?.ID ?? 0;
            var summary = weatherData?.Daily[1].Summary;
            System.Diagnostics.Debug.WriteLine($"Weather ID received: {ID}");


            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await ChangeIconSourceAsync(ID, DefaultIcon, NextIcon);
                await ChangeBackgroundAsync(ID, DefaultBG, BackgroundImage);
                
                isdefaultactive = !isdefaultactive;

                if (MaximumTemperature != null) MaximumTemperature.Text = maxTemp;
                if (TempLabel != null) TempLabel.Text = currentTemp;
                if (CityLabel != null) CityLabel.Text = city;
                if (MinimumTemperature != null) MinimumTemperature.Text = minTemp;
                if (TomorrowForecastTemp != null) TomorrowForecastTemp.Text = tomorrowMax;
                if (HumidityPercentage != null) HumidityPercentage.Text = humidity;
                if (Summary != null) Summary.Text = summary;

                var windLabel = this.FindByName<Label>("WindSpeedKMPH")
                            ?? this.FindByName<Label>("WindSpeedKmph")
                            ?? this.FindByName<Label>("WindSpeed");
                if (windLabel != null) windLabel.Text = wind;

                var feelsLabel = this.FindByName<Label>("FeelsLikeText");
                if (feelsLabel != null && !string.IsNullOrEmpty(feelsLike)) feelsLabel.Text = feelsLike;
            });
        }

        public async Task ChangeBackgroundAsync(int ID, Image defaultBG, Image nextBG)
        {
            if(nextBG != defaultBG)
            {
                string newImageSource = ID switch
                {
                    800 => "sunny.png",
                    >= 200 and < 300 => "thunderstorm.png",
                    >= 300 and < 400 => "rainy.png",
                    >= 500 and < 600 => "rainy.png",
                    >= 600 and < 700 => "snowy.png",
                    > 800 and < 810 => "clouds.png",
                    _ => "dusty.png"

                };
                Image currentImage = isdefaultactive ? defaultBG : nextBG;
                Image nextImage = isdefaultactive ? nextBG : defaultBG;




                nextImage.Source = newImageSource;

                await Task.WhenAll(currentImage.FadeTo(0, 1000), nextImage.FadeTo(1, 1000));

            }




        }

        public async Task ChangeIconSourceAsync(int ID, Image defaultIcon, Image nextIcon)
        {
            string newIconSource = ID switch
            {
                800 => "sunny_icon.png",
                >= 200 and < 300 => "thunderstorm_icon.png",
                >= 300 and < 400 => "rain_icon.png",
                >= 500 and < 600 => "drizzle_icon.png",
                >= 600 and < 700 => "snow_icon.png",
                > 800 and < 810 => "weather_icon.png",
                _ => "dusty_icon.png"
            };

            Image currentIcon = isdefaultactive ? defaultIcon : nextIcon;
            Image nextIc = isdefaultactive ? nextIcon : defaultIcon;
            nextIc.Source = newIconSource;
            await Task.WhenAll(currentIcon.FadeTo(0, 1000), nextIc.FadeTo(1, 1000));

            
        }


    }
}