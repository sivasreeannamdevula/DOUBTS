using Microsoft.Data.SqlClient;

namespace DB.DB
{
public class DBClass
{
    private readonly DbContexts _context;
    public DBClass(DbContexts context)
    {
        _context=context;
    }

    public void GetDBUser()
    {
        using(SqlConnection con = new SqlConnection(@"data source=PTU1DELL0102\SQLEXPRESS; initial catalog=ECommerce1; trustservercertificate=true; User id=sa ;password=Welcome@1234 ;"))
        {
            con.Open();
            string query = "select * from Users";
             SqlCommand command = new SqlCommand(query, con);
               using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["UserID"]}, Name: {reader["Name"]}");
                    }
                }


        }
    }
}
}