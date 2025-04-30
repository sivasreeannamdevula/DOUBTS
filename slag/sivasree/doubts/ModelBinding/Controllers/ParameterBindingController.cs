using Microsoft.AspNetCore.Mvc;

//Fombody,FromForm,FromQuery,FromRoute(same as FromUri),FromHeader
[ApiController]
[Route("[Controller]/[Action]")]
public class ParameterBindingController:ControllerBase
{
    //[HttpPost]
    //public string GetFromBody([FromBody]int id2)             //we cannot use [fromBody] for primitive types can only be used 
    //{                                                        //with object/struct type
    //    return "the id is"+id2;
    // }

    //   [HttpPost]
    //   public string GetFromForm([FromForm]int i)          //can be used with both primitive and object/struct types
    //   {
    //     return "the id from FORM is"+i;
    //   }

    //   [HttpGet]
    //   public string GetFromQuery([FromQuery]int id)      //we can set the value of the url from the http query
    //   {
    //     return "the id from the query is "+id;
    //   }

    //   [HttpGet] 
    //   public string GetIdWithoutFromQuery(int id,string s)  //even here we can provide inputs in the url without 
    //   {                                                     //any [fromQuery] attirbute...but the drawback is if the input is
    //     return "we can use by "+id+s;                       //complex types like Student/Employee...then we have to go for 
    //   }                                                     //[FromQuery]
    //  [HttpGet("{id1}")]
    //   public string GetId([FromRoute(Name="id1")]int id)      //here we r saying bind the id1 to id
    //   {
    //     return "we can use by "+id;
    //   }

    //by default [fromroute]
      // [HttpGet("{id1}")]
      // public string GetId2([FromRoute]int id)                 //here as we didn't bind o/p=we can use by 0
      // {
      //   return "we can use by "+id;
      // }


    //  [HttpGet]
    //   public string GetId3([FromRoute]int id)               //here too as we didn't bind. o/p=we can use by 0
    //   {
    //     return "we can use by "+id;
    //   }

      [HttpGet("id:int")]
      public string Get(int id)
      {
          return "the id is "+ id;                           //here id got binded o/p=the id is {userGivenValue}
      }
    //  [HttpGet]
    //  public string GetData([FromHeader] string dsv)         //in postman we define a request header dsv and set its value 
    //  {                                                      //to our own value
    //     return dsv;
    //  }

      [HttpGet("{sno}")]
      public string getpo([FromRoute(Name="sno")]int id2)       //here sno in route and id2 are binded.
      {
        return "id2 id :" +id2;
      }

     
//if we specify [fromqeury] when dealing with complex types we have to specify as below
//http://localhost:5265/Australia/GetData/player?JerseyNo=3&PlayerName=rohit&Place=mi&HighestScore=264
 
}