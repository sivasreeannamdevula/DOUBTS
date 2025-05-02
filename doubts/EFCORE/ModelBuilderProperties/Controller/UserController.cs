using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class UserController:ControllerBase
{
    private readonly ContextClass _context;
    public UserController(ContextClass context)
    {
       _context=context;
    }
    [HttpGet]
    public IActionResult GetEmployees()
    {
      return Ok( _context.EmpTable.ToList());
    
    }

    [HttpPost]
    public IActionResult AddEmp(EmployeeEntity employeeEntity)
    {
        _context.EmpTable.Add(employeeEntity);
        _context.SaveChanges();
        return Ok();
    }
}