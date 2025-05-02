using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[Controller]")]
public class ManagerController:ControllerBase{

   InterfaceB i;
   public ManagerController([FromKeyedServices("in")]InterfaceB b)
   {
     i=b;
   }
}