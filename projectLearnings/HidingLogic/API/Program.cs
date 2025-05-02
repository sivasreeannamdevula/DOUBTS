using Microsoft.EntityFrameworkCore;
using DB.DB;
using Services.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

builder.Services.AddScoped<ServicesClass>();
builder.Services.AddScoped<DB>();

builder.Services.AddDbContext<DbContexts>(options =>
        options.UseSqlServer(@"data source=PTU1DELL0102\SQLEXPRESS; initial catalog=ECommerce1; trustservercertificate=true; User id=sa; password=Welcome@1234;")
        );
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();




app.Run();


