using AutoMapper;

public class EmployeeImplementation:IEmployee
{
     private readonly IMapper _mapper;
    private readonly EmployeeDBImplementation _employeeDBImplementation;
    public EmployeeImplementation(IMapper mapper,EmployeeDBImplementation employeeDBImplementation)
    {
        _mapper=mapper;
        _employeeDBImplementation=employeeDBImplementation;
    } 
    public void AddEmployee(EmployeeDTO employeeDTO)
    {
       EmployeeEntity employeeEntity=_mapper.Map<EmployeeDTO,EmployeeEntity>(employeeDTO);
       _employeeDBImplementation.CreateEmployee(employeeEntity);
    }
  

    public List<EmployeeDTO> Display1Many()
    {
        List<EmployeeEntity> listOfEmployeeEntities=_employeeDBImplementation.Display1Many();
        List<EmployeeDTO> listOfEmployeeDTO=_mapper.Map<List<EmployeeDTO>>(listOfEmployeeEntities);
        return listOfEmployeeDTO;
    }
}