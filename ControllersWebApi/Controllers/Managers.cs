
// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("[Controller]/[Action]")]
// public class Manager:ControllerBase
// {
//     [HttpGet("{id:min(1):max(100)}")]          //id must be in the range min=1 and max =100
//     [ProducesResponseType(200)]                //we can define the type of responses ---we can see these in description of swagger.
//     [ProducesResponseType(404)]   
//     [ProducesResponseType(204)] 
//     public IActionResult ManagerById(int id)    //when u define 200,404....then returntype==IActionResult/ActionResult
//     {
//         return Ok("The Manager details are {id}");
//     }

//     [HttpGet("{name:alpha}")]        //accept only string
//     public string ManagerByName(string name)
//     {
//         return "The Manager details are {name}";
//     }
//     [HttpPost]
//     public void ManagerPost()
//     {

//     }

//     [HttpPut]
//     public int ManagerPut()
//     {
//       return 56;
//     }

//     [HttpDelete]
//     public int ManagerDelete()
//    {
//        return 0;
//    }
// }