using AutoMapper;

namespace Services.Mapping;
public class Mapping:Profile
{
    public Mapping()
    {
        CreateMap<CustomerDTO,CustomerEntity>().ReverseMap();
        CreateMap<AddressDTO,AddressEntity>().ReverseMap();
        //for list no need to do like this list is internally taken care by CreateMap<CustomerDTO,CustomerEntity>();
         //CreateMap<List<AddressEntity>,List<AddressDTO>>();
        CreateMap<EmployeeDTO,EmployeeEntity>().ReverseMap();
        CreateMap<DepartmentDTO,DepartmentEntity>().ReverseMap();
    }
}