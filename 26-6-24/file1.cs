//using NameSpace2;
namespace Namespace1
{
    class StaticClass
    {
        static int x=90;
        static StaticClass()
        {
            System.Console.WriteLine("static StaticClass ctor is called {0}",x);
        }
        static void Method()
        {
            System.Console.WriteLine("StaticClass method is called");
        }
         
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Main of StaticClass called");
            //StaticClass.Method();
            System.Console.WriteLine(StaticClass2.x);
        }
      
    }
}