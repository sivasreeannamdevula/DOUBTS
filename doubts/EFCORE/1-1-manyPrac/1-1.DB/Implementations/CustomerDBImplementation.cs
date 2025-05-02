namespace DataBase.Implementation;
using DataBase.ContextClass;
using Microsoft.EntityFrameworkCore;

public class CustomerDBImplementation
{
    private readonly ContextClass _context;

    public CustomerDBImplementation(ContextClass context)
    {
        _context=context;
    }
    public void AddCustomerToDB(CustomerEntity customerentity)
    {
       _context.CustomerTable.Add(customerentity);
       _context.SaveChanges();
    }

    // public List<CustomerEntity> DisplayCustomers()
    // {
    //     // return _context.CustomerTable.Include(s=>s.Address).ToList();
        
    // }
}