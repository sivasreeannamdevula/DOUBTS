using Newtonsoft.Json;
namespace UserLogic;
public class UserImplementation
{
   private Dictionary<string,User> userDetails=new Dictionary<string,User>();
   public int CreateUserAccount(string userName,User user)
    {
        LoadUserFromFile("C:/slagprac/slag/sivasree/26-9-24/DataBase/User.json");
        if(userDetails.ContainsKey(userName))
        {
           int flag=Authentication(userName,user);
            return flag;
        }
       
        userDetails[userName]=user;
        SaveUserToFile("C:/slagprac/slag/sivasree/26-9-24/DataBase/User.json");
        return 2;
    }

    public int Authentication(string userName,User user)
    {
       if(userDetails[userName].Password==user.Password && userDetails[userName].Email==user.Email)
       {
        return 1;
       }
       return 0;
    }

    public void SaveUserToFile(string fileName)
    {
       string json=JsonConvert.SerializeObject(userDetails);
       File.WriteAllText(fileName,json);
    }

    public void LoadUserFromFile(string fileName)
    {
        string json=File.ReadAllText(fileName);
        userDetails=JsonConvert.DeserializeObject<Dictionary<string,User>>(json);
        if(userDetails==null)
        {
            userDetails=new Dictionary<string,User>();
        }
    }

}