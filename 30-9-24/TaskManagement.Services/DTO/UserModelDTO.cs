using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Services.DTO;

public class UserModelDTO
{
     

    [EmailAddress]
    public string Email { get; set; }
      
    [Required]
    public string Password { get; set; }

}
