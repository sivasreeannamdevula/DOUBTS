
using TaskManagement.DataBase.Implementations;
using TaskManagement.Services.DTO;
using TaskManagement.DataBase.Entities;
using AutoMapper;

namespace TaskManagement.Services.Implementations;

public class TaskImplementation : ITaskOperations
{
    private TaskDictionary _taskDictionaryObject;
    private ITaskDBOperations _taskDBOperations;
    private IMapper _mapper;
    public TaskImplementation(TaskDictionary taskDictionaryObj,ITaskDBOperations taskDBOperations,IMapper mapper)
    {
        _taskDictionaryObject = taskDictionaryObj;
        _taskDBOperations=taskDBOperations;
        _mapper=mapper;
    }

    //1.Task Creation
    public Dictionary<string, List<TaskEntity>> CreateTask(TaskModelDTO newTask, string userName)
    {
        TaskEntity taskEntity=_mapper.Map<TaskModelDTO,TaskEntity>(newTask);
        taskEntity.Id=Guid.NewGuid().ToString();
        List<TaskEntity> list=new List<TaskEntity>();
        if(_taskDictionaryObject.list.ContainsKey(userName))
        {
           list=_taskDictionaryObject.list[userName];
           list.Add(taskEntity);
           _taskDictionaryObject.list[userName]=list;
        }
        else{
            list.Add(taskEntity);
            _taskDictionaryObject.list[userName]=list;
        }
        return _taskDictionaryObject.list;
    }


    //Task Assignmentt
    public int TaskAssignment(string id, string assignToUserName, string currentUserName)
    {
        if (_taskDictionaryObject.list.ContainsKey(currentUserName) == null)
        {
            return 0;
        }
        List<TaskEntity> currentUserTasks = _taskDictionaryObject.list[currentUserName];
        List<TaskEntity> assignToUserTasks = (_taskDictionaryObject.list.ContainsKey(assignToUserName) == false) ? 
                                            new List<TaskEntity>() 
                                            : 
                                            _taskDictionaryObject.list[assignToUserName];
        bool flag = false;
        foreach (TaskEntity task in currentUserTasks)
        {
            if (task.Id.Equals(id))
            {
                assignToUserTasks.Add(task);
                currentUserTasks.Remove(task);
                flag = true;
                break;
            }
        
        }
        if (flag == false)
        {
            return -1;
        }
        _taskDictionaryObject.list[currentUserName] = currentUserTasks;
        _taskDictionaryObject.list[assignToUserName] = assignToUserTasks;
        
        return 1;
    }

    //Task Status Update
    public bool TaskStatusUpdate(string id, string statusUpdateTo, string currentUserName)
    {
        List<TaskEntity> currentTasks = _taskDictionaryObject.list[currentUserName];
        foreach (TaskEntity task in currentTasks)
        {
            if (task.Id.Equals(id))
            {
                task.Status = statusUpdateTo;
                _taskDictionaryObject.list[currentUserName] = currentTasks;
               
                return true;
            }
        }
        return false;
    }

    //Task Priority
    public bool SetTaskPriority(string id, string setPriorityTo, string currentUserName)
    {
        List<TaskEntity> currentTasks = _taskDictionaryObject.list[currentUserName];
        foreach (TaskEntity task in currentTasks)
        {
            if (task.Id.Equals(id))
            {
                task.Priority = setPriorityTo;
                _taskDictionaryObject.list[currentUserName] = currentTasks;

                return true;
            }
        }
        return false;
    }

    //DueDate setting

    public bool SetDueDate(string id, DateTime dueDate, string currentUserName)
    {
        List<TaskEntity> currentTasks = _taskDictionaryObject.list[currentUserName];
        foreach (TaskEntity task in currentTasks)
        {
            if (task.Id.Equals(id))
            {
                task.DueDate = dueDate;
                _taskDictionaryObject.list[currentUserName] = currentTasks;
                
                return true;
            }
        }
        return false;
    }


    //Comment
    public bool TaskCommenting(string id, string comment, string currentUserName)
    {
        List<TaskEntity> currentTasks = _taskDictionaryObject.list[currentUserName];
        foreach (TaskEntity task in currentTasks)
        {
            if (task.Id.Equals(id))
            {
                task.Comment = comment;
                _taskDictionaryObject.list[currentUserName] = currentTasks;
                
                return true;
            }
        }
        return false;
    }

    //save task to a file
    public void SaveTaskToFile()
    {
        _taskDBOperations.SaveTaskToFile();
    }

    //load task from a file
    public void LoadTaskFromFile()
    {
        _taskDBOperations.LoadTaskFromFile();
    }
}

 