class Pro
{
    static int count=0;
    public void Method()
    {
        count++;
    }
    public static void Main(String[] args)
    {
       Pro p1=new Pro();
       p1.Method();
       Pro p2=new Pro();
       p2.Method();
       Pro p3=new Pro();
       p3.Method();
       System.Console.WriteLine(count);
    }
}