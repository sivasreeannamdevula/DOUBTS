//in general to make non-generic or generic collections thread safe we have 
//arraylist,hashtable,queue can be synchronised by synchronised method
//dictionary by using lock concept

//diff btw ToArray and CopyTo is we can copy from certain index in ToArray

//0 to 4 velthadhi ga size...aa  tarvtha 4*2 =8 avvudhi ga,
//ippudu only 6 elements unnay anuko...queue to...appudu trimtosize 
//chesthe 6 avvudhi size...from now again 6*2=12  ala increases
 
using System.Collections;
using System.ComponentModel.DataAnnotations;
class QueueMethods
{
    public static void Main(string[] args)
    {
        Queue q=new Queue();
        //Adding elements to queue
        q.Enqueue(2);
        q.Enqueue("sivasree");
        q.Enqueue(3.8);
        q.Enqueue(true);
        q.Enqueue('a');
        q.Enqueue(5);

        //removing elements from queue using FIFO fashion
        q.Dequeue();
        q.Enqueue(9);

    //     //Accessing from queue
    //     foreach(var v in q)
    //     {
    //         System.Console.WriteLine(v);
    //     }

    //     //no.of elements in queue
    //     System.Console.WriteLine("No.of elements is {0}",q.Count);

    //     //whether threadsafe or not i.e; collection has the inbuilt mechanism to handle multiple threads
    //     //...by default false
    //    Queue q1=new Queue();               
    //    q1=Queue.Synchronized(q1);          //we are making queue threadsafe externally using synchronised method
    //    System.Console.WriteLine("BFR Q IS {0}",q.IsSynchronized);       //returns false as q isn't sync
    //    System.Console.WriteLine("AFTR QUEUE IS {0}",q1.IsSynchronized);  

    //     //syncroot method returns an object which can be used as lock 
    //     object o=q.SyncRoot;
    //     System.Console.WriteLine(o);

    //     //removes all objects in queue
    //     q.Clear();
    //     System.Console.WriteLine("aftr clearing");
    //     foreach(var v in q)
    //     {
    //         System.Console.WriteLine(v);
    //     }

    //     Queue newqueue=(Queue)q.Clone();
    //     System.Console.WriteLine("after cloning");
    //     foreach(var v in newqueue)
    //     {
    //         System.Console.WriteLine(v);
    //     }

    //     System.Console.WriteLine(q.Contains(3.83));
    //     object[] i=new object[q.Count+9];
    //     q.CopyTo(i,4);
    //     System.Console.WriteLine("array");
    //     for(int j=0;j<i.Length;j++)
    //     {
    //        System.Console.WriteLine(i[j]);
    //     }

    //     IEnumerator e=q.GetEnumerator();
    //     System.Console.WriteLine("using enumerator");
    //     while(e.MoveNext())
    //     {
    //         System.Console.WriteLine(e.Current);
    //     }
    //     System.Console.WriteLine("peek element is {0}",q.Peek());


    //     object[] qnew=q.ToArray();
    //     System.Console.WriteLine("using toarray method");
    //     foreach(object ob in qnew)
    //     {
    //         System.Console.WriteLine(ob);
    //     }
    //     System.Console.WriteLine("bfr trimming {0}",q.Count);
    //     q.TrimToSize();
    //     System.Console.WriteLine("aftr trimming {0}",q.Count);

        // q.ToString();
        // foreach(string v in q)
        // {
        //     System.Console.WriteLine(v);
        // }
        System.Console.WriteLine(string.Join(", ",q));
        System.Console.WriteLine(q);

    }
}


