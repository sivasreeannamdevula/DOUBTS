//  class Parent1
// {
//     public virtual void M()
//     {
//         System.Console.WriteLine("parent m");
//     }

// }
// class Child1:Parent1
// {
//     public sealed override void M()  //sealed and override must always be used as a combo
//     {
//         System.Console.WriteLine("child m");
//     }
// }





//  class Parent1
// {
//     public abstract void M();
   
// }
// class Child1:Parent1
// {
//     public sealed override void M()  //sealed can also be used with abstract
//     {
//         System.Console.WriteLine("child m");
//     }
// }








//  class Parent1
// {
//     public virtual void M()
//     {
//         System.Console.WriteLine("parent m");
//     }
// // 
// }
// class Child1:Parent1
// {
//     public  override void M()  
//     {
//         System.Console.WriteLine("child m");
//     }
// }
// class Child2:Child1{
//     public sealed override void M()  
//     {
//         System.Console.WriteLine("child m"); //sealed can also be used with override
//     }
// }


