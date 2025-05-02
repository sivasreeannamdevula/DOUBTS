using System.Collections.CustomGenerics;

public class Program
{

    public static void Main()
    {
       
        bool flag = true;
        GenericClass<Book> Library_Object= new GenericClass<Book>();
        Library_Object.LoadFromFile();
        do
        {
            System.Console.WriteLine("Please Enter your choice:-");
             Display d = new Display();
             d.DisplayMenu();
            char choice = Convert.ToChar(Console.ReadLine());
            switch (choice)
            {
                case '1':
                    Library_Object.Add();
                    break;
                case '2':
                    Library_Object.ViewAll();
                    break;
                case '3':
                    Library_Object.Update();
                    break;
                case '4':
                    Library_Object.Remove();
                    break;
                case '5':
                    List<Book> resultOfSearch = Library_Object.Search();
                   foreach(Book b in resultOfSearch)
                    {
                        System.Console.WriteLine(b.Title+" "+b.Author+" "+b.Genre+" "+b.Published_Year+" "+b.Id);
                    }
                    break;
                case '6':
                    Library_Object.Sort();
                    break;
                case '7':
                    Library_Object.SaveToFile();
                    break;
                case '8':
                    Library_Object.LoadFromFile();
                    break;
                case '9':
                    flag=false;
                    break;
                default:
                    System.Console.WriteLine("Enter correct value");
                    System.Console.WriteLine("would you like to continue or not?y/n");
                    string input=Console.ReadLine();
                    if(input=="n")
                    {
                        flag=false;
                    }
                    break;
            }
        }
        while (flag);

    }
}
