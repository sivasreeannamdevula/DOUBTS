using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class TaskController:ControllerBase
{
    //Dependency Injection
     private TaskImplementation _taskObject;
     private UserImplementation _userObject;
     public TaskController(TaskImplementation taskObject,UserImplementation userObject)
     {
        _taskObject=taskObject;
        _userObject=userObject;
     }
     
     [HttpPost("{username}/{email}")]
     public IActionResult CreateUserAccount([FromRoute]string? username,[FromRoute]string email)
     {
        _userObject.CreateUserAccount(username,email);
        return Ok();
     }
     
    [HttpPost("{username}/{password}")]
     public IActionResult UserLogin([FromRoute]string? username,[FromRoute]string password)
     {
        _userObject.UserLogin(username,password);
        return Ok();
     }
     [HttpPost]
     public List<Task> Create([FromBody]Task newTask)
     {
       return  _taskObject.CreateTask(newTask);
     }
      
    [HttpPost("{ID}/{userName}")]
     public IActionResult TaskAssignmentController([FromRoute]int ID,[FromRoute]string userName)
     {
        if(_taskObject.TaskAssignment(ID,userName)==null)
        {
            return BadRequest();
        }
       return Ok(_taskObject.TaskAssignment(ID,userName));
     }
    
     [HttpPost("{ID}/{statusUpdateTo}")]
     public IActionResult TaskStatusUpdateController([FromRoute]int ID,[FromRoute]string statusUpdateTo)
     {
         if(_taskObject.TaskAssignment(ID,statusUpdateTo)==null)
        {
            return BadRequest();
        }
       
        return Ok(_taskObject.TaskStatusUpdate(ID,statusUpdateTo));
     }
  
     [HttpPost("{ID}/{setPriorityTo}")]
     public IActionResult SetTaskPriorityController([FromRoute]int ID,[FromRoute] string setPriorityTo)
     {
        if( _taskObject.SetTaskPriority(ID,setPriorityTo)==null)
        {
            return BadRequest();
        }
        return Ok( _taskObject.SetTaskPriority(ID,setPriorityTo));
     }

     [HttpPost("{ID}/{dueDate}")]
     public IActionResult SetDueDateController([FromRoute]int ID,[FromRoute] string dueDate)
     {
        if(_taskObject.SetDueDate(ID,dueDate)==null)
        {
            return BadRequest();
        }
        return Ok(_taskObject.SetDueDate(ID,dueDate));
     }
    
     [HttpPost("{ID}/{comment}")]
       public IActionResult TaskCommentingController([FromRoute]int ID,[FromRoute] string comment)
     {
        if(_taskObject.TaskCommenting(ID,comment)==null)
        {
            return BadRequest();
        }
        return Ok(_taskObject.TaskCommenting(ID,comment));
     }
   
}

