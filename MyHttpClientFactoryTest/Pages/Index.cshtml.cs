using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyHttpClientFactoryTest.Common;
using MyHttpClientFactoryTest.Models;

namespace MyHttpClientFactoryTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WeatherClient _weatherClient;
        public IndexModel(ILogger<IndexModel> logger, WeatherClient weatherClient)
        {
            _logger = logger;
            _weatherClient = weatherClient;
        }

        public IList<WeatherInfo> WeatherData { get; set; }

        public async Task<IActionResult> OnGet()
        {
            
                WeatherData = (await _weatherClient.GetWeatherInfo()).ToList();
         
            return Page();
        }
    }
}
