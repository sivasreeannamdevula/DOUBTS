class Q
{
    public static void Main()
    {
        int[,] arr=new int[3,2];
        
        int[,] arr2={{1,4},{5,8},{6,8}};
        
        for(int i=0;i<arr.GetLength(0);i++)
        {
            for(int j=0;j<arr.GetLength(1);j++)
            {
                System.Console.WriteLine(arr[i,j]);
            }
        }

        foreach(int i in arr)
        {
            System.Console.WriteLine(i);
        }
        
    }
}