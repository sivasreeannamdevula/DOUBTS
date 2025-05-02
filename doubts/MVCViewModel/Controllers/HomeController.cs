using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCViewModel.Models;

namespace MVCViewModel.Controllers;

public class HomeController : Controller
{
    public IActionResult Get()
    {
        Student s1=new Student()
            {
                StdID=100,
                Name="Sivasree",
                FavSubject="Physics"
            };
        StudentAddress s2=new StudentAddress()
        {
           StreetName="P&T COLONY",
           City="Rjahmundry",
           State="Andhra Pradesh"
        };
        
        HomeGetViewModel h=new HomeGetViewModel();
        h.StudentObj=s1;
        h.AddressObj=s2;
        h.RandomProp="randomness";
        return View(h);
    }
}
