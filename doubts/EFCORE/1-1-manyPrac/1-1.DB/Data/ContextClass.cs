//the only difference between 1-1 and 1-many is that in 1-1 we cannot same value twice in foreign key field but in 
//1-many we can as many ppl exist.
using Microsoft.EntityFrameworkCore;

namespace DataBase.ContextClass;
public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> options):base(options)
    {

    }
   
    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //FLUENT API

        modelBuilder.Entity<CustomerEntity>().HasKey(U=>U.CustomerID);
        
        modelBuilder.Entity<CustomerEntity>().
            HasOne(u=>u.Address).
            WithOne(u=>u.Customer).
            HasForeignKey<AddressEntity>(u=>u.CustomerID);
        
        
        modelBuilder.Entity<DepartmentEntity>().HasKey(U=>U.DeptId);
        modelBuilder.Entity<DepartmentEntity>().
        HasMany(u=>u.ListOfEmployees).
        WithOne(u=>u.Department).
        HasForeignKey(u=>u.DeptId);    //for 1-many no need of <EntityName> && 1-many anna many-1 anna same ye...


        //modelBuilder.Entity<EmployeeEntity>().

    }

   

    public DbSet<CustomerEntity> CustomerTable{get;set;}
    public DbSet<AddressEntity> AddressTable{get;set;}

    public DbSet<EmployeeEntity> EmployeeTable{get;set;}
    public DbSet<DepartmentEntity> DepartmentTable{get;set;}
}