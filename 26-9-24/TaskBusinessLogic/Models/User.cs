using System.ComponentModel.DataAnnotations;

public class User()
{
  
    [Required]
    public string Password { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}