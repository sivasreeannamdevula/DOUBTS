using System.Collections;
// class Li1
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
//         Employee s=new Employee();
//         l.Sort(s);
//         foreach(Employee e in l)
//         {
//            System.Console.WriteLine(e.id + " " + e.name + " " + e.age);
//         }
//     }
// }

// // public class SortByAge:IComparer<Employee>
// // {
// //     public int Compare(Employee e1,Employee e2)
// //     {
// //         return e1.age.CompareTo(e2.age);
// //     }
// // }
public class Employee:IComparer{
    public int id;
    public string? name;
    public int age;
     public int Compare(object e1,object e2)
    {
        if((e1 is Employee p1) && (e2 is Employee p2))
        {
             
            return p1.id.CompareTo(p2.id);
        }
        return 0;
    }
}
class Li1
{
    public static void Main()
    {
       ArrayList l=new ArrayList();
        Employee emp1=new Employee()
        {
            id=101,
            name="eknadh",
            age=31
        };
        Employee emp2=new Employee()
        {
            id=102,
            name="dhoni",
            age=45
        };
        Employee emp3=new Employee()
        {
            id=103,
            name="trisha",
            age=43
        };
        Employee emp4=new Employee()
        {
            id=104,
            name="charmi",
            age=41
        };
        l.Add(emp1);
        l.Add(emp2);
        l.Add(emp3);
        l.Add(emp4);
        Employee e=new Employee();

        l.Sort(e);
        
    }
}

