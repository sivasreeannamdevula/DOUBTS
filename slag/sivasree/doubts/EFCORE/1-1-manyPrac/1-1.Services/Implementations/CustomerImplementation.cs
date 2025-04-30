using AutoMapper;
using DataBase.Implementation;
using Services.ICustomer;

public class CustomerImplementation : ICustomer
{
    private readonly IMapper _mapper;
    private readonly CustomerDBImplementation _custDbimplementation;
    public CustomerImplementation(IMapper mapper,CustomerDBImplementation custDbimplementation)
    {
        _mapper=mapper;
        _custDbimplementation=custDbimplementation;
    }
    public void AddCustomer(CustomerDTO customerdto)
    {
        CustomerEntity customerentity=_mapper.Map<CustomerEntity>(customerdto);
        _custDbimplementation.AddCustomerToDB(customerentity);
    }

    // public List<CustomerDTO> DisplayCutomers()
    // {

    // }
}