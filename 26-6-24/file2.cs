
    static class StaticClass2
    {
        public static int x=6;
        static StaticClass2()
        {
            System.Console.WriteLine("StaticClass2 ctor called {0}",x);
        }
        static void Method2()
        {
            System.Console.WriteLine("method2 of namespace2 called");
        }
    }

