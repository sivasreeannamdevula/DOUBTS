using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TaskManagement.API.Filters;

public class CustomActionFilter : Attribute, IActionFilter
{

   private ITaskDBOperations _taskDBObject;

   public CustomActionFilter(ITaskDBOperations taskDBObject)
   {
      _taskDBObject=taskDBObject;
   }
    public void OnActionExecuted(ActionExecutedContext context)
    {
          _taskDBObject.SaveTaskToFile();

    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
      
        _taskDBObject.LoadTaskFromFile();
    }
}
