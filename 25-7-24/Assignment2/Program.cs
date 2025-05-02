namespace NonGeneric;

public class Program
{

    public static void Main()
    {
       
        bool flag = true;
        NonGeneric Library_Object=new NonGeneric();
        do
        {
            System.Console.WriteLine("Please Enter your choice:-");
             Display display= new Display();
             display.DisplayMenu();
            
            try
            {
                char choice = Convert.ToChar(Console.ReadLine());
               switch (choice)
              {
                case '1':
                    Library_Object.InsertBook();
                    break;
                case '2':
                    Library_Object.DisplayBooks();
                    break;
                case '3':
                    Library_Object.UpdateBook();
                    break;
                case '4':
                    Library_Object.RemoveBook();
                    break;
                case '5':
                    List<Book> resultOfSearch = Library_Object.SearchBook();
                   foreach(Book b in resultOfSearch)
                    {
                        System.Console.WriteLine(b.Title+" "+b.Author+" "+b.Genre+" "+b.Published_Year+" "+b.Id);
                    }
                    break;
                case '6':
                    Library_Object.SortBooks();
                    break;
                case '7':
                    Library_Object.SaveBookToFile();
                    break;
                case '8':
                    Library_Object.LoadBookFromFile();
                    break;
                case '9':
                    flag=false;
                    break;
                default:
                    System.Console.WriteLine("You have entered wrong value");
                    System.Console.WriteLine("Would you like to continue or not?y/n");
                    string input=Console.ReadLine();
                    if(input=="n")
                    {
                        flag=false;
                    }
                    break;
            }  
        }
        catch(FormatException f)
        {
            System.Console.WriteLine("Clearly check the Formats of ur input");
        }
        } while (flag);    

    }
}
     



