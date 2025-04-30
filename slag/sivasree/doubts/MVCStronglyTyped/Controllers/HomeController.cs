using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCStronglyTyped.Models;

namespace MVCStronglyTyped.Controllers;

public class HomeController : Controller
{
    public IActionResult Get()
    {
        EmployeeImplementation employeeImplementationobj=new EmployeeImplementation();
        Employee resultedobject=employeeImplementationobj.GetEmployeeById(200);
        ViewBag.Header="hey header";           //In strongly typed other than object prop to use we have to go for
                                               //either ViewData or ViewBag.
       return View(resultedobject);
    }
}
