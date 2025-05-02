using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
public class IndexController:Controller
{

    public IActionResult IndexMethod1()
    {
        return View();
    }

   

    public IActionResult IndexMethod2()
    {
        return View();
    }
}