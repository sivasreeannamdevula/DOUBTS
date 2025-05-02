using TaskManagement.DataBase.Implementations;
using TaskManagement.Services.Implementations;
using TaskManagement.API.Filters;


namespace TaskManagement.API.Configurations;
public static class AllServices
{
   public static void InjectingServices(this IServiceCollection service)
   {
        service.AddEndpointsApiExplorer();
        service.AddSwaggerGen();
        service.AddControllers();
        service.AddSingleton<ITaskOperations,TaskImplementation>();
        service.AddSingleton<IUserOperations,UserImplementation>();
        service.AddSingleton<UserDictionary>();
        service.AddSingleton<TaskDictionary>();
        service.AddSingleton<IUserDBOperations,UserDBOperations>();
        service.AddSingleton<ITaskDBOperations,TaskDBOperations>();
        service.AddSingleton<CustomActionFilter>();
        service.AddAutoMapper(typeof(MappingClass));
   }
}
