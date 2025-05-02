

public interface IBook
{
    public void Add(string title,string authorName,string Name,int Published_Year);
    public List<Book> Display();

    public bool Update(int id,Book book);
    public bool Remove(int id);

    public List<Book> Sort(string sortByProperty);


}