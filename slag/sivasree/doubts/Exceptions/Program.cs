// //here the CLR internally identifies the type of runtime error using exception manager present in it.
// //after identifying that it is divide by zero error..it will create an object of that exception class and throws the object 
// //as throw new DivideByZeroException();
// //here we can see the abnrml termination of the program
// class Exceptions
// {
//     public static void Main()
//     {
  
//          int a=25;
//         int b=0;
//         System.Console.WriteLine("started dividing");
//         int c=a/b;
//         System.Console.WriteLine("after divison the result is {0}",c);
      
        
//     }
// }


// //to handle the above the exception we have two ways--here handling means that program doesn't terminate
// //1.LOGICAL IMPLEMENTATION
// class Exceptions
// {
//     public static void Main()
//     {
  
//          int a=25;
//         int b=0;
//         if(b==0)
//         {
//             System.Console.WriteLine("divisor is 0");
//         }
//         else{
//             System.Console.WriteLine("result after division is {0}",a/b);
//         }
      
        
//     }
// }

//2.TRY-CATCH
class Exceptions
{
    public static void Main()
    {
        try
        {
           int a=25;
           int b=0;
           System.Console.WriteLine("started dividing");
            int c=a/b;
           System.Console.WriteLine("after divison the result is {0}",c);
        }
        catch(Exception e)
        {
            System.Console.WriteLine("some error occurred");
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.Source);
            System.Console.WriteLine(e.HelpLink);
            System.Console.WriteLine(e.StackTrace);
        }
      
        
    }
}


//generic catch that means it can handle any kind of Exception
class ExceptionsGeneric
{
    public static void Main()
    {
        try
        {
           int a=25;
           int b=0;
           System.Console.WriteLine("started dividing");
            int c=a/b;
           System.Console.WriteLine("after divison the result is {0}",c);
        }
        catch(Exception e)    //this is generic catch
        {
            System.Console.WriteLine("some error occurred");
            
        }
      
        
    }
}