using System;
using System.Collections;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
      
        Circle circle=new Circle("Circle",1);
        circle.Draw();
        Rectangle rectangle=new Rectangle("Recatangle",1);
        rectangle.ChangeColor();

        ShapeManager s=new ShapeManager();
        s.AddShape("CIRCLE","round in shape");
        s.AddShape("RECTANGLE","square type where length!=breadth");
        s.AddShape("CIRCLE","hey");
        StringBuilder sb=s.GetShapeDesciption("CIRCLE");
        System.Console.WriteLine(sb);
    }
}





