using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CustomerEntity
{
    //[Key]
     public int CustomerID{get;set;}
     public string NameOfCustomer{get;set;}
     [JsonIgnore] //must be included for each related entity
     public AddressEntity Address{get;set;}
     
     
}