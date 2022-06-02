using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void GetWeatherDetails()
        {

            var location = await Geolocation.GetLocationAsync();


            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application /json");

            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=lat&lon=lon&appid=0a174e1be268d8c199778d5f16059615");


            var weatherDetails = JsonConvert.DeserializeObject<WeatherDetails>(response);

        }
    } 

}
