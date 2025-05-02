using System.Collections;
class D
{
    public static void Main()
    {
        Dictionary<int,string> d=new Dictionary<int, string>();
        d.Add(1,"veerraju");
        d.Add(2,"nagamani");
        d.Add(3,"chaitanya");
        d[4]="roja";
        d[5]="sivasree";

        //accessing
        // foreach(KeyValuePair<int,string> k in d)
        // {
        //     System.Console.WriteLine(k.Key + " " +k.Value);
        // }
        // for(int i=0;i<d.Count;i++)
        // {
        //     int key=d.Keys.ElementAt(i);
        //     System.Console.WriteLine(d[key]);
        // }
        //d.AsParallel().ForAll(entry=>System.Console.WriteLine(entry.Key+" "+entry.Value));
        // IDictionaryEnumerator e=d.GetEnumerator();
        // while(e.MoveNext())
        // {
        //     System.Console.WriteLine(e.Key+" "+e.Value);
        // }

        //size
        // System.Console.WriteLine(d.Count);

        //exists or not
        // System.Console.WriteLine(d.ContainsKey(1));
        // System.Console.WriteLine(d.ContainsValue("veerraju"));

        //Remove
        // d.Remove(3);
        // d.Clear();
        string t="siva";
        if(!d.TryGetValue(1,out t))
        {
            d[1]="nagasai";
            System.Console.WriteLine(t);
            System.Console.WriteLine("not found");
        }
        else{
            System.Console.WriteLine("found");
        }

    }
}
