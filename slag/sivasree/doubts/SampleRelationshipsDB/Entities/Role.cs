using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public int RoleID{get;set;}
    public string Name { get; set; }
    public List<Employee> Employees{get;set;}

}