
using Microsoft.EntityFrameworkCore;
public class DbContexts:DbContext
{

    public DbContexts(DbContextOptions<DbContexts> options) : base(options)
    {
    }
    public DbSet<Users> Users{get;set;}
}