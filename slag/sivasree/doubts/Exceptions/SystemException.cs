using System.Text;
using System.Collections.Generic;
using System.Collections;
class SysytemException
{
    public static void somemethod2(String s,int i)
    {
        if(s==null)
        {
            throw new ArgumentNullException();
        }
        s+="hey";
    }
    public static void SomeMethod()
    {
        SomeMethod();
    }
    static void Main(string[] args)
    {
        //ArithmeticException are 2 types i)DivideByZeroException    ii)OverFlowException
        // //1a .DivideByZeroException--->>if b==0 then we get dividebyzero exception
        // int a=Convert.ToInt32(Console.ReadLine());
        // int b=Convert.ToInt32(Console.ReadLine());
        // //1b.OverFlowException--->>we we enter the int value greater than its max value then we get this
        // int i=Convert.ToInt32(Console.ReadLine());
        // //2.FormatException--->>if a or b ==string then we get FormatException
        // System.Console.WriteLine(a/b);
        

        // //3.IndexOutOfRangeException--->>if we try to access the index that is not under array
        // int[] arr={2,5,6,7,8};
        // for(int i=0;i<8;i++)
        // {
        //     System.Console.WriteLine(arr[i]);
        // }

        // //4.NullReferenceException--->>on null references if we try to perform any operations then we get this
        // StringBuilder s=null;
        // s.Append("hey");

        // //5.StackOverFlow--->>if we donot mention any bse case while recursion then we get this type of exceptions
        // SomeMethod();
        

        // //6.InvalidOperationException--->>here as we are keep on adding the elements to list..there is no stop
        // List<int> l=new List<int>();
        // l.Add(8);
        // l.Add(7);
        // l.Add(5);
        // IEnumerator e=l.GetEnumerator();
        // while(e.MoveNext())
        // {
        //   if(e.Current is int)
        //   {
        //     System.Console.WriteLine(e);
        //     l.Add(7);
        //   }
        // }
       
       //7.ArgumentException are 2 types
       //7a.ArgumentNullException
       //somemethod2();

       //7b.ArguementOutOfRangeException


       //8.IOException
    
    }
}