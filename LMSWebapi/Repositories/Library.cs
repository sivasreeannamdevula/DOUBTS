public class Library : Book, IBook
{
    private List<Book> list = new List<Book>();
    private static int count=1;
    public void Add(string title,string authorName,string genre,int Published_Year )
    {
        Book newBook=new Book();
        newBook.ID=count++;
        newBook.Author=authorName;
        newBook.Title=title;
        newBook.Published_Year=Published_Year;
        newBook.Genre=genre;
        list.Add(newBook);
    }

    public bool Remove(int bookIdToDelete)
    {
        bool flag=false;
        foreach(Book book in list)
        {
            if (book.ID == bookIdToDelete)
            {
                list.Remove(book);
                flag=true;
                break;
            }
        }
        return flag;
    }

    public bool Update(int bookIdToUpdate,Book b)
    {
        bool flag=false;
        foreach(Book book in list)
        {
            if(book.ID==bookIdToUpdate)
            {
                list.Remove(book);
                flag=true;
                break;
            }
        }
        if(flag)
         {
            list.Add(b);
         }
        return flag;
    }

    public List<Book> Display()
    {
       if(list.Count==0)
       {
        return null;
       }    
       return list;
    
    }

    public Book DisplayByID(int ID)
    {
        foreach(Book book in list)
        {
            if(book.ID==ID)
            {
                return book;
                
            }
        }
       return null;
    }
     public List<Book> DisplayByAuthor(string Author)
    {
        List<Book> ans=new List<Book>();
        bool flag=false;
        foreach(Book book in list)
        {
            if(book.Author==Author)
            {
                ans.Add(book);
                flag=true;
            }
        }
        return flag?ans:null;
    }
     public List<Book> DisplayByGenre(string Genre)
    {
        List<Book> ans=new List<Book>();
        bool flag=false;
        foreach(Book book in list)
        {
            if(book.Genre==Genre)
            {
                ans.Add(book);
                flag=true;
            }
        }
        return flag?ans:null;
    }
     public List<Book> DisplayByPublished_Year(int Published_Year)
    {
        List<Book> ans=new List<Book>();
        bool flag=false;
        foreach(Book book in list)
        {
            if(book.Published_Year==Published_Year)
            {
                ans.Add(book);
                flag=true;
            }
        }
        return flag?ans:null;
    }

    public List<Book> Sort(string sortByProperty)
    {
      if(list.Count==0)
      {
        return null;
      }
      else
      {
        var propertyInfo=typeof(Book).GetProperty(sortByProperty);
        list=list.OrderBy(x=>propertyInfo.GetValue(x)).ToList();
        return list;
      }
    }

   
}