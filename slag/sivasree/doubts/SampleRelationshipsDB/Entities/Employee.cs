using System.ComponentModel.DataAnnotations;

public class Employee
{
    [Key]
    public int EmployeeID{get;set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BloodGroup { get; set; }

    public Address Address{get;set;}
    public List<Project> Project{get;set;}
    public Role Role{get;set;}
    public int RoleID{get;set;}

}