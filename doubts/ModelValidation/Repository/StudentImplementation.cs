public class StudentImplementation
{
    private List<Student> list=new List<Student>();

    public void AddStudent(Student newStudent)
    {
        list.Add(newStudent);
    }

    public List<Student> Display()
    {
        return list;
    }
}