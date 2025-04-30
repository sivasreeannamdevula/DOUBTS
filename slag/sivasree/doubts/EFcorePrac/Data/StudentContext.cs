using Microsoft.EntityFrameworkCore;

public class StudentContext:DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options):base(options)
    {

    }
    public DbSet<Student> StudentTable{get;set;}
}