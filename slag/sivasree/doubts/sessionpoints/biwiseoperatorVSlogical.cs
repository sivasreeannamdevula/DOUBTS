// public class P{
//     public static void Main()
//     {
//        // bool bool.operator |(bool left, bool right)--internally there are two overloaded methods 
//        //for bitwise |.whenever we use in conditioanl statements there bool overloaded method gets triggered
//           //that is why the below code doesn't work.
        
//         if(2 | 5)
//         {
//             System.Console.WriteLine();
//         }
        
//         if((2>7) | (5>9))     //uses this overloaded method bool bool.operator |(bool left, bool right)
//         {
//             System.Console.WriteLine(2|3);     //uses int int.operator |(int left, int right)
//         }
        
//         if((2>0) | (4>8))             //both expressions gets resolved
//         {
//             System.Console.WriteLine("block executed");
//         }

//         if((4>7) && (6>8))           //only expression gets resolved if first exp is false
//         {
//             System.Console.WriteLine("executed");
//         }

//     }
// }