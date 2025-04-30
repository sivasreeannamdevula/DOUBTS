using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTempData.Models;

namespace MVCTempData.Controllers;

public class HomeController : Controller
{
   public IActionResult Get()
   {
     TempData["key1"]="siva";
     TempData["key2"]="sree";
     return View();
   }
   public IActionResult Post()
   {
      string s1;
      string s2;
      
      if(TempData.ContainsKey("key1"))
      {
        s1=TempData["key1"].ToString();
        s2=TempData["key2"].ToString();
      }
      TempData.Keep();
      return View();
   }
     public IActionResult Post1()
   {
      string s1;
      string s2;
     //System.Console.WriteLine(TempData["key1"]);   //if we do not use tempdata.keep then we get null here.
      if(TempData.ContainsKey("key1"))
      {
        s1=TempData["key1"].ToString();
        s2=TempData["key2"].ToString();
      }
      return View();
   }
}


