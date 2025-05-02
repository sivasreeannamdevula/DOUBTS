// using System.Linq;
// class Li2
// {
//     public static void Main()
//     {
//         List<Employee> l=new List<Employee>();
//         Employee emp1=new Employee()
//         {
//             id=101,
//             name="eknadh",
//             age=31
//         };
//         Employee emp2=new Employee()
//         {
//             id=102,
//             name="dhoni",
//             age=45
//         };
//         Employee emp3=new Employee()
//         {
//             id=103,
//             name="trisha",
//             age=43
//         };
//         Employee emp4=new Employee()
//         {
//             id=104,
//             name="charmi",
//             age=41
//         };
//         l.Add(emp1);
//         l.Add(emp2);
//         l.Add(emp3);
//         l.Add(emp4); 
           
//         l=l.OrderBy(x=>x.age).ToList();
//         foreach(Employee e in l)
//         {
//            System.Console.WriteLine(e.id + " " + e.name + " " + e.age);
//         }
//     }
// }



// public class Employee{
//     public int id;
//     public string name;
//     public int age;
// }