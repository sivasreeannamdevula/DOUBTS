using System.ComponentModel.DataAnnotations;

public class Family
{
    [Key]
    public int Id{get;set;}
    public string Surname{get;set;}
    public int NoofPpl{get;set;}
    public string HeadOfFamily{get;set;}
}
