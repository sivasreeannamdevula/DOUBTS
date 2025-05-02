
using TaskManagement.Services.DTO;
public interface IUserOperations
{
     public int CreateUserAccount(string userName, UserModelDTO user);
}