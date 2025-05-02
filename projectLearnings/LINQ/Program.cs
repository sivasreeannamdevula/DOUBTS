using System.Xml;

public class Program()
{
    public static void Main()
    {
      //we can implement linq in two ways


      //1.query style (internally gets converted into method syntax)
      //1a)Datasource
      List<int> list1=new List<int>();
      list1.AddRange(1,2,3,4,5);
      //1b)query
      var res1=from c in list1    //intialisation
               where c>3          //condition
               select c;          //selection
      //query style tells the type of output rather than the output itself 
      System.Console.WriteLine(res1);
      //so to print the output
      //1c)execution
      foreach(var i in res1)
      {
        System.Console.WriteLine(i);
      }

      ////IEnumerable and IEnumerator
      //IEnumerator<int> enumerator1=list1.GetEnumerator();
      //while(enumerator1.MoveNext())
      //  {
      //      System.Console.WriteLine(enumerator1.Current);
      //  }
     
        
    //2.Method syntax
       System.Console.WriteLine(list1.Where(c=>c>3));



 



       
    }
}

