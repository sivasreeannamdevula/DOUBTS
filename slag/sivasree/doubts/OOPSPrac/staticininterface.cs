//  interface Bank
// {  
//     //STATIC FIELDS AND STATIC MEMBERS CAN BE WRITTEN IN INTERFACE 
//     //WE MAY GET A DOUBT LIKE INTERFACE DOESN'T CONTAIN ANY STATIC OR DEFAULT CTOR THEN WHO IS INITIALISING
//     //STATIC THOSE?CLR INITIALISING THOSE TO DEFAULT 0
//     static int e;    //STATIC FIELD
//     //WE CAN'T INITIALISE NON-STATIC FIELDS BECAUSE INTERFACES DOESN'T CONTAIN CONSTRCTORS
//    // int x=10;       //NON-STATIC FIELD
//     static Bank(){
//         e=8908;          //static ctors are possible in interface.
//     }
//     static void M()   //STATIC METHOD
//     {
//         System.Console.WriteLine(e);
//         System.Console.WriteLine("static M");
//     }
//     public void Add()
//     {
//         int x=90; //this is possible because these local variables are not intialised by any ctor
//         System.Console.WriteLine(x);
//         System.Console.WriteLine("addition");
//     }
//     void M1();
// }
// class In:Bank{
//    public void M1()
//    {
//     System.Console.WriteLine("M1 implementation");
//    }
// }
// class   Pro{
 
//      public static void Main(string[] args)
//      {
//         System.Console.WriteLine(Bank.e);
//         Bank.M();
//         In i=new In();
//         i.M1();
//         //i.M();  //as method is static  
//         //i.Add();  //since interface is not inheritance so interface concrete methods are not avaialable to In class
        
//         Bank b=new In(); 
//         b.Add();

//      }

// }




// // interfaces cannot be static bcus static means we cannot implement those in child class which is 
// // against interface definition.
// // static interface I
// // {
// //     void M();
// // }