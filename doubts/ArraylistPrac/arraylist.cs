// using System.Collections;                        //namespace to use arraylist 
// class AL
// {
   
//     public static void Main()
//     {
//         //constructors available to create a arraylist in c#
//         //1.creates an empty arraylist with size 0  
//         ArrayList a=new ArrayList();
//         a.Add(3);                 //when we add first element size becomoes 4 from where it gets increased by *2
//                                   //when the array is full.
        
//         //2.creates a list with initial size=7
//         ArrayList b=new ArrayList(7);
//         b.Add(8);
//         b.Add(9);
//         b.Add(10);
//         //3.copy of existing arraylist
//         ArrayList c=new ArrayList(a);
//         System.Console.WriteLine("size of arraylist a {0}",a.Count);       //size==size of "a" arraylist


//         //adding elements into arraylist
//         a.Add("siva"); 
//         a.Add("siva");                          //we can add duplicates
//         a.Add(9.8);
//         a.Add(true);                            //we can add any datatype
//         a.Add(5);
//         Employee e=new Employee()
//         {
//             id=103,
//             name="sree"
//         };
//         a.Add(e);                              //we can also add custom objects
//         a.AddRange(b);
       


//        //Accessing elements of arraylist
//         int i=(int)a[0];                      //here a[0] is converted to int i.e; unboxing
//         string s=(string)a[1];
//         foreach(var v in a)
//         {
//             System.Console.WriteLine(v);
//         }



//         //size of arraylist
//         System.Console.WriteLine(a.Count);      //no.of elements
//         System.Console.WriteLine(a.Capacity);   //total elements it can contain


//         //insert at position 
//         a.Insert(1,"laxmana rao");
//         a.InsertRange(4,b);
        


//         //removing elements
//         a.Remove("laxmana rao");
//         a.RemoveAt(0);
//         a.RemoveRange(3,4);
//         a.Clear();
//         //System.Console.WriteLine(a.Capacity);

//         //exists or not
//         System.Console.WriteLine(  a.Contains("sr"));
//         //implicit type arraylist craetion + initialisation
//         var d=new ArrayList()
//         {
//             101,"ss",9.8,true
//         };



//     }
// }
// class Employee
// {
//     public int id;
//     public string name;
// }
