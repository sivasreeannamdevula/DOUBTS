namespace Database.StudentEntity;

using System.ComponentModel.DataAnnotations;
using Database.CourseEntity;
public class StudentEntity
{
    [Key]
    public int StdId{get;set;}
    public string StudentName{get;set;}
    public List<CourseEntity> listOfCourses{get;set;}
}