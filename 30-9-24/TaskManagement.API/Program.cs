using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TaskManagement.API.Configurations;
using TaskManagement.API.Middlewares;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 

builder.Services.InjectingServices();

// builder.Services.AddSwaggerGen(
//     options =>
//     {
//         options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//         {
//             In = ParameterLocation.Header,
//             Name = "Authorization",
//             Type = SecuritySchemeType.ApiKey,
//             Scheme = "Bearer"
//         });
//         //options.OperationFilter<SecurityRequirementsOperationFilter>();
// });

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
                new string[]{}
            }
        });
});
//to inject all the services written in configuration folder.
builder.Services.AddAuthentication
(
    Options => 
    {
        Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = builder.Configuration["Jwt:Issuer"],
         ValidAudience = builder.Configuration["Jwt:Audience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
     };
 });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
//app.UseMiddleware<AuthenticationMiddleware>();
app.MapControllers();



app.Run();



//DB reference shouldn't be added to API.
//Entities shouldn't be exposed to any other layer except DB.