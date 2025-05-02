//Generally to extend a class we use inheritance concept and we add new methods in the child class that can 
//be called using child class object.But what if the class is sealed? then we cant use inheritance concept
//that is where extention methods concept came into existence


//Let us extend the inbuilt string class

static class Mystring
{
    public static string Name(this string s)
    {
        return "sivasree";
    }
    public static void Main(string[] args)
    {
        string s="hey";
        System.Console.WriteLine( s.Name());
       
    }
}





// Here G class contains three methods
// Now we want to add two more new methods in it 
public class G {
 
  // Method 1
  public void M1() 
  {
      Console.WriteLine("M1");
  }
 
  // Method 2
  public void M2()
  {
      Console.WriteLine("M2");
  }
 
  // Method 3
  public void M3()
  {
      Console.WriteLine("M3");
  }
  
 }
   
public static class Extension{
    public static void M(this G s,int x)
    {
        System.Console.WriteLine("extension method {0}",x);
    }
}
class X{
    public static void Main()
    {
        G p=new G();
        p.M(8);
        p.M1();
    }
}
