
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class HomeController:ControllerBase
{
    private readonly ILogger<HomeController> _logger;
     public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    [HttpGet]
    public IActionResult Get()
    {
         _logger.LogInformation("API started at:"+DateTime.Now);
         return Ok(); 
    }
}
 