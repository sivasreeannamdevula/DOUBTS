public class Rectangle:Shape, IColorable
{
    public Rectangle(string name,int id):base(name,id)
    {

    }
    public override void Draw()
    {
        System.Console.WriteLine("Draw rectangle");
    }
    public void ChangeColor()
    {
        System.Console.WriteLine("change rectangle colour");
    }
}