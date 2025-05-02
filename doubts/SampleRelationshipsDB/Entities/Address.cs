using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Address
{
    [Key]
    public int AddressID{get;set;}
    public int DoorNo{get;set;}
    public string Landmark{get;set;}
    public string City { get; set; }
    public string State{get;set;}
    public int PostalCode { get; set; }
    public int EmployeeID{get;set;}
    [JsonIgnore]
    public Employee Employee{get;set;}
  
}