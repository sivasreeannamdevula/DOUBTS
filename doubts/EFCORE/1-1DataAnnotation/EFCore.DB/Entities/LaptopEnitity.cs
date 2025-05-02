using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Entity;
public class LaptopEntity
{
   public int Id{get;set;}

   [ForeignKey("Student")]
   public int StudentId { get; set; }

   public string LaptopName{get;set;}
   public StudentEntity Student{get;set;}
 

}




//its a 1-1 relationship that means every student has a laptop so manam data add chesinappudu for sure first student undali appudey 
//laptop add cheyyagalamu.

//in two ways we can create 1-1 relationship
//1.using data annotatiosns
//2.using fluent API