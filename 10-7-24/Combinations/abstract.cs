//1.abstract-virtual
//see in virtual.cs file

// //2.abstract-override
// class Parent{
//     public virtual void M()
//     {
//        System.Console.WriteLine("virtual method");
//     }
// }
// abstract class Child:Parent{
//     public abstract override void M();
   
// }
//  class C:Child{
//     public override void M()
//     {
//         System.Console.WriteLine("overriden");
//     }
// }

// //3.abstract-new
class Parent{
    public virtual void M()
    {
       System.Console.WriteLine("virtual method");
    }
}
abstract class Child:Parent{
    public abstract new void M();
    public static void Main()
    {

    }
   
}

//4.abstract-sealed
//see in sealed.cs

//5.abstract-static
// //bcus static needs implemantation where as abstarct donot need...which is a contradiction
// class Parent{
//     public virtual void M()
//     {
//        System.Console.WriteLine("virtual method");
//     }
// }
// abstract class Child:Parent{
//     public abstract static void M();
   
// }

//6.abstract-partial
//abstarct method definition should be in child class,partial class within same class so contradiction
// class Parent{
//     public virtual void M()
//     {
//        System.Console.WriteLine("virtual method");
//     }
// }
// abstract partial class Child:Parent{
//     public abstract partial void M();
//     public partial void M()
//     {
//         System.Console.WriteLine("m method");
//     }

// }


