public class DepartmentEntity
{
    public int DeptId{get;set;}
    public string DeptName{get;set;}

    public List<EmployeeEntity> ListOfEmployees{get;set;}
}