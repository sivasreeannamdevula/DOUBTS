public class BookImplementation
{
    private List<Book> list=new List<Book>();
    public void Add(Book newBook)
    {
        list.Add(newBook);
    }

    public Book getByID(int ID)
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

    public List<Book> Display()
    {
        return list;
    }
}