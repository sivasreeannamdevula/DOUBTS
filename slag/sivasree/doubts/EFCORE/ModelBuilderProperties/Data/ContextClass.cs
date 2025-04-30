using Microsoft.EntityFrameworkCore;

public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<EmployeeEntity>().HasKey(u=>u.Id);
       //though the entity name changed it still maps to the original entity...here i changed employeeentity to employee but still
       //EmpTablechanged pointed to the same table
      //modelBuilder.Entity<EmployeeEntity>().ToTable("CurrentTableNameChanged","newtable");  //newone is the schema name(dbo.EmpTable changes to
                                                                            //newone.EmpTable)

     //while creating the database itself to add data we use hasdata 
    //   modelBuilder.Entity<EmployeeEntity>().HasData(new EmployeeEntity{
    //     Id=1,
    //     EmpName="sivasree",
    //      Designation="Trainee"
    //   });
    modelBuilder.Entity<EmployeeEntity>().ToTable("EmpTable", "newone");

    //in ssms we can change the column name
    modelBuilder.Entity<EmployeeEntity>().Property(s=>s.EmpName).HasColumnName("EmployeeName");
    //tells that particular filed is required while entering data into db
    modelBuilder.Entity<EmployeeEntity>().Property(s=>s.Id).IsRequired();
    //empname can have a length of 20
    modelBuilder.Entity<EmployeeEntity>().Property(s=>s.EmpName).HasMaxLength(20);
    //we can change the datatype of a column
    modelBuilder.Entity<EmployeeEntity>().Property(s=>s.EmpName).HasColumnType("nvarchar(60)");
    
       
    }

    public DbSet<EmployeeEntity> EmpTable{get;set;}
}