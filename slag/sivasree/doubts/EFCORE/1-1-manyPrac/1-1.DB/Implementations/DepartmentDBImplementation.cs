using DataBase.ContextClass;

public class DepartmentDBImplementation
{
    private readonly ContextClass _context;

    public DepartmentDBImplementation(ContextClass context)
    {
        _context=context;
    }
    public void CreateDepartment(DepartmentEntity departmentEntity)
    {
       _context.DepartmentTable.Add(departmentEntity);
       _context.SaveChanges();
    }
}