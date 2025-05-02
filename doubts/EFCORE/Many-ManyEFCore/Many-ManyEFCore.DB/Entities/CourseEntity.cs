namespace Database.CourseEntity;
using Database.StudentEntity; 

public class CourseEntity
{
    public int Id{get;set;}
    public string CourseName{get;set;}
    public List<StudentEntity> listOfStudents{get;set;}
}