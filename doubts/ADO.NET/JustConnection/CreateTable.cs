
using System.Data.SqlClient;
using System.Xml.Serialization;

using Microsoft.Extensions.Configuration;

public class CreateTable
{
     public void CreateTables()
    {
        SqlConnection con=null;
        try
            {
                // Creating Connection 
                //1. 
                //con=new SqlConnection("Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User ID=sa;Password=Welcome@1234;Encrypt=False");
                //2.
                con = new SqlConnection();
                con.ConnectionString="Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User ID=sa;Password=Welcome@1234;Encrypt=False";   
                // writing sql query  
                SqlCommand cm = new SqlCommand("create table ADO2PRIMARYKEY(id int not null PRIMARY KEY, name varchar(100), email varchar(50), join_date date)", con);  
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }


       //no need to explicitly close the connection
        using(SqlConnection conn=new SqlConnection())
        {
            conn.ConnectionString="Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User Id=sa;Password=Welcome@1234;Encrypt=False";
            conn.Open();
            System.Console.WriteLine("Connection opened");
        }

        //to use connectionstring from appsettings.json file
        //initialize IConfiguration instance through ctor in webapi
        // var connectionstring=_configuration.GetConnectionString("DefaultConnection");
        // SqlConnection conn=new SqlConnection(connectionstring);
        // conn.Open();
        // System.Console.WriteLine("opened using appsettings.json configuration");
        // conn.Close();
    }

}