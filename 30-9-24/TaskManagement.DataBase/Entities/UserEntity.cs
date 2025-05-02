using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DataBase.Entities;

public class UserEntity
{
    [EmailAddress]
    public string Email { get; set; }
      
    [Required]
    public string Password { get; set; }

}
