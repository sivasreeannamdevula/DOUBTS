
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AddressEntity
{
   // [Key]
    public int Id{get;set;}
    public string StreetName{get;set;}
    public string City{get;set;}
    public CustomerEntity Customer{get;set;}

    //[ForeignKey("Customer")]  --for fluent api we can vomit this line...and add modelbuilder method in context class.
     public int CustomerID{get;set;}
}