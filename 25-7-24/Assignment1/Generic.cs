using System.Collections.Generic;
using Newtonsoft.Json;

namespace System.Collections.CustomGenerics
{
    public class GenericClass<T> where T:new()
    {
       
        private List<T> list;
       public void Add()
        {
           T AnObjectOfTypeT = new T();
           
             foreach(var property in typeof(T).GetProperties())
             {
                System.Console.WriteLine("Enter the data for {0}",property.Name);
                string inputOfUser=Console.ReadLine();
                object inputConversion=Convert.ChangeType(inputOfUser,property.PropertyType);
                property.SetValue(AnObjectOfTypeT,inputConversion);
             }
             list.Add(AnObjectOfTypeT);
    
        }


        public void ViewAll()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return ;
            }

            foreach (T ObjectOfTypeT in list)
            {
                foreach (var property in ObjectOfTypeT.GetType().GetProperties())
                {
                    System.Console.WriteLine($"{property.Name}:{property.GetValue(ObjectOfTypeT)}");
                }
                System.Console.WriteLine();
            }
           
        }
        public List<T> Update()
        {
            try
            {
                System.Console.WriteLine("Enter the id of object which you would like to update");
                int idOfUpdatingObj = Convert.ToInt32(Console.ReadLine());
                foreach (var ObjectOfTypeT in list)
                {
                    foreach (var property in ObjectOfTypeT.GetType().GetProperties())
                    {
                        System.Console.WriteLine(property.Name);
                    }
                    break;
                }
                System.Console.WriteLine("Enter property to be changed");
                string? propertyToUpdate = Console.ReadLine();
                System.Console.WriteLine("Enter to which new value we should change");
                string? newValue = Console.ReadLine();
                foreach (var ObjectOfTypeT in list)
                {
                    foreach (var property in ObjectOfTypeT.GetType().GetProperties())
                    {
                        if (property.Name == "Id" && ((int)property.GetValue(ObjectOfTypeT)) == idOfUpdatingObj)
                        {
                            var updateProp = ObjectOfTypeT.GetType().GetProperty(propertyToUpdate);
                            if (updateProp != null)
                            {
                                updateProp.SetValue(ObjectOfTypeT, newValue);
                            }

                        }
                    }
                }
                
            }
            catch(Exception e)
            {
                System.Console.WriteLine("enter the valid");
            }
             return list;
           
        }


        public void Remove()
        {
            int flag=0;
            System.Console.WriteLine("Enter an id to remove");
            int idtobeRemoved = Convert.ToInt32(Console.ReadLine());
            foreach (var ObjectOfTypeT in list)
            {

                foreach (var property in ObjectOfTypeT.GetType().GetProperties())
                {
                  
                    if (property.Name == "Id" && ((int)property.GetValue(ObjectOfTypeT)==(idtobeRemoved)))
                    {
                        list.Remove(ObjectOfTypeT);
                        flag=1;
                        break;
                    }
                }
                if(flag==1)
                  break;
            }
        }



        public List<T> Search()
        {
            System.Console.WriteLine("Enter the property and its value to which u would like to search");
            string propertyToSearch = Console.ReadLine();
            string inputValue = Console.ReadLine();

            List<T> ans = new List<T>();
            foreach (var ObjectOfTypeT in list)
            {
                foreach (var property in ObjectOfTypeT.GetType().GetProperties())
                {
                    if (property.Name == propertyToSearch && property.GetValue(ObjectOfTypeT).Equals(inputValue))
                    {
                        System.Console.WriteLine("entered");
                        ans.Add(ObjectOfTypeT);
                    }
                }
            }

            return ans;
        }


        public void Sort()
        {
           list.Sort();

        }

        public bool SaveToFile()
        {
            string jsfrmt = JsonConvert.SerializeObject(list);
            File.WriteAllText("file.json", jsfrmt);
            return true;
        }

        public bool LoadFromFile()
        {
            if (File.Exists("file.json") )
            {
                var f = new FileInfo("file.json");
                if(f.Length==0)
                {
                    list=new List<T>();
                    return true;
                }
                string jsonfrmt = File.ReadAllText("file.json");
                list = JsonConvert.DeserializeObject<List<T>>(jsonfrmt);
            }
            else
            {
                list = new List<T>();
            }
            return true;
        }


    }
}


