
//step1:create a delegate the takes one parameter as input which is nothing but the result from the thread and return type=void.
public delegate void ResultDelegate(int Result);
public class Helper
{
    private int _num;
   
    
    private ResultDelegate _resultdelegate;
    public Helper(int num,ResultDelegate resultdelegate)
    {
      _num=num;
      _resultdelegate=resultdelegate;
    }

    public void DisplayNumbers()
    {
        int result=0;
        for(int i=1;i<_num;i++)
        {
            System.Console.WriteLine("The i value is:"+i);
            result+=i;
        }
        if(_resultdelegate!=null)
        {
            //step-3:invoke the delegate.
            _resultdelegate(result);
        }
    }
}