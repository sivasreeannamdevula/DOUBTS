using Microsoft.AspNetCore.Mvc;
using ServicesClassNamespace;
public class BaseController:ControllerBase
{
    public readonly ServicesClass _service;
    public BaseController(ServicesClass service)
    {
        _service=service;
    }
    [HttpGet]
    public IActionResult GetMethod()
    {
        return _service.GetMethod();
    }
}

