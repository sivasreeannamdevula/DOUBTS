//1.virtual-abstract COMBO
//NO-both virtual and abstract are saying to implement in the child class so as both meaning is same 
//we cant use them together.
// abstract class Parent{

//     public virtual abstract void M();
    
//  }
//  class Child:Parent{
//     public override void M()
//     {
//          System.Console.WriteLine("child class m");
//     }
//  }


//2.virtual-override COMBO
//NO-virtual means implement and override also means to implement so both cannot be used together
// class Parent{

//     public virtual  void M()
//     {
//         System.Console.WriteLine("parent method");
//     }
    
//  }
//  class Child:Parent{
//     public virtual override  void M()
//     {
//          System.Console.WriteLine("child class m");
//     }
//        Child c= new Child();
//    }
// class C:Child
// {
//     public override void M()
//     {
//         System.Console.WriteLine();
//     }
//    public static void Main()
//    {
//      Child d=new Child();
//     d.M();
//    }
// }

//3.virtual-sealed COMBO
//already in sealed.cs

//4.virtual-new COMBO
// class Parent{
//     public virtual  void M()
//     {
//         System.Console.WriteLine("Parent m");
//     }
// }
// class Child:Parent{
//      public virtual new void M()                      //OR public virtual void M()
//     {                                                   // {
//         System.Console.WriteLine("Child m");             //System.Console.WriteLine("child m");
//     }                                                   // }
    
// }
// class SubClass:Child{
//     public override void M()
//     {
//         System.Console.WriteLine("subclass m");
//     }
//     public static void Main()
//     {
//         Parent p=new Child();
//         p.M();
//     }
// }

//5.virtual-static COMBO
//static cant be virtual bcus static is class type whereas virtual is intance type
// class Parent{
//      public virtual void S()
//      {
//         System.Console.WriteLine("method parent s");
//      }
// }
// class Child:Parent{
//       public virtual override static void S()
//       {
//         System.Console.WriteLine("child s");
//       }
// }

//6.virtual-partial
//yes possible partial is nrml class itself finally
// class Parent{
//      public virtual void M()
//      {

//      }
// }
// partial class Child:Parent{
//      public virtual partial void M();
//      public virtual partial void M()
//      {

//      }
// }