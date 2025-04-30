using Microsoft.EntityFrameworkCore;
using DataBase.ContextClass;
using DataBase.Implementation;
using Services.ICustomer;
using Services.IAddress;
using AutoMapper;
using Services.Mapping;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Mapping));



builder.Services.AddScoped<AddressDBImplementation>();
builder.Services.AddScoped<CustomerDBImplementation>();
builder.Services.AddScoped<ICustomer,CustomerImplementation>();
builder.Services.AddScoped<IAddress,AddressImplementation>();
builder.Services.AddScoped<IDepartment,DepartmentImplementation>();
builder.Services.AddScoped<IEmployee,EmployeeImplementation>();
builder.Services.AddScoped<DepartmentDBImplementation>();
builder.Services.AddScoped<EmployeeDBImplementation>();
builder.Services.AddDbContext<ContextClass>(options=>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}
);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
