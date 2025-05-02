var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//if we use IMiddleware interface to implement then we have to add the below line bcus default ctor has
//to be called.For that we add a dependency injection to call that ctor.
//but if we create custom middleware using the second method, as we are explicitly writing the ctor for 
//next so no need to add any dependency injection line.

//builder.Services.AddSingleton<ResponseTime>();
var app = builder.Build();

//string? name=builder.Configuration["Siva"];
//System.Console.WriteLine(name);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Use is a middleware.Uze is an extension method that takes context(an object that contains all
//the data about incoming request and outgng response) and next(it is a delegate that passes on to next 
// middleware in the pipeline)
app.Use(async(context,next) =>
{
    System.Console.WriteLine("Middleware1");
    await next();
    System.Console.WriteLine("2nd statement of middleware1");
});


app.Use(async (h, y) =>
{
    // context.Response.WriteAsync("middleware 2");
    // await next();
    // context.Response.WriteAsync("second statemenet of middleware 2");
    System.Console.WriteLine("Middleware2");
    await y(h);
    System.Console.WriteLine("2nd statement of middleware2");
});


//Run is also an extension method that doesn't call any next middleware.
app.Run(async (context) =>
{
    // context.Response.WriteAsync("RUN");
    System.Console.WriteLine("run");
});

app.MapControllers();
//app.UseMiddleware<ResponseTime>();
app.UseMiddleware<ResponseTime2>();
app.UseHttpsRedirection();
//this is not the middleware, it is just to start the application.
app.Run();
