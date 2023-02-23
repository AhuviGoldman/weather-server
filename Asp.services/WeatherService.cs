
using System;
using System.Xml.Linq;

namespace Asp.services
{
    public class WeatherService : IWeatherService
    {
        public async Task<string> GetByCityNameAsync(string cityName)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (httpClient != null)
                    {
                        var response = await httpClient.GetAsync("https://api.weatherapi.com/v1/forecast.json?key=39f8ecaf506c4f76b3f55139222906&q=" + cityName + "&api=yes&alerts=yes");
                        string json = await response.Content.ReadAsStringAsync();
                        var obj = XObject.Parse(json);
                        string temp_c = obj["current"]["temp_c"].ToString();
                        string condition = obj["current"]["condition"]["text"].ToString();
                        return $"The weather in {cityName} is: temp {temp_c}, condition {condition}";
                    }
                }
            }
            catch (Exception ex)
            {
                return "the city isnt good";
                throw new Exception(ex.Message);

            }
            return "the city isnt good";
        }

        public async Task<string> Get3DaysByCityNameAsync(string cityName)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://api.weatherapi.com/v1/forecast.json?key=39f8ecaf506c4f76b3f55139222906&q=" + cityName + "&days=3&api=yes&alerts=yes");
                string json = await response.Content.ReadAsStringAsync();
                var obj = Object.Parse(json);
                return obj["forecast"]["forecastday"].ToString();
            }
        }
    }
}