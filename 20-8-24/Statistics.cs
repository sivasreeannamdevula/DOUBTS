public class Statistics<T>
{
    public static int InstanceCount{get;set;}
    public Statistics()
    {
        InstanceCount++;
    }
    public static void PrintType()
    {
        System.Console.WriteLine("The generic class is of type {0}",typeof(T).Name);
    }

}
