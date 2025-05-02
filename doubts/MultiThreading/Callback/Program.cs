
public class Program
{
    
    public static void Main()
    {
        //step-2:Create an instance of the delegate created and register the method(resultmethod)
        ResultDelegate resultDelegate1=new ResultDelegate(ResultMethod);
        
        Helper h=new Helper(10,resultDelegate1);
        Thread t1=new Thread(h.DisplayNumbers);
        t1.Start();

    }

    public static void ResultMethod(int result)
    {
        System.Console.WriteLine("THE RESULT FROM THREAD IS:"+result);
    }
}