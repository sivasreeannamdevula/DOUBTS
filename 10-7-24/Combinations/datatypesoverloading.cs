class Program
{
    //updated
    // public void M(int i)
    // {
    //     System.Console.WriteLine("int method");
    // }
    // public void M(long i)
    // {
    //     System.Console.WriteLine("long method");
    // }
    public void M(float i)
    {
        System.Console.WriteLine("float method");
    }
    public void M(double i)
    {
        System.Console.WriteLine("double method");
     }
    //  public void M(decimal i)
    // {
    //     System.Console.WriteLine("decimal method");
    // }
    // public void M(byte i)
    // {
    //     System.Console.WriteLine("byte method");
    // }

     public void M(char i)
    {
        System.Console.WriteLine("char method");
    }
    public void M(string i)
    {
        System.Console.WriteLine("string method");
    }
    //y not possible?---at the time of declaration itslef we have to initialise var 
    // public void M(var i)
    // {
    //     System.Console.WriteLine("var method");
    // }
    public void M(dynamic i)
    {
        System.Console.WriteLine("dynamic method");
    }
    //either dynamic or object can only be declared y?
    // public void M(Object i)
    // {
    //     System.Console.WriteLine("object method");
    // }
    public static void Main()
    {
        Program p=new Program();
       // p.M(8);          //int method--As every number is treated as int at first
       // p.M(256);        //byte method--nearest datatype is matched(int method is commented),if out of range
                           //then long method is called
       //p.M(8);          //long method--as nearest datatpe is long(byte,int methods are commented)
        //p.M(7L);         //We can also explicitly call using L
        //p.M(7);         //doesn't b exist? no doesn't exist
        //p.M(8.9);        //double method--floating point numbers are treated as doubles by default
        // p.M(7.8);        //dynamic method--if we comment double method next dynamic is given preference
        // p.M(8);          //if we comment all int,long,byte methods then after it choooses float/decimal 
        //p.M(7f);         //explicit call to float method
         p.M(6);         //decimal method--as it is the last option 
         //p.M(8M);        //explicit call to decimal method.
         //p.M(8);         //dynamic or object method is called whichever is present
         //p.M('y');        //char method is called
         //p.M("sree");     //string method is called\
         //p.M('j');          //if char method is commented object/dynamic method is called

    }
}

//p.M(8)----------int>byte>long>float>double

//(float/double,decimal) conflict
//float double no conflict ----float method is called
