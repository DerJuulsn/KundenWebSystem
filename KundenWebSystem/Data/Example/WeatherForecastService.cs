using System;
using System.Linq;
using System.Threading.Tasks;

namespace KundenWebSystem.Data.Example
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var r = new Random();
            
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = r.Next(-20, 55),
                Summary = Summaries[r.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}