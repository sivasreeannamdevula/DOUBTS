using System.Text;
public class ShapeManager
{
    private Dictionary<string, StringBuilder> _shapeStore = new Dictionary<string, StringBuilder>();
    public void AddShape(string name, string description)
    {
        try
        {

            if (_shapeStore.ContainsKey(name))
            {
                throw new KeyExistsException();
            }
            else
            {
                StringBuilder desc = new StringBuilder(description);
                desc.AppendLine($"Name is {name}");
                desc.AppendLine($"descprition is {description}");
                _shapeStore[name] = desc;
            }
        }
        catch (KeyExistsException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    public StringBuilder GetShapeDesciption(string name)
    {
        return _shapeStore[name];
    }
}