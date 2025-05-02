namespace Services.IAddress;


public interface IAddress
{
    public List<AddressEntity> DisplayAddress();
    public void AddAddress(AddressDTO addressdto);
}