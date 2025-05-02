using AutoMapper;
using DataBase.Entity;
using EFServices.DTO;
namespace Services.StudentImplementation;
public class StudentImplementation : IStudent
{
    private readonly IMapper _mapper;
    private readonly CRUD _crud;
    public StudentImplementation(IMapper mapper,CRUD crud)
    {
        _mapper=mapper;
        _crud=crud;
    }
    public void AddStudent(StudentDTO student)
    {
        StudentEntity studententity=_mapper.Map<StudentDTO,StudentEntity>(student);
        _crud.Create(studententity);
    }

    public void AddLaptop(LaptopDTO laptopdto)
    {
        LaptopEntity laptopentity=_mapper.Map<LaptopDTO,LaptopEntity>(laptopdto);
        _crud.CreateLappy(laptopentity);
    }
    public void GetStudentDetails()
    {
        
    }

    public void RemoveStudent(int id)
    {
        
    }

    public void UpdateStudent(int id, StudentDTO studentdto)
    {
        
    }

   
}