
// // Parent p=new Parent();    calls parent specific methods irrespective of any keyword as runtime object is parent
// // Child c=new Child();      calls child specific methods irrespective of any keyowrd as the runtime object is child
// // Parent p=new Child();     first goes to parent and checks the method...if it is overriden then calls child 
// //                             method else parent method itslef is called.
 class Parent
{
     public virtual int A()
    {
        System.Console.WriteLine("parents");
        return 0;
    }
    public static void Method()
    {
        System.Console.WriteLine("static method");
    }
    
}
class Child:Parent{
//    public override int A()
//    {
//     System.Console.WriteLine("child");
//     return 0;
//    }
//    public new int A()
//    {
//     System.Console.WriteLine("childs");
//     return 0;
//    }
}
class Pro{

    public static void Main(string[] args)
    {
        Parent p=new Parent();
        p.A();
        Child c=new Child();
        c.A();
        Parent pc=new Child();
        pc.A();
          
          

    }
}


// //MULTIPLE INHERITANCE ---- ERROR:Class 'Dro' cannot have multiple base classes: 'Bro' and 'Pro'
// class Pro{
//     public void Sum()
//     {
//         System.Console.WriteLine("sum of Pro class");
//     }
//     public void Diff()
//     {
//         System.Console.WriteLine("differenece func");
//     }
// }
// class Bro{
//    public void Sum()
//    {
//     System.Console.WriteLine("sum of bro class");
//    }
// }
// class Dro:Bro,Pro{ 
                       
// }


// //To call parameterised ctor of parent from child

// class Parent
// {
//     public Parent(int x)
//     {
//         System.Console.WriteLine("x of parent ctor {0}",x);
//     }
// }
// class Child:Parent{
//     public Child(int c,int y):base(y)
//     {
//         System.Console.WriteLine("child class ctor {0}",c);
      
//     }
// }
// class Pro{
//     public static void Main(string[] args)
//     {
//         Child c=new Child(0,11);
//         Child q=new Child(1,89);
//         Child e=new Child(2,78);
//     }
// }






// //CONCLUSION 
// class Parent1
// {
//    public  void M1()
//    {
//       System.Console.WriteLine("parent static");
//    }
// }
//  class Child1:Parent1{
// //     public  void M1()
// //    {
// //       System.Console.WriteLine("parent static");     //general ga we think that M1() method comes to child like this during inheritance but 
// //                                                      //   that's not true...still the methods are specific to class .that is parent class has only
// //                                                      //   one M1() method and child class has only one M1() method...if we again try to define other M1()
// //                                                      //   method in the same class i.e; Parent or child then we get error due to a class having methods with
// //                                                       //  same signature.
// //    }
//    public void M1()
//    {
//       System.Console.WriteLine("child sttaic");
//    }
//       public static void Main()
//    {
//       Parent c=new Child();
//       c.M1();
//    }
// }


// // CONCLUSION 4:
// // static methods cannot be overriden because they are class specific and not object specific,as method overriding is runtime object specific