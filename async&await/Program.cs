// public class AsyncAwait
// {
//     static  void Main(string[] args)
//     {
//          Method1();
//          Method2();
//     }
   
//     public async static Task Method1()
//     {
//         await Task.Delay(1);              //await pedthe that means current thread(main thread) gets back to where
//                                           //it called this method1 i.e; to line6 inorder to execute method2.
//                                           //if 1ms waiting time is finished that ctrl comes back to below for loop.
//         for(int i=0;i<8;i++)
//         {
//             System.Console.WriteLine("METHOD 1");
//         }
//     }
//     public static async Task Method2()
//     {
//         for(int i=0;i<59;i++)
//         {
//             System.Console.WriteLine("method 2");
//         }
//     }
// }



// C# program for await keyword 
using System; 
using System.Threading; 
using System.Threading.Tasks; 

public class GFG 
{ 

	static void Main(string[] args) 
	{ 

		Demo();
        //await Demo();             //this makes sure that until or unless Demo method executes the next line do 
                                    //not get executed. 
		Console.ReadLine(); 

	} 

	public static async void Demo() 
	{ 
		var watch = new System.Diagnostics.Stopwatch(); 
		watch.Start(); 

		var task1 = StartSchoolAssembly(); 
		await task1; 
		var task2 = TeachClass12(); 
		var task3 = TeachClass11(); 


		Task.WaitAll(task1, task2, task3); 
		watch.Stop(); 
		Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds}"); 

	} 


	public static async Task StartSchoolAssembly() 
	{ 
		await Task.Run(() => 
		{ 
			Thread.Sleep(8000); 
			Console.WriteLine("School Started"); 
		}); 
	} 


	public static async Task TeachClass12() 
	{ 
		await Task.Run(() => 
		{ 
			Thread.Sleep(3000); 
			Console.WriteLine("Taught class 12"); 
		}); 


	} 

	public static async Task TeachClass11() 
	{ 
		await Task.Run(() => 
		{ 
			Thread.Sleep(2000); 
			Console.WriteLine("Taught class 11"); 
		}); 


	} 

} 
