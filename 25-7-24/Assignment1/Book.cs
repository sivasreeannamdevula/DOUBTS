

public class Book
{
    public int Id{get;set;}
    public string Title{get;set;}
    public string Author{get;set;}
    public string Genre{get;set;}
    public int Published_Year{get;set;}

    
    
    public static bool flag=false;
    
        // public int CompareTo(Book incomingObject)
        // {
            
        //     if(SortByinputProp==null)
        //     {
        //         System.Console.WriteLine("Enter the property acc to which you would like to sort");
        //         SortByinputProp=Console.ReadLine();
        //         flag=true;
        //     }
                      
        //     var propertyInfo=typeof(Book).GetProperty(SortByinputProp);
        //     if(SortByinputProp!=null && flag!=true)
        //     {
        //         SortByinputProp=null;
        //         flag=false;
        //     }
        //     return ((dynamic)propertyInfo.GetValue(this)).CompareTo((dynamic)propertyInfo.GetValue(incomingObject));
            
        // }
        

}