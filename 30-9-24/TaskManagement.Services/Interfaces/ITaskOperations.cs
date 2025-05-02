
using TaskManagement.Services.DTO;
using System.Reflection.Metadata;
using TaskManagement.DataBase.Entities;

public interface ITaskOperations
{
    public Dictionary<string, List<TaskEntity>> CreateTask(TaskModelDTO newTask, string userName);
    public int TaskAssignment(string id, string assignToUserName, string currentUserName);
    public bool TaskStatusUpdate(string id, string statusUpdateTo, string currentUserName);
    public bool SetTaskPriority(string id, string setPriorityTo, string currentUserName);

    public bool SetDueDate(string id, DateTime dueDate, string currentUserName);
    public bool TaskCommenting(string id, string comment, string currentUserName);
    public void SaveTaskToFile();
    public void LoadTaskFromFile();

}