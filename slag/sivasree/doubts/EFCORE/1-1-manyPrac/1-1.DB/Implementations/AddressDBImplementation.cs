namespace DataBase.Implementation;
using DataBase.ContextClass;
using Microsoft.EntityFrameworkCore;

public class AddressDBImplementation
{
    private readonly ContextClass _context;

    public AddressDBImplementation(ContextClass context)
    {
        _context=context;
    }
    public void AddAddressToDB(AddressEntity addressentity)
    {
       _context.AddressTable.Add(addressentity);
       _context.SaveChanges();
    }

   //INCLUDE METHOD----both tables combined data ni retrieve chesthadhi.
    public List<AddressEntity> Display()
    {
        return _context.AddressTable.Include(s=>s.Customer).ToList();
    }


   
}