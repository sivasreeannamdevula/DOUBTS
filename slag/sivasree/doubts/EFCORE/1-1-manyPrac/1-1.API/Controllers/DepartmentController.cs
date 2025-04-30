using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]

public class DepartmentController:ControllerBase
{
    private readonly IDepartment _department;
    private readonly IEmployee _employee;

    public DepartmentController(IDepartment department,IEmployee employee)
    {
      _department=department;
      _employee=employee;
    }
    [HttpPost]
    public IActionResult AddEmployee(EmployeeDTO employeeDTO)
    {
        _employee.AddEmployee(employeeDTO);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddDepartment(DepartmentDTO departmentDTO)
    {
        _department.AddDepartment(departmentDTO);
        return Ok();
    }
    [HttpGet]
    public IActionResult Display()
    {
        return Ok(_employee.Display1Many());
    }
}