using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullSTack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
    [HttpGet]
    public IActionResult GetWeather()
    {
        return Ok(new { Temperature = "25°C", Condition = "Sunny" });
    }
    }
}
