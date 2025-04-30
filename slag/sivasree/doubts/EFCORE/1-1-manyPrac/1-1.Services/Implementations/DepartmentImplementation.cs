using AutoMapper;

public class DepartmentImplementation : IDepartment
{
    private readonly IMapper _mapper;
    private readonly DepartmentDBImplementation _departmentDBImplementation;
    public DepartmentImplementation(IMapper mapper,DepartmentDBImplementation departmentDBImplementation)
    {
        _mapper=mapper;
        _departmentDBImplementation=departmentDBImplementation;
    } 
    public void AddDepartment(DepartmentDTO departmentDTO)
    {
       DepartmentEntity departmentEntity=_mapper.Map<DepartmentDTO,DepartmentEntity>(departmentDTO);
       _departmentDBImplementation.CreateDepartment(departmentEntity);
    }
}