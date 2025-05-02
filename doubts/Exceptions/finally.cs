//if catch of one method didn't catch then other method catch catches that exception....
//System.Exit(0)----finally doesn't get executed here...if thread or process terminates
class Finally
{
    public static void Somemethod2()
    {
          try{
            System.Console.WriteLine("entered somemthod2");
            int a=89;
            int b=0;
            int c=a/b;
        }
        finally{
            switch(0)
            {
                case 0:
                  System.Console.WriteLine("hrhy");
                  break;
                default:
                  System.Console.WriteLine("default");
                  break;
            }
            System.Console.WriteLine("i am finally");
        }
        System.Console.WriteLine("outside of somemthod2");
    }
    public static void SomeMethod()
    {
       try{
        System.Console.WriteLine("entered somemethod");
        Somemethod2();
       }
       finally{
        System.Console.WriteLine("fin of method");
       }
       System.Console.WriteLine("outside of somemthod");
    }
    static void Main(string[] args)
    {
       try{
        System.Console.WriteLine("entered main");
           SomeMethod();
       }
       catch
       {
        System.Console.WriteLine("main catch");
       }
       System.Console.WriteLine("outside of main");
    }
}