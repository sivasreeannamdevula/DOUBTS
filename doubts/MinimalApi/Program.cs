using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app=builder.Build();
if(builder.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.MapGet("PalTech/Employee",()=>
{
    
    return "Emplyee name is sivasree";
});


app.MapPost("Paltech/Employee",()=>
{
    System.Console.WriteLine("posted");
});

app.MapPut("Paltech/Employee/Put",(int id)=>
{
   return id;
});

app.MapDelete("Paltech/Employee/Delete",()=>
{
    System.Console.WriteLine("Deleted");
});
app.Run();
