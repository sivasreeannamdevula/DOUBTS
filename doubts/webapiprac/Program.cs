var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//we can add global urls like this method1
// builder.WebHost.UseUrls("https://localhost:1234","http://localhost:2345");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();
app.MapGet("get",()=>
{
    System.Console.WriteLine("HEY");
});

app.MapPost("post",()=>
{
    System.Console.WriteLine("post i am");
});

app.MapDelete("delete",()=>
{
    return "sree";
});

app.MapPut("/put",()=>
{ 
    return "put";
});


//method2
// app.Urls.Add("http://localhost:4567");
app.MapControllers();

//method3
// app.Run("http://localhost:9000");

app.Run();
// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
