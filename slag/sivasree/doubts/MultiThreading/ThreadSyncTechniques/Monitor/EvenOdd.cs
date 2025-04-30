public class Program2
{
    static Object lockobject=new object();
    static int range=20;
    static void Main(string[] args)
    {
       Thread EvenThread=new Thread(EvenMethod);
       EvenThread.Start();
       Thread.Sleep(100);         //this makes sure that even thread executes first only then odd thread starts
       Thread OddThread=new Thread(OddMethod);  
       OddThread.Start(); 
    }

    public static void EvenMethod()
    {
        try
        {
          Monitor.Enter(lockobject);
          for(int i=0;i<range;i=i+2)
          {
            System.Console.Write(i+" ");
            Monitor.Pulse(lockobject);
            Monitor.Wait(lockobject);
          }
        }
        finally
        {
               Monitor.Exit(lockobject);
        }
    }

    public static void OddMethod()
    {
         try
        {
          Monitor.Enter(lockobject);
          for(int i=1;i<range;i=i+2)
          {
            System.Console.Write(i+" ");
            Monitor.Pulse(lockobject);    //notifies even thread in the waiting queue that lock state has changed  
            Monitor.Wait(lockobject);     //releases the lock and blocks the current thread execution until lock is acquired
          }
        }
        finally
        {
               Monitor.Exit(lockobject);
        }
    }
}