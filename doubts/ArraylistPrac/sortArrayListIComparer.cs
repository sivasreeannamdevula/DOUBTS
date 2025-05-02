using System.Collections;
using System.Runtime.InteropServices;

class A{

    public static void Main()
    {
        //Non-generic homogenous arraylist can be sorted
        // ArrayList a=new ArrayList();
        // a.Add(4);
        // a.Add(3);
        // a.Add(1);
        // a.Add(0);
        // a.Sort();
        // foreach(var v in a)
        // {
        //     System.Console.WriteLine(v);
        // }


        //non-generic heterogenous arraylist cannot be sorted for that we have to either implement IComparable
        //or IComparer interfaces

        ArrayList b=new ArrayList()
        {
            new Student(){Stdid=6,name="Ruhana"},
            new Student(){Stdid=13,name="Deepu"},
            new Student(){Stdid=4,name="Sakeena"},
            new Teacher(){Tid=12,deptName="mech"},
            new Teacher(){Tid=3,deptName="eee"}
        };
        Student std=new Student();
        b.Sort(std);
        foreach(var v in b)
        {
            if(v is Student s)
            {
                System.Console.WriteLine(s.Stdid + " " + s.name);
            }
            if(v  is Teacher t)
            {
                System.Console.WriteLine(t.Tid + " " + t.deptName);
            }
        }
    
        // IEnumerator e=b.GetEnumerator();
        // while(e.MoveNext())
        // {
                  
        //      if(e.Current is Student s)
        //      {
                
        //         System.Console.WriteLine(s.Stdid + " " + s.name);
        //      }
        //      if( e.Current is Teacher t)
        //      {
        //         System.Console.WriteLine(t.Tid + " " + t.deptName);
        //      }
        // }

    }

}
//if we implement IComparer in any one class(Student/Teacher) then thats enough.
public class Student:IComparer
{
    public int Stdid;
    public string name;

    public int Compare(object obj1,object obj2)
    {
        if(obj1 is Student s1 && obj2 is Student s2)
        {
            
            return s1.Stdid.CompareTo(s2.Stdid);
        }
        if(obj1 is Student s && obj2 is Teacher t)
        {
             return s.Stdid.CompareTo(t.Tid);
        }
        if(obj1 is Teacher st && obj2 is Student tt)
        {
             return st.Tid.CompareTo(tt.Stdid);
        }
         if(obj1 is Teacher z && obj2 is Teacher y)
        {
            
            return z.Tid.CompareTo(y.Tid);
        }
        return 0;
    }
}
public class Teacher
{
    public int Tid;
    public string deptName;
    // public int Compare(object obj1,object obj2)
    // {
    //     if(obj1 is Teacher s1 && obj2 is Teacher s2)
    //     {
            
    //         return s1.Tid.CompareTo(s2.Tid);
    //     }
    //     if(obj1 is Teacher s && obj2 is Student t)
    //     {
    //          return s.Tid.CompareTo(t.Stdid);
    //     }
    //       if(obj1 is Student st && obj2 is Teacher tt)
    //     {
    //          return st.Stdid.CompareTo(tt.Tid);
    //     }
    //      if(obj1 is Student q && obj2 is Student w)
    //     {
            
    //         return q.Stdid.CompareTo(w.Stdid);
    //     }
        
    //     return 0;
    // }
    
}
