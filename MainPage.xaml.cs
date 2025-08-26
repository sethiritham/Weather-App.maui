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
        public MainPage()
        {
            InitializeComponent();
            weatherService = new WeatherService();
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                var weatherData = await weatherService.GetWeatherInfoAsync(CityEntry.Text);

                if(weatherData != null)
                {
                    CityLabel.Text = weatherData.Name;
                    TempLabel.Text = $"{weatherData.Main.Temp}°C";
                    DescriptionLabel.Text = weatherData.Weather.FirstOrDefault()?.Description ?? "N/A";
                }
            }
        }
    }

   
}
