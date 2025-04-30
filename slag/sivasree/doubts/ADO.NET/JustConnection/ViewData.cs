using System.Xml.Serialization;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

public class ViewData
{
         public void DisplayData()
        {
            try
            {
                using(SqlConnection con=new SqlConnection("Server=PTU1DELL0102\\SQLEXPRESS;DataBase=ADO;User Id=sa;Password=Welcome@1234;Encrypt=False"))
                {
                    con.Open();
                    //ExecuteReader using 2 parameters for SqlCommad ctor----more no.of rows
                    SqlCommand sc=new SqlCommand("Select *from student;Select *from ADO",con);
                    SqlDataReader sdr=sc.ExecuteReader();
                    while(sdr.Read())
                    {
                        //System.Console.WriteLine(sdr["Id"]+" "+sdr["Name"]+" "+sdr["Email"]+" "+sdr["Mobile"]);
                        System.Console.WriteLine(sdr[0]+" "+sdr[1]);
                    }

                    //we can retrive two queries data using nextreader method sqlDataReader
                    // while(sdr.NextResult())
                    // {
                    //     while(sdr.Read())
                    //     {
                    //         System.Console.WriteLine(sdr[0]+ " "+sdr[1]+" "+sdr[2]);
                    //     }
                    // }
                   
                   //ExecuteReader using parameterless SqlCommad ctor
                    // SqlCommand sc=new SqlCommand();
                    // sc.CommandText="Select *from Student";
                    // sc.Connection=con;
                    // SqlDataReader sdr=sc.ExecuteReader();
                    // while(sdr.Read())
                    // {
                    //   System.Console.WriteLine(sdr["Id"]+" "+sdr["Name"]+" "+sdr["Email"]+" "+sdr["Mobile"]);
                    // }


                    //ExecuteScalar---returna a single object as an o/p
                    // SqlCommand sc=new SqlCommand("Select count(Id) from Student",con);
                    // int count=(int)sc.ExecuteScalar();    //as it returns object we have to typecast it
                    // System.Console.WriteLine(count);


                    //ExecuteNonQuery-----returns the no.of rows effected
                    // SqlCommand sc=new SqlCommand("Insert into Student values('1','Sivasree','Siva@gmail.com','24/10/24') ",con);
                    // sc=new SqlCommand("Insert into Student values('3','Sivasree','Sivasre@gmail.com','24/10/24') ",con);
                    // int rowseffected=sc.ExecuteNonQuery();
                    // System.Console.WriteLine("no.of rows got effected "+rowseffected);


                    //Parameterised query--if we use like this we can prevent SQLInjection
                    // string sqlQuery="Select from Student where Name=@Name";
                    // SqlCommand s=new SqlCommand(sqlQuery,con);
                    // s.Parameters.AddWithValue("Name","Sivasree");
                    // SqlDataReader sdr=s.ExecuteReader();
                }
            }
            catch(Exception ex)
            {
                 System.Console.WriteLine("something went wrong "+ex);
            }
           
               
        }

}