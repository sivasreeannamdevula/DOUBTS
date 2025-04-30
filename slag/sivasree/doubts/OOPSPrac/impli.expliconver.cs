// class Impli
// {
//     public static void Main()
//     {
//         float x=90.8f;
//         int y=9;
//         float res=y + x;      //here implicitly y converted from int to float....float higher 
//                               //datatype than int so conversion possible 
//         System.Console.WriteLine(res);

//     }
// }


// class Expli
// {
//         public static void Main()
//     {
//         float x=90.8f;
//         int y=9;
//         //1.this type of conversions doesn't throw any exception
//         int res=y + (int)x;                                    //here explicitly x converted from float to int
//         //2.this conversion throwse exception
//         int ans=Convert.ToInt32(x);
//         System.Console.WriteLine(res + " " + ans);
//         float b=123456789346.4f;
//         System.Console.WriteLine((int)b);                     //output=-2147483648
//         System.Console.WriteLine(Convert.ToInt32(b));         //output=System.OverflowException

//     }
// }



// //as keyword
// //used only for reference type converion such as class,string,object,interface...
// //it doesnt throw any exception if conversion not possible,instead returns null
// class Convo{
//    public static void Main()
//    {
//         object o="hey ram";
//         string str=(o as string) ?? ""; 
//          //(OR)
//         string? s=o as string;
//    }
// }

