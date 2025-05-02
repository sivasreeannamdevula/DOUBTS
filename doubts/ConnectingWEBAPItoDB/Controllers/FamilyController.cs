using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[Controller]/[Action]")]
public class FamilyController:ControllerBase
{
    private readonly FamilyContext _familyContextObject;
    
    public FamilyController(FamilyContext familyContextObject)
    {
        _familyContextObject=familyContextObject;
    }
    [HttpPost]
    public IActionResult AddFamily([FromBody]Family family)
    { 
       if(family==null)
       {
        return BadRequest();
       }
      _familyContextObject.currentFamilyDB.Add(family);
      _familyContextObject.SaveChanges();
      return Ok();
    }
   [HttpGet]
   public IActionResult getFamilyDetails()
   {
       return Ok( _familyContextObject.currentFamilyDB); 
   }

//    [HttpPut]
//    public IActionResult Update(int numberofppl)
//    {
//        _familyContextObject.currentFamilyDB.FirstOrDefault
//    }
}
