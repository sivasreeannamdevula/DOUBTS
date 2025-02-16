public class CustomerEntity
{
    [key]
     public int Id{get;set;}
     public string CustomerName{get;set;}
     public AddressEntity Address{get;set;}
     
}