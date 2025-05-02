using System.Xml.Serialization;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DeleteFromTable
{
    public void DeleteData()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
             
               con = new SqlConnection();
                con.ConnectionString="Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User ID=sa;Password=Welcome@1234;Encrypt=False";  
                // writing sql query  
                SqlCommand cm = new SqlCommand("delete from ADO where id = '101'", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                Console.WriteLine("Record Deleted Successfully");
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
        }
    
}