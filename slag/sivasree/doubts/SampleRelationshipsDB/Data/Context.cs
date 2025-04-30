using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class Context:DbContext
{
    public Context():base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(@"Server=PTU1DELL0102\SQLEXPRESS;Database=SQLPRAC;User Id=sa;Password=Welcome@1234;Encrypt=False;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
        .HasOne(a => a.Employee) 
        .WithOne(e => e.Address) 
        .HasForeignKey<Address>(a => a.EmployeeID)
        .OnDelete(DeleteBehavior.Cascade); 
       
        modelBuilder.Entity<Employee>()
           .HasOne(p=>p.Role)
           .WithMany(s=>s.Employees)
           .HasForeignKey(p=>p.RoleID)
           .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Project>()
            .HasMany(s=>s.Employees)
            .WithMany(p=>p.Project)
            .UsingEntity(j=>j.ToTable("ProjectEmployeeJunction"));
    }
    public DbSet<Employee> Employee{get;set;}
    public DbSet<Address> Address{get;set;}
    public DbSet<Role> Role{get;set;}
    public DbSet<Project> Project{get;set;}
}