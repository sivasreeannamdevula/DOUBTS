using Microsoft.AspNetCore.Mvc;
using Services.IAddress;
using Services.ICustomer;

[ApiController]
[Route("[Controller]/[Action]")]
public class CustomerDetailsController:ControllerBase
{
    private readonly ICustomer _customerimplementation;
    private readonly IAddress _addressimplementation;
    
    public CustomerDetailsController(ICustomer customerimplementation,IAddress addressimplementation)
    {
        _customerimplementation=customerimplementation;
        _addressimplementation=addressimplementation;
    }
    [HttpPost]
    public IActionResult AddCustomer([FromBody]CustomerDTO customerdto)
    {
       _customerimplementation.AddCustomer(customerdto);
       return Ok();
    }

    [HttpPost]
    public IActionResult AddAddress(AddressDTO addressdto)
    {
      _addressimplementation.AddAddress(addressdto);
      return Ok();
    }

    [HttpGet]
    public IActionResult DisplayAddress()
    {
        return Ok(_addressimplementation.DisplayAddress());
    }

    // [HttpGet]
    // public IActionResult DisplayCustomers()
    // {
    //     return Ok(_customerimplementation.DisplayCutomers());
    // }
}