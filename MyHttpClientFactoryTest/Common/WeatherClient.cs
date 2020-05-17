using MyHttpClientFactoryTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyHttpClientFactoryTest.Common
{
    public class WeatherClient
    {
        public HttpClient Client { get; }
        public WeatherClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5500/");
            client.DefaultRequestHeaders.Add("Auth", "my-bearer-token");

            client.DefaultRequestHeaders.Add("User-Agent", "Codehaks Sample App");


            Client = client;
        }

        public async Task<IEnumerable<WeatherInfo>> GetWeatherInfo()
        {
            var response = await Client.GetAsync("/weatherforecast");

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();

            var results = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<WeatherInfo>>(data);

            return results;
        }


    }
}
