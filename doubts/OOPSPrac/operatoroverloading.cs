namespace S{
    class Complex
{
    int real;
    int img;
    public Complex(int real,int img)
    {
        this.real=real;
        this.img=img;
    }
    public void Display(Complex c)
    {
        System.Console.WriteLine(c.real + "i" + c.img);
    }
    public static Complex operator +(Complex a,Complex b)
    {
        Complex temp=new Complex(0,0);
        temp.real=a.real + b.real;
        temp.img=a.img + b.img ;
        return temp;
    }
}
class Progre
{
    public static void Main(string[] args)
    {
        Complex c1=new Complex(2,3);
        Complex c2=new Complex(4,5);
        c1.Display(c1);
        c1.Display(c2);
        Complex res=c1 + c2;
        c1.Display(res);
    }
}
}