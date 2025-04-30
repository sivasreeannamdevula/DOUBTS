using AutoMapper;
using EFServices.StudentImplementation;
using Microsoft.EntityFrameworkCore;
using Services.StudentImplementation;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapping));

//make studentimplementation as scoped bcus within the studentimplementation we are using crud which is scoped so make this as scoped
builder.Services.AddScoped<IStudent,StudentImplementation>();
//as we are using context in crud we must make crud as scoped.
builder.Services.AddScoped<CRUD>();
builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
