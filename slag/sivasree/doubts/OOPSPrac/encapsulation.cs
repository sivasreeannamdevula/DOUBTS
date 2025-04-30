// // using System.Runtime.InteropServices;

// class Encapsulation
// {
//    public int x=90;
//    private int y;
    
//   //  public int get()
//   //  {
//   //    return y;
//   //  }
//   //  public void set(int input)
//   //  {
//   //    y=input;
//   //  }
//   public int Prop
//   {
//     set{
//       if(value<0)
//       {
//         System.Console.WriteLine("enter a correct value");
//       }
//       else
//       {
//         y=value;
//       }
       
//     }
//     get{

//       return y;
//     }
//   }

// }
// class Other
// {
//   public static void Main(string[] args)
//   {
//     Encapsulation e=new Encapsulation();
//     e.Prop=45;
//      System.Console.WriteLine(e.Prop);
//     e.Prop=-90;
//      System.Console.WriteLine(e.Prop);
//   }
// }