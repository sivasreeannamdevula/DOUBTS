using DataBase.Entity;

public class CRUD
{
   private readonly StudentContext _context;

    public CRUD(StudentContext context)
    {
        _context=context;
    }
    public void Create(StudentEntity studententity)
    {
       _context.StudentTable.Add(studententity);
       _context.SaveChanges();
    }
 
    public void CreateLappy(LaptopEntity laptopentity)
    {
        _context.LaptopTable.Add(laptopentity);
        _context.SaveChanges();
    }
    public void Update(int id,StudentEntity studententity)
    {
    //    StudentEntity found=_context.StudentTable.Where(x => x.StudentId==id).FirstOrDefault();
    //    found.Lappy=studententity.Lappy;
    //    _context.SaveChanges();

    }

    public void Remove(int id)
    {
        StudentEntity found=_context.StudentTable.Where(b => b.StudentId==id).FirstOrDefault();
        _context.StudentTable.Remove(found);
        _context.SaveChanges();
    }
}