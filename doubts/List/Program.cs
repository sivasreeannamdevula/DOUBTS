using System.Collections.Generic;
using System.Runtime.InteropServices;
class L{
   public static void Main()
   {
     List<int> l=new List<int>();
      l.Add(8);
      l.Add(4);
      l.Add(3);
      l.Add(1);
      l.Add(2);
      List<int> a=new List<int>();
      a.Add(4356);
      a.Add(8990);
      l.AddRange(a);
      foreach(var v in l)
      {
        System.Console.WriteLine(v);
      }
      System.Console.WriteLine(l.Count);
      System.Console.WriteLine(l.Capacity);

      l.Insert(2,0);
      l.InsertRange(6,a);
      l.Remove(0);
      l.RemoveAt(2);
      l.RemoveRange(1,4);
      l.Clear();

      System.Console.WriteLine(l.IndexOf(2));
      System.Console.WriteLine(l.Contains(3));
   }
}
