using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCViewData.Models;

namespace MVCViewData.Controllers;

public class HomeController : Controller
{

  [HttpGet]
  public IActionResult Get(int id)
  {
    EmployeeImplementation employeeImplementationobj=new EmployeeImplementation();
    Employee resultedobject=employeeImplementationobj.GetEmployeeById(200);
    //In this way we can store the model data in dictionary using VIEWDATA
    ViewData["key1"]="value1";                 //no need of explicit conversion as string is object type
    ViewData["key2"]=resultedobject;       //we have to convert explicitly to employee type in views
    



    //VIEWBAG
    ViewBag.Header="Header";
    ViewBag.Employee=resultedobject;
    return View();
  }    

  public IActionResult Post()
  {
    string str;
    //we cannot use the dictionary that created using ViewData/ViewBag in anonther actionmethods of same or 
    //different controller bcus after the request the data gets deallocated so we TempData 
    // if(ViewData.ContainsKey("key1"))
    // {
    //    str=ViewData["key1"].ToString();
    // }
    return View();
  }
    
}
