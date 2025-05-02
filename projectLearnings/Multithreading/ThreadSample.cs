using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading
{
    public class ThreadSample
    {
        public static void Main()
        {
            ////three diff ways to create THREAD instance 
            // Thread t1=new Thread(Method1);

            // //this is what happens behind the scenes
            // //as ThreadStart is a delegate,first its instance gets created and then method gets registered to it,same how we invoke delegate
            // ThreadStart ts = new ThreadStart(Method1);
            // Thread t2 = new Thread(ts);

            // //error bcus threadstart can only accepts methods that have 0 parameters and return type is void
            // //Thread t3 = new Thread(new ThreadStart(Method2));
            // ThreadSample sample = new ThreadSample();
            // Thread t6 = new Thread(new ParameterizedThreadStart(sample.Method2));
            // //while invoking we have to pass the input parameter value
            // t6.Start(4);

            // //this start internally invokes ts.Invoke() which means the method1 that is being pointed gets executed
            // t1.Start();


            // //we can also pass anonymous method 
            // Thread t4 = new Thread(delegate()
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         Console.WriteLine(i);
            //     }
            // });

            // //we can also pass lambda function
            // Thread t5 = new Thread(() =>
            // {
            //     Console.WriteLine("jd");
            // });




            //calling 
            Helper h = new Helper(2, 3);
            Thread demo = new Thread(h.MethodHelper);
            demo.Start();
            Console.WriteLine(h.result);
        }

        static void Method1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method1 ", i);
            }
        }

        public void Method2(object j)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Method2 ", i);
            }
        }
    }
}










//Thread class which is in System.Thread is used to create threads
//Thread class contains 4 ctors that accepts one parameter as delegate type
//Delegate bcus whenever thread is statred we have to invoke the corresponding method registered to it
//but ThreadStart and ParameterisedTHreadStart returns void and takes in 0,1 paramter respectivley
//then how to register other methods that have different signatures?---create a helper class and do as below

class Helper
{
    private int n1;
    private int n2;
    public int result ;

    public Helper(int n1, int n2)
    {
        this.n1 = n1;
        this.n2 = n2;
       
    }

    public void MethodHelper()
    {
        for(int i = 0;i<n1 && i<n2;i++)
        {
            Console.WriteLine("heyy");
        }
        result = n1+n2;
    }
}
