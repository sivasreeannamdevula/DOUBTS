// using System.Collections;
// public class li{

//      public static void Main()
//      {
//         List<Manager> l=new List<Manager>()
//         {
//             new Manager(){id=8,name="sree"},
//             new Manager(){id=76,name="roja"},
//             new Manager(){id=5,name="chaitanya"},
//             new Manager(){id=34,name="mani"}
//         };
//             Manager p=new Manager();
//         l.Sort(p);
//         IEnumerator s=l.GetEnumerator();
//         while(s.MoveNext())
//         {
//             if(s.Current is Manager M)
//             {
//                 System.Console.WriteLine(M.id + "  " + M.name);
//             }
//         }
//      }


// }
// public class Manager:IComparer<Manager>{
//     public int id;
//     public string name;

//     public int Compare(Manager m1,Manager m2)
//     {

//        return m1.id.CompareTo(m2.id);
//     }
    
// }