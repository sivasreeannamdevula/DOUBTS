using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
namespace NonGeneric;
public class NonGeneric
{

    List<Book> list=new List<Book>();
    public static int id_tracker=0;
    public void InsertBook()
    {
        LoadBookFromFile();
        foreach(Book item in list)
        {
            if(item.Id > id_tracker)
            {
                id_tracker=item.Id;
            }
        }
        Book bookobj=new Book();
        System.Console.WriteLine("Enter title of the book");
        bookobj.Title=Console.ReadLine();
        System.Console.WriteLine("Enter author of the book");
        bookobj.Author=Console.ReadLine();
        System.Console.WriteLine("Enter genre of the book");
        bookobj.Genre=Console.ReadLine();
        bookobj.Id=++id_tracker;
        System.Console.WriteLine("Enter Published_Year of the book");
        bookobj.Published_Year=Convert.ToInt32(Console.ReadLine());

        list.Add(bookobj);

    }


    public void DisplayBooks()
    {
        if(list.Count==0)
        {
            System.Console.WriteLine("No books in library");
            return;
        }
        foreach(Book item in list)
        {
                System.Console.WriteLine("id is {0}",item.Id);
                System.Console.WriteLine("Title is {0}",item.Title);
                System.Console.WriteLine("Author is {0}",item.Author);
                System.Console.WriteLine("genre is {0}",item.Genre);
                System.Console.WriteLine("publishedyear is {0}",item.Published_Year);
                System.Console.WriteLine();
                
        }
    }

    public void UpdateBook()
    {
         System.Console.WriteLine("Enter the choice you would like to update");
         System.Console.WriteLine("1.Title");
         System.Console.WriteLine("2.Author");
         System.Console.WriteLine("3.Genre");
         System.Console.WriteLine("4.Published_Year");
         char choice=Convert.ToChar(Console.ReadLine());
          System.Console.WriteLine("Enter the BookId of book whose property you would like tochange");
          int IdOfUpdatingBook=Convert.ToInt32(Console.ReadLine());
         switch(choice)
         {
            case '1':
              System.Console.WriteLine("Enter the new Title");
               string newTitle=Console.ReadLine();
                foreach(Book item in list)
               {
                  if(item.Id==IdOfUpdatingBook)
                  {
                    item.Title=newTitle;
                    break;
                  }      
            
               }
               break;
            case '2':
          
               System.Console.WriteLine("Enter the new Author");
               string newAuthor=Console.ReadLine();
                foreach(Book item in list)
               {
                  if(item.Id==IdOfUpdatingBook)
                  {
                    item.Author=newAuthor;
                    break;
                  }      
            
               }
               break;
            case '3':
               
               System.Console.WriteLine("Enter the new Genre");
               string newGenre=Console.ReadLine();
                foreach(Book item in list)
               {
                  if(item.Id==IdOfUpdatingBook)
                  {
                    item.Genre=newGenre;
                    break;
                  }      
            
               }
               break;
            case '4':
           
               System.Console.WriteLine("Enter the new published_year");
               int newPublishedYear=Convert.ToInt32(Console.ReadLine());
                foreach(Book item in list)
               {
                  if(item.Id==IdOfUpdatingBook)
                  {
                    item.Published_Year=newPublishedYear;
                    break;
                  }      
            
               }
               break;
            default:
            System.Console.WriteLine("Enter the correct choice");
             break;
         }
    }

    public void RemoveBook()
    {
         System.Console.WriteLine("Enter the id of book you would like to remove");
         int inputId=Convert.ToInt32(Console.ReadLine());
        if (list.Count == 0)
        {
            System.Console.WriteLine("books are unavailable to Delete");
            return;
        }
               foreach(Book item in list)
               {
                  if(item.Id==inputId)
                  {
                    list.Remove(item);
                    break;
                  }      
                  
               }
    }
    public void SortBooks()
    {
        System.Console.WriteLine("Enter the choice acc to which you would like to sort");
        System.Console.WriteLine("1.Title");
        System.Console.WriteLine("2.Author");
        System.Console.WriteLine("3.Genre");
        System.Console.WriteLine("4.Published year");
        System.Console.WriteLine("5.ID");
        char ch=Convert.ToChar(Console.ReadLine());
        switch(ch)
        {
            case '1':
                   list=list.OrderBy(x=>x.Title).ToList();
                   break;
            case '2':
                   list=list.OrderBy(x=>x.Author).ToList();
                   break;
            case '3':
                   list=list.OrderBy(x=>x.  Genre).ToList();
                   break;
            case '4':
                  list=list.OrderBy(x=>x.Published_Year).ToList();
                  break;
            case '5':
            list=list.OrderBy(x=>x.Id).ToList();
            break;
            default:
            System.Console.WriteLine("Enter valid choice");
            break;
        }

    }
    public List<Book> SearchBook()
    {
        List<Book> ans=new List<Book>();
        System.Console.WriteLine("Enter the choice acc to which you would like to search");
        System.Console.WriteLine("1.Title");
        System.Console.WriteLine("2.Author");
        System.Console.WriteLine("3.Genre");
        System.Console.WriteLine("4.Published_Year");
        char ch=Convert.ToChar(Console.ReadLine());
        
        switch(ch)
        {
            case '1':
              System.Console.WriteLine("Enter book title you would like to search");
              string UserInputTitle=Console.ReadLine();
              if(string.IsNullOrEmpty(UserInputTitle))
              {
                System.Console.WriteLine("Donot give null as input");
                break;
              }
              foreach(Book item in list)
              {
                if(item.Title==UserInputTitle)
                {
                    ans.Add(item);
                }
              }
            break;
            case '2':
               System.Console.WriteLine("Enter book author you would like to search");
                string UserInputAuthor=Console.ReadLine();
                  if(string.IsNullOrEmpty(UserInputAuthor))
              {
                System.Console.WriteLine("Donot give null as input");
                break;
              }
              foreach(Book item in list)
              {
                if(item.Author==UserInputAuthor)
                {
                    ans.Add(item);
                }
              }
            break;
            case '3':
               System.Console.WriteLine("Enter book genre you would like to search");
                 string UserInputGenre=Console.ReadLine();
                
                  if(string.IsNullOrEmpty(UserInputGenre))
                {
                System.Console.WriteLine("Donot give null as input");
                break;
                }
               foreach(Book item in list)
              {
                if(item.Genre==UserInputGenre)
                {
                    ans.Add(item);
                }
              }
            break;
            case '4':
               System.Console.WriteLine("Enter book published_year you would like to search");
               int UserInputYear=Convert.ToInt32(Console.ReadLine());
               
               foreach(Book item in list)
              {
                if(item.Published_Year==UserInputYear)
                {
                    ans.Add(item);
                }
              }
            break;
            default:
            System.Console.WriteLine("enter the correct choice");
            break;
        }
        return ans;
    }
   
    

   

     public bool SaveBookToFile()
     {
        string jsfrmt=JsonConvert.SerializeObject(list);
        File.WriteAllText("file.json",jsfrmt);
        return true;
     }

     public bool LoadBookFromFile()
     {
        if(File.Exists("file.json"))
        {
            string jsonfrmt=File.ReadAllText("file.json");
            list=JsonConvert.DeserializeObject<List<Book>>(jsonfrmt);
        }
        else
        {
          
           list=new List<Book>();
        }
        return true;
     }


}


