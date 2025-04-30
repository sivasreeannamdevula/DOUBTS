class Pro2
{

    public delegate void DuplicateDelegate(string name);
    event DuplicateDelegate MyEvent;
    public Pro2()
    {
        DuplicateDelegate d1=new DuplicateDelegate(Print);
        this.MyEvent=d1;
    }
    static void Main(string[] args)
    {
        Pro2 p=new Pro2();
        p.MyEvent("chaitanya");

    }

    public void Print(string name)
    {
        System.Console.WriteLine("My name is {0}",name);
    }
}