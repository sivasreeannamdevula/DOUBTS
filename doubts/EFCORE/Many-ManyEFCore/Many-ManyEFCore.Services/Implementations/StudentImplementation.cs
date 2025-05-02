using AutoMapper;
using Database.StudentEntity;
public class StudentImplementation
{
    private readonly IMapper _mapper;
    private readonly StudentDBImplementation _studentDBImplementation;
    public StudentImplementation(IMapper mapper,StudentDBImplementation studentDBImplementation)
    {
        _mapper=mapper;
        _studentDBImplementation=studentDBImplementation;
    }
    public void AddStudent(StudentDTO StudentDTO)
    {
        StudentEntity studentEntity=_mapper.Map<StudentDTO,StudentEntity>(StudentDTO);
        _studentDBImplementation.AddStudentDB(studentEntity,StudentDTO.CourseId);
    }
}