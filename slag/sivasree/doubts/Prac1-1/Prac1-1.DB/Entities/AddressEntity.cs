
public class AddressEntity
{
    [key]
    public int Id{get;set;}
    public string StreetName{get;set;}
    public string City{get;set;}
    public CustomerEntity Customer{get;set;}
}