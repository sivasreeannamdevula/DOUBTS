using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Services.Implementations;
using TaskManagement.Services.DTO;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         public static string userNameGlobal;
        private IUserOperations _userObject;
        private readonly IConfiguration _configuration;

         public UserController(IUserOperations userObject, IConfiguration configuration)
        {
             _userObject = userObject;
             _configuration = configuration;
        }
         [HttpPost]
        public IActionResult UserLogin([FromForm] string? username, [FromForm] UserModelDTO user)
        {
            int result = _userObject.CreateUserAccount(username, user);
            if (result == 1 || result == 2)
            {
                userNameGlobal = username;
                _configuration["customKeyForUser"] = userNameGlobal;
            
                

               var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
               var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

              var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
                //claims: claims,
                expires: DateTime.Now.AddMinutes(90),
               signingCredentials: creds);

             return Ok("Bearer "+ new JwtSecurityTokenHandler().WriteToken(token));
                
                // return (result == 1) ? Ok("USER ALREADY EXISTS,SUCCESSFULLY LOGGED-IN") : Ok("NEW USER,SUCCESSFULLY LOGGED-IN");

            }

            return Unauthorized("INVALID LOGIN");
        }
    }
}
