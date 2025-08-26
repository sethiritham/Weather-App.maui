using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Weather_App.maui
{
    public class WeatherInfo
    {
        public Main Main { get; set; }
        public List<WeatherDetail> Weather { get; set; }
        public string Name { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }

    }
    public class WeatherDetail
    {
        public string Description { get; set; }
    }
}
