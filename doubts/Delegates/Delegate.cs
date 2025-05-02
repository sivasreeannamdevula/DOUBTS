//We have two abstarct classes Delegate and MulticastDelegate 
//MulticastDelegate class internally inherits Delegate class
//we cannot inherit Delgate/MultiCastDelegate classes explicitly
//Whenever we create a delegate,internally a class gets  created which internally inherits MultiCast delegate.
//Delegate class contains properties such as Method,Target,InvocationList

class Delegate1
{
    public delegate int DelegateClass(int a,int b);
    
    public static int Add(int a,int b)                //signature of methods and delegates should match
    {
        return a+b;
    }
    public int Substract(int a,int b)
    {
        return a-b;
    }
    public static int Multiply(int a,int b)
    {
        return a*b; 
    }

    public static int Divide(int a,int b)
    {
        return a/b;
    }
    static void Main(string[] args)
    {
        Delegate1 de=new Delegate1();
        DelegateClass d=new DelegateClass(de.Substract);     //for non-static methods we have to add to delegate by using
                                                             //object instance


        System.Console.WriteLine(d.Method);                  //-->gives the method signature of last method in Invocationlist


        System.Console.WriteLine(d.Target);                  //-->returns NUll if static method else ClassName of last method 
                                                             //in invocationlist
                
        d+=Divide;
        d+=Multiply;
        d+=Add;
        int res=d(8,2);
        System.Console.WriteLine(d.GetInvocationList);     //gives the list of methods in the delegate
        // System.Console.WriteLine(res);
    }
}














class Program
{
    //Delegate Declaration
    public delegate void FirstDelegate(int s,string str);

    public void FirstHandler(int i,string s)
    {
       System.Console.WriteLine("FirstHandler invoked");
    }
    public static void SecondHandler(int i,string s)
    {
       System.Console.WriteLine("staic SecondHandler invoked");
     
    }
    public  void ThirdHandler(int i,string s)
    {
       System.Console.WriteLine("ThirdHandler invoked");
    }
    static void Main()
    {
       Program p=new Program();
       //To add instance methods we have to create object(p in this case)
       FirstDelegate d1=new FirstDelegate(p.FirstHandler);
       //static methods can be added directly using just className.methodName
        d1+=SecondHandler;

        d1+=p.ThirdHandler;
        d1-=SecondHandler;
       //calling delegate
       d1(8,"sree");
       //It returns the method signature of last added method to delegate[] invocation list.
       System.Console.WriteLine(d1.Method);
       //If the last added method is static then it returns null,If the last added method is instance then
       //it returns the namespaceName.ClassName of the last added method to delegate
       System.Console.WriteLine(d1.Target);

       Delegate[] list=d1.GetInvocationList();
       foreach(var item in list)
       {
        System.Console.WriteLine(item);
       }
    }    
}
