//Func---->    must have a returntype and takes any  no.of parameters
//Action--->   no return type + >0 arguements
//Predicate->  bool type + only one arguement

//FUNC
public class GenericDelegate1
{

    //int==return type  and 0 arguements to methods(circle,square,oval,rectangle)
    public static int Circle()
    {
        System.Console.WriteLine("I am Circle");
        return -1;
    }
    public static  int Rectangle()
    {
        System.Console.WriteLine("I am Rectangle");
        return -2;
    }

    public static int Square()
    {
        System.Console.WriteLine("I am square");
        return -3;
    }
   public static int Oval()
   {
    System.Console.WriteLine("I am oval");
    return -4;
   }
   
    static void Main(string[] args)
    {
        Func<int> f=new Func<int>(Circle);
        f+=Square;
        int res=f();
        System.Console.WriteLine(res);
    }
}


//ACTION
public class GenericDelegate2
{

    public static void Circle(int x)
    {
        System.Console.WriteLine("I am Circle");
    }    
    public static  void Rectangle(int x)
    {
        System.Console.WriteLine("I am Rectangle");
    }

    public static void Square(int x)
    {
        System.Console.WriteLine("I am square");
    }
   public static void Oval(int x)
   {
    System.Console.WriteLine("I am oval");
   }

    static void Main(string[] args)
    {
        Action<int> fa=new Action<int>(Circle);
        fa+=Oval;
        fa(3);
        
    }
}


//PREDICATE
public class GenericDelegate3
{

    //int==return type  and 0 arguements to methods(circle,square,oval,rectangle)
    public static bool IsCircle(int x)
    {
        System.Console.WriteLine("I am Circle");
        return true;
    }
    public static  bool IsRectangle()
    {
        System.Console.WriteLine("I am Rectangle");
        return false;
    }

    public static bool IsSquare(int x)
    {
        System.Console.WriteLine("I am square");
        return true;
    }
   public static bool IsOval()
   {
    System.Console.WriteLine("I am oval");
    return true;
   }

    static void Main(string[] args)
    {
        Predicate<int> f=new Predicate<int>(IsCircle);
        f+=IsSquare;
        bool res=f(3);
        System.Console.WriteLine(res);
    }
}
