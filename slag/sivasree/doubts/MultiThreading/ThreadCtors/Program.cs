public class Program
{
    static void Main(string[] args)
    {
    //     //creation of custom thread
    //     Thread t=new Thread(Add);  
    //     //executing the thread i.e; Add method       
    //     t.Start();
    //     System.Console.WriteLine("custom thread isalive?:"+t.IsAlive);
    //     //setting the thread as not background thread 
    //     t.IsBackground=false;
    //     System.Console.WriteLine("custom thread is background?"+t.IsBackground);
    //     //managedid prints unique id of thread
    //     System.Console.WriteLine("custom thread ID:"+t.ManagedThreadId);
    //     System.Console.WriteLine("custom thread state:"+t.ThreadState);
    //     //setting the name of current thread
    //     Thread.CurrentThread.Name="sree";
    //    System.Console.WriteLine("Name is: "+Thread.CurrentThread.Name);    //printing current thread name
    //    System.Console.WriteLine("Alive?"+Thread.CurrentThread.IsAlive);    //printing whether the thread is alive or not
    //    System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);     //printing the id of current thread i.e; sree
    //    System.Console.WriteLine(Thread.CurrentThread.ThreadState);         //state of thread is printed i.e; running/aborted/..

    //Thread class contains 4 ctors 
    //1.which takes ThreadState as input where ThreadState is a delegate of returntype=void and parameterless methods are accepted
    Thread t1=new Thread(Add);     //we can either pass the method directly or by 2-step process
    t1.Start();



    ThreadStart ts1=new ThreadStart(Add);  //here we are creating a delegate(Threadstart) instance and to that we are regsitering Add method
    Thread t2=new Thread(ts1);      
     t2.Start();


     //ANONYMOUS METHOD TO THREAD
     Thread t3=new Thread(delegate()
     { 
        for(int i=0;i<4;i++)
        {
            System.Console.WriteLine(i);
        }
        
     });
      t3.Start();

     //lamda function to thread
      Thread t4=new Thread(()=>
      {
         System.Console.WriteLine("LAMDA");
      });
      t4.Start();


      //2.ParameterizedThreadState ctor=which accepts the method that has one object input paramter and returntype=void
      Program obj=new Program();
      ParameterizedThreadStart pt=new ParameterizedThreadStart(obj.ParameterMethod);
      Thread t5=new Thread(pt);
      t5.Start(8);
      t5.Start("hello");      //here generally we dont get any compiletime error as string is also an objecttype
                              //but at runtime we will get FormatException
                              //to overcome this exception we must use a ctor(helperclass) that takes the input of only a specific type

     Helper h=new Helper(90);
     Thread t6=new Thread(h.DisplayNumbers);
     t6.Start();
    }

    public static void Add()
    {
        System.Console.WriteLine("Addition of two numbers by custom thread");
    }

    public void ParameterMethod(object input)
    {
        int convertedvalue=Convert.ToInt32(input);
        for(int i=1;i<convertedvalue;i++)
        {
            System.Console.WriteLine("from parameterized method"+i);
        }
    }
}
