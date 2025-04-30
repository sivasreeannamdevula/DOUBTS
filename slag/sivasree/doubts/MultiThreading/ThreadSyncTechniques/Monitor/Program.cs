// //oka thread daggara lock unnappudu  othet thread cannot enter critical section until lock is released
// public class Program
// {
//     static object lockobj=new object();
//     static void Main(string[] args)
//     {
//        Thread[] array=new Thread[3];
//        for(int i=0;i<3;i++)
//        {
//          array[i]=new Thread(DisplayMethod3)
//          {
//             Name="Childthread"+i
//          };
//        }
//        foreach(Thread t in array)
//        {
//          t.Start();
//        }
//     }

//     // public static void DisplayMethod()
//     // {
//     //     System.Console.WriteLine("Entered DisplayMethod "+Thread.CurrentThread.Name);
//     //     try
//     //     {
//     //       Monitor.Enter(lockobj);
//     //       //critical section code after acquiring the lock
//     //       System.Console.WriteLine("entered critical section by "+Thread.CurrentThread.Name);
//     //       Thread.Sleep(2000);
//     //     }
//     //     finally
//     //     {
//     //        //Monitor.Exit(lockobj);
//     //        System.Console.WriteLine("exited from DisplayMethod  "+Thread.CurrentThread.Name);
           
//     //     }
//     // }

   

//    //overloaded method of Monitor class ENTER METHOD i.e; it takes 2 parameters 
//     // public static void DisplayMethod2()
//     // {
//     //        bool LockWasTaken=false;
//     //      try
//     //      {
//     //         System.Console.WriteLine("Entered into DisplayMethod2 "+Thread.CurrentThread.Name);
//     //         Monitor.Enter(lockobj,ref LockWasTaken);
//     //         if(LockWasTaken)
//     //         {
//     //             System.Console.WriteLine("Lock taken by "+Thread.CurrentThread.Name);
//     //         }
//     //      }
//     //      finally
//     //      {
//     //         if(LockWasTaken)
//     //         {
//     //             Monitor.Exit(lockobj);
//     //             System.Console.WriteLine("Exited lock by "+Thread.CurrentThread.Name);
//     //         }
//     //      }
//     // }


//     //TryEnter method 
//     public static void DisplayMethod3()
//     {
//         bool LockWasTaken=false;
//         try
//         {
//            System.Console.WriteLine("Entered into DiplayMethod3 "+Thread.CurrentThread.Name);
//            Monitor.TryEnter(lockobj,10,ref LockWasTaken);      //if within 10ms lock is not acquired then that thread doesn't enter
//                                                                //criticial section
//            if(LockWasTaken)
//            {
//              System.Console.WriteLine("Entered critical section "+Thread.CurrentThread.Name);
//              for(int i=0;i<4;i++)
//              {
//                 System.Console.Write(i);
//                 Thread.Sleep(100);
//              }
//              System.Console.WriteLine();
//            }
//            else
//            {
//             System.Console.WriteLine("Lock was not acquired for "+Thread.CurrentThread.Name);
//            }
//         }
//         finally
//         {
//             if(LockWasTaken)
//             {
//                 Monitor.Exit(lockobj);
//                 System.Console.WriteLine("exited "+Thread.CurrentThread.Name);
//             }
//         }
//     }
// }
