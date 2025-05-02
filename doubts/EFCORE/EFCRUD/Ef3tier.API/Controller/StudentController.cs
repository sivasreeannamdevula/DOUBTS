
[ApiController]
[Route("[Controller]/[Action]")]
public class StudentController:ControllerBase
{
    [HttpPost]
    public IActionResult AddStudent([FromBody]StudentDTO student)
    {
        return Ok();
    }
    
    [HttpGet]
    public IActionResult GetStudentDetails()
    {
        return sd;
    }


   
}