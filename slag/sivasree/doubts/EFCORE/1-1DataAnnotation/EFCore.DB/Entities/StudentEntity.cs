

using System.ComponentModel.DataAnnotations;

namespace DataBase.Entity;
public class StudentEntity
{
     [Key]
     public int StudentId{get;set;}
     public string Name{get;set;}
     public LaptopEntity lappy{get;set;}
    
}