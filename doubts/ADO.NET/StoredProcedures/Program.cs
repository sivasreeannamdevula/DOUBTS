using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;

public class Program
{
    static void Main(string[] args)
    {
        // using(SqlConnection con=new SqlConnection("Server=PTU1DELL0102\\SQLEXPRESS;DataBase=SQLConnectionDB;User Id=sa;Password=Welcome@1234;Encrypt=False"))
        // {
        //     //1.stored procedure without any inputs
        //     //Registering stored procedure
        //     SqlCommand cmd=new SqlCommand("Proc1",con);
        //     cmd.CommandType=CommandType.StoredProcedure;
        //     con.Open();
        //     //calling stored procedure
        //     SqlDataReader reader=cmd.ExecuteReader();
        //     while(reader.Read())
        //     {
        //         System.Console.WriteLine(reader[0]+" "+reader[1]+" "+reader[2]);
        //     }
        // }

        //     //2.stored procedures with inputs

        //             //Create Procedure Proc2
        //             // (
        //             //   @inputid int
        //             // )
        //             // As
        //             // Begin
        //             // Select *from SQLTable
        //             // where Id=@inputid;
        //             // End
        // using(SqlConnection con=new SqlConnection("Server=PTU1DELL0102\\SQLEXPRESS;DataBase=SQLConnectionDB;User Id=sa;Password=Welcome@1234;Encrypt=False"))
        // {
        //    SqlCommand cmd=new SqlCommand("Proc2",con);
        //    con.Open();
        //    cmd.CommandType=CommandType.StoredProcedure;
        //    SqlParameter param=new SqlParameter
        //    {
        //       ParameterName="@inputid",     //input defined in storedprocedure
        //       SqlDbType=SqlDbType.Int,
        //       Value=7,
        //       Direction=ParameterDirection.Input
        //    };
        //    cmd.Parameters.Add(param);
        //    SqlDataReader reader=cmd.ExecuteReader();
        //    while(reader.Read())
        //    {
        //     System.Console.WriteLine(reader[0]+" "+reader[1]);
        //    }

        // }


        //3.stored procedure with multiple inputs and one output
        using(SqlConnection con=new SqlConnection("Server=PTU1DELL0102\\SQLEXPRESS;DataBase=SQLConnectionDB;User Id=sa;Password=Welcome@1234;Encrypt=False"))
        {
            SqlCommand cmd=new SqlCommand("Proc4",con);
            con.Open();
            cmd.CommandType=CommandType.StoredProcedure;
            SqlParameter param=new SqlParameter
            {
               ParameterName="@name",
               Value="veerraju"
            };
            
            SqlParameter outparam=new SqlParameter
            {
                ParameterName="@OUT",
                SqlDbType=SqlDbType.Int,
                Direction=ParameterDirection.Output
            };
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@email","veerraju@gmail.com");
            cmd.Parameters.AddWithValue("@inputid","232");
            cmd.ExecuteNonQuery();
            System.Console.WriteLine(outparam.Value.ToString);
        }
         

    }
}