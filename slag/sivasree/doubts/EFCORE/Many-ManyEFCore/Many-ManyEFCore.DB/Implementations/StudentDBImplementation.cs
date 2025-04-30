using Database.ContextClass;
using Database.CourseEntity;
using Database.StudentEntity;

public class StudentDBImplementation
{
    private readonly ContextClass _context;
    public StudentDBImplementation(ContextClass context)
    {
        _context=context;
    }
    
      public void AddStudentDB(StudentEntity studentEntity,int courseID)
    {
        //if we donot perform like this then we cannot maintain junction table logic so this is important.
        //we have to maintain this logic either while inserting Student or course at any one place its enough
       
       //first create an empty listof courses
        studentEntity.listOfCourses=new List<CourseEntity>();
        //fetch the row in course table with the courseid given by user
        var row =_context.CourseTable.FirstOrDefault(U=>U.Id==courseID);
        //append that row in the listof courses
        studentEntity.listOfCourses.Add(row);
        _context.StudentTb.Add(studentEntity);
        _context.SaveChanges();
    }
}