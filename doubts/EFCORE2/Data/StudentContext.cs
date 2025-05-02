using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class StudentContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer("Server=PTU1DELL0102\\SQLEXPRESS;Database=StudeTable;User Id=sa;Password=Welcome@1234;Encrypt=False");
    }
    public DbSet<Student> Stud_Table{get;set;}
    
    
}