using System.Xml.Serialization;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


public class InsertIntoTable
{
        public void InsertRecord()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
               
                con = new SqlConnection();
                con.ConnectionString="Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User ID=sa;Password=Welcome@1234;Encrypt=False"; 


                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into ADOPRIMARYKEY (id, name, email, join_date) values ('99', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", con); 
                
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
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