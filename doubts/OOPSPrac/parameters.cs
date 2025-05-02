// // using System.Runtime.InteropServices;  //to use [Optional] kwyword
// // // pass by value
// // // in this new memory is allocated for k and new memory for i..after the end of SomeMethod call k memory 
// // // is deallocated

// // class x
// // {
// //     public static void SomeMethod(int k)
// //     {
// //         k=90;
// //     }
// //     public static void Main()
// //     {
// //         int i=9;
// //         SomeMethod(i);
// //         System.Console.WriteLine("value of i after methodcall {0}",i);
// //     }
// // }


// // // pass by reference
// // // here k and i point to the same memory location
// ////must be initialised bfr passing to method
// // class x
// // {
// //     public static void SomeMethod(ref int k)
// //     {
// //         k=908;
// //     }
// //     public static void Main()
// //     {
// //         int i=9;
// //         SomeMethod(ref i);
// //         System.Console.WriteLine("value of i after methodcall {0}",i);
// //     }
// // }


// // // out keyword
// // // if we want a method to return multiple oytputs then we use out keyword
// // //out no need to initialise bfr passing
// // class x
// // {
// //     public static void SomeMethod(int k,int l,out int s,out int p)
// //     {

// //         s=k+l;
// //         p=k*l;
// //     }
// //     public static void Main()
// //     {
// //         int i=9;
// //         int j=8;
// //         int sum=0;
// //         int product=0;
// //         SomeMethod(i,j,out sum,out product);
// //         System.Console.WriteLine("sum={0}  product={1}",sum,product);
// //     }
// // }


// // // params keyword
// // // it must be the last arguement
// // // we cannot have more than one params as input to the method
// // // we can send 0/any number of arguements to the params parameter
// // class x
// // {
// //     public static void SomeMethod(params int[] n)
// //     {
// //         System.Console.WriteLine(n.Length);
// //     }
// //     public static void Main()
// //     {
// //         int[] x={6,7};
// //         SomeMethod(9,8,7,6,5,4);
// //         SomeMethod();
// //         SomeMethod(x);
// //     }
// // } 

// // // default
// // // defaultly we will set a value to the input of method,its optional to send again in the method call
// // //if we didn't send it will take the default value
// // class x
// // {
// //     public static void SomeMethod(int k,int b=78,double f=5.8)
// //     {
// //         System.Console.WriteLine(k);
// //     }
// //     public static void Main()
// //     {

// //         SomeMethod(7);               //b,f parameters are optional to send
// //         SomeMethod(8,89);            //f is optioanl to send as parameter
// //         SomeMethod(1,4,8.9);
// //     }
// // }


// // // named paramters
// // // we can change the order of parameters while calling  the method
// // class x
// // {
// //     public static void SomeMethod(int k,double d)
// //     {
// //         System.Console.WriteLine("integer is {0},double is {1}",k,d);
// //     }
// //     public static void Main()
// //     {
// //         SomeMethod(d:6.8,k:6);
// //     }
// // }



// // //OPTIONAL PARAMETERS
// // //We can achieve this in 4 ways
// // //1.using params
// // class x
// // {
// //     public static void SomeMethod(int a,int b,params int[] n)
// //     {
// //         System.Console.WriteLine(n.Length);
// //     }
// //     public static void Main()
// //     {
// //         int[] x={6,7};
// //         //params parameter is optional
// //         SomeMethod(9,8,7,6,5,4);   
// //         SomeMethod(1,2);
// //         SomeMethod(2,3,x);
// //     }
// // } 

// // using method overloading


// // class x
// // {
// //     public static void SomeMethod(int a,int b)
// //     {
// //         System.Console.WriteLine("2 params");
// //     }
// //     public static void SomeMethod(int a,int b,int[] n)
// //     {
// //         System.Console.WriteLine(">2 parameters");
// //     }
// //     public static void Main()
// //     {
// //         int[] x={6,7};
// //         SomeMethod(9,8);
// //         SomeMethod(4,7);
// //         SomeMethod(6,7,x);
// //     }
// // } 


// // //3.using defaults
// // //in this optioanl must be the LAST parameter

// // class x
// // {
// //     public static void SomeMethod(int k,int b=78,double f=5.8)
// //     {
// //         System.Console.WriteLine(k);
// //     }
// //     public static void Main()
// //     {
        
// //         SomeMethod(7);               //b,f parameters are optional to send
// //         SomeMethod(8,89);            //f is optioanl to send as parameter
// //         SomeMethod(1,4,8.9);
// //     }
// // }

// // //4.using optional attribute in System.Runtime.InteropServices


// // class X
// // {
// //     public static void SomeMethod(int k,[Optional] double f,int b=78)
// //     {
// //         System.Console.WriteLine(k);
// //     }
// //     public static void Main()
// //     {
        
// //         SomeMethod(7);              
// //         SomeMethod(8,89);            
// //         SomeMethod(1,4,8);
// //     }
// // }



// // //in parameter

// // class x{
// //     public static void Method(in int x)
// //     {
// //       x=89;                            //in are readonly that is we cannot change them and they are also pass by reference
// //     }
// //     public static void Main(String[] args)
// //     {
// //         int x=90;
// //         Method(x);
// //     }
// // }




// //ref,out,in,params all are pass by reference.
// //here in c# there is no pointers concept instead scope gets increased and decreased
// class Scope
// {
//     static void M(ref int y)
//     {
//        y=87;
//     }
//     public static void Main()
//     {
//         int x=90;        //here scope of x is only upto main method but as we passed to M method scope
//                          //gets extended to M Method too.
//         M(ref x);
//     }
// }