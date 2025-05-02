


// public class ResponseTime : IMiddleware
// {
//     //CONTEXT==current request ,  RequestDlegate points to next delegate in the pipeline
//     public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//     {
//         DateTime start=DateTime.Now;

//         await next(context);
//         DateTime end=DateTime.Now;
//         System.Console.WriteLine("TIME11:" + (end-start).TotalMilliseconds);
        
//     }

// }

public class ResponseTime2
{
    private RequestDelegate _next;
    public ResponseTime2(RequestDelegate next)
    {
       _next=next;
    }
  
   
    public async Task Invoke(HttpContext context)
    {

        //we have to restrict the execution of middleware for a url.
        if(context.Request.Path.StartsWithSegments("/id"))
        {
            //System.Console.WriteLine("skipping");
            return ;
        }
        System.Console.WriteLine("request delegate");
        await _next(context);
    }

    //two methods untte error osthadhi....so oka method ye rayali either Invoke or Sree,not both

    // public async Task Sree(HttpContext context)
    // {
    //     System.Console.WriteLine("request delegate 2");
    //     await _next(context);
    // } 
   
}

