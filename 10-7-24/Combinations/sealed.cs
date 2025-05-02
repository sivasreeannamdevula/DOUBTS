
//1.abstract-sealed COMBO
//not possible beacuse abstract needs implementation whereas sealed cannot be overriden that means 
//in child class we cannot have implementation for abstarct method.
// abstract class Parent
// {
//     public  abstract void MethodEx();
   
// }
// abstract class Child:Parent
// {
//     public  sealed override abstract void MethodEx();
    
// }

//2.//sealed-virtual COMBO
//with override we cannot use virtual because virtual method can be overriden where as sealed 
//cannot be overriden
// class Parent
// {
//     public  virtual void MethodEx()
//     {
//         System.Console.WriteLine("parent");
//     }
   
// }
// abstract class Child:Parent
// {
//     public  sealed override virtual void MethodEx()
//     {

//     }
    
// }

//3.Sealed-new COMBO
//for reimplementation we have to either use new/override but not both...
// class Parent
// {
//     public  virtual void MethodEx()
//     {
//         System.Console.WriteLine("parent");
//     }
   
// }
// abstract class Child:Parent
// {
//     public  sealed override new void MethodEx()
//     {

//     }
    
// }


//4.Sealed-override COMBO
//Its possible as it is the concept of sealed method.
// class Parent
// {
//     public  virtual void MethodEx()
//     {
//         System.Console.WriteLine("parent");
//     }
   
// }
// abstract class Child:Parent
// {
//     public  sealed override  void MethodEx()
//     {

//     }
    
// }

//5.Sealed-static COMBO
//not possible bcus sealed is relate to instance and static related to class
// class Parent
// {
//     public  virtual void MethodEx()
//     {
//         System.Console.WriteLine("parent");
//     }
   
// }
// abstract class Child:Parent
// {
//     public  sealed override static void MethodEx()
//     {

//     }
    
// }

//6.Sealed-partial COMBO
//its possible because partial class and normal class acts same
// class Parent
// {
//     public  virtual void MethodEx()
//     {
//         System.Console.WriteLine("parent");
//     }
   
// }
// partial class Child:Parent
// {
//     public  sealed override partial void MethodEx();
//     public sealed override  partial void MethodEx()
//     {
//        System.Console.WriteLine("he");
//     }

// }
