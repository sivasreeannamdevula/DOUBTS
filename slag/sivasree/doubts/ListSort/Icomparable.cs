// using System.Collections.Generic;
// using System.Timers;
// class Li
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
//         l.Sort();
//         foreach(Employee e in l)
//         {
//            System.Console.WriteLine(e.id + " " + e.name + " " + e.age);
//         }
//     }
// }
// class Employee:IComparable<Employee>{
//     public int id;
//     public string name;
//     public int age;

//     public int CompareTo(Employee e)
//     {
//         if(this.age > e.age)
//         {
//             return 1;
//         }
//         else if(this.age <e.age)
//         {
//             return -1;
//         }
//         else
//         {
//             return 0;
//         }
//     }
// }

