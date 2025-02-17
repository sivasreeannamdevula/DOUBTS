
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]/[Action]")]
public class Trainee:ControllerBase
{
    [Route("/traineeid")]      //if we keep / bfr traineeid in route then parent route gets overrided.
    [HttpGet]        
    public string TraineeById([FromQuery(Name="sno")] int id1)    //if sno is the column name in database and we have to
                                                                  //refer it then we use Name="sno"
   {
        string ans="The Trainee details are "+id1;
        return ans;
    }

    [Route("empid:string")]
    [HttpGet]        //accepts only string 
    public string TraineeByName(string name)
    {
        return "The Trainee details are "+name;
    }
    [HttpPost]
    public int TraineePost(int ID)
    {
         return ID;
    }

    [HttpPut]
    public int TraineePut()
    {
      return 56;
    }

    [HttpDelete]
    public int TraineeDelete()
   {
       return 0;
   }
}