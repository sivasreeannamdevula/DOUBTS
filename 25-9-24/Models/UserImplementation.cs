public class UserImplementation
{
   private Dictionary<string,string> userRegistrationDetails;
    private Dictionary<string,string> userLoginDetails;
    public void CreateUserAccount(string userName,string email)
    {
         userRegistrationDetails[userName]=email;
    }

    public void UserLogin(string username,string password)
    {
       if(userRegistrationDetails[username]!=null)
       {
           userLoginDetails["username"]=password;
       }
       else
       {
           System.Console.WriteLine("Not a valid user"); 
       }
    }
}