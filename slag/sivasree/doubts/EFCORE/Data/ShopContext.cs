using Microsoft.EntityFrameworkCore;
//import this namepsace for configuring appsettings.json file
using Microsoft.Extensions.Configuration;
public class ShopContext:DbContext
{
    public ShopContext():base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //connection string can be added here but not a good practice
        // optionsBuilder.UseSqlServer("Server=PTU1DELL0102\\SQLEXPRESS;Database=MultiplexTableDB;User Id=sa;Password=Welcome@1234;Encrypt=False;");
    
        var configurationBuilder=new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var configSection=configurationBuilder.GetSection("connectionstring");
        var data=configSection["SQLserverdetails1"];
        optionsBuilder.UseSqlServer(data);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    public DbSet<Zudio> ZudioTable{get;set;}
    public DbSet<MaxShowroom> MaxTable{get;set;}

}