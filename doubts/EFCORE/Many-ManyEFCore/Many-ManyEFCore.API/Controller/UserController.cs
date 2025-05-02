using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class UserController:ControllerBase
{
   private readonly CourseImplementation _courseimplementation;
   private readonly StudentImplementation _studentimplementation;
   public UserController(CourseImplementation courseimplementation,StudentImplementation studentimplementation)
   {
       _courseimplementation=courseimplementation;
       _studentimplementation=studentimplementation;
   }
   [HttpPost]
   public IActionResult AddCourse(CourseDTO courseDTO)
   {
      _courseimplementation.AddCourse(courseDTO);
      return Ok();
   }

   [HttpPost]
   public IActionResult AddStudent(StudentDTO studentDTO)
   {
     _studentimplementation.AddStudent(studentDTO);
     return Ok();
   }
}