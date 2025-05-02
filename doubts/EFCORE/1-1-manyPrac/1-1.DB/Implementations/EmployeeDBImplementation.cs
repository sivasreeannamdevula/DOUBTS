using DataBase.ContextClass;
using Microsoft.EntityFrameworkCore;

public class EmployeeDBImplementation
{
    private readonly ContextClass _context;
    public EmployeeDBImplementation(ContextClass context)
    {
        _context=context;
    }

    public void CreateEmployee(EmployeeEntity employeeEntity)
    {
       _context.EmployeeTable.Add(employeeEntity);
       _context.SaveChanges();
    }

     public List<EmployeeEntity> Display1Many()
    {
        return _context.EmployeeTable.Include(u=>u.Department).ToList();
    }
}