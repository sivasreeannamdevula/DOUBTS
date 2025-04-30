// using System.Data.SqlTypes;
// using System.Runtime.CompilerServices;

//   interface Bank
// {
//        void CheckBal();
//        static int e;
//      void WithDraw();
//      void Validate();
   
//       public void Method1()
//     {
//         int x=10;
//           System.Console.WriteLine(x);
//         System.Console.WriteLine("interface method1");
//     }
//     static void M()
//     {
//         System.Console.WriteLine(e);
//         System.Console.WriteLine("static M");
//     }
// }
//  class SBI:Bank{
//     public  void CheckBal()
//     {
//         System.Console.WriteLine("SBI balance viewed successfully");
//     }
//     public void WithDraw()
//     {
//         System.Console.WriteLine("SBI withdrawn successfully");
//     }
//     public void Validate()
//     {
//         System.Console.WriteLine("SBI validated successfully");
//     }

// }

// class HDFC:Bank{
//     public  void CheckBal()
//     {
//         System.Console.WriteLine("HDFC balance viewed successfully");
//     }
//     public void WithDraw()
//     {
//         System.Console.WriteLine("HDFC withdrawn successfully");
//     }
//     public void Validate()
//     {
//         System.Console.WriteLine("HDFC validated successfully");
//     }
// }

// class Outer
// {
    
//      static Bank createObj(string name)
//     {
//         Bank b=null;
//         if(name=="SBI")
//         {
//             b=new SBI();
//         }
//         else{
//             b=new HDFC();
//         }
//         return b;
//     }
//     public static void Main(string[] args)
//     {
//         Bank refe=createObj("SBI");
//         //refe.CheckBal();
//         //refe.Method1();
//         //SBI s=new SBI();
//         //s.Method1();
//         Bank.M();
//     }
// }