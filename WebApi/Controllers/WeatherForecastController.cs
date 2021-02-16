using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
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
        private readonly IUserService _user;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpGet]
        public IEnumerable<Entity.ModelDb.Users> Get()
        {        
            return  _user.TestList();         
        }
    }
}
