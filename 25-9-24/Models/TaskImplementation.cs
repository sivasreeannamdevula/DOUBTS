public class TaskImplementation
{
   private List<Task> list=new List<Task>();
   static int id=1;
   //1.Task Creation
    public List<Task> CreateTask(Task newTask)
    {
        newTask.ID=id++;
        list.Add(newTask);
        return list;
    }

    //Task Assignment
    public Task TaskAssignment(int ID,string userName)
    {
       foreach(Task task in list)
       {
        if(task.ID==ID)
        {
            task.AssignedTo=userName;
            return task;
        }
       }
       return null;
    }

   //Task Status Update
    public Task TaskStatusUpdate(int ID,string statusUpdateTo)
    {
        foreach(Task task in list)
        {
            if(task.ID==ID)
            {
               task.StatusOfTask=statusUpdateTo;
               return task;
            }
        }
        return null;
    }

   //Task Priority
   public Task SetTaskPriority(int ID,string setPriorityTo)
   {
        foreach(Task task in list)
        {
            if(task.ID==ID)
            {
               task.Priority=setPriorityTo;
               return task;
            }
        }
        return null;
   }

   //DueDate setting
   
   public Task SetDueDate(int ID,string dueDate)
   {
        foreach(Task task in list)
        {
            if(task.ID==ID)
            {
               task.Priority=dueDate;
               return task;
            }
        }
        return null;
   }


   //Comment
   public Task TaskCommenting(int ID,string comment)
   {
      foreach(Task task in list)
        {
            if(task.ID==ID)
            {
               task.Comment=comment;
               return task;
            }
        }
        return null;
   }
   
}