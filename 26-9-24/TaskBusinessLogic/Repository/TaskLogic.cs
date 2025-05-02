using Newtonsoft.Json;

namespace TaskLogic;

public class TaskImplementation
{
   private Dictionary<string,List<TaskModel>> list=new Dictionary<string,List<TaskModel>>();
 
   //1.Task Creation
    public Dictionary<string,List<TaskModel>> CreateTask(TaskModel newTask,string userName)
    {

        List<TaskModel> temp1;
        if(list.ContainsKey(userName))
        {
           temp1=list[userName];
           newTask.Id=temp1.Count+1;
           temp1.Add(newTask);
           list[userName]=temp1;
        }
        else
        {    temp1=new List<TaskModel>();
             newTask.Id=1;
              temp1.Add(newTask);
             list[userName]=temp1;
        }
     
       return list;
    }


    //Task Assignment
    public int TaskAssignment(int ID,string assignToUserName,string currentUserName)
    {
       if(list.ContainsKey(currentUserName)==null )
       {
         return 0;
       }
       List<TaskModel> currentUserTasks=list[currentUserName];
       List<TaskModel> assignToUserTasks=(list.ContainsKey(assignToUserName)==false)?new List<TaskModel>() : list[assignToUserName];
       bool flag=false;
       foreach(TaskModel task in currentUserTasks)
       {
         if(task.Id==ID)
         {
            task.Id=assignToUserTasks.Count+1;
            assignToUserTasks.Add(task);
            currentUserTasks.Remove(task);
            flag=true;
            break;
         }
         
      }
      if(flag==false)
      {
        return -1;
      }
       list[currentUserName]=currentUserTasks;
       list[assignToUserName]=assignToUserTasks;
       return 1;
    }

   //Task Status Update
    public bool TaskStatusUpdate(int ID,string statusUpdateTo,string currentUserName)
    {
       List<TaskModel> currentTasks=list[currentUserName];
       foreach(TaskModel task in currentTasks)
       {
         if(task.Id==ID)
         {
           task.Status=statusUpdateTo;
           list[currentUserName]=currentTasks;
           return true;
         }
       }
       return false;
    }

   //Task Priority
   public bool SetTaskPriority(int ID,string setPriorityTo,string currentUserName)
   {
        List<TaskModel> currentTasks=list[currentUserName];
       foreach(TaskModel task in currentTasks)
       {
         if(task.Id==ID)
         {
           task.Priority=setPriorityTo;
           list[currentUserName]=currentTasks;
           return true;
         }
       }
       return false;
   }

   //DueDate setting
   
   public bool SetDueDate(int ID,DateTime dueDate,string currentUserName)
   {
       List<TaskModel> currentTasks=list[currentUserName];
       foreach(TaskModel task in currentTasks)
       {
         if(task.Id==ID)
         {
           task.DueDate=dueDate;
           list[currentUserName]=currentTasks;
           return true;
         }
       }
       return false;
   }


   //Comment
   public bool TaskCommenting(int ID,string comment,string currentUserName)
   {
     List<TaskModel> currentTasks=list[currentUserName];
       foreach(TaskModel task in currentTasks)
       {
         if(task.Id==ID)
         {
           task.Comment=comment;
           list[currentUserName]=currentTasks;
           return true;
         }
       }
       return false;
   }
   
   //save task to a file
   public void SaveTaskToFile(string fileName)
   {
      string json=JsonConvert.SerializeObject(list);
      File.WriteAllText("C:/slagprac/slag/sivasree/26-9-24/DataBase/Task.json",json);
   }

   //load task from a file
   public void LoadTaskFromFile(string fileName)
   {
      string json=File.ReadAllText("C:/slagprac/slag/sivasree/26-9-24/DataBase/Task.json");
      list=JsonConvert.DeserializeObject<Dictionary<string,List<TaskModel>>>(json);
      if(list==null)
      {
        list=new Dictionary<string,List<TaskModel>>();
      }
   }


}