// using System.Collections;
// using System.Runtime.CompilerServices;
// using System.Text;

// //clone--one object with two references(if we change value in one object automatically in other
// // object it gets changed,but for new objects that are added as there will be no mapping that doesn't get
// //reflected)
// public class Pro
// {
//     public static void Main()
//     {
//         ArrayList a=new ArrayList()
//         {
//             new Family(){num=89,name="nagamani"},
//             new Family(){num=56,name="chaitanya"},
//             new Family(){num=45,name="roja"},
//             new Family(){num=90,name="sree"}
//         };
//         //cloning
//         ArrayList b=(ArrayList)a.Clone();
//         //copying                
//         ArrayList C=new ArrayList(a);
//         IEnumerator e=C.GetEnumerator();
//         System.Console.WriteLine("before cloning");
//         while(e.MoveNext())
//         {
//             if(e.Current is Family f)
//             {
//                 System.Console.WriteLine(f.name + " " + f.num);
//             }
//         }
//         ((Family)(C[0])).name="Siva";               //the changes we made in c donot get reflected in a.
//         ((Family)b[0]).num=89; 
//         ((Family)b[3]).name="nagasai";
//         System.Console.WriteLine("after cloning");
//         e.Reset();                               //ENUMERATOR NI INTIAL POSITION KI THEESUKURAVADAM
//          while(e.MoveNext())
//         {
//             if(e.Current is Family f)
//             {
//                 System.Console.WriteLine(f.name + " " + f.num);
//             }
//         }
        
//         IEnumerator p=a.GetEnumerator();
//         while(p.MoveNext())
//         {
//             if(p.Current is Family f)
//             {
//                  System.Console.WriteLine(f.name + "" + f.num);
//             }
//         }
    
//      }
// }
// public class Family
// {
//     public int num;
//     public string name;
// }