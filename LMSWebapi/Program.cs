//In Models we should maintain properties and actual code logic should be written in repository folder--this is just for 
//better readablity of code

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddSingleton<Library>();
builder.Services.AddControllers().AddNewtonsoftJson();
//We add the below line to retrieve xml format 
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();


