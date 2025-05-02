public class FactoryPattern
{
    static void Main(string[] args)
    {
    //the below commented code iS without using factory design pattern

        // Car obj=null;
        // if(userInput=="Maruthi")
        // {
        //    obj=new Maruthi();
        // }
        // else if(userInput=="honda")
        // {
        //     obj=new Honda();
        // }
        // else{
        //     obj=new Audi();
        // }
        // return obj;

       //this code is using factory pattern where the object creation logic is hidden from the client
        Car carobject=TypeOfCar.GetCarType("Audi");
        carobject.CarType();
        System.Console.WriteLine(carobject.Mailage());
        System.Console.WriteLine(carobject.Mailage());
    }
}
