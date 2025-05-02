using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskLogic;
using UserLogic;

namespace TaskAPI.Controllers;
[ApiController]
[Route("[Controller]/[Action]")]
public class TaskController : ControllerBase
{
    public static string UserNameGlobal;
    //Dependency Injection
    private TaskImplementation _taskObject;
    private UserImplementation _userObject;
    private IConfiguration _configuration;

    public TaskController(TaskImplementation taskObject, UserImplementation userObject,IConfiguration configuration)
    {
        _taskObject = taskObject;
        _userObject = userObject;
        _configuration=configuration;
        _taskObject.LoadTaskFromFile("C:/slagprac/slag/sivasree/26-9-24/DataBase/Task.json");

    }
    [HttpPost("{username}")]
     public IActionResult UserLogin([FromRoute]string? username,[FromBody]User user)
     {
        int result=_userObject.CreateUserAccount(username,user);
        if(result==1 || result==2)
        {
            UserNameGlobal = username;
            _configuration["customKeyForUser"]=UserNameGlobal;
            return (result==1) ? Ok("USER ALREADY EXISTS,SUCCESSFULLY LOGGED-IN") : Ok("NEW USER,SUCCESSFULLY LOGGED-IN");
    
        }
       
        return Unauthorized("INVALID LOGIN");
     }

    [HttpPost]
    public Dictionary<string,List<TaskModel>> CreateTask([FromBody] TaskModel newTask)
    {
       return _taskObject.CreateTask(newTask,UserNameGlobal);
    }

    [HttpPost("{ID}/{AssignToUserName}")]
    public IActionResult TaskAssignment([FromRoute] int ID, [FromRoute] string AssignToUserName)
    {
        
        int result=_taskObject.TaskAssignment(ID, AssignToUserName,UserNameGlobal);
        if (result== -1)
        {
            return BadRequest("Task with the userid is not present");
        }
        return (result==1)?Ok("successful assignment") : BadRequest("User Does not exist");
    }

    [HttpPost("{ID}/{statusUpdateTo}")]
    public IActionResult TaskStatusUpdate([FromRoute] int ID, [FromRoute] string statusUpdateTo)
    {
        if (_taskObject.TaskStatusUpdate(ID, statusUpdateTo,UserNameGlobal) == false)
        {
            return BadRequest("INVALID TASK ID FOR USER");
        }

        return Ok(_taskObject.TaskStatusUpdate(ID, statusUpdateTo,UserNameGlobal));
    }

    [HttpPost("{ID}/{setPriorityTo}")]
    public IActionResult SetTaskPriority([FromRoute] int ID, [FromRoute] string setPriorityTo)
    {
        if (_taskObject.SetTaskPriority(ID, setPriorityTo,UserNameGlobal) == null)
        {
            return BadRequest();
        }
        return Ok(_taskObject.SetTaskPriority(ID, setPriorityTo,UserNameGlobal));
    }

    [HttpPost("{ID}/{dueDate}")]
    public IActionResult SetDueDate([FromRoute] int ID, [FromRoute] DateTime dueDate)
    {
        if (_taskObject.SetDueDate(ID,dueDate,UserNameGlobal) == false)
        {
            return BadRequest();
        }
        return Ok(_taskObject.SetDueDate(ID, dueDate,UserNameGlobal));
    }

    [HttpPost("{ID}/{comment}")]
    public IActionResult TaskCommentingController([FromRoute] int ID, [FromRoute] string comment)
    {
        if (_taskObject.TaskCommenting(ID, comment,UserNameGlobal) == false)
        {
            return BadRequest();
        }
        return Ok(_taskObject.TaskCommenting(ID, comment,UserNameGlobal));
    }

    [HttpPost("/SaveTask")]
    public void SaveTask()
    {
        _taskObject.SaveTaskToFile("C:/slagprac/slag/sivasree/26-9-24/DataBase/User.json");
    }

    [HttpPost("/LoadTask")]
    public void LoadTask()
    {
         _taskObject.LoadTaskFromFile("C:/slagprac/slag/sivasree/26-9-24/DataBase/Task.json");
    }

}

