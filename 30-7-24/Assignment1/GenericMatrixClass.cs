// class Matrix<T> where T:struct
// {
//     List<List<T>> matrix=new List<List<T>>();
//     int rows;
//     int colsbfr=0;

//     bool isRectangleMatrix=true;

//     public void CreateMatrix()
//     { 
//         System.Console.WriteLine("enter the no.of rows");
//         rows=Convert.ToInt32(Console.ReadLine());
//         for(int j=0;j<rows;j++)
//         {
//             List<T> l=new List<T>();
//             System.Console.WriteLine("enter the no.of elements in {0}th row",j);
//             int colsafter=Convert.ToInt32(Console.ReadLine());
//             if(colsbfr!=0 && colsbfr != colsafter)
//             {
//                 isRectangleMatrix=false;
//             }
//             colsbfr=colsafter;
//             for(int k=0;k<colsafter;k++)
//             {
//                dynamic s=Console.ReadLine();
//             //    T d=(T)Convert.ChangeType(s,typeof(T));
//                l.Add(s);
//             }
//             matrix.Add(l);
//         }
//     }

//     public static List<List<T>> operator +(Matrix<T> m1,Matrix<T> m2)
//     {
//         List<List<T>> ans=new List<List<T>>();

//         if((m1.matrix.Count == m2.matrix.Count))
//         {
//             for(int i=0;i<m1.matrix.Count;i++)
//             {
//                 List<T> l=new List<T>();
//                 if(m1.matrix[i].Count == m2.matrix[i].Count)
//                 {
//                   for(int j=0;j<m1.matrix[i].Count;j++)
//                   {
//                     //as we cannot add two elements of Type T we should convert to dynamic
//                     l.Add((dynamic)m1.matrix[i][j] + (dynamic)m2.matrix[i][j]);
//                   }
//                   ans.Add(l);
//                 }
//                 else{
//                     System.Console.WriteLine("we cannot add matrices");
//                     ans.Clear();
//                     break;
//                 }
//             }
//         }
//         else
//         {
//             System.Console.WriteLine("matrices cannot be added");
//             ans.Clear();
//         }
//        return ans;
//     }
//      public static List<List<T>> operator -(Matrix<T> m1,Matrix<T> m2)
//     {
//         List<List<T>> ans=new List<List<T>>();

//         if((m1.matrix.Count == m2.matrix.Count))
//         {
//             for(int i=0;i<m1.matrix.Count;i++)
//             {
//                 List<T> l=new List<T>();
//                 if(m1.matrix[i].Count == m2.matrix[i].Count)
//                 {
//                   for(int j=0;j<m1.matrix[i].Count;j++)
//                   {
//                     l.Add((dynamic)m1.matrix[i][j] - (dynamic)m2.matrix[i][j]);
//                   }
//                   ans.Add(l);
//                 }
//                 else{
//                     System.Console.WriteLine("we cannot sub matrices");
//                     ans.Clear();
//                     break;
//                 }
//             }
//         }
//         else
//         {
//             System.Console.WriteLine("matrices cannot be subtracted");
//             ans.Clear();
//         }
//        return ans;
//     }

//     public static List<List<T>> operator *(Matrix<T> m1,Matrix<T> m2)
//     {
//         List<List<T>> ans=new List<List<T>>();
//         if(m1.isRectangleMatrix && m2.isRectangleMatrix)
//       {
//         if(m1.matrix[0].Count == m2.matrix.Count)
//         {
//              for(int i=0;i<m1.matrix.Count;i++)
//              {
//                 List<T> l=new List<T>();
//                 for(int j=0;j<m2.matrix[i].Count;j++)
//                 {
//                    T sum=default(T);
//                    for(int z=0;z<m1.matrix[i].Count;z++)
//                    {
//                      sum+=(dynamic)m1.matrix[i][z] * (dynamic)m2.matrix[z][j];
//                    }
//                    l.Add(sum);
//                 }
//                 ans.Add(l);
//              }
//         }
//         else{
//             System.Console.WriteLine("multiplication is not possible for the given arrays");
//             ans.Clear();
//         }
//       }
//     else{
//         System.Console.WriteLine("cannot be multiplied");
//         ans.Clear();
//     }
//         return ans;
//     }
// }
