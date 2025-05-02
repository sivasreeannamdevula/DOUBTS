using EFServices.DTO;
public interface IStudent
{
    public void GetStudentDetails();
    public void AddStudent(StudentDTO student);

   public void AddLaptop(LaptopDTO laptopdto);
    public void RemoveStudent(int id);

    public void UpdateStudent(int id,StudentDTO studentdto);
    
}