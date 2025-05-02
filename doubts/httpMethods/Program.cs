var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<BookImplementation>();
builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//for global options 
// app.Use(async(Context,next)=>
// {
//     if(Context.Request.Method==HttpMethods.Options)
//     {
//         Context.Response.Headers.Add("Allow","get,post,put,OPTIONS");
//         return;
//     }
//     await next.Invoke();
// });
app.UseHttpsRedirection();
app.MapControllers();

app.Run();


