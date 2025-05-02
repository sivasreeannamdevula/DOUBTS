

using TaskManagement.DataBase.Entities;


namespace TaskManagement.DataBase.Implementations;

public class TaskDictionary
{
   public Dictionary<string, List<TaskEntity>> list = new Dictionary<string, List<TaskEntity>>();
}
