using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[ApiController]
[Route("[Controller]/[Action]")]
public class StudentController:ControllerBase
{
   private readonly StudentContext _studentContext;
    public StudentController(StudentContext studentContext)
    {
       _studentContext=studentContext;
    }
    [HttpGet]
    public IActionResult GetStudents()
    {
      
      return Ok(_studentContext.StudentTable.ToList());
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody]Student student)
    {
        _studentContext.StudentTable.Add(student);
        _studentContext.SaveChanges();
        return Ok("SUCCESSFUL");
    }

    [HttpPatch]
    public IActionResult UpdateStudent([FromQuery] int ID, [FromBody] Student student)
    {
      Student studentToUpdate = _studentContext.StudentTable.Find(ID);
      if(student.Name != null && (student.Name != "string")) studentToUpdate.Name = student.Name;
      if(student.Dept != null && (student.Dept != "string")) studentToUpdate.Dept = student.Dept;
      studentToUpdate.Age = student.Age;
      // _studentContext.StudentTable.Remove(studentToUpdate);
      _studentContext.SaveChanges();
      return Ok();
    }
}