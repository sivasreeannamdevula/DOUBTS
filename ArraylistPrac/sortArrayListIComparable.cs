// using System.Collections;
// using System.Runtime.InteropServices;

// class A{

//     public static void Main()
//     {
//         //Non-generic homogenous arraylist can be sorted
//         // ArrayList a=new ArrayList();
//         // a.Add(4);
//         // a.Add(3);
//         // a.Add(1);
//         // a.Add(0);
//         // a.Sort();
//         // foreach(var v in a)
//         // {
//         //     System.Console.WriteLine(v);
//         // }


//         //non-generic heterogenous arraylist cannot be sorted for that we have to either implement IComparable
//         //or IComparer interfaces

//         ArrayList b=new ArrayList()
//         {
//             new Student(){Stdid=6,name="akshay"},
//             new Student(){Stdid=13,name="tarun"},
//             new Student(){Stdid=4,name="Bhargav"},
//             new Teacher(){Tid=12,deptName="cse"},
//             new Teacher(){Tid=3,deptName="IT"}
//         };
        
//         b.Sort();
//         foreach(var v in b)
//         {
//             if(v is Student s)
//             {
//                 System.Console.WriteLine(s.Stdid + " " + s.name);
//             }
//             if(v  is Teacher t)
//             {
//                 System.Console.WriteLine(t.Tid + " " + t.deptName);
//             }
//         }
    
//         // IEnumerator e=b.GetEnumerator();
//         // while(e.MoveNext())
//         // {
                  
//         //      if(e.Current is Student s)
//         //      {
                
//         //         System.Console.WriteLine(s.Stdid + " " + s.name);
//         //      }
//         //      if( e.Current is Teacher t)
//         //      {
//         //         System.Console.WriteLine(t.Tid + " " + t.deptName);
//         //      }
//         // }

//     }

// }
// public class Student:IComparable
// {
//     public int Stdid;
//     public string name;

//     public int CompareTo(object obj)
//     {
//         if(obj is Student s)
//         {
//             if(this.Stdid > s.Stdid)
//             {
//                 return 1;
//             }
//             else if(this.Stdid < s.Stdid)
//             {
//                 return -1;
//             }
//             else{
//                 return 0;
//             }
//         }
//         if(obj is Teacher t)
//         {
//              if(this.Stdid > t.Tid)
//              {
//                 return 1;
//              }
//              else if(this.Stdid < t.Tid)
//              {
//                 return -1;
//              }
//              return 0;
//         }
//         return 0;
//     }
// }
// public class Teacher:IComparable
// {
//     public int Tid;
//     public string deptName;
//      public int CompareTo(object obj)
//     {
//         if(obj is Teacher s)
//         {
//             if(this.Tid > s.Tid)
//             {
//                 return 1;
//             }
//             else if(this.Tid < s.Tid)
//             {
//                 return -1;
//             }
//             else{
//                 return 0;
//             }
//         }
//         if(obj is Student t)
//         {
//              if(this.Tid > t.Stdid)
//              {
//                 return 1;
//              }
//              else if(this.Tid < t.Stdid)
//              {
//                 return -1;
//              }
//              return 0;
//         }
//         return 0;
// }
// }