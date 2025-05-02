using AutoMapper;
using Database.CourseEntity;
using Microsoft.EntityFrameworkCore.Metadata;

public class CourseImplementation
{
    private readonly IMapper _mapper;
    private readonly CourseDBImplementation _coursedbimplementation;
    public CourseImplementation(IMapper mapper,CourseDBImplementation coursedbimplementation)
    {
        _mapper=mapper;
        _coursedbimplementation=coursedbimplementation;
    }
    public void AddCourse(CourseDTO courseDTO)
    {
        CourseEntity courseEntity=_mapper.Map<CourseDTO,CourseEntity>(courseDTO);
        _coursedbimplementation.AddCourseDB(courseEntity);
    }
}