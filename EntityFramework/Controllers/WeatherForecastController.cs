using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Database;
using EntityFramework.Database.Repostories;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        //połączenie do startup
        private IServiceProvider  _ServiceProvider;
        private ISettingsRepository _settingsRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IServiceProvider serviceProvider, ISettingsRepository settingsRepository)
        {
            //połączenie do bazy danych
            _ServiceProvider = serviceProvider;
            _settingsRepository = settingsRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public IActionResult Index()
        {
            //połączenie do bazy danych
            //var database = _ServiceProvider.GetService(typeof(EntityFrameworkDbContext)) as EntityFrameworkDbContext;

           // var reposytory = new SettingsRepository(database);

            _settingsRepository.UpdateSetting(new Setting
            {
                Name = "lala",
                Value = "lalal"
            });

            _settingsRepository.SaveChanges();

            return Ok();
        }
    }
}
