using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


[ApiController]
[Route("[Controller][Action]")]
[CustomActionFilter("controller")]                //like this we have to add action filter at controller level
public class ActionFilterController:ControllerBase
{
    
     
    [HttpGet]
    [CustomActionFilter("Method")]              //like this we have to add action filter at method level
    
    public IActionResult Get(string UserName,string Password)
    {
        return Ok();
    }


    [HttpGet("{UserName},{Password}")]
    [ActionFilters2]
    public string GetMethod(string UserName,string Password)
    {
        return "ok";
    }

    [HttpPost]
    [ActionFilter3]
    public IActionResult GetM(Employee e)
    {
        return Ok();
    }
}