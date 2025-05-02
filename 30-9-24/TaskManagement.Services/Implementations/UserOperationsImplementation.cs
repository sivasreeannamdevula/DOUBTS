using AutoMapper;
using Newtonsoft.Json;
using TaskManagement.DataBase.Entities;
using TaskManagement.DataBase.Implementations;
using TaskManagement.Services.DTO;

namespace TaskManagement.Services.Implementations;



public class UserImplementation:IUserOperations
{
    private UserDictionary _userDictionaryObject;
    private IUserDBOperations _userDBOperations;
    private IMapper _mapper;
    public UserImplementation(UserDictionary userDictionaryObject,IUserDBOperations userDBOperations,IMapper mapper)
    {
        _userDictionaryObject=userDictionaryObject;
        _userDBOperations=userDBOperations;
        _mapper=mapper;
    }
    public int CreateUserAccount(string userName, UserModelDTO user)
    {

        UserEntity userEntityObject=_mapper.Map<UserModelDTO,UserEntity>(user);
        _userDBOperations.LoadUserFromFile();

        if (_userDictionaryObject.userDetailsCollection.ContainsKey(userName))
        {
            int flag = Authentication(userName, userEntityObject);
            return flag;
        }

        _userDictionaryObject.userDetailsCollection[userName] = userEntityObject;

        _userDBOperations.SaveUserToFile();
        return 2;
    }

    public int Authentication(string userName, UserEntity user)
    {
        if (_userDictionaryObject.userDetailsCollection[userName].Password == user.Password && _userDictionaryObject.userDetailsCollection[userName].Email == user.Email)
        {
            return 1;
        }
        return 0;
        

    }
 }
