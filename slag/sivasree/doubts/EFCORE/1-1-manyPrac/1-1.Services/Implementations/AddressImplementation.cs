using AutoMapper;
using DataBase.Implementation;
using Services.IAddress;

public class AddressImplementation : IAddress
{
     private readonly IMapper _mapper;
     private readonly AddressDBImplementation _addressDbimplementation;

    public AddressImplementation(IMapper mapper,AddressDBImplementation addressDbimplementation)
    {
        _mapper=mapper;
        _addressDbimplementation=addressDbimplementation;
    }
    public void AddAddress(AddressDTO addressdto)
    {
         AddressEntity addressentity=_mapper.Map<AddressDTO,AddressEntity>(addressdto);
        _addressDbimplementation.AddAddressToDB(addressentity);
        
    }

    public List<AddressEntity> DisplayAddress()
    {
        List<AddressEntity> addresses= _addressDbimplementation.Display();
        // List<AddressDTO> dtoconverted=_mapper.Map<List<AddressDTO>>(addresses);
        return addresses;
    }
}