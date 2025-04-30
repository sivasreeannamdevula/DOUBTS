// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
// Thread t1=Thread.CurrentThread;     //returntype of currentThread is thread.
// t1.Name="sree";                    //bt default thread has no name.we have to set it explicitly
// System.Console.WriteLine(t1.Name);
// System.Console.WriteLine(Thread.CurrentThread.Name);


// public class Program
// {
//     static void Main(string[] args)
//     {
//         System.Console.WriteLine("main started");
//         Method1();
//         Method2();
//         Method3();
//         System.Console.WriteLine("main ended");
//     }
//     public static void Method1()
//     {
//         for(int i=0;i<5;i++)
//         {
//             System.Console.WriteLine("Method1 "+ i);
//         }
//     }
//      public static void Method2()
//     {
//         for(int i=0;i<5;i++)
//         {
//             System.Console.WriteLine("Method2 "+ i);
//             if(i==3)
//             {
//                 System.Console.WriteLine("Method2 gng to sleeping state");
//                 Thread.Sleep(5000);                    //if singlethreaded, until this line executes doesn't go to next line.
//             }
//         }
//     }
//      public static void Method3()
//     {
//         for(int i=0;i<5;i++)
//         {
//             System.Console.WriteLine("Method3 "+ i);
//         }
//     }
// }




//This program is using multiple threads where execution continues though there are time taking tasks such as reading from
//file/db/sleeping
public class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("main started");
       Thread t1=new Thread(Method1);
       Thread t2=new Thread(Method2);
       Thread t3=new Thread(Method3);
       t1.Start();
       t2.Start();
       t3.Start();
        System.Console.WriteLine("main ended");
    }
    public static void Method1()
    {
        for(int i=0;i<5;i++)
        {
            System.Console.WriteLine("Method1 "+ i);
        }
    }
     public static void Method2()
    {
        for(int i=0;i<5;i++)
        {
            System.Console.WriteLine("Method2 "+ i);
            if(i==3)
            {
                System.Console.WriteLine("Method2 gng to sleeping state");
                Thread.Sleep(5000);                    //if singlethreaded, until this line executes doesn't go to next line.
            }
        }
    }
     public static void Method3()
    {
        for(int i=0;i<5;i++)
        {
            System.Console.WriteLine("Method3 "+ i);
        }
    }
}