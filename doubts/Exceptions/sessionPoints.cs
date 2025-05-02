class Session
{
    static void method1()
    {
          try{
          int a=90;
          int b=0;
          System.Console.WriteLine("try exec");
          int c=a/b;

        }
        catch(Exception e){
          int a=90;
          int b=0;
          int c=a/b;
          System.Console.WriteLine("executed");
        }
        finally{
          System.Console.WriteLine("hey uoi");
        }
    }
    static void Main(string[] args)
    {
      method1(); 
    }
}