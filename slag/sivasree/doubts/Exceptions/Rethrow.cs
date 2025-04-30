class StaticClass
{
    // static void Main(string[] args)
    // {
        // System.Console.WriteLine("executing RETHROW");
        // try{
        //     int a=90;
        //     int b=0;
        //     System.Console.WriteLine(a/b);
        // }
        // catch(Exception ex)
        // {
        //     throw;
        // }
    
      
}
class program{
    static void Main(string[] args)
    {
        int x=1;
        switch(x)
        {
            case 1:
            try{
                throw new Exception("message");
            }
            catch{
                System.Console.WriteLine();
            }
            finally
            {
                
            }
            break;
            case 2:
            System.Console.WriteLine("case");
            break;
            default:
            System.Console.WriteLine("defau;t");
            break;
        }
    }
}
