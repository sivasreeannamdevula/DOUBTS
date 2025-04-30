public interface IStudent
{
    public void GetStudentDetails();
    public void AddStudent(StudentDTO student);

    public void RemoveStudent(int id);

    public void UpdateStudent(int id,StudentDTO studentdto);
    
}