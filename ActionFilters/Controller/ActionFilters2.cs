using Microsoft.AspNetCore.Mvc.Filters;

//using interface(IActionFilter) and Attribute
public class ActionFilters2: Attribute, IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
       string name=context.RouteData.Values["UserName"].ToString();
       string pwd=context.RouteData.Values["Password"].ToString();

       if(pwd!="123")
       {
          throw new UnauthorizedAccessException();
       }
       
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        System.Console.WriteLine("succesful authorisation");
    }
}