//Q class accepts only reference types for T
class Q<T> where T : class
{
    public void Method()
    {
        System.Console.WriteLine("method");
    }
   
}

//P accepts only value types for T
class P 
{
    public static void Main()
    {
        Q<int> q=new Q<int>();               //as Q class has a class constraint so we have to pass only
        q.Method();                                     //refernce types and not value types
                                           
    }
}


//where T : struct           accepts only value types for T  
//where T : new()            accepts only those classes for T that has parameterless ctors
//where T : Parentclass      accepts Parent class and its derived class as T
//where T : InterfaceName    accepts only those for T that implements InterfaceName