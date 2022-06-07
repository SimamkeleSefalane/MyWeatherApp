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
using static WeatherApp.WeatherDetails;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async Task<OpenWeatherDetails>GetWeatherDetails()
        { 


            var data = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (data != PermissionStatus.Granted)
            {
                var newdata = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }


            var location = await Geolocation.GetLocationAsync();

            var latitude= location.Latitude;
            var longitude= location.Longitude;



            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application /json");

            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=lat&lon=lon&appid=0a174e1be268d8c199778d5f16059615");


            var weatherDetails = JsonConvert.DeserializeObject<OpenWeatherDetails>(response);

            return weatherDetails;

        }
    } 

}
