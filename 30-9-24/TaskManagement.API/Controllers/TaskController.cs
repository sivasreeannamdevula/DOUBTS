using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services.Implementations;
using TaskManagement.Services.DTO;
using TaskManagement.API.Filters;
using TaskManagement.Services.DTO;
using TaskManagement.DataBase.Entities;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[Action]")]
    //we have to use servicetype incase we would like to call our ciustom methods in filter
    [ServiceFilter(typeof(CustomActionFilter))]
    public class TaskController : ControllerBase
    {
       
        //Dependency Injection
        private ITaskOperations _taskObject;
        public TaskController(ITaskOperations taskObject, IConfiguration configuration)
        {
            _taskObject = taskObject;
        }
      
       [HttpPost("/CreateTask")]
        public Dictionary<string, List<TaskEntity>> CreateTask([FromBody] TaskModelDTO newTask)
        {
            return _taskObject.CreateTask(newTask, UserController.userNameGlobal);
        }

        [HttpPost("{id}/{assignToUserName}")]
        public IActionResult TaskAssignment([FromBody] string id, [FromRoute] string assignToUserName)
        {

            int result = _taskObject.TaskAssignment(id, assignToUserName,UserController.userNameGlobal);
            if (result == -1)
            {
                return BadRequest("Task with the userid is not present");
            }
            return (result == 1) ? Ok("successful assignment") : BadRequest("User Does not exist");
        }

        [HttpPost("{id}/{statusUpdateTo}")]
        public IActionResult TaskStatusUpdate([FromRoute] string id, [FromRoute] string statusUpdateTo)
        {
      
          return (_taskObject.TaskStatusUpdate(id, statusUpdateTo, UserController.userNameGlobal) == false)?
                   BadRequest("INVALID TASK ID FOR USER"):
                   Ok("successful");
        }

        [HttpPost("{id}/{setPriorityTo}")]
        public IActionResult SetTaskPriority([FromRoute] string id, [FromRoute] string setPriorityTo)
        {
        
            return (_taskObject.SetTaskPriority(id, setPriorityTo, UserController.userNameGlobal) == null)?
                    BadRequest("INVALID TASK ID FOR USER"):
                    Ok("successful");
        }

        [HttpPost("{id}/{dueDate}")]
        public IActionResult SetDueDate([FromRoute] string id, [FromRoute] DateTime dueDate)
        {
            return (_taskObject.SetDueDate(id, dueDate, UserController.userNameGlobal) == false)?
                   BadRequest("INVALID TASK ID FOR USER"):
                   Ok("successful");
        }

        [HttpPost("{id}/{comment}")]
        public IActionResult TaskCommentingController([FromRoute] string id, [FromRoute] string comment)
        {
            return (_taskObject.TaskCommenting(id, comment, UserController.userNameGlobal) == false)?
                   BadRequest("INVALID TASK ID FOR USER"):
                   Ok("successful");
        }

        
        
        [HttpPost("/SaveTask")]
       
        public void SaveTask()
        {
            _taskObject.SaveTaskToFile();
        }

        [HttpPost("/LoadTask")]
        public void LoadTask()
        {
            _taskObject.LoadTaskFromFile();
        }

    }
}
