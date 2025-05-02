using System.ComponentModel.DataAnnotations;

public class User
{
    public string Username;

    [EmailAddress]
    public string email;
    
    public string password;
}