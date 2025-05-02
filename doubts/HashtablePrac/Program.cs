using System.Collections;
class H
{
    public static void Main()
    {
        //creation
        Hashtable h1=new Hashtable();
      
        //adding elements
        h1.Add(1,"sree");
        h1.Add("siva","sree");
        h1.Add(1.9,"chaitu");
        h1.Add(11,4);
        h1.Add(10,true);
        //or
        //h1[8]="roja";

        //both creation and adding in single flow
        var h2=new Hashtable()
        {
            {2,"sree"},
            {3,4},
            {true,"akira"}
        };


        //accessing
       System.Console.WriteLine(h1[8]);
        foreach(object o in h1.Keys)
        {
            System.Console.WriteLine(h1[o]);
        }
        foreach(DictionaryEntry d in h1)
        {
            System.Console.WriteLine(d.Key + " " + d.Value);
        }
        

        //exists or not
        System.Console.WriteLine(h1.Contains("sree"));
       System.Console.WriteLine(h1.ContainsKey(1));
       System.Console.WriteLine(h1.ContainsValue("sreep"));

       //Removing elements
       h1.Remove(1);
       System.Console.WriteLine("bfr");
        foreach(object o in h1.Keys)
        {
            System.Console.Write(h1[o]);
        }
       h1.Clear();
       System.Console.WriteLine("after");
        foreach(object o in h1.Keys)
        {
            System.Console.WriteLine(h1[o]);
        }


        //size
        System.Console.WriteLine(h1.Count);
        //update
        h1["siva"]="me";

        //clone
        Hashtable cloned=(Hashtable)h1.Clone();

        //copying hashtable to array
        //way 1
        DynamicEntry d=new DynamicEntry(h1.Count);
        h1.CopyTo(d,0);
        foreach(DictionaryEntry d in h1)
        {
            System.Console.WriteLine(d.Key + " " + d.Value);
        }

        //way 2
        Object[] ks=new Object[h1.Count];
        //copies only keys to ks array
        h1.Keys.CopyTo(keys,0);
        Object[] vs=new Object[h1.Count];
        //copies only values to vs array
        h1.Values.CopyTo(keys,0);



    }
}
