using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Filters;


//1.using ActionFilterAtrribute
public class CustomActionFilter:ActionFilterAttribute
{
    public string Str{get;set;}
    public CustomActionFilter(string str)
    {
       Str=str;
    }
    //OnActionExecuted gets invoked aftr controller and after method based on where we have used that attribute
    public override void OnActionExecuted(ActionExecutedContext context)         //context stores the data that we get from route
    {
        System.Console.WriteLine("after run " + Str);
    }

    //OnActionExecuting gets invoked bfr controller and bfr method based on where we have used that attribute
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        System.Console.WriteLine("bfr run "+ Str);
    }
}


