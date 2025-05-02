

using Microsoft.Extensions.Configuration;

public class Program
{
    static void Main(string[] args)
    {
        var context=new Context();
       

        //  Employee newEmployee2=new Employee()
        // {
        //    FirstName="Chaitanya",
        //    LastName="Annamdevula",
        //    RoleID=4,
        //    BloodGroup="A-"
        // };
        //  Employee newEmployee3=new Employee()
        // {
        //    FirstName="Vncss",
        //    LastName="Annamdevula",
        //    RoleID=3,
        //    BloodGroup="AB+"
        // };
        //  Employee newEmployee4=new Employee()
        // {
        //    FirstName="Veerraju",
        //    LastName="Annamdevula",
        //    RoleID=2,
        //    BloodGroup="A+"
        // };
        //  Employee newEmployee5=new Employee()
        // {
        //    FirstName="Nagamani",
        //    LastName="Annamdevula",
        //    RoleID=1,
        //    BloodGroup="O+"
        // };
        //  Employee newEmployee6=new Employee()
        // {
        //    FirstName="Sakeena",
        //    LastName="Dodda",
        //    RoleID=6,
        //    BloodGroup="B+"
        // };
        // context.Employee.Add(newEmployee1);
        // context.Employee.Add(newEmployee2);
        // context.Employee.Add(newEmployee3);
        // context.Employee.Add(newEmployee4);
        // context.Employee.Add(newEmployee5);
        // context.Employee.Add(newEmployee6);
        // Address newAddress=new Address()
        // {
        //   DoorNo=7251,
        //   Landmark="P&T Colony",
        //   City="RJY",
        //   State="AP",
        //   PostalCode=54423,
        //   EmployeeID=13
        // };
        // context.Address.Add(newAddress);
        Project newproject2=new Project{
           Name="Anonymous",
           
        };
         Employee newObjectEmployee=new Employee()
        {
           FirstName="first",
           LastName="first",
           RoleID=5,
           BloodGroup="p+",
           Project=new List<Project>{newproject2}
        };
        // context.Employee.Remove(context.Employee.FirstOrDefault(u=>u.EmployeeID==13));
        context.Employee.Add(newObjectEmployee);
        context.SaveChanges();

    }
}
