
using Microsoft.AspNetCore.Mvc;
using EFServices.DTO;
[ApiController]
[Route("[Controller]/[Action]")]
public class StudentController:ControllerBase
{
    private readonly IStudent _studentservice;
    public StudentController(IStudent studentservice)
    {
        _studentservice=studentservice;
    }

    [HttpPost]

    public IActionResult AddStudent([FromBody]StudentDTO student)
    {
        _studentservice.AddStudent(student);
        return Ok();
    }
    
    [HttpPost]
    public IActionResult AddLaptop(LaptopDTO laptopdto)
    {
        _studentservice.AddLaptop(laptopdto);
        return Ok();
    }


   
}