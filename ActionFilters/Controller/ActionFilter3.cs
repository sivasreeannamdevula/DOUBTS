

using Microsoft.AspNetCore.Mvc.Filters;

public class ActionFilter3 : Attribute, IActionFilter
{

    public void OnActionExecuting(ActionExecutingContext context)
    {
         //using headers in postman we are getting data here
    //    var name=context.HttpContext.Request.Headers["NAME"];
    //    var pwd=context.HttpContext.Request.Headers["PWD"];
    //    System.Console.WriteLine(name + " " + pwd);

       //using action parameters we are retrieveing data.
       var data=context.ActionArguments;                   //returns a dictionary of employee objects
       if(data.ContainsKey("e"))
       {
           var objAtE=(Employee)data["e"];                 //returns e object
           System.Console.WriteLine(objAtE.Name);
           System.Console.WriteLine(objAtE.age);
           System.Console.WriteLine(objAtE.Dept);
       }
      
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
         System.Console.WriteLine("Executed method");
    }
}