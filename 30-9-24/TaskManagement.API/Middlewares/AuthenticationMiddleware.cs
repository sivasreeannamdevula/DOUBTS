using System;

namespace TaskManagement.API.Middlewares;

public class AuthenticationMiddleware
{
     private RequestDelegate _next;
    private IConfiguration _configuration;
    public AuthenticationMiddleware(RequestDelegate next,IConfiguration configuration) 
    {
        _configuration=configuration;
        _next=next;
    }
    public async Task Invoke(HttpContext context)
    {
  
        if(context.Request.Path.StartsWithSegments("/api/User/UserLogin"))
        {
          await _next(context);
          return;
        }
        if(_configuration["customKeyForUser"]=="")
        {
            context.Response.WriteAsync("USER DIDN'T LOGIN");
            return;
        
        }
        else{
            
         await _next(context);
        }
       
}
}