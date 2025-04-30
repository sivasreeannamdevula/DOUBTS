// //TrimExcess is same as TrimToSize

// class   GenQueue
// {
//     public static void Main()
//     {
//         Queue<int> q=new Queue<int>();
//         //to add elements to queue
//         q.Enqueue(3);
//         q.Enqueue(7);
//         q.Enqueue(37);
//         q.Enqueue(22);
        
//         //to remove elements from queue
//         q.Dequeue();
//         q.Dequeue();
//         q.Dequeue();
//         q.Dequeue();
//         //Accessing elements
//         // foreach(int i in q)
//         // {
//         //     System.Console.WriteLine(i);
//         // }

//         //System.Console.WriteLine("size of queue is {0}",q.Count);
//         //q.Clear();
//         //System.Console.WriteLine("size of queue is {0}",q.Count);
//         //System.Console.WriteLine("does queue contains {0}",q.Contains(373));
//         // int[] newArray=new int[q.Count];
//         // q.CopyTo(newArray,0);
//         // foreach(int x in newArray)
//         // {
//         //     System.Console.WriteLine(x);

//         // }
//         //System.Console.WriteLine(q.Count);

//         //it ensures that the internal array has a size >= ensurecapacity
//         //it successively inc the size by *2 until the above condition is met
       
//         //q.EnsureCapacity(6);
        
//         // IEnumerator<int> e=q.GetEnumerator();
//         // while(e.MoveNext())
//         // {
//         //     if(e.Current is int i)
//         //     {
//         //         System.Console.WriteLine(i);
//         //     }
//         // }

//         //System.Console.WriteLine(q.Peek());
//         // System.Console.WriteLine("to array method");
//         // int[] toArr=q.ToArray();
//         // foreach(int x in toArr)
//         // {
//         //     System.Console.WriteLine(x);
//         // }

//         // if(q.TryDequeue(out int result))
//         // {
//         //     System.Console.WriteLine("result is {0}",result);
//         // }
//         // else
//         // {
//         //     System.Console.WriteLine("empty");
//         // }

//         //  if(q.TryDequeue(out int resu))
//         // {
//         //     System.Console.WriteLine("result is {0}",resu);
//         // }
//         // else
//         // {
//         //     System.Console.WriteLine("empty");
//         // }
//         //  if(q.TryDequeue(out int res))
//         // {
//         //     System.Console.WriteLine("result is {0}",res);
//         // }
//         // else
//         // { 
//         //     System.Console.WriteLine("empty");            //as queue is empty we get this as output.for dequeue
//         //                                                   //we get exception if queue is empty and false if we
//         //                                                   //use tryDequeue
//         // }

//         // if(q.TryPeek(out int r))
//         // {
//         //     System.Console.WriteLine(r);
//         // }
//         // else{
//         //     System.Console.WriteLine("emptied");            //if queue is empty then as trypeek returns false
//         //                                                     //we get this else output.
//         // }


//     }
// }