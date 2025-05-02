var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//in this way we can access appsettings.json file variables
// ConfigurationManager config=builder.Configuration;     //it returns configurationmanager instance
// //configurationmanager contains getvalue method to retrieve appsettings.json values
// //way 1:
// string str=builder.Configuration["Customkey"];
// //way 2:
// string str2=builder.Configuration.GetValue<string>("CustomKey","defualt");


// System.Console.WriteLine(str);
// System.Console.WriteLine(str2);
var app = builder.Build();
if(builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseHttpsRedirection();
app.Run();



//basically these two below are to print errors/warnings in th terminal
// "Default": "Information"    --->logs above information(error,warning,critical) level gets logged
//this below line is to print aspnetcore namespace related errors/warnings
//"Microsoft.AspNetCore": "Warning"---->only logs at critical,warning level get slogged by aspnet namespace.


//* means allows any other domain to access our api
//"AllowedHosts":"*"

//appsettings.Development.json , appsettings.Production.json appsettings.Stagimg.json are the parents of appsettings.json
//that is why child configurations are overriden by parent

//defualt order for same customkey at multiplemlevels
// appsettings.json       
// appsettings.{Environment}.json ------>for this we have to change the environment variable to development
                                        //or production in profiles section of launchsettings.json file
                                        //if we didn't mention appsettings.json will be used
// User Secrets
// Environment Variables                //we can add our custom keys in launchsettings which will override
                                        //appsettings.json and appsettings.{Environment}.json
// Command-line Arguments