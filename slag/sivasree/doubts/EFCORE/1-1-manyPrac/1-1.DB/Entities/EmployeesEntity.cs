public class EmployeeEntity
{
    public int Id{get;set;}
    public string EmpName{get;set;}

    public int DeptId{get;set;}
    public DepartmentEntity Department{get;set;}
}