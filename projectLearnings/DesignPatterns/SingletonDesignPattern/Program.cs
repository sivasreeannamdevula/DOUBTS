public class Program
{
    public static void Main()
{
 
    Singleton s1=Singleton.GetInstance();
    Singleton s2=Singleton.GetInstance();
    
    if(s1==s2)
    {
        System.Console.WriteLine("same object");
    }
    else{
        System.Console.WriteLine("different");
    }
}
}


public class Singleton
{
    //as we can only use static variable inside static class
    private static Singleton _singletonInstance;

   //private so that no one else can call this to create an object
    private Singleton()
    {

    }

//static method as we have to call this method from other class without creating an object
    public static Singleton GetInstance()
    {
        if(_singletonInstance is null)
        {
          _singletonInstance=new Singleton();
        }
        return _singletonInstance;
    }
}
