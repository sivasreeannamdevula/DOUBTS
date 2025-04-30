class InnerException{
    static void Main(string[] args)
    {
     
       try
       {
         try
         {
            double a=Convert.ToDouble(Console.ReadLine());
            double b=Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Quotient is {0}",a/b);
        }
        catch(Exception e)            //here e=exception in above try.lets say we entered b as string so e=FormmatExcp
        {
            int a=Convert.ToInt32(Console.ReadLine());
            int b=Convert.ToInt32(Console.ReadLine());
            if(b==0)
            {
                //let say again we raised an exception by giving b=0
                //now the above exception i.e; FormatExcp is being passed as an InnerException to DivideByZeroExcp
                throw new DivideByZeroException("DivideByZeroException",e);
            }
        }
       
       }
       catch(Exception ex)      //here ex is DivideByZeroException 
       {
          System.Console.WriteLine(ex.Message);
          if(ex.InnerException!=null)
          {
            System.Console.WriteLine(ex.InnerException.Message);  //here as InnerExcp is holding FormatException that
                                                                  //corresponding msg gets displayed
          }
       }
    
  
    }
}