public class EmployeeImplementation
{
    public Employee GetEmployeeById(int id)
    {
        Employee employee=new Employee();
        employee.ID=id;
        employee.Name="Sivasree";
        employee.type="Traineee";
        employee.salary=20000;
        return employee;
    }
}