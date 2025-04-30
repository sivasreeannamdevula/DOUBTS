public static class TypeOfCar
{
    public static Car GetCarType(string userInput)
    {
        Car obj=null;
        if(userInput=="Maruthi")
        {
           obj=new Maruthi();
        }
        else if(userInput=="honda")
        {
            obj=new Honda();
        }
        else{
            obj=new Audi();
        }
        return obj;
    }
    
}