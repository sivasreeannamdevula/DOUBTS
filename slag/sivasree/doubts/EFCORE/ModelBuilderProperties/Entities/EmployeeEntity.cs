using System.ComponentModel.DataAnnotations.Schema;

//we can also chaange the tablename and schema name as below
//[Table("CurrentTable",Schema="newtable")]
public class EmployeeEntity
{
    public int Id{get;set;}
    public string EmpName{get;set;}
    public string Designation{get;set;}
}