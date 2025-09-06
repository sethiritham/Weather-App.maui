# 🌦️ Weather App

A clean and simple cross-platform weather application built with .NET MAUI that provides real-time weather information for cities around the world.

![App Screenshot]([https://user-images.githubusercontent.com/your-username/your-repo/your-screenshot.png](https://github.com/sethiritham/Weather-App.maui/blob/master/Screenshot%20(6).png))

## 📖 About

This application offers a modern and intuitive interface to get the latest weather updates. It fetches data from a weather API to provide accurate and essential information. On startup, the app automatically displays the current weather for **Bengaluru, India**, and allows users to search for any other city.

---

## ✨ Features

* **🌡️ Current Temperature**: Get the real-time temperature.
* **🔼 Max & 🔽 Min Temperature**: See the forecasted high and low for the day.
* **💧 Humidity**: Check the current humidity levels.
* **🤔 Feels Like**: Understand what the temperature actually feels like.
* **💨 Wind Speed**: Get information on the current wind conditions.
* **🌧️ Precipitation**: View the precipitation probability.
* **📍 Default Location**: Automatically loads weather for Bengaluru on startup.
* **🔍 City Search**: Find weather information for any city worldwide.

---

## 🛠️ Technologies Used

* **.NET MAUI**: For building the cross-platform user interface.
* **C#**: The primary programming language for the application logic.
* **XAML**: For defining the user interface and layout.
* **OpenWeatherMap API**: Used to fetch the weather data.

---

## 🚀 Getting Started

To get a local copy up and running, follow these simple steps.

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
* Visual Studio 2022 with the **.NET Multi-platform App UI development** workload installed.

### Installation

1.  **Clone the repository:**
    ```sh
    git clone [https://github.com/sethiritham/Weather-App.maui)
    ```
2.  **Add your API Key:**
    * Get a free API key from [OpenWeatherMap](https://openweathermap.org/api).
    * Open the project in Visual Studio and navigate to the `WeatherService.cs` file.
    * Insert your API key where indicated:
        ```csharp
        private readonly string _apiKey = "YOUR_API_KEY_HERE";
        ```
3.  **Run the Application:**
    * Open the solution file (`.sln`) in Visual Studio.
    * Wait for the NuGet packages to restore.
    * Select your desired target (Windows Machine, Android Emulator, etc.) and click the run button.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to fork the repo and create a pull request. You can also open an issue with the tag "enhancement".
