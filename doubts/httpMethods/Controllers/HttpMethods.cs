using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
[ApiController]
[Route("[Controller]/")]

public class HttpController:ControllerBase{
 
    public BookImplementation bookImpleObj;
     public HttpController(BookImplementation obj)
     {
        bookImpleObj=obj;
     }
    // [HttpHead("ResoruceExsits/{id}")]
    // public IActionResult HeadMethod(int id)
    // {
    //     //generally here we retrieve the resource from the list collection in the case of library management system.
    //     //i have done this approach in librarymanagmentsystem have a look
    //     bool resourceexists=true;
    //    if(resourceexists)
    //    {
    //     return Ok("succes");
    //    } 
    //    return NotFound("not exists");
    // }

    // [HttpHead("LastModified/{id}")]
    // public IActionResult LastModified(int id)
    // {
    //     //here generally we retrieve the resource headers from the database
    //     //creating anonymous object to store metadata
    //     var r=new{
    //         LastModified=DateTime.Now,
    //         CustomHeader="siva"
    //     };
    //     //using below code we can add respose headers to the resource
    //    Response.Headers.Add("LastModified",r.LastModified.ToString());
    //    Response.Headers.Add("customheader",r.CustomHeader);
    //    return Ok();
    // }


    // [HttpOptions]
    // public void Options()
    // {
    //     Response.Headers.Add("Allow","Get,PUT");
    // } 
    
 

   [HttpPost]
   public void Get(int id,string name,string author)
   {
     Book newBook= new Book(id,name,author);
     bookImpleObj.Add(newBook);
   }

   [HttpGet]
    public List<Book> Get()
    {
      return  bookImpleObj.Display();
    }
    [HttpPatch("{ID:int}")]
     public IActionResult PatchMethod(int ID,[FromBody]JsonPatchDocument<Book> book)
    {
        Book foundBook=bookImpleObj.getByID(ID);
        if(foundBook==null)
        {
            return NotFound();
        }
        //MODELSTATE TAKES CARE OF ERRORS
        book.ApplyTo(foundBook,ModelState);  //applyto method can be applied on jsonpatchdocument
        if(!TryValidateModel(foundBook))     //if errors are present send badrequest
        {
            return BadRequest();
        }
        return Ok(); 
    }

   
}