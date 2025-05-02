//using single thread we are trying to run the methods --- here only after completion of method1 , method2 runs


//public class Program
//{
//    public static void Main()
//    {
//        Thread t=Thread.CurrentThread;
//        t.Name = "singleThreadMain";
//        Console.WriteLine(Thread.CurrentThread.Name);
//        Console.WriteLine(t.Name);
//        Method1();
//        Method2();
//    }

//    public static void Method1()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Console.WriteLine("Method1 " + i);
//        }
//    }
//    public static void Method2()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            Console.WriteLine("Method2 " + i);
//            if(i==0)
//            {
//                Thread.Sleep(10000);
//            }
//        }
//    }
//}



//using multi threading to run the method1,method2 conc urrently...u can see the irregular output
//main thread creates t1 and t2
//public class Program         
//{
//    public static void Main()
//    {
//        Thread t1 = new Thread(Method1)
//        {
//            Name="thread1"
//        };

//        Thread t2 = new Thread(Method2);
//        t2.Start();
//        t1.Start();
       
//    }

//    public static void Method1()
//    {
//        for(int i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Method1 "+i);
//        }
//    }

//    public static void Method2()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            Console.WriteLine("Method2 " + i);
//            if(i== 1)
//            {
//                Thread.Sleep(10000);
//            }
//        }
//    }
//}