public class Helper
{
    private int _num;
    public Helper(int num)
    {
        _num=num;
    }
     
    public void DisplayNumbers()
    {
        for(int i=1;i<_num;i++)
        {
            System.Console.WriteLine("From Helper:"+i);
        }
    }
}