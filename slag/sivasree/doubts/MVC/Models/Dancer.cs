public class Dancer
{
    public int ID;
    public string Name;

    public string DanceType;
}

public class DancerFunctionality
{
    List<Dancer> list=new List<Dancer>();

    public void AddDancer(Dancer obj)
    {
        list.Add(obj);
    }
    public Dancer GetDancerByName(string Name)
    {
        foreach(Dancer obj in list)
        {
            if(obj.Name==Name)
            {
                return obj;
            }
        }
        return null;
    }
}