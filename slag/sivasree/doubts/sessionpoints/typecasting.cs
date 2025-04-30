// //TYPE-CASTING
// //1.Implicit typecasting
// public class Q
// {
//     public static void Main()
//     {
//         int a=90;
//         long b=a;
//         System.Console.WriteLine(b);
//     }
// }

// //2.Explicit typecasting
// public class Q
// {
//     public static void Main()
//     {
//         long b=78;
//         int a=(int)b;
//         System.Console.WriteLine(a);
//     }
// }


// //3.Using Helper classes
// public class Q
// {
//     public static void Main()
//     {
//         int a=Convert.ToInt32(Console.ReadLine());
//     }
// }

// 4.userdefined typecasting





// //Boxing: This is a type of casting that involves converting a value type to a reference type
// public class B{
//     public static void Main()
//     {
//         int i=9;
//         object o=i;
//     }
// }


// //Unboxing: This is a type of casting that involves converting a reference type to a value type. 
// public class b{
//     public static void Main()
//     {
//         object s=7;
//         int i=(int)s;
//     }
// }


// //upcasting-downcasting
// class Animal
// {

// }
// class Dog:Animal{
//    public static void Main()
//    {
//       Animal a=new Dog();   //upcasting--conversion from derived to base class

//       Animal p=new Dog();   //downcasting--parnet to child
//       Dog s=(Dog)p;        //downcasting as p holds dog object we can convert p to dog refernce

//       Animal si=new Animal();
//       Dog g=(Dog)si;       //we get runtime exception saying cannot cast bcus here si holding animal object 
//                            //and we are trying to convert into dog refernce
//    }

// }


// //as
// using System.Runtime.Serialization;

// public class S{
//    public static void Main()
//    {
//       object o="";
//       string str=(o as string) ?? "";
//       System.Console.WriteLine(str);
//    }
// }

// //is--tells what exactly is stored in object type or var type etc...
// public class S{
//    public static void Main()
//    {
//       int o=3;
//       object ob="hello";
//       var num=90;
//       System.Console.WriteLine(o is int);
//       System.Console.WriteLine(ob is string);
//       System.Console.WriteLine(num is string);
//    }
// }