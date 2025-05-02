

class MultipleCatch
{
    public static void Main(){

       try
       {
         int a=Convert.ToInt32(Console.ReadLine());
         int b=Convert.ToInt32(Console.ReadLine());
         System.Console.WriteLine("division is {0}",a/b);
       }
       catch(FormatException f)
       {
         System.Console.WriteLine(f);
       }
       catch(DivideByZeroException d)
       {
         System.Console.WriteLine(d);
       }
       catch(Exception e)
       {
        System.Console.WriteLine("someother exception");
       }
    }
}