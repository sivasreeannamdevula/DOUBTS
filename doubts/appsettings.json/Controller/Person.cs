using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class PersonController:ControllerBase
{
    //accessing appsettings.json customkey values in controllers using IConfiguration.
    // private IConfiguration _config;

    // public PersonController(IConfiguration config)
    // {
    //     _config=config;
    // }
    [HttpGet]
    public IActionResult GetMethod()
    {
        //we have to access as dictionary
       // string str=_config["Customkey"];
        //System.Console.WriteLine(str);
       return Ok("hey");
    }
}