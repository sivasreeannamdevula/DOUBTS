public class Program
{
    static void Main(string[] args)
    {
        //main thread creates 3 child threads t1,t2 and t3
        Thread t1=new Thread(Method1);
        t1.Start();
        Thread t2=new Thread(Method2);
        t2.Start();
        Thread t3=new Thread(Method3);
        t3.Start();
        t1.Join();                 //BLOCK main thread until t1 completes its execution
        if(t2.Join(3000))         //Now, Main Thread will block for 3 seconds and wait for thread2 to complete its execution
        {
            System.Console.WriteLine("execution of t2 completed");
        }
        else
        {
            System.Console.WriteLine("not complted t2 execution");
        }


        if(t3.Join(TimeSpan.FromSeconds(1)))
        {
           System.Console.WriteLine("t3 execution complted");
        }
        else
        {
           System.Console.WriteLine("not completed t3 execution");
        }
        System.Console.WriteLine("MAIN END");

    }

    public static void Method1()
    {
        System.Console.WriteLine("Method 1 executing");
    }
     public static void Method2()
    {
        System.Console.WriteLine("Method 2 executing");
        Thread.Sleep(5000);
    }
     public static void Method3()
    {
        System.Console.WriteLine("Method 3 executing");
    }
}

//isalive tells whether the thread terminated or not.true=started/running false=terminated

// namespace ThreadingDemo
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Main Thread Started");

//             Thread thread1 = new Thread(Method1);
//             thread1.Start();

//             if (thread1.IsAlive)
//             {
//                 Console.WriteLine("Thread1 Method1 is still Executing");
//             }
//             else
//             {
//                 Console.WriteLine("Thread1 Method1 Completed its work");
//             }
//             //Wait Till thread1 to complete its execution
//             thread1.Join();
//             if (thread1.IsAlive)
//             {
//                 Console.WriteLine("Thread1 Method1 is still Executing");
//             }
//             else
//             {
//                 Console.WriteLine("Thread1 Method1 Completed its work");
//             }

//             Console.WriteLine("Main Thread Ended");
//             Console.Read();
//         }

//         static void Method1()
//         {
//             Console.WriteLine("Method1 - Thread1 Started");
//             //Making thread to sleep for 2 seconds
//             Thread.Sleep(TimeSpan.FromSeconds(2));
//             Console.WriteLine("Method1 - Thread 1 Ended");
//         }
//     }
// }