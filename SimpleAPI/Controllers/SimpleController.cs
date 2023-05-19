using Microsoft.AspNetCore.Mvc;
using SimpleAPI.DTO;
using SimpleAPI.Interface.Service;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISimpleService _simpleService;

        public SimpleController(ILogger<WeatherForecastController> logger,
                                ISimpleService simpleService)
        {
            _logger = logger;
            _simpleService = simpleService;
        }

        [HttpGet]
        public IEnumerable<SimpleDTO> GetList()
        {
            _logger.LogInformation("Retrieving information from service interface");
            return _simpleService.GetList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] SimpleDTO simpleDTO)
        {
            return (_simpleService.addPerson(simpleDTO).Equals("ok")) ? Ok() : NotFound();
        }
    }
}
