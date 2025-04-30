//in many-many relationship no need of any foreign key....instead we maintain a junction table ..
//we can name that junction table manually in onmodelcreating
//in junction table we have composite key

using Microsoft.EntityFrameworkCore;


namespace Database.ContextClass;
using Database.CourseEntity;
using Database.StudentEntity;
public class ContextClass:DbContext
{
    public ContextClass(DbContextOptions<ContextClass> options):base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
          modelBuilder.Entity<StudentEntity>().HasKey(u=>u.StdId);

          modelBuilder.Entity<StudentEntity>().
          HasMany(U=>U.listOfCourses).
          WithMany(u=>u.listOfStudents).
          UsingEntity(junction=>junction.ToTable("JunctionTableName"));    //like this we can name juntion table
    }
    public DbSet<CourseEntity> CourseTable{get;set;}
    public DbSet<StudentEntity> StudentTb{get;set;}
}