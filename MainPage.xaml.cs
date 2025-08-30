using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Weather_App.maui;
namespace Weather_App.maui

{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService weatherService;
        private readonly GetLocation getLocation;
        public MainPage()
        {
            InitializeComponent();
            weatherService = new WeatherService();
            getLocation = new GetLocation();
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                var weatherData = await weatherService.GetWeatherInfoAsync(CityEntry.Text);

                if(weatherData != null)
                {
                    CityLabel.Text = weatherData.Name ?? "N/A";
                    int Temp = (int)(weatherData.Main?.Temp ?? 0);
                    TempLabel.Text = $"{Temp}°C";
                    //DescriptionLabel.Text = weatherData.Weather.FirstOrDefault()?.Description ?? "N/A";
                }
            }
        }
        /*
        public async void OnGetCurrentLocationClicked(object sender, EventArgs e)
        {

            var deviceLocation = await getLocation.GetCurrentLocationAsync();
            if (deviceLocation != null)
            {
                var cityName = await getLocation.GetCityFromLocationAsync(deviceLocation);
                await DisplayAlert("Debugging", $"The city found was: '{cityName}'", "OK");
                var weatherData = await weatherService.GetWeatherInfoAsync(cityName);
                if (weatherData != null)
                {
                    CityLabel.Text = weatherData.Name;
                    TempLabel.Text = $"{weatherData.Main.Temp}°C";
                    DescriptionLabel.Text = weatherData.Weather.FirstOrDefault()?.Description ?? "N/A";

                }
            }
            else
            {
                await DisplayAlert("ERROR!", "UNABLE TO GET CURRENT LOCATION", "OK");
            }
        }*/
    }

   
}
