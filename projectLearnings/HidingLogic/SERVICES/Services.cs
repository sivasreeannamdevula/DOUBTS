using DB.DB;
namespace ServicesClassNamespace
{


    public class ServicesClass
   {
    private readonly DBClass _db;
    public ServicesClass(DBClass db)
    {
        _db=db;
    }

    public void GetMethod()
    {
         _db.GetDBUser();
         return ;
    }
}
}