using System.Diagnostics;     //to use stopwatch
using System.Text;            //to use StringBuilder class

//the below code tells the difference in execution time of string and stringbuilder class
//as strings are immutable they take more time as they create a new object eachtime
class Str{
  public static void Main()
  {
    StringBuilder sb=new StringBuilder();
    String s=new  String("siva");
    Stopwatch sw=new Stopwatch();
    sw.Start();
    for (int i=0;i<17890;i++)
    {
      sb.Append("SREE");
    // s+="siva";
    }
    sw.Stop();
    System.Console.WriteLine(sw.ElapsedMilliseconds);
  }
}


class s{
  public static void Main()
  {
    //CONSTRUCTORS

    //1.default ctor of capacity=16 characters
    StringBuilder sb0=new StringBuilder();
    //2.default capacity=16  length=stringlength
    StringBuilder sb1=new StringBuilder("hey");
    //3.with custom defined capacity(7)
    StringBuilder sb2=new StringBuilder(7);
    //4.with string as well as custom defined capacity=8
    StringBuilder sb3=new StringBuilder("hey",8);
    //5.capacity(4) and maxcapacity(9) are custom defined
    StringBuilder sb4=new StringBuilder(4,9);

    //PROPERTIES

    //Length       
    //1.gives the no.of charcaters in the string that is being held by char[]  array of StringBuilder
    System.Console.WriteLine(sb1.Length +" "+ sb1.Capacity);
    //2.setting length less than already existing string length---in this case extra characters are truncated
    sb1.Length=1;
    System.Console.WriteLine(sb1.Length +" "+sb1.Capacity);
    System.Console.WriteLine( sb1);         //ouput:h
    //3.setting length greater than already existing string length---in this case null characters are added at the end
    sb1.Length=8;
    System.Console.WriteLine(sb1.Length+" "+sb1.Capacity);
    System.Console.WriteLine(sb1);

    // Capacity
    //1.gives the no.of charcaters that the char[]  array of StringBuilder can hold
    System.Console.WriteLine(sb1.Length +" "+ sb1.Capacity);
    //2.setting capacity less than already existing string length---thorws error
    sb1.Capacity=1;

    //Maxcapacity
    //1.by default INT_MAX=MaxCapacity
    System.Console.WriteLine(sb1.MaxCapacity);
    //2.we can also set manullay using the above 5th ctor

    //indexer
    System.Console.WriteLine(sb1[0]);                    //getting the value at 0th index
    sb1[0]='i';                                          //setting the value at 0th index
    System.Console.WriteLine(sb1[0]);


    //Methods
    //1.Append     passed string gets added at the end of existing string
    sb0.Append("first");
    System.Console.WriteLine(sb0);
    //2.Insert(int startIndex,string stringToBeAppended)
    sb0.Insert(2,"second");
    System.Console.WriteLine(sb0);
    //3.Replace(string oldString,string newstring)
    sb0.Replace("fi","hi");
    System.Console.WriteLine(sb0);
    sb0.Append("fififi");
    sb0.Replace("fi","hi",7,9);
    System.Console.WriteLine(sb0);
    //4.Remove(int startINdex,int noofCharToBeRemoved)
    sb0.Remove(3,4);
    System.Console.WriteLine(sb0);
    //Clear  empties the string 
    sb0.Clear();
    System.Console.WriteLine(sb0);
  }

}


