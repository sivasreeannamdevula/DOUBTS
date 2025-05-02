

using Newtonsoft.Json;
using TaskManagement.DataBase.Implementations;
using TaskManagement.DataBase.Entities;
public class TaskDBOperations : ITaskDBOperations
{
    private TaskDictionary _taskDictionary;
    public TaskDBOperations(TaskDictionary taskDictionary)
    {
        _taskDictionary=taskDictionary;
    }
    public  void LoadTaskFromFile()
    {
        string json = File.ReadAllText("C:/slagprac/slag/sivasree/30-9-24/TaskManagement.DataBase/LocalDB/TaskDB.json");
        _taskDictionary.list = JsonConvert.DeserializeObject<Dictionary<string, List<TaskEntity>>>(json);
        if (_taskDictionary.list == null)
        {
            _taskDictionary.list = new Dictionary<string, List<TaskEntity>>();
        }
    }

    public  void SaveTaskToFile()
    {
        string json = JsonConvert.SerializeObject(_taskDictionary.list);
        File.WriteAllText("C:/slagprac/slag/sivasree/30-9-24/TaskManagement.DataBase/LocalDB/TaskDB.json", json);
    }
}