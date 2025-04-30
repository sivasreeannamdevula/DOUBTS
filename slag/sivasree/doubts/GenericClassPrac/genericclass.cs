// //main methos cannot be in a generic class bcus compiler internally calls thatbmain method...as per the rule 
// //of generic method we have to send the type like main<int>();  but we cannot that is y we cannot use main in
// //generic class
// public class Q<T>
// {
//     public Q()
//     {
//         System.Console.WriteLine("ctor of Q class");
//     }
//     public void Sum<T1>(T1 a,T1 b)
//     {
//         System.Console.WriteLine("generic sum method");
        
//     }
//     public static void M<T>(T a)
//     {
//         System.Console.WriteLine("static method");
//     }
   
// }
// class R
// {
//      public static void Main()
//     {
//         Q<int> q=new Q<int>();
//          q.Sum<float>(7,8);
//          Q<int>.M<int>(7);
//     }
// }