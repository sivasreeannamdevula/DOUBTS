using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class PersonController:ControllerBase
{
     [HttpGet]
     public int get()
     {
        return 34;
     }

     [HttpGet("/id")]
     public int GetMethod()
     {
       return 47;
     }
}