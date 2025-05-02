using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace StudentLibrary
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public int StudentId(int ID)
        {
            return ID;
        }

        [HttpPost]
        public IActionResult StudentId()
        {
           return NotFound("SUCCESFULL");
        }

        [HttpPut]
        public void StudentIds()
        {

        }

        [HttpDelete]
        public void StudentIdss()
        {

        }
    }
}
