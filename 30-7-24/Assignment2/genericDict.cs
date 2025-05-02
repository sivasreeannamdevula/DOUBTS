class DictionaryWrapperClass<TKey, TValue> where TKey : class, new() where TValue : struct
{
    Dictionary<TKey, TValue> d = new Dictionary<TKey, TValue>();
    public void Adding()
    {
        TKey k1 = new TKey();
        foreach (var prop in k1.GetType().GetProperties())
        {
            System.Console.WriteLine("enter the {0} value", prop.Name);
            string s = Console.ReadLine();
            object o = Convert.ChangeType(s, prop.PropertyType);
            prop.SetValue(k1, o);
        }
        TValue k2 = new TValue();
        object temp = k2;
        foreach (var prop in typeof(TValue).GetProperties())
        {
            System.Console.WriteLine("entr the value for {0}", prop.Name);
            String s = Console.ReadLine();
            object? o = Convert.ChangeType(s, prop.PropertyType);
            prop.SetValue(temp, o);
        }
        k2 = (TValue)temp;
        d.Add(k1, k2);
    }
    public void Updating()
    {
        System.Console.WriteLine("what would u like to chage key/value?");
        string s = Console.ReadLine();
        s = s.ToLower();
        if (s == "key")
        {
            System.Console.WriteLine("Which property of key object would u like to change from the given properties");
            foreach (KeyValuePair<TKey, TValue> p in d)
            {
                foreach (var prop in p.Key.GetType().GetProperties())
                {
                    System.Console.WriteLine(prop.Name);
                }
            }
            string inputProp = Console.ReadLine();
            System.Console.WriteLine("enter the id of object whose prop u would like to change");
            int inputId = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<TKey, TValue> p in d)
            {
                foreach (var prop in p.Key.GetType().GetProperties())
                {
                    if (prop.Name == "id" && prop.GetValue(p.Key).Equals(inputId))
                    {
                        break;
                    }
                }
                System.Console.WriteLine("new value plz");
                string inp = Console.ReadLine();
                var property = typeof(TKey).GetProperty(inputProp);
                property.SetValue(p.Key, inp);
            }
        }

        if (s == "value")
        {
            System.Console.WriteLine("Which property of value object would u like to change from the given properties");
            foreach (KeyValuePair<TKey, TValue> p in d)
            {
                foreach (var prop in p.Value.GetType().GetProperties())
                {
                    System.Console.WriteLine(prop.Name);
                }
            }
            string inputProp = Console.ReadLine();
            System.Console.WriteLine("enter the id of object whose prop u would like to change");
            int inputId2 = Convert.ToInt32(Console.ReadLine());
            foreach (KeyValuePair<TKey, TValue> p in d)
            {
                foreach (var prop in p.Value.GetType().GetProperties())
                {
                    if (prop.Name == "id" && prop.GetValue(p.Value).Equals(inputId2))
                    {
                        break;
                    }
                }
                System.Console.WriteLine("new value plz");
                string inp = Console.ReadLine();
                object o = p.Value;
                var property = typeof(TValue).GetProperty(inputProp);
                property.SetValue(o, inp);
                //   p.Value=(TValue)o;
                d[p.Key] = (TValue)o;
            }
        }
    }

    public void Retrieve()
    {
        foreach (KeyValuePair<TKey, TValue> t in d)
        {
            foreach (var prop in t.Key.GetType().GetProperties())
            {
                System.Console.Write("the {0} is", prop.Name);
                System.Console.Write(prop.GetValue(t.Key) + "  ");
            }
            System.Console.WriteLine();
            System.Console.WriteLine();
            foreach (var prop in t.Value.GetType().GetProperties())
            {
                System.Console.Write("the {0} is", prop.Name);
                System.Console.Write(prop.GetValue(t.Value));
            }
            System.Console.WriteLine();
        }
    }
}