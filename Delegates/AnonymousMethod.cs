using System.Reflection.Emit;

class AnonymousMethod
{
    public delegate int AnonyDelegate(int x);
   
   static void Main(string[] args)
   {
      //xo is outer varaible and it can be used in anonymous method .
      int xo=10;
    //this is anonymous method, it returns the delegate so AnonyDelegate is used.
     AnonyDelegate ad=delegate (int x)
     {
        System.Console.WriteLine("I am anonymous method");
        //break,continue,goto statements cannot be used
        xo=90;
        return 9;
     };

    
     int res=ad(7);
     System.Console.WriteLine(xo);
     System.Console.WriteLine(res);
   }

}

class AnonymousMethod1
{
    public delegate int AnonyDelegate(int x);
   
   public static void Method(int x,int y,out int total)
   {
      total=x+y;
      AnonyDelegate ad=delegate (int x)
     {
        System.Console.WriteLine("I am anonymous method");
         return 9;
        // total=90; --->we cannot use out or ref parametrs of outer functions in anonymous methods.
     };
   }
   static void Main(string[] args)
   {
    
      int Total=0;
      Method(63,47,out Total);
      System.Console.WriteLine(Total);
   }

}




//the above code using lamda expressions
 class AnonymousMethod2
{
    public delegate int AnonyDelegate(int x);
   static void Main(string[] args)
   {
    //this is anonymous method, it returns the delegate so AnonyDelegate is used.
     AnonyDelegate ad=(x) =>
     {
        System.Console.WriteLine("I am anonymous method");
        return 0;
     };
     int res=ad(7);
     System.Console.WriteLine(res);
   }

}