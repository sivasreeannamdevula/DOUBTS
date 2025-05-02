
public class Synchronisation
{
     static int availableTickets=7;
    static Object obje=new Object();
    static void Main(string[] args)
    {
        
        Thread t1=new Thread(BookTickets)
        {
            Name="A"
        };
        t1.Start(4);
        Thread t2=new Thread(BookTickets)
        {
            Name="B"
        };
        t2.Start(3);
        Thread t3=new Thread(BookTickets)
        {
            Name="C"
        };
        t3.Start(2);
    }

    private static void BookTickets(object? obj)
    {
        
        int convertedint=Convert.ToInt32(obj);
       lock(obje)          //donot use the same lock object for different shared resources as it may cause deadlock 
       {
         if(convertedint<=availableTickets)
         {
            System.Console.WriteLine("booked for "+Thread.CurrentThread.Name+availableTickets);
            availableTickets=availableTickets-convertedint;
           

         }
         else{
            System.Console.WriteLine("no tickets available to book");
         }
       }
    }

   
}