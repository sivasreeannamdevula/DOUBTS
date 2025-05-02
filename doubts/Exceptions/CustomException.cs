//surely custom exception class must inherit Exception/ApplicationException class and then we can override 
//properties/methods of parent class.

class NullException:ApplicationException        //or class NullException:Exception--->>both acts same as internally 
                                                //applicationexception class inherits exception class
{
    //calling Exception class ctor that takes string as arguement
    //if we use string arguement ctot then no need to override Message property
    public NullException(string msg):base(msg)
    {
        
    }
    // public string Message
    // {
    //    get{
    //      return "message";
    //    }
    // }
    public string StackTrace{
        get{
            return "stackdata is : nullexception";
        }
    }
    public string Source{
        get{
            return "my custom class";
        }
    }
    public string HelpLink{
        get{
            return "u can get more info from:https:://nullexception";
        }
    }
}
class CustomExceptions
{
    static void Main(string[] args)
    {
       try{
        //  System.Console.WriteLine("enter the value for string");
        string s=Console.ReadLine();
        //we have to explicitly create the object of our custom class becuase unlike SystemException(dividebyzero,
        //indexoutofrange...)where clr implicitly throws the object.
        if(string.IsNullOrEmpty(s))
        {
            throw new NullException("");
        }
        System.Console.WriteLine("executes try");
       }
       catch(NullException n)
       {
        System.Console.WriteLine(n.Message);
        System.Console.WriteLine(n.StackTrace);
        System.Console.WriteLine(n.HelpLink);
        System.Console.WriteLine(n.Source);
       }
       System.Console.WriteLine("out of catch");
    }
}