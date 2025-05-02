//generic class has extra '1 '0 things in ildasm code
class Generic<T>
{
    public static void Add<T>(T a,T b)
    {
        System.Console.WriteLine((dynamic)a+(dynamic)b);
    }
  
} 
class Program
{
      public static void Main()
    {
        System.Console.WriteLine("generic main entered");
        Generic<int>.Add(1,1);
    }
}

