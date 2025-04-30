using Database.ContextClass;
using Database.CourseEntity;

public class CourseDBImplementation
{
    private readonly ContextClass _context;
    public CourseDBImplementation(ContextClass context)
    {
        _context=context;
    }

    public void AddCourseDB(CourseEntity courseEntity)
    {
        _context.CourseTable.Add(courseEntity);
        _context.SaveChanges();
    }
}