using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class Task
{
    public int ID{get;set;}

    [Required]
    public string Title{get;set;}
    [Required]
    public string Description{get;set;}
    
    
    public string Priority{get;set;}


    public string DueDate{get;set;}

    public string Comment{get;set;}

    public string AssignedTo{get;set;}

    public string StatusOfTask{get;set;}

}