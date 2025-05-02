class EventsUsingDelegates
{
    //Creation of delegate 
    public delegate int Delegate_Name(int a,int b);

    //creation of event wrt delegate...that means linking delegte to be called when that event raises
    event Delegate_Name First_Event;

    //in ctor we have bind methods to that event using delegate....this means for every instance created we are binging 
    //the methods/eventhndhlers.
    public EventsUsingDelegates()
    {
        Delegate_Name d=new Delegate_Name(Add);
        d+=Sub;
        d+=Mul;
        d+=Div;
        this.First_Event +=d;
    }

    public static int Add(int a,int b)
    {
        return a+b;
    }
    public static int Sub(int a,int b)
    {
        return a-b;
    }
    public static int Mul(int a,int b)
    {
        return a*b;
    }
    public static int Div(int a,int b)
    {
        return a/b;
    }
    static void Main(string[] args)
    {
        EventsUsingDelegates ed=new EventsUsingDelegates();
        //triggering the event.
        int result=ed.First_Event(10,5);
        System.Console.WriteLine(result);
    }
}
