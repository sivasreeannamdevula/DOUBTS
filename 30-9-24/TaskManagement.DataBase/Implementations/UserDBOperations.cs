using Newtonsoft.Json;
using TaskManagement.DataBase.Entities;
using TaskManagement.DataBase.Implementations;


public class UserDBOperations : IUserDBOperations
{
    private UserDictionary _userDictionary;
    public UserDBOperations(UserDictionary userDictionary)
    {
        _userDictionary=userDictionary;
    }
    public void LoadUserFromFile()
    {
        string json = File.ReadAllText("C:/slagprac/slag/sivasree/30-9-24/TaskManagement.DataBase/LocalDB/UserDB.json");
        _userDictionary.userDetailsCollection = JsonConvert.DeserializeObject<Dictionary<string, UserEntity>>(json);
        if (_userDictionary.userDetailsCollection == null)
        {
            _userDictionary.userDetailsCollection = new Dictionary<string, UserEntity>();
        }
     
    }

    public void SaveUserToFile()
    {
        string json = JsonConvert.SerializeObject(_userDictionary.userDetailsCollection);
        File.WriteAllText("C:/slagprac/slag/sivasree/30-9-24/TaskManagement.DataBase/LocalDB/UserDB.json", json);
    }
}
