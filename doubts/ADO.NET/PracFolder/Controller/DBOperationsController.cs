using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;


//sqldatareader read,nextread methods.

[ApiController]
[Route("[Controller]/[Action]")]
public class DBOperationsController:ControllerBase
{
    private readonly IConfiguration _configuration;
    public DBOperationsController(IConfiguration configuration)
    {
        _configuration=configuration;
    }

    [HttpPost]
    public IActionResult CreateTable()
    {
        SqlConnection con=new SqlConnection();
        string connstring=_configuration.GetConnectionString("DefaultConnection");
        //con.ConnectionString="Server=PTU1DELL0102\\SQLEXPRESS;DataBase=SQLConnectionDB;User Id=sa;Password=Welcome@1234;Encrypt=False";
        con.ConnectionString=connstring;
        con.Open();
        SqlCommand sc=new SqlCommand("Create table SQLTable(Id int,name varchar(20),email varchar(60),Primary key(id))",con); 
        sc.ExecuteNonQuery();
        con.Close();
        return Ok("SUCCESS");
    }

    [HttpPost]
    public void Insert()
    {
        using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("defaultConnection")))
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("insert into SQLTable values('1','chaitu','chaitu@gmail.com')",con);
            cmd.ExecuteNonQuery();
        }
    }

    [HttpGet]
    public void Retrieve()
    {
        //  using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        // {
        //     con.Open();
        //     SqlCommand cmd=new SqlCommand("Select *from SQLConnectionTable;Select *from SQLTable",con);
        //     SqlDataReader sdr=cmd.ExecuteReader();

        //     System.Console.WriteLine(sdr.HasRows);    //returns whether there are rows or not
        //     System.Console.WriteLine(sdr.FieldCount);   //returns no.of columns in present row
        //     while(sdr.Read())
        //     {
        //         System.Console.WriteLine(sdr[0] +" " +sdr[1] + " "+sdr[2]);
        //     }        

        //     while(sdr.NextResult())
        //     {
        //         while(sdr.Read())
        //        {
        //         System.Console.WriteLine(sdr[0] +" " +sdr[1]);
        //        }        
        //     }
        // }


        //    using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        // {
        //     con.Open();
        //     SqlCommand cmd=new SqlCommand("Select *from SQLConnectionTable",con);
            
        //     int noofrows=(int)cmd.ExecuteScalar();  //explicitly we have to convert from object to int/float/double
           
        //         System.Console.WriteLine(noofrows);
               
        // }






        //using SQLDATAADAPTER
        
        using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            //SqlDataAdapter sda=new SqlDataAdapter("select *from SQLConnectionTable",con);
            //1.DATATABLE

            // DataTable dt=new DataTable();
            // sda.Fill(dt);      //fill opens ths db connection,retrieves the data, fills the datatable/dataset with the data,
            //                    //closes the connection

            // foreach(DataRow row in dt.Rows)
            // {
            //     System.Console.WriteLine(row["name"] + " "+row["email"]);
            // }       


            //2.DATASET
            // DataSet ds=new DataSet();
            // sda.Fill(ds,"SqlConnectionTable");      //here we are giving the set to adapter and result stored as a table
            // foreach(DataRow row in ds.Tables["SQLConnectionTable"].Rows)   //each row ni iterate chestham
            // {
            //     System.Console.WriteLine(row["name"]+" "+row["email"]);
            // }     


            SqlDataAdapter sda=new SqlDataAdapter("getStudents",con);
            sda.SelectCommand.CommandType=CommandType.StoredProcedure;  
            DataTable dt=new DataTable();
            sda.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                System.Console.WriteLine(row["email"]);
            }     

        }


    
    }
    [HttpPost]
    public void Update()
    {
        using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("Update SQLConnectionTable SET name='rojasree' where id='1'",con);
            cmd.ExecuteNonQuery();        }
    }



    [HttpDelete]
    public void Delete()
    {
        using(SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        {
            con.Open();
            SqlCommand cmd=new SqlCommand("delete from SQLTable where id='1'",con );
            cmd.ExecuteNonQuery();

        }
    }


   [HttpPost]
   public IActionResult CreateDataTable()
   {
           //1.Create an instance of Datatable
          DataTable table=new DataTable("Student");
          //2.Create columns
          DataColumn col1=new DataColumn("ID");
        //   col1.AllowDBNull=false;
        //   col1.Unique=true;
        //   col1.DataType=typeof(int);
          col1.AutoIncrement=true;
          col1.AutoIncrementSeed=200;
          col1.AutoIncrementStep=4;
          table.Columns.Add(col1);                       //col1 and its constraints are added successfully.
          table.PrimaryKey=new DataColumn[]{col1};        //adding primary key 
          DataColumn col2=new DataColumn("Name");
          col2.MaxLength=50;
          col2.AllowDBNull=false;
          table.Columns.Add(col2);            //col2 added successfully


          DataColumn col3=new DataColumn("Email");
          table.Columns.Add(col3);            //col3 added successfully



          //3.Populationg rows with data
          table.Rows.Add(null,"Sivasree","sree@gmail.com");
          table.Rows.Add(null,"Roja","roja@gmail.com");
          table.Rows.Add(null,"chaitanya","chaitanya@gmail.com");
          System.Console.WriteLine("before ");
          foreach(DataRow row in table.Rows)
          {
            System.Console.WriteLine(row[0] + " " + row[1] + " "+row[2]);
          }


          foreach(DataRow row in table.Rows)
          {
            if(Convert.ToInt32(row["ID"])==208)
            {
                row.Delete();
                // table.Rows.Remove(row);
                System.Console.WriteLine("ROW DELETED SUCCESSFULLY");
                break;
            }
          }
          table.AcceptChanges();
          System.Console.WriteLine("Rolling back the changes");
          string ans="";
          foreach(DataRow row in table.Rows)
          {
           
            ans+=(row[0] + " "+row[1]);
          }
          return Ok(ans);

   }
   

  [HttpPost]
   public ActionResult CreateDatsetFromExistingTablesinDB()
   {
      SqlConnection con=new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
      SqlDataAdapter sdr=new SqlDataAdapter("select * from SQLNewTable;Select *from SQLConnectionTable",con);  //if we use 2 queries that means we are adding two tables to dataset
      //to update the changes that we made in datatable to db we need commandbuilder 
      SqlCommandBuilder builder1=new SqlCommandBuilder(sdr);
      DataTable dt1=new DataTable();
      sdr.Fill(dt1);
    //   DataSet dt2=new DataSet();
    //   sdr.Fill(dt2);
      System.Console.WriteLine("before");
    //   foreach(DataRow row in dt1.Rows)
    //   {
    //     System.Console.WriteLine(row[0] + " "+row[1]);
    //   }
      
      
          foreach(DataRow row in dt1.Rows)
          {
            if(Convert.ToInt32(row["Id"])==1)
            {
                row.Delete();
                // table.Rows.Remove(row);
                System.Console.WriteLine("ROW DELETED SUCCESSFULLY");
                break;
            }
          }
         
          //System.Console.WriteLine(rowsAffected);
          //dt1.AcceptChanges();
          //dt1.RejectChanges();
           //int rowsAffected=sdr.Update(dt1);
          string res="";
      foreach(DataRow row in dt1.Rows)
      {
        res+=(row[0]+" "+row[1]+"\n");
        System.Console.WriteLine(row[0] + " "+row[1]);
      }
        return Ok(res);
   }

  [HttpPost]
   public void CreateDataSetFromCreatedDataTables()
   {
      //creation of table1 MovieActors
      DataTable dt=new DataTable("MovieActors");
      DataColumn col1=new DataColumn("Id");
      col1.AllowDBNull=false;
      col1.DataType=typeof(int);
      DataColumn col2=new DataColumn("Name");
      col2.MaxLength=30;
      DataColumn col3=new DataColumn("Email");
      dt.Columns.Add(col1);
      dt.Columns.Add(col2);
      dt.Columns.Add(col3);
      dt.Rows.Add("1","Prabhas","prabha@gmail.com");
      dt.Rows.Add("2","Anushka","shetty@gmail.com");
      dt.Rows.Add("3","Rajamouli","mouli@gmail.com");

      //creation of table2 cinemas
      DataTable dt2=new DataTable("Cinemas");
      DataColumn c1=new DataColumn("Id");
      DataColumn c2=new DataColumn("Cinema");
      DataColumn c3=new DataColumn("Rating");
      c1.AllowDBNull=false;
      c1.DataType=typeof(int);
      c2.MaxLength=44;
      dt2.Columns.Add(c1);
      dt2.Columns.Add(c2);
      dt2.Columns.Add(c3);
      dt2.Rows.Add("2","Bahubali","8");
      dt2.Rows.Add("3","Darling","9.9");
      dt2.Rows.Add("1","Mrs.Shetty&&Polishetty","10");

      //creation of Dataset
      DataSet set1=new DataSet("MoviesSet");
      set1.Tables.Add(dt);
      set1.Tables.Add(dt2);


      //retrieving data from the tables in a set
      //we can retrieve either by table name i.e; MovieActors
    //   foreach(DataRow row in set1.Tables["MovieActors"].Rows)
    //   {
    //       System.Console.WriteLine(row[0] + " " + row[1] +" "+row[2]);
    //   }

    //  //or by index
    //   foreach(DataRow row in set1.Tables[1].Rows)
    //   {
    //       System.Console.WriteLine(row[0] + " " + row[1] +" "+row[2]);
    //   }



      //METHODS OF DATASET
      //1.COPY
      // DataSet copiedset=set1.Copy();
      // System.Console.WriteLine("COPIED SET");
      // foreach(DataRow row in copiedset.Tables[0].Rows)
      // {
      //   System.Console.WriteLine(row[0]+" "+row[1]+" "+row[2]);
      // }

      //2.CLONE
      // DataSet clonedset=set1.Clone();
      // if(clonedset.Tables[0].Rows.Count>0)
      // {
      //   System.Console.WriteLine("Datatable exixts");
      // }
      // else{
      //   System.Console.WriteLine("datatable doesn't exist");
      // }

      //3.Clear
      // set1.Clear();
      // if(set1.Tables[0].Rows.Count>0)
      // {
      //   System.Console.WriteLine("Table exists");
      // }
      // else{
      //   System.Console.WriteLine("No such table exixts");
      // }

      //Removing Datatable from a dataset
      //first check whether the table exists or not and also whether it can be removed or not using CanRemove method
      // if(set1.Tables.Contains("MovieActors") && set1.Tables.CanRemove(set1.Tables["MovieActors"]))
      // {
      //    set1.Tables.Remove(set1.Tables["MovieActors"]);
      // }
      // if(set1.Tables.Contains("MovieActors"))
      // {
      //   System.Console.WriteLine("Table MovieActors exists");
      // }
      // else
      // {
      //   System.Console.WriteLine("Doesn't exist table MovieActors");
      // }
   }
}