using Microsoft.AspNetCore.Mvc;

public class OutputController:Controller{
    public IActionResult Output(string username,string psd)
    {
        ViewData["username"]=username;
        ViewData["psd"]=psd;
        return View();
    }
}