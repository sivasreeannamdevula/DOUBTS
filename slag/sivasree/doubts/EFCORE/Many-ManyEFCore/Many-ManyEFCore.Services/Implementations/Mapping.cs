using AutoMapper;
using Database.CourseEntity;
using Database.StudentEntity;

public class Mapping:Profile{
    
    public Mapping()
    {
        CreateMap<CourseDTO,CourseEntity>().ReverseMap();
        CreateMap<StudentDTO,StudentEntity>().ReverseMap();
    }
}