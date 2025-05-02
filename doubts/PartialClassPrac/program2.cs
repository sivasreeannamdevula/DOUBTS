namespace Partial{
  partial  class MyPartial
{
    
    public virtual partial int Display()
    {
        System.Console.WriteLine("the value of x is {0}",x);
        return 0;
    }
    public static void Main()
    {
         MyPartial p=new MyPartial();
         System.Console.WriteLine(p.Display());
    }

}
}