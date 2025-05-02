
using Microsoft.EntityFrameworkCore;

public class FamilyContext:DbContext
{
    public FamilyContext(DbContextOptions<FamilyContext> options):base(options)
    {

    }
   public DbSet<Family> currentFamilyDB{get;set;}
}