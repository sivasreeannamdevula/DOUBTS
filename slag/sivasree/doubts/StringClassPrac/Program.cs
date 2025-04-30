using System.Diagnostics;
using System.Text;
// //the below program shows that due to immutablility nature of strings they take more time for execution and hence 
// //the time in milliseconds is high
// class Str
// {
//     public static void Main()
//     {
//         Stopwatch stopwatch=new Stopwatch();
//         stopwatch.Start();
//         string s="immutable";
//       
//         for(int i=0;i<40000000;i++)
//         {
//            s=Guid.NewGuid().ToString();   //generates a new value for string
//          
//         }
//         stopwatch.Stop();
//         System.Console.WriteLine("time is {0}",stopwatch.ElapsedMilliseconds);
//     }
// }


// //the below program shows that due to mutablility nature of int they take less time for execution and hence 
// //the time in milliseconds is less compared to strings
// class Str
// {
//     public static void Main()
//     {
//         Stopwatch stopwatch=new Stopwatch();
//         stopwatch.Start();
        
//         int j=90;
//         for(int i=0;i<40000000;i++)
//         {
           
//            j++;
//         }
//         stopwatch.Stop();
//         System.Console.WriteLine("time is {0}",stopwatch.ElapsedMilliseconds);
//     }
// }



//the below program shows that due to interning nature of string they take less time for execution and hence 
//the time in milliseconds is less(no need to create any new object so no extra time)
class Str
{
    public static void Main()
    {
        Stopwatch stopwatch=new Stopwatch();
        stopwatch.Start();
        string s="sree";
        for(int i=0;i<40000000;i++)
        {
           s="sree";
        }
        stopwatch.Stop();
        System.Console.WriteLine("time is {0}",stopwatch.ElapsedMilliseconds);
    }
}



class Pro1
{
    static void Main(string[] args)
    {
        Stopwatch s=new Stopwatch();
        s.Start();
        //string str="siva";
        StringBuilder SB=new StringBuilder();
        for(int i=0;i<40000;i++)
        {
            //str=Guid.NewGuid().ToString();         //More time as each time new string gets memory allocation
            //str="siva";                            //due to interning nature,it takes less time
           // str="siva" +str;                      //as during appending new object gets created so more time
           SB.Append("sive");                       //stringbuilder so less time as same char[] is used instead of new memory
        }
        s.Stop();
        System.Console.WriteLine(SB);
        System.Console.WriteLine("THE TIME TOOK IS {0}",s.ElapsedMilliseconds);
    }
}