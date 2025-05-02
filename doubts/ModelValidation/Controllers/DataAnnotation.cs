using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class DataAnnotationController:ControllerBase
{
    StudentImplementation si;

    public DataAnnotationController(StudentImplementation s)
    {
        si=s;
    }
     
    [HttpGet]
    public List<Student> View()
    {
        return si.Display();
    }

    [HttpPost]
    public IActionResult Post([FromBody]Student s)
    {
        //if we comment [Apicontroller] then validations wont work....in order to apply add the below commented code.
        // if(!ModelState.IsValid)             //CHECKING WHETHER THE ERRORS ARE PRESENT OR NOT.
        // {
        //     return BadRequest(ModelState);
        // }



        //1.THE BELOW CODE IF FOR CUSTOM VALIDATION 
        // if(s.AdmissionDate < 90)                //CHECKING WHETHER THE ERRORS ARE PRESENT OR NOT.
        // {
        //     ModelState.AddModelError("AdmsisionError","enter the valid admission date please");     //USED TO CREATE OUR OWN ERROR MESSAGES
        //     return BadRequest(ModelState);               //RETURNING THOSE ERRORS
        // }
        si.AddStudent(s);
        return Ok();
    }

}