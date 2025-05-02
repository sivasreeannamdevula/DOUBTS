using System;
using TaskManagement.DataBase.Entities;

namespace TaskManagement.DataBase.Implementations;

public class UserDictionary
{
    public Dictionary<string, UserEntity> userDetailsCollection = new Dictionary<string, UserEntity>();
}
