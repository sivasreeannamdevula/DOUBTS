abstract class Bank{
    public abstract void CheckBal();
    public abstract void Validate();
    public abstract void withDraw();
    public void Method1()
    {
        System.Console.WriteLine("interface method1");
    }
}
class SBI:Bank{
    public override void CheckBal()
    {
        System.Console.WriteLine("SBI checked balance");
    }
    public override void Validate()
    {
        System.Console.WriteLine("SBI validate");
    }
    public override void withDraw()
    {
        System.Console.WriteLine("SBI withdrawn");
    }
}
class HDFC:Bank
{
    public override void CheckBal()
    {
        System.Console.WriteLine("HDFC checked balance");
    }
    public override void Validate()
    {
        System.Console.WriteLine("HDFC validate");
    }
    public override void withDraw()
    {
        System.Console.WriteLine("HDFC withdrawn");
    }
}
class Outer{
  
    static Bank createObj(string name)
    {
        Bank? b=null;
        if(name=="SBI")
        {
            b=new SBI();
        }
        else{
            b=new HDFC();
        }
        return b;
    }
    public static void Main(string[] args)
    {
        Bank refe=createObj("HDFC");
        refe.CheckBal();
        refe.Method1();
        SBI s=new SBI();
        
        s.Method1();
    }




}