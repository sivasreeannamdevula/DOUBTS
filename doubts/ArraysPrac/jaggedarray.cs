class J
{
    public static void Main()
    {
        //1.
        int[][] jag=new int[3][];
        jag[0]=new int[2];
        jag[1]=new int[3];
        jag[2]=new int[5];
        //2.
        int[][] jagged={
                    new int[]{8,7},
                    new int[]{5,9},
                    new int[]{7,0,9}
                   };
        for(int i=0;i<jag.GetLength(0);i++)
        {
            for(int j=0;j<jag[i].Length;j++)
            {
                jag[i][j]=Convert.ToInt32(Console.ReadLine());
            }
        }
        for(int i=0;i<jag.GetLength(0);i++)
        {
            for(int j=0;j<jag[i].Length;j++)
            {
                System.Console.Write(jag[i][j]);
            }
            System.Console.WriteLine();
        }

        foreach(var x in jag)
        {
            foreach(int i in x )
            {
                System.Console.Write(i);
            }
            System.Console.WriteLine();
        }
    }
}