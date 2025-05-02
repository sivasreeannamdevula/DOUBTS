using DataBase.Entity;
using Microsoft.EntityFrameworkCore;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
    {

    }
    public DbSet<StudentEntity> StudentTable { get; set; }
    public DbSet<LaptopEntity> LaptopTable { get; set; }
}