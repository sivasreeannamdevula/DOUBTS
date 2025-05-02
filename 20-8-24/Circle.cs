public class Circle:Shape, IColorable
{
    public Circle(string name,int ID):base(name,ID)
    {

    }
    public override void Draw()
    {
       System.Console.WriteLine("Draw Circle");
    }
    public void ChangeColor()
    {
       System.Console.WriteLine("change circle colour");
    }
}