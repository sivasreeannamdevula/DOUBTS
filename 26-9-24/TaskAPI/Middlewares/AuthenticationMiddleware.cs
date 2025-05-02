

public class TaskMiddleware
{
    private RequestDelegate _next;
    public IConfiguration _configuration;
    public TaskMiddleware(RequestDelegate next,IConfiguration configuration) 
    {
        _configuration=configuration;
        _next=next;
    }
    public async Task Invoke(HttpContext context)
    {
  
        if(context.Request.Path.StartsWithSegments("/Task/UserLogin"))
        {
          await _next(context);
           
        }
        if(_configuration["customKeyForUser"]=="")
        {
            context.Response.WriteAsync("USER DIDN'T LOGIN");
            return;
        
        }
       
    
    }
  
}